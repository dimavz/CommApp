using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommApp
{
    class ConnectionData
    {

            public string AdressIP { get; set; }
            public string Port { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public string Database { get; set; }
            public string Timeout { get; set; }
            public string ServerName { get; set; }

            public ConnectionData(string adressIP, string port, string user, string password, string database, string timeout, string serverName)
            {
                this.AdressIP = adressIP;
                this.Port = port;
                this.User = user;
                this.Password = password;
                this.Database = database;
                this.Timeout = timeout;
                this.ServerName = serverName;
            }
    }
}
