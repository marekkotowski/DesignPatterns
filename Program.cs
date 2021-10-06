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
            SoruceBaza.ConnectionString =  mssqlkreator.CreateConnectiontring("10.0.0.1", "mssqlbase");

            Console.WriteLine(SoruceBaza.ConnectionString);
            SoruceBaza.Connect();
            SoruceBaza.SQLInsert();

            BaseCreator odbckreator = new BaseODBCCreator();
            IBase TargetBaza = odbckreator.CreateBase();
            
            TargetBaza.ConnectionString = odbckreator.CreateConnectiontring("odbcbase", "testdatabase");
            Console.WriteLine(TargetBaza.ConnectionString);
            TargetBaza.Connect();
            TargetBaza.SQLInsert(); 
      

            Console.ReadLine(); 
        }
    }
}
