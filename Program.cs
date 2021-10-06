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
            FactoryMethod(); 
      

            Console.ReadLine(); 
        }


        static void FactoryMethod()
        {
            ICollection<IBase> Bazy = new List<IBase>();


            BaseCreator mssqlkreator = new BaseMSSQLCreator();
            IBase SoruceBaza = mssqlkreator.CreateBase();
            SoruceBaza.ConnectionString = mssqlkreator.CreateConnectiontring("10.0.0.1", "mssqlbase");
            Console.WriteLine(SoruceBaza.ConnectionString);
            Bazy.Add(SoruceBaza);

            BaseCreator odbckreator = new BaseODBCCreator();
            IBase TargetBaza = odbckreator.CreateBase();
            TargetBaza.ConnectionString = odbckreator.CreateConnectiontring("odbcbase", "testdatabase");
            Console.WriteLine(TargetBaza.ConnectionString);
            Bazy.Add(TargetBaza);

            foreach (IBase baza in Bazy)
            {
                baza.Connect();
                baza.SQLInsert(); 
            }

        }
    }
}
