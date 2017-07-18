using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommApp
{
    public class ConnectionData
    {
        public string ServerName { get; set; }
        public string AdressIP { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Timeout { get; set; }

        public string ConnectionString { get; }


        public ConnectionData(string serverName, string adressIP, string port, string database, string user, string password, string timeout="5")
       {
            this.ServerName = serverName;
            this.AdressIP = adressIP;
            this.Port = port;
            this.Database = database;
            this.User = user;
            this.Password = password;
            this.Timeout = timeout; 

            this.ConnectionString = "Server=" + adressIP + ";" + "Port=" + port + ";" + "Database = " + database + ";" + "User Id=" + user + ";" + "Password=" + password + ";" + "Timeout=" + timeout + ";";
        }
    }
}
