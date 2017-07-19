using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CommApp
{
    public class ReaderContext
    {
        //Свойства
        public NpgsqlDataReader Reader { get; set; }
        public ConnectionData ConnectData { get;}

        public ReaderContext(NpgsqlDataReader reader, ConnectionData connData)
        {
            this.Reader = reader;
            this.ConnectData = connData;
        }
    }
}
