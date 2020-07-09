﻿using MiddlewareApp.Persistence;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Service
{
    public class AuthentificationCheckService
    {
        public bool GetUser(string login, string pwd)
        {
            DataTable dt = new DataTable();
            UsersDAO DB = new UsersDAO();
            bool success = false;

            //Recuperer la table Users
            DB.OpenConnection();
            dt = DB.GetUsersTable();

            //Trouver une correspondance à login et vérifier le password
            foreach(DataRow row in dt.Rows)
            {
                if ((string)row[1] == login && (string)row[2] == pwd)
                {
                    success = true;
                    break;
                }
            }
            DB.CloseConnection();
            return success;
        }

        public static bool CheckUserToken(string usertoken)
        {
            DataTable dt = new DataTable();
            UsersDAO DB = new UsersDAO();

            //Recuperer la table Users
            DB.OpenConnection();
            dt = DB.GetUsersTable();

            //Trouver une correspondance à login et vérifier le password
            foreach (DataRow row in dt.Rows)
            {
                if ((string)row[3] == usertoken)
                {
                    return true;
                }
            }
            DB.CloseConnection();
            return false;
        }

        public static string GetMailAdress(string usertoken)
        {
            DataTable dt = new DataTable();
            UsersDAO DB = new UsersDAO();

            //Recuperer la table Users
            DB.OpenConnection();
            dt = DB.GetUsersTable();

            //Trouver une correspondance à login et vérifier le password
            foreach (DataRow row in dt.Rows)
            {
                if ((string)row[3] == usertoken)
                {
                    return (string)row[1];
                }
            }
            DB.CloseConnection();
            return "";
        }

    }
}
