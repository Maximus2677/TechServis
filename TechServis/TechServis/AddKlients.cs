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
using System.Data.Common;

namespace TechServis
{
    public partial class AddKlients : Form
    {
        DataBase dataBase = new DataBase();
        public AddKlients()
        {
            InitializeComponent();
        }

        private void AddKlients_Load(object sender, EventArgs e)
        {

        }

        //Нажатие на кнопку добавить
        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var FIO = tb_FIO.Text;
            var Tel = tb_Telefon.Text;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select KlientID, FIO from Klients where FIO = '{FIO}'";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count == 0)
            {
                querystring = $"Insert into Klients (FIO, Telefon) values ('{FIO}', '{Tel}')";

                sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Клиент успешно добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Такой клиент уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataBase.closeConnection();
        }
    }
}
