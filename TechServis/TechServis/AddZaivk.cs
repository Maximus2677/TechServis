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
    public partial class AddZaivk : Form
    {
        DataBase dataBase = new DataBase();
        public AddZaivk()
        {
            InitializeComponent();
        }

        private void AddZaivk_Load(object sender, EventArgs e)
        {
            tb_Date.Text = DateTime.Now.ToString();
            AddClients();
            AddMasters();
            cb_Klient.SelectedIndex = -1;
            cb_Master.SelectedIndex = -1;
        }

        //Нажатие на кнопку добавить
        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            if (cb_Klient.SelectedIndex != -1 && cb_Master.SelectedIndex != -1) 
            {
                var oborud = tb_Ob.Text;
                var tipe = tb_Tipe.Text;
                var op = tb_Op.Text;

                int kli, mas;

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                DataTable dataTable = new DataTable();

                string querystring = $"Select KlientID, FIO from Klients where FIO = '{cb_Klient.SelectedItem.ToString()}'";

                SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                dataAdapter.SelectCommand = sqlCommand;
                dataAdapter.Fill(dataTable);

                kli = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);

                querystring = $"Select MasterID, FIO from Masters where FIO = '{cb_Master.SelectedItem.ToString()}'";

                sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                dataAdapter = new SqlDataAdapter();
                dataTable = new DataTable();

                dataAdapter.SelectCommand = sqlCommand;
                dataAdapter.Fill(dataTable);

                mas = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);

                if (DateTime.TryParse(tb_Date.Text, out var date))
                {
                    querystring = $"insert into Zaivky (DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, KlientID, MasterID, KomentMaster, StatusID) values ('', '', '', '{oborud}', '{tipe}', '{op}', {kli}, {mas}, 'Коментарий', 1)";

                    sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Заявка успешно добавлена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не правильный формат даты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверное значения в полях клиент и мастер!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        //Добавление клиентов в cb_klient
        private void AddClients()
        {
            dataBase.openConnection();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select FIO from Klients";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                cb_Klient.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }

            dataBase.closeConnection();
        }

        //Добавление мастеров в cb_master
        private void AddMasters()
        {
            dataBase.openConnection();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select FIO from Masters";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cb_Master.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }

            dataBase.closeConnection();
        }
    }
}
