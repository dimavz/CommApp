using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace CommApp
{
    public class QueryContext
    {
        //Свойства
        public DataTable Table { get; }
        public ConnectionData ConnectData { get;}

        public QueryContext(DataTable dt, ConnectionData conData)
        {
            this.Table = dt;
            this.ConnectData = conData;
        }
    }
}
