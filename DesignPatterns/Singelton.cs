using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singelton
{
    class SingeltonModel
    {
        public static string Name { get; set; }
        private static SingeltonModel _instance; 
        

        private SingeltonModel()
        { 
        }

        /// <summary>
        /// Jeśli nie ma instancji to ją tworzy jeśli jest to ją zwraca
        /// </summary>
        /// <returns></returns>
        public static SingeltonModel GetInstance(string _test)
        {
            if (_instance == null)
            {
                _instance = new SingeltonModel();
                Name = _test;


            }
            return _instance;
        }

        public static string SomeFunctionWrite()
        {
            return Name;
        }


    }
}
