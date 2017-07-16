using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;// Подключаем для записи и чтения файлов
using Npgsql;

namespace CommApp
{
    public partial class MainForm : Form
    {
        //Свойства

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            ServerForm sf = new ServerForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Формируем строку для таблицы серверов DataGridView
                DataGridViewRow row = new DataGridViewRow();

                // Создаём ячейки для строки
                // Ячейка Выбрать
                DataGridViewCell cell0 = new DataGridViewCheckBoxCell();
                //Ячейка Состояние
                DataGridViewCell cell1 = new DataGridViewImageCell();
                //Ячейка Название
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                //Ячейка Адрес IP
                DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                //Ячейка База данных
                DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                //Ячейка Порт
                DataGridViewCell cell5 = new DataGridViewTextBoxCell();
                //Ячейка Пользователь
                DataGridViewCell cell6 = new DataGridViewTextBoxCell();
                //Ячейка Пароль
                DataGridViewCell cell7 = new DataGridViewTextBoxCell();


                // Добавляем в строку ячейки
                row.Cells.AddRange(cell0, cell1, cell2, cell3, cell4, cell5, cell6, cell7);

                // Присваиваем ячейкам значения
                // Выбрать
                cell0.Value = true;
                // Состояние
                //cell1.

                // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                string conn_params = "Server=" + sf.AdressIP + ";" + "Port=" + sf.Port + ";" + "Database = " + sf.DB_Name + ";" + "User Id=" + sf.User + ";" + "Password=" + sf.Pass + ";";
                NpgsqlConnection conn = new NpgsqlConnection(conn_params);

                if (conn.State == ConnectionState.Open)
                {
                    StatusImg.Image = Properties.Resources.success_16х16;
                    conn.Close();
                }
                else
                {
                    StatusImg.Image = Properties.Resources.error_16х16;
                }
                // Название
                cell2.Value = sf.NameServer;
                // Адрес IP
                cell3.Value = sf.AdressIP;
                // Порт
                cell4.Value = sf.Port;
                //База данных
                cell5.Value = sf.DB_Name;
                //Пользователь
                cell6.Value = sf.User;
                //  Пароль
                //cell7.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 18); // Устанавливаем Шрифт и размер шрифта для ячейки
                //int count_chars = sf.Pass.Count(); //счётчик символов введённых в пароле
                //string pass = new String('*', count_chars); // Заменяем реальные символы символом "*"
                //cell7.Value = pass;
                cell7.Value = sf.Pass;

                // Добавляем строку в DataGridView
                dgvServers.Rows.Add(row);

                try
                {

                    //Формируем строку для записи в файл
                    string spl = ";";
                    //row.Cells[0].State.
                    string str = row.Index.ToString() + spl + cell0.Value + spl + sf.NameServer + spl + sf.AdressIP + spl + sf.Port + spl + sf.DB_Name + spl + sf.User + spl + sf.Pass;


                    //Создаём объект директории в файловой системе где хранится файл параметров серверов
                    DirectoryInfo di = new DirectoryInfo("files");

                    //Если директории нет, то создаём её
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    //Создаём файл в директории
                    string path = di.FullName + "/servers.txt";
                    FileInfo fi = new FileInfo(path);

                    //Если файл не существует, то создаём его
                    if (fi.Exists == false)
                    {
                        //Записываем в файл
                        StreamWriter sw = fi.CreateText(); //Createtext создаёт новый файл и записывает в него техт
                        sw.WriteLine(str);
                        sw.Close();
                    }
                    else
                    {
                        StreamWriter sw = fi.AppendText(); //AppendText добавляет данные в конец существующего файла
                        sw.WriteLine(str);
                        sw.Close();
                    }
                }
                catch (DirectoryNotFoundException msg)
                {
                    MessageBox.Show(msg.Message);
                }
                catch (EndOfStreamException msg)
                {
                    MessageBox.Show(msg.Message);
                }
                catch (FileNotFoundException msg)
                {
                    MessageBox.Show(msg.Message);
                }
                catch (FileLoadException msg)
                {
                    MessageBox.Show(msg.Message);
                }
                catch (PathTooLongException msg)
                {
                    MessageBox.Show(msg.Message);
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbQuery.Text = "";
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            /* Заполняем таблицу Серверы */

            //Создаём объект директории для чтения
            DirectoryInfo di = new DirectoryInfo("files");

            //Если директория есть,то проверяем есть ли в ней файл
            if (di.Exists)
            {
                //Создаём путь к файлу в директории
                string path = di.FullName + "/servers.txt";
                //Создаём объект файла для чтения
                FileInfo fi = new FileInfo(path);

                //Если файл существует, то читаем его содержимое
                if (fi.Exists)
                {
                    StreamReader sr = new StreamReader(fi.FullName);
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        //Разбиваем строку на элементы
                        string[] columns = str.Split(';');

                        // Формируем строку для таблицы серверов DataGridView
                        DataGridViewRow row = new DataGridViewRow();

                        // Создаём ячейки для строки
                        // Ячейка Выбрать
                        DataGridViewCell cell0 = new DataGridViewCheckBoxCell();
                        //Ячейка Состояние
                        DataGridViewCell cell1 = new DataGridViewImageCell();
                        //Ячейка Название
                        DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                        //Ячейка Адрес IP
                        DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                        //Ячейка База Данных
                        DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                        //Ячейка Порт
                        DataGridViewCell cell5 = new DataGridViewTextBoxCell();
                        //Ячейка Пользователь
                        DataGridViewCell cell6 = new DataGridViewTextBoxCell();
                        //Ячейка Пароль
                        DataGridViewCell cell7 = new DataGridViewTextBoxCell();


                        // Добавляем в строку ячейки
                        row.Cells.AddRange(cell0, cell1, cell2, cell3, cell4, cell5, cell6, cell7);

                        // Присваиваем ячейкам значения
                        // Выбрать
                        //cell0.Selected = true;
                        // Состояние
                        //cell1.
                        // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                        string conn_params = "Server=" + columns[3] + ";" + "Port=" + columns[4] + ";" + "Database = " + columns[5] + ";" + "User Id=" + columns[6] + ";" + "Password=" + columns[7] + ";";
                        NpgsqlConnection conn = new NpgsqlConnection(conn_params);

                        if (conn.State == ConnectionState.Open)
                        {
                            StatusImg.Image = Properties.Resources.success_16х16;
                            conn.Close();
                        }
                        else
                        {
                            StatusImg.Image = Properties.Resources.error_16х16;
                        }

                        //Выбор
                        cell0.Value = columns[1];
                        // Название
                        cell2.Value = columns[2];
                        // Адрес IP
                        cell3.Value = columns[3];
                        // Порт
                        cell4.Value = columns[4];
                        //База Данных
                        cell5.Value = columns[5];
                        //Пользователь
                        cell6.Value = columns[6];
                        //  Пароль
                        //cell7.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 18); // Устанавливаем Шрифт и размер шрифта для ячейки
                        //int count_chars = columns[6].Count(); //счётчик символов введённых в пароле
                        //string pass = new String('*', count_chars); // Заменяем реальные символы символом "*"
                        //cell7.Value = pass;
                        cell7.Value = columns[7];

                        // Добавляем строку в DataGridView
                        dgvServers.Rows.Add(row);
                    }
                    sr.Close();


                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Загружаем форму для редактирования
            ServerForm sf = new ServerForm();
            sf.NameServer = dgvServers.CurrentRow.Cells[2].Value.ToString();
            sf.AdressIP = dgvServers.CurrentRow.Cells[3].Value.ToString();
            sf.Port = dgvServers.CurrentRow.Cells[4].Value.ToString();
            sf.DB_Name = dgvServers.CurrentRow.Cells[5].Value.ToString();
            sf.User = dgvServers.CurrentRow.Cells[6].Value.ToString();
            sf.Pass = dgvServers.CurrentRow.Cells[7].Value.ToString();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                dgvServers.CurrentRow.Cells[2].Value = sf.NameServer;
                dgvServers.CurrentRow.Cells[3].Value = sf.AdressIP;
                dgvServers.CurrentRow.Cells[4].Value = sf.Port;
                dgvServers.CurrentRow.Cells[5].Value = sf.DB_Name;
                dgvServers.CurrentRow.Cells[6].Value = sf.User;
                dgvServers.CurrentRow.Cells[7].Value = sf.Pass;


                //Создаём объект директории в файловой системе где хранится файл параметров серверов
                DirectoryInfo di = new DirectoryInfo("files");

                //Если директории нет, то создаём её
                if (di.Exists == false)
                {
                    di.Create();
                }

                //Создаём файл в директории
                string path = di.FullName + "/servers.txt";
                FileInfo fi = new FileInfo(path);

                //Записываем в файл
                StreamWriter sw = fi.CreateText(); //Createtext создаёт новый файл и записывает в него техт
                string spl = ";";
                foreach (DataGridViewRow row in dgvServers.Rows)
                {
                    string str = row.Index.ToString() + spl + row.Cells[0].Value + spl + row.Cells[2].Value + spl + row.Cells[3].Value + spl + row.Cells[4].Value + spl + row.Cells[5].Value + spl + row.Cells[6].Value + spl + row.Cells[7].Value;
                    //rtbQuery.Text = str;
                    sw.WriteLine(str);
                }
                sw.Close();
            }
        }

        private void btnDelit_Click(object sender, EventArgs e)
        {
            //Извлекаем идентификатор NDS из выделенной строки
            WarningForm wf = new WarningForm();
            if (wf.ShowDialog() == DialogResult.OK)
            {
                dgvServers.Rows.Remove(dgvServers.CurrentRow);

                //Обновляем файл серверов

                //Создаём объект директории в файловой системе где хранится файл параметров серверов
                DirectoryInfo di = new DirectoryInfo("files");

                //Если директории нет, то создаём её
                if (di.Exists == false)
                {
                    di.Create();
                }

                //Создаём файл в директории
                string path = di.FullName + "/servers.txt";
                FileInfo fi = new FileInfo(path);

                //Записываем в файл
                StreamWriter sw = fi.CreateText(); //Createtext создаёт новый файл и записывает в него техт
                string spl = ";";
                foreach (DataGridViewRow row in dgvServers.Rows)
                {
                    string str = row.Index.ToString() + spl + row.Cells[0].Value + spl + row.Cells[2].Value + spl + row.Cells[3].Value + spl + row.Cells[4].Value + spl + row.Cells[5].Value + spl + row.Cells[6].Value + spl + row.Cells[7].Value;
                    //rtbQuery.Text = str;
                    sw.WriteLine(str);
                }
                sw.Close();

            }
           

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Обновляем файл серверов

            //Создаём объект директории в файловой системе где хранится файл параметров серверов
            DirectoryInfo di = new DirectoryInfo("files");

            //Если директории нет, то создаём её
            if (di.Exists == false)
            {
                di.Create();
            }

            //Создаём файл в директории
            string path = di.FullName + "/servers.txt";
            FileInfo fi = new FileInfo(path);

            //Записываем в файл
            StreamWriter sw = fi.CreateText(); //Createtext создаёт новый файл и записывает в него техт
            string spl = ";";
            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                string str = row.Index.ToString() + spl + row.Cells[0].Value + spl + row.Cells[2].Value + spl + row.Cells[3].Value + spl + row.Cells[4].Value + spl + row.Cells[5].Value + spl + row.Cells[6].Value + spl + row.Cells[7].Value;
                //rtbQuery.Text = str;
                sw.WriteLine(str);
            }
            sw.Close();

        }

        private void btSelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void btClearAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности

            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                string conn_params = "Server=" + row.Cells[3].Value + ";" + "Port=" + row.Cells[4].Value + ";" + "Database = " + row.Cells[5].Value + ";" + "User Id=" + row.Cells[6].Value + ";" + "Password=" + row.Cells[7].Value + ";";
                NpgsqlConnection conn = new NpgsqlConnection(conn_params);

                if (conn.State == ConnectionState.Open)
                {
                    StatusImg.Image = Properties.Resources.success_16х16;
                    conn.Close();
                }
                else
                {
                    StatusImg.Image = Properties.Resources.error_16х16;
                }
            }
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                //rtbQuery.Text += row.Cells[0].Value.ToString();
                if (row.Cells[0].Value.ToString() == "True")
                {
                    string conn_params = "Server=" + row.Cells[3].Value + ";" + "Port=" + row.Cells[4].Value + ";" + "Database = " + row.Cells[5].Value + ";" + "User Id=" + row.Cells[6].Value + ";" + "Password=" + row.Cells[7].Value + ";";
                    NpgsqlConnection conn = new NpgsqlConnection(conn_params);

                    if (conn.State == ConnectionState.Open)
                    {
                        string sql = rtbQuery.Text;
                        NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
                        conn.Open(); //Открываем соединение.
                        string result = comm.ExecuteScalar().ToString(); //Выполняем нашу команду.
                        conn.Close(); //Закрываем соединение.
                        StatusImg.Image = Properties.Resources.success_16х16;
                    }
                    else
                    {
                        StatusImg.Image = Properties.Resources.error_16х16;
                    }
                }
            }
        }
    }
}
