using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace TechServis
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Persist Security Info=True;Trusted_Connection=True; database=TechServis;server=(local)");

        //создание бд если её не существует
        public void createDB()
        {
            if (File.Exists("dbExist.txt") == false)
            {
                File.Create("dbExist.txt");

                SqlConnection sqlConnection1 = new SqlConnection(@"Persist Security Info=True;Trusted_Connection=True; database=master;server=(local)");

                sqlConnection1.Open();

                string querystring = $"Create database TechServis";
                SqlCommand sqlCommand = new SqlCommand(querystring, sqlConnection1);
                sqlCommand.ExecuteNonQuery();

                sqlConnection1.Close();

                createTable();
                createForeignKeys();
                insert();
            }
        }

        //Подключение к субд
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
            sqlConnection.Open();
            }
        }

        //Отключение от субд
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        //Возращает строку подключение к бд
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

        //Создание таблиц
        private void createTable()
        {
            openConnection();

            string querystring = $"create table Users(\r\nUserID int identity(1,1) primary key,\r\nUserName varchar(30),\r\nUserPassword varchar(40),\r\nRoleAdmin bit,\r\nRoleManager bit,\r\nRoleMaster bit)\r\n\r\ncreate table Klients(\r\nKlientID int identity(1,1) primary key,\r\nFIO varchar (50),\r\nTelefon varchar (20))\r\n\r\ncreate table Masters(\r\nMasterID int identity(1,1) Primary key,\r\nFIO varchar (50),\r\nTelefon varchar (20),\r\nUserID int)\r\n\r\ncreate table Statuses(\r\nStatusID int identity(1,1) primary key,\r\nStatusName varchar (20))\r\n\r\ncreate table Zaivky(\r\nZaivkaID int identity(1,1) primary key,\r\nDataZaivky datetime,\r\nDataNachaloRemonta datetime,\r\nDataVipolnenie datetime,\r\nOborudovanie varchar(40),\r\nTipPolomky varchar(40),\r\nOpisanie varchar(300),\r\nKlientID int,\r\nMasterID int,\r\nKomentMaster varchar(300),\r\nStatusID int)";
            SqlCommand sqlCommand = new SqlCommand(querystring, getConnection());
            sqlCommand.ExecuteNonQuery();

            closeConnection();
        }

        //Создание связей между таблицами
        private void createForeignKeys()
        {
            openConnection();

            string querystring = $"alter table Zaivky \r\nAdd constraint FK_Zaivky_Klients foreign key (KlientID)\r\nreferences Klients (KlientID)\r\n\r\nalter table Zaivky \r\nAdd constraint FK_Zaivky_Masters foreign key (MasterID)\r\nreferences Masters (MasterID)\r\n\r\nalter table Zaivky \r\nAdd constraint FK_Zaivky_Statuses foreign key (StatusID)\r\nreferences Statuses (StatusID)\r\n\r\nalter table Masters \r\nAdd constraint FK_Masters_Users foreign key (UserID)\r\nreferences Users (UserID)";
            SqlCommand sqlCommand = new SqlCommand(querystring, getConnection());
            sqlCommand.ExecuteNonQuery();

            closeConnection();
        }

        //Внесение данных в таблицы
        private void insert()
        {
            openConnection();

            string querystring = $"insert into Statuses (StatusName) values ('В ожидании')\r\ninsert into Statuses (StatusName) values ('В работе')\r\ninsert into Statuses (StatusName) values ('Выполнено')\r\ninsert into Statuses (StatusName) values ('Не выполнено')\r\n\r\ninsert into Users (UserName, UserPassword, RoleAdmin, RoleManager, RoleMaster) values ('admin','21232F297A57A5A743894A0E4A801FC3',1,1,1)";
            SqlCommand sqlCommand = new SqlCommand(querystring, getConnection());
            sqlCommand.ExecuteNonQuery();

            closeConnection();
        }
    }
}
