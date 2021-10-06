using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabrykaWytworcza;

namespace WzorceProjektowe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseCreator mssqlkreator = new BaseMSSQLCreator();
            IBase SoruceBaza =  mssqlkreator.CreateBase();
            SoruceBaza.ConnectionString =  mssqlkreator.CreateConnectiontring("zapr-test", "zapr-test");

            SoruceBaza.Connect();
            SoruceBaza.SQLInsert();

            BaseCreator odbckreator = new BaseODBCCreator();
            IBase TargetBaza = odbckreator.CreateBase();
            
            TargetBaza.ConnectionString = odbckreator.CreateConnectiontring("zapr-kooperacja", "zapr-kooperacja");
            TargetBaza.Connect();
            TargetBaza.SQLInsert(); 
      

            Console.ReadLine(); 
        }
    }
}
