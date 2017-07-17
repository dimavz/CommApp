using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommApp
{
    class StringForWrite
    {
        //Свойства
        public string SelServer { get; set; }
        public string ServerName { get; set; }
        public string AdressIP { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Timeout { get; set; }
        //Записываемая строка
        public string StrWrite{ get; }

        public StringForWrite(string index, string selServer, string serverName,string adressIP,string port, string user, string passw, string database, string timeout )
        {
            this.SelServer = selServer;
            this.ServerName = serverName;
            this.AdressIP = adressIP;
            this.Port = port;
            this.User = user;
            this.Password = passw;
            this.Database = database;
            this.Timeout = timeout;

            this.StrWrite = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", index, selServer, serverName, adressIP, port, user, passw, database, timeout);
        }
    }
}
