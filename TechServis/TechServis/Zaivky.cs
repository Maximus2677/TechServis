using System;
using System.Collections;
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
    public partial class Zaivky : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        int id;
        string role;

        public Zaivky(int iid, string rrole)
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 0;
            id = iid;
            role = rrole;

            AddClients();
            AddMasters();
            AddUsers();
        }

        private void Zaivky_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            for (int i = 0; i < 3; i++)
            {
                tabControl1.SelectedIndex = i;
                RefreshDataGrid();
            }

            tabControl1.SelectedIndex = 0;

            switch (role)
            {
                case "admin":
                    tb_Date.Enabled = true;
                    tb_Oborudovanie.Enabled = true;
                    tb_TipPolomky.Enabled = true;
                    tb_Opisanie.Enabled = true;
                    tb_Klient_FIO.Enabled = true;
                    tb_Klient_Telefon.Enabled = true;
                    tb_FIO_Master.Enabled = true;
                    tb_Telefon_Master.Enabled = true;

                    cb_Klient.Enabled = true;
                    cb_Master.Enabled = true;
                    cb_Login.Enabled = true;

                    btn_Add.Enabled = true;
                    btn_Delete.Enabled = true;
                    btn_Admin.Enabled = true;
                    btn_Stat.Enabled = true;
                    break;
                case "manager":
                    tb_Date.Enabled = true;
                    tb_Oborudovanie.Enabled = true;
                    tb_TipPolomky.Enabled = true;
                    tb_Opisanie.Enabled = true;
                    tb_Klient_FIO.Enabled = true;
                    tb_Klient_Telefon.Enabled = true;
                    tb_FIO_Master.Enabled = true;
                    tb_Telefon_Master.Enabled = true;

                    cb_Klient.Enabled = true;
                    cb_Master.Enabled = true;
                    cb_Login.Enabled = true;

                    btn_Add.Enabled = true;
                    btn_Delete.Enabled = true;
                    btn_Stat.Enabled = true;
                    break;
            }
        }

        //Открытие формы для добавления строк
        private void btn_Add_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    AddZaivk addZaivk = new AddZaivk();
                    addZaivk.ShowDialog();
                    break;
                case 1:
                    AddKlients addKlients = new AddKlients();
                    addKlients.ShowDialog();
                    break;
                case 2:
                    AddMaster addMaster = new AddMaster();
                    addMaster.ShowDialog();
                    break;
            }
        }

        //Удаление строки
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow();
            RefreshDataGrid();
        }

        //Изменения строки
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
            RefreshDataGrid();
        }

        //Обновления таблицы
        private void btn_Update_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
            AddClients();
            AddMasters();
            AddUsers();
        }

        //Поиск введёных значений в таблице
        private void btn_Search_Click(object sender, EventArgs e)
        {
            Search();
        }

        //Поиск введёных значений в таблице
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        // Добавление строк в таблицу
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    dgw.Rows.Add(record.GetInt32(0), record.GetDateTime(1), record.GetDateTime(2), record.GetDateTime(3), record.GetString(4), record.GetString(5),
                        record.GetString(6), record.GetString(7), record.GetString(8), record.GetString(9), record.GetString(10));
                    break;
                case 1:
                    dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2));
                    break;
                case 2:
                    dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3));
                    break;
            }
        }

        // Обноление данных таблице
        private void RefreshDataGrid()
        {
            DataGridView dgw = dgv_Zaivky;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    dgw = dgv_Zaivky;
                    break;
                case 1:
                    dgw = dgv_Klients;
                    break;
                case 2:
                    dgw = dgv_Masters;
                    break;
            }

            dgw.Rows.Clear();

            string query = $" ";

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (role == "master")
                    {
                        query = $"Select ZaivkaID, DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, Klients.FIO, Masters.FIO, KomentMaster, StatusName From Zaivky, Klients, Masters, Statuses Where Zaivky.KlientID = Klients.KlientID and Zaivky.MasterID = Masters.MasterID and Zaivky.StatusID = Statuses.StatusID and Masters.UserID = '{id}'";
                    }
                    else
                    {
                        query = $"Select ZaivkaID, DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, Klients.FIO, Masters.FIO, KomentMaster, StatusName From Zaivky, Klients, Masters, Statuses Where Zaivky.KlientID = Klients.KlientID and Zaivky.MasterID = Masters.MasterID and Zaivky.StatusID = Statuses.StatusID";
                    }
                    break;
                case 1:
                    query = $"select * from Klients";
                    break;
                case 2:
                    query = $"Select MasterID, FIO, Telefon, UserName From Masters, Users Where Masters.UserID = Users.UserID";
                    break;
            }

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        //Нажатие на клетку в Таблице Заявки
        private void dgv_Zaivky_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Zaivky.Rows[selectedRow];

                lbl_ZaivkaID.Text = row.Cells[0].Value.ToString();
                tb_Date.Text = row.Cells[1].Value.ToString();
                tb_Data_Nach.Text = row.Cells[2].Value.ToString();
                tb_Date_Vip.Text = row.Cells[3].Value.ToString();
                tb_Oborudovanie.Text = row.Cells[4].Value.ToString();
                tb_TipPolomky.Text = row.Cells[5].Value.ToString();
                tb_Opisanie.Text = row.Cells[6].Value.ToString();
                cb_Klient.SelectedItem = row.Cells[7].Value;
                cb_Master.SelectedItem = row.Cells[8].Value;
                tb_Koment_Master.Text = row.Cells[9].Value.ToString();
                cb_Status.SelectedItem = row.Cells[10].Value;
            }
        }

        //Нажатие на клетку в Таблице Клиенты
        private void dgv_Klients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Klients.Rows[selectedRow];

                lbl_ID_Klient.Text = row.Cells[0].Value.ToString();
                tb_Klient_FIO.Text = row.Cells[1].Value.ToString();
                tb_Klient_Telefon.Text = row.Cells[2].Value.ToString();
            }
        }

        //Нажатие на клетку в Таблице Мастера
        private void dgv_Masters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Masters.Rows[selectedRow];

                lbl_ID_Master.Text = row.Cells[0].Value.ToString();
                tb_FIO_Master.Text = row.Cells[1].Value.ToString();
                tb_Telefon_Master.Text = row.Cells[2].Value.ToString();
                cb_Login.SelectedItem = row.Cells[3].Value;
            }
        }

        // Поиск значений в таблице
        private void Search()
        {
            dataBase.openConnection();

            DataGridView dgw = dgv_Zaivky;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    dgw = dgv_Zaivky;
                    break;
                case 1:
                    dgw = dgv_Klients;
                    break;
                case 2:
                    dgw = dgv_Masters;
                    break;
            }

            dgw.Rows.Clear();
            string search;
            SqlCommand command;
            SqlDataReader reader;

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (role == "master")
                    {
                        search = $"Select ZaivkaID, DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, Klients.FIO, Masters.FIO, KomentMaster, StatusName From Zaivky, Klients, Masters, Statuses Where Zaivky.KlientID = Klients.KlientID and Zaivky.MasterID = Masters.MasterID and Zaivky.StatusID = Statuses.StatusID and Masters.UserID = '{id}' and concat (ZaivkaID, DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, Klients.FIO, Masters.FIO, KomentMaster, StatusName) like '%" + tb_Search.Text + "%'";
                    }
                    else
                    {
                        search = $"Select ZaivkaID, DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, Klients.FIO, Masters.FIO, KomentMaster, StatusName From Zaivky, Klients, Masters, Statuses Where Zaivky.KlientID = Klients.KlientID and Zaivky.MasterID = Masters.MasterID and Zaivky.StatusID = Statuses.StatusID and concat (ZaivkaID, DataZaivky, DataNachaloRemonta, DataVipolnenie, Oborudovanie, TipPolomky, Opisanie, Klients.FIO, Masters.FIO, KomentMaster, StatusName) like '%" + tb_Search.Text + "%'";
                    }

                    command = new SqlCommand(search, dataBase.getConnection());

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ReadSingleRow(dgw, reader);
                    }

                    reader.Close();
                    break;
                case 1:
                    search = $"Select KlientID, FIO, Telefon From Klients Where concat (KlientID, FIO, Telefon) like '%" + tb_Search.Text + "%'";

                    command = new SqlCommand(search, dataBase.getConnection());

                    dataBase.openConnection();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ReadSingleRow(dgw, reader);
                    }

                    reader.Close();
                    break;
                case 2:
                    search = $"Select MasterID, FIO, Telefon, UserName From Masters, Users Where Masters.UserID = Users.UserID and concat (MasterID, FIO, Telefon, UserName) like '%" + tb_Search.Text + "%'";

                    command = new SqlCommand(search, dataBase.getConnection());

                    dataBase.openConnection();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ReadSingleRow(dgw, reader);
                    }

                    reader.Close();
                    break;
            }
        }

        // Удаление строки
        private void DeleteRow()
        {
            dataBase.openConnection();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    var id = lbl_ZaivkaID.Text;

                    if (Convert.ToInt32(id) != 0)
                    {
                        string querystring = $"delete from Zaivky where ZaivkaID = '{id}'";
                        SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Строка успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lbl_ZaivkaID .Text = "0";

                        cb_Klient.SelectedIndex = -1;
                        cb_Master.SelectedIndex = -1;
                        cb_Status.SelectedIndex = -1;

                        tb_Date.Text = "";
                        tb_Data_Nach.Text = "";
                        tb_Date_Vip.Text = "";
                        tb_Oborudovanie.Text = "";
                        tb_TipPolomky.Text = "";
                        tb_Opisanie.Text = "";
                        tb_Koment_Master.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана строка для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1:
                    var idk = lbl_ID_Klient.Text;

                    if (Convert.ToInt32(idk) != 0)
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        DataTable dataTable = new DataTable();

                        string querystring = $"Select KlientID from Zaivky where KlientID = '{idk}'";

                        SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                        dataAdapter.SelectCommand = sqlCommand;
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            querystring = $"delete from Klients where KlientID = '{idk}'";
                            sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Строка успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lbl_ID_Klient.Text = "0";

                            tb_Klient_FIO.Text = "";
                            tb_Klient_Telefon.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить клиента так как есть упоминания в таблице Заявки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана строка для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    var idm = lbl_ID_Master.Text;

                    if (Convert.ToInt32(idm) != 0)
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        DataTable dataTable = new DataTable();

                        string querystring = $"Select MasterID from Zaivky where MasterID = '{idm}'";

                        SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

                        dataAdapter.SelectCommand = sqlCommand;
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            querystring = $"delete from Masters where MasterID = '{idm}'";
                            sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Строка успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            lbl_ID_Master.Text = "0";

                            cb_Login.SelectedIndex = -1;

                            tb_FIO_Master.Text = "";
                            tb_Telefon_Master.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить мастера так как есть упоминания в таблице Заявки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбрана строка для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            dataBase.closeConnection();
        }

        // Изменение строки
        private void Edit()
        {
            dataBase.openConnection();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    var id = lbl_ZaivkaID.Text;
                    var ob = tb_Oborudovanie.Text;
                    var tipe = tb_TipPolomky.Text;
                    var op = tb_Opisanie.Text;
                    var KomMas = tb_Koment_Master.Text;
                    int Sat = 0;
                    int kli, mas;

                    switch (cb_Status.SelectedIndex)
                    {
                        case 0:
                            Sat = 1;
                            break;
                        case 1:
                            Sat = 2;
                            break;
                        case 2:
                            Sat = 3;
                            break;
                        case 3:
                            Sat = 4;
                            break;
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    DataTable dataTable = new DataTable();

                    if(cb_Klient.SelectedIndex != -1 && cb_Master.SelectedIndex != -1)
                    {
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
                            if (DateTime.TryParse(tb_Date_Vip.Text, out var dateVip))
                            {
                                if (DateTime.TryParse(tb_Data_Nach.Text, out var dateNach))
                                {
                                    querystring = $"update Zaivky set DataZaivky = '{date}', DataNachaloRemonta = '{dateNach}', DataVipolnenie = '{dateVip}', oborudovanie = '{ob}', TipPolomky = '{tipe}', Opisanie = '{op}', KlientID = '{kli}', MasterID = '{mas}', KomentMaster = '{KomMas}', StatusID = '{Sat}' where ZaivkaID = '{id}'";

                                    sqlCommand = new SqlCommand(querystring, dataBase.getConnection());
                                    sqlCommand.ExecuteNonQuery();

                                    MessageBox.Show("Заявка успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Не правильный формат даты начало работ!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Не правильный формат даты выполниения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                    break;
                case 1:
                    var idk = lbl_ID_Klient.Text;
                    var KFIO = tb_Klient_FIO.Text;
                    var KTel = tb_Klient_Telefon.Text;

                    string querystringk = $"update Klients set FIO = '{KFIO}', Telefon = '{KTel}' where KlientID = '{idk}'";

                    SqlCommand sqlCommandk = new SqlCommand(querystringk, dataBase.getConnection());

                    sqlCommandk.ExecuteNonQuery();

                    MessageBox.Show("Клиент успешно изменён!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    var idm = lbl_ID_Master.Text;
                    var MFIO = tb_FIO_Master.Text;
                    var MTel = tb_Telefon_Master.Text;

                    int UserID;

                    if (cb_Login.SelectedIndex != -1)
                    {
                        SqlDataAdapter dataAdapterm = new SqlDataAdapter();
                        DataTable dataTablem = new DataTable();

                        string querystringm = $"Select UserID, UserName from Users where UserName = '{cb_Login.SelectedItem.ToString()}'";

                        SqlCommand sqlCommandm = new SqlCommand(querystringm, dataBase.getConnection());

                        dataAdapterm.SelectCommand = sqlCommandm;
                        dataAdapterm.Fill(dataTablem);

                        UserID = Convert.ToInt32(dataTablem.Rows[0].ItemArray[0]);

                        querystringm = $"update Masters set FIO = '{MFIO}', Telefon = '{MTel}', UserID = '{UserID}' where MasterID = '{idm}'";

                        sqlCommandm = new SqlCommand(querystringm, dataBase.getConnection());
                        sqlCommandm.ExecuteNonQuery();

                        MessageBox.Show("Мастер успешно изменён!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Неверное значение в поле логин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            dataBase.closeConnection();
        }

        //Открытие Админпанели
        private void btn_Admin_Click(object sender, EventArgs e)
        {
            AdminPanel adminpanel = new AdminPanel();
            adminpanel.ShowDialog();
        }

        //Отркытие Статистики
        private void btn_Stat_Click(object sender, EventArgs e)
        {
            Stat stat = new Stat();
            stat.ShowDialog();
        }

        //Добавление клиентов в cb_Klient
        private void AddClients()
        {
            dataBase.openConnection();

            cb_Klient.Items.Clear();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"Select FIO from Klients";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cb_Klient.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }

            dataBase.closeConnection();
        }

        //Добавление мастеров в cb_Master
        private void AddMasters()
        {
            dataBase.openConnection();

            cb_Master.Items.Clear();

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

        //Добавление логинов в cb_Login
        private void AddUsers()
        {
            dataBase.openConnection();

            cb_Login.Items.Clear();

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
