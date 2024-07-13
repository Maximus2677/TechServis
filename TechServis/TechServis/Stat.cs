using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechServis
{
    public partial class Stat : Form
    {
        DataBase dataBase = new DataBase();
        public Stat()
        {
            InitializeComponent();
        }

        private void Stat_Load(object sender, EventArgs e)
        {
            lbl_Kol.Text = "Количество выполненых заявок: " + SumComplete().ToString();
            lbl_Sred.Text = "Среднее время выполнения заявки: " + testDate().Days + " дней " + testDate().Hours + " часов " + testDate().Minutes + " минут";
            GetTipe();
        }

        //Вычисляет среднее время выполнения заявки
        private TimeSpan testDate()
        {
            dataBase.openConnection();

            int i;

            string querystring = $"Select DataNachaloRemonta, DataVipolnenie from Zaivky where DataVipolnenie > DataNachaloRemonta and StatusID = 3";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            TimeSpan timeSpan = new TimeSpan(0, 0, 0);

            if (dataTable.Rows.Count != 0)
            {
                for (i = 0; i < dataTable.Rows.Count; i++)
                {
                    timeSpan += Convert.ToDateTime(dataTable.Rows[i].ItemArray[1]) - Convert.ToDateTime(dataTable.Rows[i].ItemArray[0]);
                }

                int a = Convert.ToInt32(timeSpan.TotalSeconds);

                a /= i;

                timeSpan = new TimeSpan(0, 0, a);
            }
            dataBase.closeConnection();

            return timeSpan;
        }

        //Присылает количество выполненых заявок
        public int SumComplete()
        {
            dataBase.openConnection();

            string querystring = $"Select KlientID from Zaivky where StatusID = '3'";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            dataBase.closeConnection();

            return dataTable.Rows.Count;
        }

        //Присылает типы поломок их количество
        private void GetTipe()
        {
            dataBase.openConnection();

            string querystring = $"Select Distinct TipPolomky from Zaivky";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            string[] tipe = new string[dataTable.Rows.Count];

            for(int i = 0; i < dataTable.Rows.Count;  i++)
            {
                tipe[i] = dataTable.Rows[i].ItemArray[0].ToString();

                string querystringI = $"Select TipPolomky from Zaivky where TipPolomky = '{tipe[i]}'";

                SqlCommand sqlCommandI = new SqlCommand(querystringI, dataBase.getConnection());

                SqlDataAdapter dataAdapterI = new SqlDataAdapter();
                DataTable dataTableI = new DataTable();

                dataAdapterI.SelectCommand = sqlCommandI;
                dataAdapterI.Fill(dataTableI);

                dataGridView1.Rows.Add(tipe[i], dataTableI.Rows.Count);
            }

            dataBase.closeConnection();
        }
    }
}
