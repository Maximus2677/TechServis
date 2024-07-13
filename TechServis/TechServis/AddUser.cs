using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TechServis
{
    public partial class AddUser : Form
    {
        DataBase dataBase = new DataBase();
        public AddUser()
        {
            InitializeComponent();
        }

        //Нажатие на кнопку добавить
        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var login = tb_UserName.Text;
            var pass = md5.hashPassword(tb_UserPassword.Text);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select UserName From Users where UserName = '{login}'";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count == 0)
            {
                querystring = $"insert into Users (UserName, UserPassword, RoleAdmin, RoleManager, RoleMaster) values ('{login}', '{pass}', '{cb_AdminRole.Checked}', '{ManagerRole.Checked}', '{MasterRole.Checked}')";

                sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Пользователь успешно добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Такой логин уже используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            tb_UserPassword.PasswordChar = '●';
        }
    }
}
