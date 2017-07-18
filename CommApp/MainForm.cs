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
        private bool FlagColumns { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.FlagColumns = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            ServerForm sf = new ServerForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Формируем строку для таблицы серверов DataGridView
                DataGridViewRow row = new DataGridViewRow();

                /*Создаём ячейки для строки*/

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
                //Ячейка Таймаут
                DataGridViewCell cell7 = new DataGridViewTextBoxCell();
                //Ячейка Пароль
                DataGridViewCell cell8 = new DataGridViewTextBoxCell();


                // Добавляем в строку ячейки
                row.Cells.AddRange(cell0, cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8);

                // Присваиваем ячейкам значения

                // Выбрать
                cell0.Value = true;

                /*Состояние подключения*/
                
                // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                //Создаём объект подключения
                ConnectionData cd = new ConnectionData(sf.NameServer, sf.AdressIP, sf.Port, sf.DB_Name, sf.User, sf.Pass,sf.Timeout);
                string connectionString = cd.ConnectionString;
                NpgsqlConnection connect = new NpgsqlConnection(connectionString);

                try
                {
                    connect.Open();
                    if (connect.State == ConnectionState.Open)
                    {
                        //StatusImg.Image = Properties.Resources.success_16х16;
                        cell1.Value = Properties.Resources.success_16х16;
                        connect.Close();
                    }
                    else
                    {
                        //StatusImg.Image = Properties.Resources.error_16х16;
                        cell1.Value = Properties.Resources.error_16х16;
                    }
                }
                catch
                {
                    cell1.Value = Properties.Resources.error_16х16;
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
                //  Таймаут
                cell7.Value = sf.Timeout;
                //  Пароль
                cell8.Value = sf.Pass;

                // Добавляем строку в DataGridView
                dgvServers.Rows.Add(row);

                try
                {

                    //Формируем строку для записи в файл
                    StringForWrite sfw = new StringForWrite(row.Index.ToString(), cell0.Value.ToString(), sf.NameServer, sf.AdressIP, sf.Port, sf.User, sf.Pass, sf.DB_Name, sf.Timeout);

                    string str = sfw.StrWrite;


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
            pbExequteQuery.Value = 0;
            pbExequteQuery.Visible = false;
            dgvResults.Columns.Clear();
            dgvResults.Rows.Clear();
            BindingSource bs = new BindingSource();
            bs = null;
            dgvResults.DataSource = bs;
            rtbQuery.Text = "";
            rtbResult.Text = "";
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
                        //Разбиваем считанную строку на элементы
                        string[] columns = str.Split(';');

                        string index = columns[0];
                        string selected = columns[1];
                        string serverName = columns[2];
                        string adresIP = columns[3];
                        string port = columns[4];
                        string user= columns[5];
                        string passw = columns[6];
                        string database = columns[7];
                        string timeout = columns[8];
                        
                        // Формируем строку для таблицы серверов DataGridView
                        DataGridViewRow row = new DataGridViewRow();

                        // Создаём ячейки для строки
                        // Ячейка Выбрать
                        DataGridViewCell cell0 = new DataGridViewCheckBoxCell();
                        //Ячейка Состояние
                        DataGridViewCell cell1 = new DataGridViewImageCell();
                        //Ячейка Название Сервера
                        DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                        //Ячейка Адрес IP
                        DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                        //Ячейка Порт 
                        DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                        //Ячейка База Данных
                        DataGridViewCell cell5 = new DataGridViewTextBoxCell();
                        //Ячейка Пользователь
                        DataGridViewCell cell6 = new DataGridViewTextBoxCell();
                        //Ячейка Таймаут
                        DataGridViewCell cell7 = new DataGridViewTextBoxCell();
                        //Ячейка Пароль
                        DataGridViewCell cell8 = new DataGridViewTextBoxCell();


                        // Добавляем в строку ячейки
                        row.Cells.AddRange(cell0, cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8);

                        /* Присваиваем ячейкам значения */ 

                        // Выбрать
                        if(selected=="True")
                        {
                            cell0.Value = true;
                        }
                        else { cell0.Value = false; }
                        
                        
                        // Проверяем СОСТОЯНИЕ подключения

                        //Создаём объект для подключения
                        ConnectionData cd = new ConnectionData(serverName, adresIP, port, database, user, passw, timeout);

                        // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                        string connectionString = cd.ConnectionString;
                        NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                        try
                        {
                            connection.Open();
                            if (connection.State == ConnectionState.Open)
                            {
                                //StatusImg.Image = Properties.Resources.success_16х16;
                                cell1.Value = Properties.Resources.success_16х16;
                                connection.Close();
                            }
                            else
                            {
                                //StatusImg.Image = Properties.Resources.error_16х16;
                                cell1.Value = Properties.Resources.error_16х16;
                            }
                        }
                        catch{
                            //StatusImg.Image = Properties.Resources.error_16х16;
                            cell1.Value = Properties.Resources.error_16х16;
                            //MessageBox.Show("Нет соединения с БД!");
                        }
                       
                        // Название
                        cell2.Value = serverName;
                        // Адрес IP
                        cell3.Value = adresIP;
                        // Порт
                        cell4.Value = port;
                        //База Данных
                        cell5.Value = database;
                        //Пользователь
                        cell6.Value = user;
                        //  Таймаут
                        cell7.Value = timeout;
                        //  Пароль
                        cell8.Value = passw;

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
            sf.Timeout = dgvServers.CurrentRow.Cells[7].Value.ToString();
            sf.Pass = dgvServers.CurrentRow.Cells[8].Value.ToString();

            if (sf.ShowDialog() == DialogResult.OK)
            {
                dgvServers.CurrentRow.Cells[2].Value = sf.NameServer;
                dgvServers.CurrentRow.Cells[3].Value = sf.AdressIP;
                dgvServers.CurrentRow.Cells[4].Value = sf.Port;
                dgvServers.CurrentRow.Cells[5].Value = sf.DB_Name;
                dgvServers.CurrentRow.Cells[6].Value = sf.User;
                dgvServers.CurrentRow.Cells[7].Value = sf.Timeout;
                dgvServers.CurrentRow.Cells[8].Value = sf.Pass;


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
                foreach (DataGridViewRow row in dgvServers.Rows)
                {
                    //Формируем строку для записи в файл
                    string index = row.Index.ToString();
                    string selServer = row.Cells[0].Value.ToString();
                    string serverName = row.Cells[2].Value.ToString();
                    string adresIP = row.Cells[3].Value.ToString();
                    string port = row.Cells[4].Value.ToString();
                    string database = row.Cells[5].Value.ToString();
                    string user = row.Cells[6].Value.ToString();
                    string timeout = row.Cells[7].Value.ToString();
                    string passw = row.Cells[8].Value.ToString();

                    StringForWrite sfw = new StringForWrite(index,selServer,serverName,adresIP,port,user,passw,database,timeout);
                    string str = sfw.SelServer;
                    sw.WriteLine(str);

                    // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                    ConnectionData cd = new ConnectionData(serverName, adresIP, port, database, user, passw, timeout);
                    string connectionString = cd.ConnectionString;

                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    try
                    {
                        connection.Open();
                        if (connection.State == ConnectionState.Open)
                        {
                            //StatusImg.Image = Properties.Resources.success_16х16;
                            row.Cells[1].Value = Properties.Resources.success_16х16;
                            connection.Close();
                        }
                        else
                        {
                            row.Cells[1].Value = Properties.Resources.error_16х16;
                            //StatusImg.Image = Properties.Resources.error_16х16;
                        }
                    }
                    catch
                    {
                        row.Cells[1].Value = Properties.Resources.error_16х16;
                        //StatusImg.Image = Properties.Resources.error_16х16;
                    }
                    
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

            foreach (DataGridViewRow row in dgvServers.Rows)
            {

                /* string index, string selServer, string serverName,string adressIP,string port, string user, string passw, string database, string timeout*/
                StringForWrite sfw = new StringForWrite(
                    row.Index.ToString(), 
                    row.Cells[0].Value.ToString(), //Выбрать
                    row.Cells[2].Value.ToString(), //Название
                    row.Cells[3].Value.ToString(), //Адрес IP
                    row.Cells[4].Value.ToString(), //Порт
                    row.Cells[6].Value.ToString(), //Пользователь
                    row.Cells[8].Value.ToString(), //Пароль
                    row.Cells[5].Value.ToString(), //База данных
                    row.Cells[7].Value.ToString() //Таймаут
                    );

                string str = sfw.StrWrite;
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
                try
                {
                    string servName = row.Cells[2].Value.ToString(); //Название сервера
                    string adressIP = row.Cells[3].Value.ToString(); //Адрес IP
                    string port = row.Cells[4].Value.ToString(); //Порт
                    string database = row.Cells[5].Value.ToString(); //База данных
                    string user = row.Cells[6].Value.ToString(); //Пользователь
                    string timeout = row.Cells[7].Value.ToString(); //Таймаут
                    string passw = row.Cells[8].Value.ToString(); //Пароль

                    ConnectionData cd = new ConnectionData(servName, adressIP, port, database, user, passw, timeout);

                    string connectionString = cd.ConnectionString;

                    NpgsqlConnection connection = null;
                    connection = new NpgsqlConnection(connectionString);
                    connection.Open();

                    if (connection.State == ConnectionState.Open)
                    {
                        //rtbQuery.Text = ("---выполнено подключение\r\n");
                        //StatusImg.Image = Properties.Resources.success_16х16;
                        row.Cells[1].Value = Properties.Resources.success_16х16;
                        connection.Close();
                    }
                    else
                    {
                        //StatusImg.Image = Properties.Resources.error_16х16;
                        row.Cells[1].Value = Properties.Resources.error_16х16;
                    }
                }
                catch
                {
                    //StatusImg.Image = Properties.Resources.error_16х16;
                    row.Cells[1].Value = Properties.Resources.error_16х16;
                }
                
            }
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (rtbQuery.Text == "")
            {
                MessageBox.Show("Вы не ввели запрос!");
            }
            else
            {
                //Показываем и Устанавливаем статусбар в нулевое значение
                pbExequteQuery.Visible = true;
                pbExequteQuery.Value = 0;

                //Считаем количество выделенных серверов
                int countSelServers = 0;
                foreach (DataGridViewRow row in dgvServers.Rows)
                {
                    //Если сервер отмечен галочкой
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        countSelServers++;
                    }
                }


                FlagColumns = true;
                dgvResults.Columns.Clear();
                dgvResults.Rows.Clear();

                foreach (DataGridViewRow row in dgvServers.Rows)
                {

                    //Получаем запрос из формы
                    string sqlQuery = rtbQuery.Text;

                    //Если сервер отмечен галочкой
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        string servName = row.Cells[2].Value.ToString(); //Название сервера
                        string adressIP = row.Cells[3].Value.ToString(); //Адрес IP
                        string port = row.Cells[4].Value.ToString(); //Порт
                        string database = row.Cells[5].Value.ToString(); //База данных
                        string user = row.Cells[6].Value.ToString(); //Пользователь
                        string timeout = row.Cells[7].Value.ToString(); //Таймаут
                        string passw = row.Cells[8].Value.ToString(); //Пароль

                        //Создаём объект соединения
                        ConnectionData cd = new ConnectionData(servName, adressIP, port, database, user, passw, timeout);

                        //Выводим результат выполнения запроса в форму
                        ExecuteReaderToDataGridView(cd, sqlQuery);

                        //Устанавливаем прогресс статусбара
                        pbExequteQuery.Value += 100/countSelServers;
                    }
                }
            }

        }

        public void ExecuteReaderToDataGridView(ConnectionData connData, string sqlQuery)
        {
            NpgsqlConnection connection = null;
            try
            {
                connection = new NpgsqlConnection(connData.ConnectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
                    NpgsqlDataReader reader;
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows) // Если в результатах запроса есть строки
                    {

                        /*Создаём название колонок для таблицы*/
                        if (this.FlagColumns) //Флаг для формирования названия колонок
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                                //column.Name = reader.GetName(i);
                                column.HeaderText = reader.GetName(i);
                                dgvResults.Columns.Add(column);
                            }
                            this.FlagColumns = false;
                        }


                        //Формируем список строк
                        List<DataGridViewRow> listRows = new List<DataGridViewRow>();

                        //Формируем строку
                        int countRows = 0;
                        while (reader.Read())
                        {

                            DataGridViewRow row = new DataGridViewRow();

                            /*Создаём ячейки для строки*/
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                DataGridViewCell cell = new DataGridViewTextBoxCell();
                                cell.Value = reader[i].ToString();

                                // Добавляем в строку ячейку
                                row.Cells.Add(cell);
                            }

                            //Добавляем строку в таблицу
                            listRows.Add(row);
                            countRows++;
                        }
                        //Закрываем соединение
                        connection.Close();

                        //Создаём информационную строку
                        DataGridViewRow rowInfo = new DataGridViewRow();
                        rowInfo.DefaultCellStyle.BackColor = Color.Pink;
                        //Создаём информационную ячейку о сервере 
                        DataGridViewCell cellInfo = new DataGridViewTextBoxCell();
                        //cellInfo.
                        cellInfo.Value = "Сервер: " + connData.ServerName + " ;" + "  Количество строк: " + countRows;
                        //Добавляем ячейку в строку
                        rowInfo.Cells.Add(cellInfo);

                        //Добавляем строку в таблицу
                        dgvResults.Rows.Add(rowInfo);

                        //Добавляем в таблицу остальные строки
                        dgvResults.Rows.AddRange(listRows.ToArray());
                        dgvResults.Columns[0].Width = 250;

                        //dgvResults.Columns[1].AutoSizeMode = Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    //выполнено отключение
                    connection.Close();
                }
            }
        }
    }
}
