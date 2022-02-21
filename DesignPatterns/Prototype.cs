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
        string GetNumber();

        IWarrriorPrototype ShallowCopy();
   
        IWarrriorPrototype CloneWarrior();
    }

    public class WarriorModel : IWarrriorPrototype
    {
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Defence { get; set; }
        public string Country { get; set; }
        protected int Number { get; set; }



        public WarriorModel()
        {
            Random los = new Random();
            this.Number = los.Next(0,200);
        }

        public IWarrriorPrototype ShallowCopy()
        {
            return (WarriorModel)this.MemberwiseClone(); 
        }

        public WarriorModel(IWarrriorPrototype _warrior)
        {
            this.Attack = _warrior.Attack;
            this.Speed = _warrior.Speed;
            this.Defence = _warrior.Defence;
            this.Country = _warrior.Country;
            Random los = new Random();
            this.Number = los.Next(0, 200);
     
        }

        public IWarrriorPrototype CloneWarrior()
        {
            WarriorModel warrior = new WarriorModel(this);
            Random los = new Random();
            warrior.Number = los.Next(200,400) ;
            return warrior; 
        }

        public string GetNumber()
        {
            return this.Number.ToString(); 
        }

    }
     

}
