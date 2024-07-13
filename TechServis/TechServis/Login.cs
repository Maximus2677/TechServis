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

namespace TechServis
{
    public partial class Login : Form
    {
        DataBase dataBase = new DataBase();
        Roles roles = new Roles();

        int id;
        string role;

        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '●';
            textBox1.MaxLength = 30;
            textBox2.MaxLength = 40;
            dataBase.createDB();
        }

        //Афторизация пользователя
        private void BottunLogin_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var userLogin = textBox1.Text;
            var userPassword = md5.hashPassword(textBox2.Text);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select UserID, UserName, UserPassword, RoleAdmin, RoleManager from Users where UserName = '{userLogin}' and UserPassword = '{userPassword}'";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                roles.SetID(Convert.ToInt32(dataTable.Rows[0].ItemArray[0]));
                roles.SetAd(Convert.ToBoolean(dataTable.Rows[0].ItemArray[3]));
                roles.SetMan(Convert.ToBoolean(dataTable.Rows[0].ItemArray[4]));
                id = roles.GetID();
                role = roles.GetRole();
                MessageBox.Show("Вы успешно вошли!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Zaivky zaivky= new Zaivky(id, role);
                this.Hide();
                zaivky.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataBase.closeConnection();
        }
    }
}
