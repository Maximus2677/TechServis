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
    public partial class AdminPanel : Form
    {
        DataBase dataBase = new DataBase();

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        //Добавление строк в таблицу
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetBoolean(3), record.GetBoolean(4), record.GetBoolean(5));
        }

        //Обновление таблицы
        private void RefreshDataGrid()
        {
            DataGridView dgw = dataGridView1;

            dgw.Rows.Clear();

            string query = $"Select * from Users";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        //Нажатие на кнопку добавить
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }

        //Нажатие на кнопку обновить
        private void btn_Update_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        //Удаление строки
        private void DeleteRow()
        {
            dataBase.openConnection();

            var id = label2.Text;

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select UserID From Masters where UserID = '{id}'";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count == 0)
            {
                if (Convert.ToInt32(id) != 0)
                {
                    querystring = $"delete from Users where UserID = '{id}'";
                    sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Пользователь успешно удалён!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не выбран пользователь для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить пользователя так как он привязан к мастеру!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataBase.closeConnection();
        }

        //Нажатие на клетку в таблице
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                label2.Text = row.Cells[0].Value.ToString();
            }
        }

        //Нажатие на кнопку удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
            RefreshDataGrid();
        }

        //Сохранение изменений в таблице
        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                var ad = dataGridView1.Rows[i].Cells[3].Value.ToString();
                var man = dataGridView1.Rows[i].Cells[4].Value.ToString();
                var mas = dataGridView1.Rows[i].Cells[5].Value.ToString();

                var query = $"update Users set RoleAdmin = '{ad}', RoleManager = '{man}', RoleMaster = '{mas}' where UserID = '{id}'";
                var command = new SqlCommand(query, dataBase.getConnection());
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Изменения успешно сохранены!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }
    }
}
