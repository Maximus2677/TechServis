using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TechServis
{
    public partial class AddMaster : Form
    {
        DataBase dataBase = new DataBase();
        public AddMaster()
        {
            InitializeComponent();
        }

        private void AddMaster_Load(object sender, EventArgs e)
        {
            AddUsers();
            cb_Login.SelectedIndex = -1;
        }

        //Нажатие на кнопку добавить
        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            if (cb_Login.SelectedIndex != -1)
            {
                var FIO = tb_FIO.Text;
                var Tel = tb_Tel.Text;

                int UserID;

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();

                string querystring = $"Select UserID, UserName from Users where UserName = '{cb_Login.SelectedItem.ToString()}'";

                SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                dataAdapter.SelectCommand = sqlCommand;
                dataAdapter.Fill(dataTable);

                UserID = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);

                querystring = $"Select FIO from Masters where FIO = '{FIO}'";
                sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                dataTable.Clear();

                dataAdapter.SelectCommand = sqlCommand;
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    querystring = $"insert into Masters (FIO, Telefon, UserID) values ('{FIO}', '{Tel}', '{UserID}')";

                    sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Мастер успешно добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Такой мастер уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверное значение в поле логин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        //Добавление логинов в cb_Login
        private void AddUsers()
        {
            dataBase.openConnection();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select UserName from Users";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cb_Login.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }

            dataBase.closeConnection();
        }
    }
}
