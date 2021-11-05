using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public interface IWarrriorPrototype
    {
        int Attack { get; set; }
        int Speed { get; set; }
        int Defence { get; set; }
        string Country { get; set; }

        IWarrriorPrototype CloneWarrior();
    }

    public class WarriorModel : IWarrriorPrototype
    {
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Defence { get; set; }
        public string Country { get; set; }


        public WarriorModel()
        { 
        
        }

        public WarriorModel(IWarrriorPrototype _warrior)
        {
            this.Attack = _warrior.Attack;
            this.Speed = _warrior.Speed;
            this.Defence = _warrior.Defence;
            this.Country = _warrior.Country;
        }

        public IWarrriorPrototype CloneWarrior()
        {
            WarriorModel warrior = new WarriorModel(this);
            return warrior; 
        }
    }
     

}
