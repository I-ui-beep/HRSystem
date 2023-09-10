using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
     //Авторизация через БД
            /*
            String loginUser = textBox1.Text;
            String passUser = textBox2.Text;
            SqlConnection con1 = new SqlConnection(@"Data Source = NOTEBOOK; Initial Catalog = HR; Integrated Security = True");
            DataTable zTable = new DataTable();
            SqlDataAdapter zAdapter;
            con1.Open();

            SqlCommand command = new SqlCommand("Select * FROM HR WHERE Name_log = @ul AND Name_pass = @up", con1);
            command.Parameters.Add("@ul", SqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@up", SqlDbType.VarChar).Value = passUser;
            zAdapter = new SqlDataAdapter(command);
            zAdapter.Fill(zTable);
            con1.Close();

            if (zTable.Rows.Count <= 0)
            {
                MessageBox.Show("Неправильные логин/пароль");
            }
            else
            {
                using (Form2 f2 = new Form2())
                {
                    f2.ShowDialog();
                }
            }
            */

            using (Form2 f2 = new Form2())
            {
                f2.ShowDialog();
            }
        }
    }
}
