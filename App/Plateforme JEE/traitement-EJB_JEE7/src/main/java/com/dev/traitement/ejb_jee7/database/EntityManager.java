/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.dev.traitement.ejb_jee7.database;

import java.sql.Connection;
import java.sql.Statement;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;


/**
 *
 * @author loicf
 */
public class EntityManager {
    
    static final String JDBC_DRIVER = "oracle.jdbc.driver.OracleDriver"; //NOT USED ANYMORE
    static final String JDBC_URL = "jdbc:oracle:oci:schema_owner/password@localhost:1521:orcl";  // NOT USED ANYMORE : redeclare in local method
    
    Connection connection = null;
    Statement stmt = null;
    // Query result with DB data
    private ResultSet result;
    
    
    
    // Constructor : Init DB connection
    public EntityManager() {
        ///System.out.println("Info: EntityManager instanciated");
        try
        {
            /*
             * STEP 1: Register JDBC driver
             */
            // Optionnal since Java 6 (JDBC 4.0)
            //Class.forName(JDBC_DRIVER);
            // OR
            DriverManager.registerDriver(new oracle.jdbc.OracleDriver());

            /*
             * STEP 2: Open a connection
             */
            ///System.out.println("Connecting to database...");
            // Oracle SID = orcl
            connection = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:orcl", "schema_owner", "password");

            if (connection != null) {
                ///System.out.println("Connected to the database!");
            } else {
                System.out.println("Failed to make connection!");
            }
        }
        catch (SQLException se)
        {
            /*
             * Handle errors for JDBC
             */
            se.printStackTrace();
        }
    }
    
    // Load existing Dictionary table (all his words)
    public void loadDictionaryWords() {
        this.loadTable("DICTIONARY");
    }
    
    // Load table's all data (return false if table doesn't exists)
    public boolean loadTable(String tableName) {
        try {
            /*
             * STEP 3: Execute a query
             */
            ///System.out.println("Loading table statement...");
            ///System.out.println("-----------------------------------------------------");
            stmt = connection.createStatement();
            String sql = "select WORD from " + tableName;
            result = stmt.executeQuery(sql);
        }
        catch (SQLException se)
        {
            /*
             * Handle errors for JDBC
             */
            // se.printStackTrace();
            return false; 
        }
        return true;
    }
    
    // Create a new database table
    public boolean createTable(String tableName) {
        try {
            ///System.out.println("Creating table statement...");
            ///System.out.println("-----------------------------------------------------");
            String sql =    "CREATE TABLE " + tableName +
                            " (" +
                            " ID INT PRIMARY KEY NOT NULL," +
                            " WORD VARCHAR(50)" +
                            " )";
            result = stmt.executeQuery(sql);
        }
        catch (SQLException se)
        { return false; }
        return true;
    }
    
    // Delete all rows in a table
    public boolean deleteTable(String tableName) {
        try {
            ///System.out.println("Deleting rows table statement...");
            ///System.out.println("-----------------------------------------------------");
            String sql =    "DELETE FROM " + tableName;
            result = stmt.executeQuery(sql);
        }
        catch (SQLException se)
        { return false; }
        return true;
    }
    
    // Push a single word into a table
    public boolean insertTable(String tableName, String word) {
        try {
            // Exe SQL query
            stmt = connection.createStatement();
            String sql = new StringBuilder(
                    "INSERT INTO ")
                    .append(tableName)
                    .append(" (ID,WORD) VALUES (seq_category_id.nextval, '")    // 'seq_category_id' is an Oracle DB Sequence fct that manage the auto_increment
                    .append(word)
                    .append("')")
                    .toString();
            result = stmt.executeQuery(sql);
        }
        catch (SQLException se)
        { se.printStackTrace(); return false; }
        return true;
    }
    
    // Compare dictionary to another table of words to join them and get nbr of match words
    public int countDicoMatch(String tableName) {
        int counterMatch = 0;
        
        try {
            ///System.out.println("Counting nbr of matchs statement...");
            ///System.out.println("-----------------------------------------------------");
            stmt = connection.createStatement();
            String sql =    "SELECT COUNT(*) AS match" +
                            " FROM " + tableName +
                            " INNER JOIN DICTIONARY ON "+tableName+".WORD = DICTIONARY.WORD";
            result = stmt.executeQuery(sql);
            while(result.next()) {
                counterMatch = result.getInt("match");
            }
            ///System.out.println("Dico match nbr = " + counterMatch);
        }
        catch (SQLException se)
        { se.printStackTrace(); }
        
        return counterMatch;
    }
    
    // Compare dictionary to another table of words to join them and calcul rate of match words
    public boolean loadDicoInnerJoin(String tableName) {
        try {
            ///System.out.println("Loading dico inner join statement...");
            ///System.out.println("-----------------------------------------------------");
            stmt = connection.createStatement();
            String sql =    "SELECT "+tableName+".WORD" +
                            " FROM " + tableName +
                            " INNER JOIN DICTIONARY ON "+tableName+".WORD = DICTIONARY.WORD";
            result = stmt.executeQuery(sql);
        }
        catch (SQLException se)
        { return false; }
        return true;
    }
    
    // Display the last loaded data
    public void dispResultData(){
        try {
            /*
            * STEP 4: Extract data from result set
            */
            while (result.next())
            {
                /*
                * Retrieve by column
                */
                String data = result.getString("WORD");
                /*
                * Display values
                */
                System.out.print(", Word: " + data);
            }
        } catch (SQLException ex) {
            Logger.getLogger(EntityManager.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    // Close DB statement (query) & connection
    public void closeConn() {
        /*
        * finally block used to close resources
        */
        try
        {
            if (stmt != null)
            {
                stmt.close();
                ///System.out.println("Statement closed.");
            }
        }
        catch (SQLException sqlException)
        {
            sqlException.printStackTrace();
        }
        try
        {
            if (connection != null)
            {
                connection.close();
                ///System.out.println("Connection closed.");
            }
        }
        catch (SQLException sqlException)
        {
            sqlException.printStackTrace();
        }
    }
    
    // Use for remove last ',' of a loop generated SQL query
    private static String removeLastChar(String str) {
        return str.substring(0, str.length() - 1);
    }
}
