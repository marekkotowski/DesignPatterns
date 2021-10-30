using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace FactoryMethod
{
    abstract class BaseCreator
    {
        public abstract IBase CreateBase();

        public abstract string CreateConnectiontring(string _host, string _database);

    }

    class BaseMSSQLCreator : BaseCreator
    {
        public override IBase CreateBase()
        {
            return new MSSQLBaseModel();
        }

        public override string CreateConnectiontring(string _host, string _database)
        {
            return $"MSSQL ConnectionString {_host} {_database}";
        }
    }

    class BaseODBCCreator : BaseCreator
    {
        public override IBase CreateBase()
        {
            return new ODBCBaseModel(); 
        }

        public override string CreateConnectiontring(string _host, string _database)
        {
            return $"ODBC ConnectionSTring {_host} {_database}";
        }
    }


    interface IBase
    {
        string Host { get; set; }
        string Database { get; set; }
        string ConnectionString { get; set; }
        bool Connect();
        bool SQLInsert(); 
    }

    class MSSQLBaseModel : IBase
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string ConnectionString { get; set; }

        public bool Connect()
        {
            Console.WriteLine("MSSQL connect...");
            return true; 

        }

        public bool SQLInsert()
        {
            Console.WriteLine("MSSQL SQLInsert");
            return true; 
        }
    }

    class ODBCBaseModel : IBase
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string ConnectionString { get; set; }

        public bool Connect()
        {
            Console.WriteLine("ODBC connect...");
            return true;         
        }

        public bool SQLInsert()
        {
            Console.WriteLine("ODBC SQLInsert");
            return true; 
        }
    }



}
