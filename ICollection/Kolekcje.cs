using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe_1.ICollection
{

    public interface ITowarModel
    {
        int ID { get; set; }

        string GetFullName();

    }

    

    public class TowarModel : ITowarModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Jednostka { get; set; }

        public string GetFullName()
        {
            return $"{Name} - {ID}"; 
        }
    }
}
