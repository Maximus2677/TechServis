using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TechServis
{
    [TestFixture]
    internal class StatTests
    {
        DataBase dataBase = new DataBase();

        [Test]
        public void sumCompleteTest() 
        {
            dataBase.openConnection();

            string querystring = $"Select KlientID from Zaivky where StatusID = '3'";

            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.getConnection());

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            dataBase.closeConnection();

            int expeced = dataTable.Rows.Count;

            Stat stat = new Stat();
            int actual = stat.SumComplete();

            Assert.That(actual, Is.EqualTo(expeced));
        }
    }
}
