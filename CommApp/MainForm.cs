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

        //Список Контентов запросов по серверам
        List<QueryContext> ListQueryContext { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.FlagColumns = true;
            this.ListQueryContext = new List<QueryContext>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ServerForm sf = new ServerForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                try
                {
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

                    //Если файл не существует, то выводим данные в таблицу и создаём файл 
                    if (fi.Exists == false)
                    {
                        //Форм строки
                        DataGridViewRow row = new DataGridViewRow();
                        row = CreateRowForDataGridView();

                        /*Присваиваем ячейкам значения*/

                        // Выбрать
                        row.Cells[0].Value = true;

                        /*Состояние подключения*/

                        // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                        //Создаём объект подключения
                        ConnectionData cd = new ConnectionData(sf.NameServer, sf.AdressIP, sf.Port, sf.DB_Name, sf.User, sf.Pass, sf.Timeout);
                        VerifyConnection(cd, row);

                        // Название
                        row.Cells[2].Value = sf.NameServer;
                        // Адрес IP
                        row.Cells[3].Value = sf.AdressIP;
                        // Порт
                        row.Cells[4].Value = sf.Port;
                        //База данных
                        row.Cells[5].Value = sf.DB_Name;
                        //Пользователь
                        row.Cells[6].Value = sf.User;
                        //  Таймаут
                        row.Cells[7].Value = sf.Timeout;
                        //  Пароль
                        row.Cells[8].Value = sf.Pass;

                        // Добавляем строку в DataGridView
                        dgvServers.Rows.Add(row);

                        //Формируем строку для записи в файл
                        StringForWrite sfw = new StringForWrite(row.Index.ToString(), row.Cells[0].Value.ToString(), sf.NameServer, sf.AdressIP, sf.Port, sf.User, sf.Pass, sf.DB_Name, sf.Timeout);

                        string str = sfw.StrWrite;

                        //Записываем в файл
                        StreamWriter sw = fi.CreateText(); //Createtext создаёт новый файл и записывает в него техт
                        sw.WriteLine(str);
                        sw.Close();
                    }
                    else //Файл существует
                    {
                        // То проверяем есть ли уже в нём запись о добавляемом сервере
                        //Считываем файл
                        StreamReader sr = new StreamReader(fi.FullName);
                        string str;

                        // Флаг записи в файл
                        bool flWrite = true;
                        
                        while ((str = sr.ReadLine()) != null)
                        {
                            //Разбиваем считанную строку на элементы
                            string[] columns = str.Split(';');

                            string index = columns[0];
                            string selected = columns[1];
                            string serverName = columns[2];
                            string adresIP = columns[3];
                            string port = columns[4];
                            string user = columns[5];
                            string passw = columns[6];
                            string database = columns[7];
                            string timeout = columns[8];

                            if (adresIP == sf.AdressIP && port == sf.Port && user == sf.User && database == sf.DB_Name)
                            {
                                flWrite = false;
                                MessageBox.Show("Сервер с такими параметрами уже есть в Базе!");
                                break;
                            }
                        }
                        sr.Close();

                        if (flWrite) // Если добавляемого сервера нет в БД
                        {
                            //Форм строки
                            DataGridViewRow row = new DataGridViewRow();
                            row = CreateRowForDataGridView();

                            /*Присваиваем ячейкам значения*/

                            // Выбрать
                            row.Cells[0].Value = true;

                            /*Состояние подключения*/

                            // Выполняем проверку доступности сервера для подключения и выводим иконку статуса доступности
                            //Создаём объект подключения
                            ConnectionData cd = new ConnectionData(sf.NameServer, sf.AdressIP, sf.Port, sf.DB_Name, sf.User, sf.Pass, sf.Timeout);
                            VerifyConnection(cd, row);

                            // Название
                            row.Cells[2].Value = sf.NameServer;
                            // Адрес IP
                            row.Cells[3].Value = sf.AdressIP;
                            // Порт
                            row.Cells[4].Value = sf.Port;
                            //База данных
                            row.Cells[5].Value = sf.DB_Name;
                            //Пользователь
                            row.Cells[6].Value = sf.User;
                            //  Таймаут
                            row.Cells[7].Value = sf.Timeout;
                            //  Пароль
                            row.Cells[8].Value = sf.Pass;

                            // Добавляем строку в DataGridView
                            dgvServers.Rows.Add(row);

                            //Формируем строку для записи в файл
                            StringForWrite sfw = new StringForWrite(row.Index.ToString(), row.Cells[0].Value.ToString(), sf.NameServer, sf.AdressIP, sf.Port, sf.User, sf.Pass, sf.DB_Name, sf.Timeout);

                            string strWrite = sfw.StrWrite;
                            //Запись в файл
                            StreamWriter sw = fi.AppendText(); //AppendText добавляет данные в конец существующего файла
                            sw.WriteLine(strWrite);
                            sw.Close();
                        }     
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                VerifyBatton();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbExequteQuery.Value = 0;
            pbExequteQuery.Visible = false;
            lbMessage.Visible = false;
            BindingSource bs = new BindingSource();
            bs = null;
            dgvResults.DataSource = bs;
            rtbQuery.Text = "";

            //Очищаем таблицы результатов запросов с серверами и строками
            //Таблица серверов
            dgvResults.Columns.Clear();
            dgvResults.Rows.Clear();
            //Таблица строк
            dgvQueryRows.Columns.Clear();
            //dgvQueryRows.Rows.Clear();
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

                        VerifyConnection(cd, row);
                       
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
                    VerifyBatton();
                    //Присваиваем фокус первой ячейке таблицы
                    btUp.Enabled = false;
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
                    VerifyConnection(cd,row);
                    
                }
                sw.Close();
            }
        }


        private void btnDelit_Click(object sender, EventArgs e)
        {
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
                VerifyBatton();
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
                string servName = row.Cells[2].Value.ToString(); //Название сервера
                string adressIP = row.Cells[3].Value.ToString(); //Адрес IP
                string port = row.Cells[4].Value.ToString(); //Порт
                string database = row.Cells[5].Value.ToString(); //База данных
                string user = row.Cells[6].Value.ToString(); //Пользователь
                string timeout = row.Cells[7].Value.ToString(); //Таймаут
                string passw = row.Cells[8].Value.ToString(); //Пароль

                ConnectionData cd = new ConnectionData(servName, adressIP, port, database, user, passw, timeout);
                VerifyConnection(cd, row);
                
            }
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (rtbQuery.Text == "")
            {
                MessageBox.Show("Вы не ввели запрос!");
               
            }
            else if (dgvServers.Rows.Count < 1)
            {
                MessageBox.Show("Вы не добавили ни одного сервера!");
            }
            else
            {
                //Показываем и Устанавливаем статусбар в нулевое значение
                pbExequteQuery.Visible = true;
                pbExequteQuery.Value = 0;

                //Отображает сообщение
                lbMessage.Visible = false;
                lbMessage.Text = "";

                //Считаем количество выделенных серверов
                int countSelServers = 0;

                //Счётчик опрошенных серверов
                int countServers= 1;

                foreach (DataGridViewRow row in dgvServers.Rows)
                {
                    //Если сервер отмечен галочкой
                    if (row.Cells[0].Value.ToString() == "True")
                    {
                        countSelServers++;
                    }
                }

                FlagColumns = true;
                //Очищаем таблицу результатов
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
                        lbMessage.Visible = true;
                        lbMessage.Text = String.Format("Выполнен запрос на {0} сервере из {1}", countServers, countSelServers);
                        countServers++;
                    }
                }
            }

        }

        public void ExecuteReaderToDataGridView(ConnectionData connData, string sqlQuery)
        {
            if (FlagColumns)
            {
                /*Создаём название колонок для таблицы*/

                DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                column1.Name = "server";
                column1.HeaderText = "Сервер";
                column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
                column2.Name = "countStrings";
                column2.HeaderText = "Найдено строк";
                column2.Width = 200;

                DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
                column3.Name = "adressIP";
                column3.HeaderText = "Адрес IP";
                column3.Visible = false;

                DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
                column4.Name = "port";
                column4.HeaderText = "Порт";
                column4.Visible = false;

                DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
                column5.Name = "database";
                column5.HeaderText = "База данных";
                column5.Visible = false;

                DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
                column6.Name = "user";
                column6.HeaderText = "Пользователь";
                column6.Visible = false;


                dgvResults.Columns.AddRange(column1,column2, column3, column4, column5, column6);

                FlagColumns = false;
            }
            /* Создаём соединение с сервером*/
            NpgsqlConnection connection = new NpgsqlConnection(connData.ConnectionString);
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);
                connection.Open(); //Открываем соединение
                if (connection.State == ConnectionState.Open)
                {
                    NpgsqlDataReader reader = command.ExecuteReader();//Выполняем запрос
                    if (reader.HasRows) // Если запрос вернул строки
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        QueryContext queryContext = new QueryContext(dt, connData);
                        //Добавляем контекст в список
                        ListQueryContext.Add(queryContext);
                        //Формируем строку
                        //int countRows = 0;
                        //while (reader.Read())
                        //{
                        //    countRows++;
                        //}
                        //Закрываем соединение
                        connection.Close();

                        //Создаём информационную строку
                        DataGridViewRow rowInfo = new DataGridViewRow();
                        rowInfo.DefaultCellStyle.BackColor = Color.Aqua;

                        /*Создаём информационные ячейки о сервере */
                        //Название сервера
                        DataGridViewCell cellInfo1 = new DataGridViewTextBoxCell();
                        cellInfo1.Value = connData.ServerName;
                        //Количество строк в запросе
                        DataGridViewCell cellInfo2 = new DataGridViewTextBoxCell();
                        cellInfo2.Value = dt.Rows.Count;//Количество строк в таблице
                        //cellInfo2.Value = countRows;
                        //Адрес IP
                        DataGridViewCell cellInfo3 = new DataGridViewTextBoxCell();
                        cellInfo3.Value = connData.AdressIP;
                        //Порт
                        DataGridViewCell cellInfo4 = new DataGridViewTextBoxCell();
                        cellInfo4.Value = connData.Port;
                        //База данных
                        DataGridViewCell cellInfo5 = new DataGridViewTextBoxCell();
                        cellInfo5.Value = connData.Database;
                        //Пользователь
                        DataGridViewCell cellInfo6 = new DataGridViewTextBoxCell();
                        cellInfo6.Value = connData.User;

                        //Добавляем ячейку в строку
                        rowInfo.Cells.AddRange(cellInfo1, cellInfo2, cellInfo3,cellInfo4, cellInfo5,cellInfo6);

                        //Добавляем строку в таблицу
                        dgvResults.Rows.Add(rowInfo);
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

        private void VerifyConnection(ConnectionData cd, DataGridViewRow row)
        {
            try
            {
                string connectionString = cd.ConnectionString;

                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
           
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    row.Cells[0].Value = true;
                    row.Cells[0].ReadOnly = false;
                    row.Cells[1].Value = Properties.Resources.success_16х16;
                    connection.Close();
                }
                else
                {
                    row.Cells[0].Value= false;
                    row.Cells[0].ReadOnly = true;
                    row.Cells[1].Value = Properties.Resources.error_16х16;
                    //StatusImg.Image = Properties.Resources.error_16х16;
                }
            }
            catch
            {
                row.Cells[0].Value = false;
                row.Cells[0].ReadOnly = true;
                row.Cells[1].Value = Properties.Resources.error_16х16;
                //StatusImg.Image = Properties.Resources.error_16х16;
            }
        }

        private void dgvResults_SelectionChanged(object sender, EventArgs e)
        {

            /*Получаем данные о сервере из таблицы Серверов*/
            //Имя Сервера
            string nameServer = dgvResults.CurrentRow.Cells[0].Value.ToString();
            //IP Адрес
            string adressIP = dgvResults.CurrentRow.Cells[2].Value.ToString();
            //Порт
            string port = dgvResults.CurrentRow.Cells[3].Value.ToString();
            //База данных
            string database = dgvResults.CurrentRow.Cells[4].Value.ToString();
            //Пользователь
            string user = dgvResults.CurrentRow.Cells[5].Value.ToString();
            //Перебираем контексты запросов и выбираем тот, где имя сервера совпадает
            foreach (QueryContext qCont in ListQueryContext)
            {
                if (qCont.ConnectData.ServerName == nameServer && qCont.ConnectData.AdressIP == adressIP && qCont.ConnectData.Port == port
                    && qCont.ConnectData.Database == database && qCont.ConnectData.User == user)
                    {
                        //Выводим строки в таблицу
                        BindingSource bs = new BindingSource();
                        bs.DataSource = qCont.Table;
                        dgvQueryRows.DataSource = bs;
                    /*Устанавливаем ширину последней колонки Авто*/
                    //Получаем количество колонок
                    int countColumns = dgvQueryRows.ColumnCount;
                    //dgvQueryRows.Columns[countColumns - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dgvQueryRows.Columns[countColumns - 1].Width = 100;
                }
            }
        }

        private void rtbQuery_TextChanged(object sender, EventArgs e)
        {
            if (rtbQuery.Text == "")
            {
                btnRun.Enabled = false;
                btnClear.Enabled = false;
            }
            else
            {
                btnRun.Enabled = true;
                btnClear.Enabled = true;
            }
        }

        private void VerifyBatton()
        {
            if (dgvServers.Rows.Count>0)
            {
                btnEdit.Enabled = true;
                btnDelit.Enabled = true;
                btSelAll.Enabled = true;
                btClearAll.Enabled = true;
                btReload.Enabled = true;
                btUp.Enabled = true;
                btDown.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelit.Enabled = false;
                btSelAll.Enabled = false;
                btClearAll.Enabled = false;
                btReload.Enabled = false;
                btUp.Enabled = false;
                btDown.Enabled = false;
            }
        }

        private void dgvServers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*Видимость кнопок перемещения строк таблицы вверх-вниз*/
            //Получаем количество строк в таблице
            int countRows = dgvServers.Rows.Count;
            if (countRows > 0)
            {
                //Получаем индекс текущей строки
                int indexCurrentRow = dgvServers.CurrentRow.Index;
                if (indexCurrentRow == 0)//Если строка первая
                {
                    btUp.Enabled = false;
                    btDown.Enabled = true;
                }
                else
                {
                    btUp.Enabled = true;
                    if (indexCurrentRow == countRows-1)//Если последняя строка
                    {
                        btDown.Enabled = false;
                    }
                    else
                    {
                        btDown.Enabled = true;
                    }
                    
                }
            }
            //Выделяем текущую строку
            dgvServers.CurrentRow.Selected = true;
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            //Получаем индексы
            int currRowInd = dgvServers.CurrentRow.Index;
            int upRowInd = dgvServers.CurrentRow.Index - 1;
            // Получаем строки
            DataGridViewRow row1 = dgvServers.Rows[currRowInd];
            DataGridViewRow row2 = dgvServers.Rows[upRowInd];
            // Удаляем строки из таблицы
            dgvServers.Rows.Remove(row1);
            dgvServers.Rows.Remove(row2);
            // Вставляем строки на новые позиции
            dgvServers.Rows.Insert(upRowInd, row1);
            dgvServers.Rows.Insert(currRowInd, row2);
            //Снимаем выделения со всех строк
            foreach(DataGridViewRow row in dgvServers.Rows)
            {
                if (row.Index == dgvServers.Rows[upRowInd].Index)
                {
                    row.Selected = true;
                    DataGridViewCell cell = dgvServers.Rows[row.Index].Cells[0];
                    dgvServers.CurrentCell = cell;
                }
                else
                {
                    row.Selected = false;
                }
                
            }
            //Выделяем перемещённую строку
            //dgvServers.Rows[upRowInd].Selected = true;
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            //Получаем индексы
            int currRowInd = dgvServers.CurrentRow.Index;
            int downRowInd = dgvServers.CurrentRow.Index + 1;
            // Получаем строки
            DataGridViewRow row1 = dgvServers.Rows[currRowInd];
            DataGridViewRow row2 = dgvServers.Rows[downRowInd];
            // Удаляем строки из таблицы
            dgvServers.Rows.Remove(row1);
            dgvServers.Rows.Remove(row2);
            // Вставляем строки на новые позиции
            dgvServers.Rows.Insert(currRowInd, row2);
            dgvServers.Rows.Insert(downRowInd, row1);
            //Выделяем перемещённую строку
            //dgvServers.Rows[downRowInd].Selected = true;
            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                if (row.Index == dgvServers.Rows[downRowInd].Index)
                {
                    row.Selected = true;
                    DataGridViewCell cell = dgvServers.Rows[row.Index].Cells[0];
                    dgvServers.CurrentCell = cell;
                }
                else
                {
                    row.Selected = false;
                }

            }

        }

        private DataGridViewRow CreateRowForDataGridView()
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

            return row;

        }
    }
}
