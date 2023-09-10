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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = NOTEBOOK; Initial Catalog = HR; Integrated Security = True");
        DataTable monTable = new DataTable();
        SqlDataAdapter monAdapter;

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void movesidepanel(Button btn)

        {
            panelslide.Top = btn.Top;
            panelslide.Height = btn.Height;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            movesidepanel(button3);
            flowLayoutPanel1.Visible = false;
            dataGridView1.Visible = false;
            flowLayoutPanel2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            panel1.Visible = false;
            button8.Visible = false;
            pictureBox1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            movesidepanel(button4);
            flowLayoutPanel1.Visible = false;
            dataGridView1.Visible = false;
            flowLayoutPanel2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            panel1.Visible = false;
            pictureBox1.Visible = false;
            button8.Visible = false;

            //Интеграция с hh.ru через API, парсинг
            /*https://hh.ru/oauth/authorize?
                response_type = code &
                client_id ={ client_id}
                &
                state ={ state}
                &
                redirect_uri ={ redirect_uri}
               https://api.hh.ru/negotiations
            */
        }
        // Отображение таблицы с кандидатами и соответствующими вакансиями
        private void button9_Click(object sender, EventArgs e)
            {
                movesidepanel(button9);
                flowLayoutPanel1.Visible = true;
                dataGridView1.Visible = true;
                flowLayoutPanel2.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                monTable.Clear();
                dataGridView1.DataSource = null;

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select CANDIDATES.Id, CANDIDATES.FIO_CAN, CANDIDATES.PHONE, CANDIDATES.E_MAIL, CANDIDATES.LINK_RES, VACANCY.Id, VACANCY.NAME_VAC FROM CANDIDATES INNER JOIN VACANCY ON VACANCY.Id = CANDIDATES.Id_VAC", con);
                    monAdapter = new SqlDataAdapter(command);
                    monAdapter.Fill(monTable);
                    con.Close();
                    dataGridView1.DataSource = monTable.DefaultView;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "ФИО кандидата";
                    dataGridView1.Columns[2].HeaderText = "Телефон кандидата";
                    dataGridView1.Columns[3].HeaderText = "E-mail кандидата";
                    dataGridView1.Columns[4].HeaderText = "Резюме кандидата";
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].HeaderText = "Вакансия";
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }     
            }


            private void button10_Click(object sender, EventArgs e)
            {
                movesidepanel(button10);
                flowLayoutPanel1.Visible = false;
                dataGridView1.Visible = false;
                flowLayoutPanel2.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button13.Visible = true;
                button14.Visible = true;

            }

            private void button11_Click(object sender, EventArgs e)
            {
                movesidepanel(button11);
                flowLayoutPanel1.Visible = false;
                dataGridView1.Visible = false;
                flowLayoutPanel2.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
            }

            private void button12_Click(object sender, EventArgs e)
            {
                movesidepanel(button12);
            }

            private void Form2_Load(object sender, EventArgs e)
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "hRDataSet.VACANCY". При необходимости она может быть перемещена или удалена.
                this.vACANCYTableAdapter.Fill(this.hRDataSet.VACANCY);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "hRDataSet.CANDIDATES". При необходимости она может быть перемещена или удалена.
                this.cANDIDATESTableAdapter.Fill(this.hRDataSet.CANDIDATES);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "hRDataSet.HR". При необходимости она может быть перемещена или удалена.
                this.hRTableAdapter.Fill(this.hRDataSet.HR);

            }
            // Отображение таблицы с кандидатами по выбранной вакансии в Combobox
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                monTable.Clear();
                dataGridView1.DataSource = null;
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select CANDIDATES.Id, CANDIDATES.FIO_CAN,CANDIDATES.PHONE, CANDIDATES.E_MAIL, CANDIDATES.LINK_RES, VACANCY.Id, VACANCY.NAME_VAC FROM CANDIDATES INNER JOIN VACANCY ON VACANCY.Id = CANDIDATES.Id_VAC WHERE VACANCY.NAME_VAC = '" + comboBox1.Text.ToString() + "'", con);
                    monAdapter = new SqlDataAdapter(command);
                    monAdapter.Fill(monTable);
                    con.Close();
                    dataGridView1.DataSource = monTable.DefaultView;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "ФИО кандидата";
                    dataGridView1.Columns[2].HeaderText = "Телефон кандидата";
                    dataGridView1.Columns[3].HeaderText = "E-mail кандидата";
                    dataGridView1.Columns[4].HeaderText = "Резюме кандидата";
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].HeaderText = "Вакансия";
                }
                catch
                {
                    MessageBox.Show("Ошибка соединения");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }

            private void button5_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Отметить этап 'Первичный контакт' пройденным?", "Внимание", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    button5.BackColor = Color.FromArgb(0, 255, 0);
                    /*try
                    {
                        con.Open();
                        string q = "UPDATE CANDIDATES SET E_MAIL = '" + textBox2.Text + "' ";
                        SqlCommand com = new SqlCommand(q, con);
                        com.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка соединения");
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }*/
        }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                button5.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Отметить этап 'Телефонное интервью' пройденным?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                button6.BackColor = Color.FromArgb(0, 255, 0);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                button6.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Отметить этап 'Тест' пройденным?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                button7.BackColor = Color.FromArgb(0, 255, 0);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                button7.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Отметить этап 'Интервью' пройденным?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                button13.BackColor = Color.FromArgb(0, 255, 0);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                button13.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Отметить этап 'Испытательный срок' пройденным?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                button14.BackColor = Color.FromArgb(0, 255, 0);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                button14.BackColor = Color.FromArgb(255, 0, 0);
            }
        }

        //Загрузка картинки в профиль
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Загрузка файлов на форму
        }
    }
}
