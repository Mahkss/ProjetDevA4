   M S B A M L   `   `   `  ����F  BProjetDevA4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjetDevA4.PresentationProjetDevA4.Presentation  5   	   +    %ProjetDevA4.Presentation.ResultWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProjetDevA4.Presentation     5   	     � Title$#  Résultats Message Random.txt��5   	   $	��300��6.   $	��500��6;   .��5	      � $��Center=�6   $��20q�6(   $	��Top=�64    � RowDefinitions 5
   
   �� 5      $��20��6   �� 5      $	��100��6   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� -   5         ��Name$ FilenameLabel��5      $��Nom du fichier: ��6'   $��0��6B   $��Right=�6R   $��0��6n   $��Center=�6{   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ FilenameTextBox��5      $��Random Message.txt��6)   $��1��6F   $
��Left=�6V   $��23��6q   $��0��6}   $��Center=�6�   $	��120��6�   �� 5   
   -   5        $ ContentLabel��5      $��Texte Déchiffré: ��6&   $��0��6B   $��Right=�6R   $��1��6n   $��Center=�6{   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5         ��Name$ ContentTextBox��5      $����Pour associer une image à un ListViewItem, à cause de la nature look-less de la bibliothèque WPF, il ne suffit pas d'associer un ID d'image ou une clé à une propriété. Au lieu de cela, vous devez définir les contrôles utilisés pour afficher l'image et le texte constituant le ListViewItem. ��6,   $��1��6V  $
��Left=�6f  $��1��6�  $
��Wrap=�6�  $��Center=�6�  �� 5   
   -   5        $ SecretInfoLabel��5      $��Info secrète: ��6)   $��0��6B   $��Right=�6R   $��2��6n   $��Center=�6{   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ SecretInfoTextBox��5      $��Ceci est l'info secrète��6+   $��1��6M   $
��Left=�6]   $��23��6x   $��2��6�   $��Center=�6�   $	��120��6�   �� 5   
   -   5        $ 	CodeLabel��5      $��Clé de déchiffrement: ��6#   $��0��6D   $��Right=�6T   $��3��6p   $��Center=�6}   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ CodeTextBox��5      $��13LKJ31DKK21��6%   $��1��6<   $
��Left=�6L   $��23��6g   $��3��6s   $��Center=�6�   $	��120��6�   �� 5   
   -	   5        $ PDFLabel��5      $��Rapport PDF: ��6"   $��0��6:   $��Right=�6J   $��4��6f   $��Center=�6s   $
��Bold"�6�   $��14(�6�   �� 5   
   -
   5         ��Name$ 	PDFButton��5      $��Télecharger��6$   $��1��6:   $
��Left=�6J   $��4��6e   $��Center=�6r   $	��100��6�   $
��Bold"�6�   $��14(�6�   5"      5#      