using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{


    public interface IArmorFactory
    {
        IHelmet CreateHelmet();
        IShield CreateShield();
        IBreastPlate CreateBreastPlate();         
    }

    public interface IHelmet
    {
        void BuildHelmet();
    }

    public interface IShield
    {
        void BuildShield(); 
    }

    public interface IBreastPlate
    {
        void BuildBreastPlate();
    }

    public class IronHemlet : IHelmet
    {
        public void BuildHelmet()
        {
            Console.WriteLine("Building Iron Helmet"); 
        }
    }

    public class IronShield : IShield
    {
        public void BuildShield()
        {
            Console.WriteLine("Building Iron Shield");
        }
    }

    public class WoodHelmet : IHelmet
    {
        public void BuildHelmet()
        {
            Console.WriteLine("Building Wood Helmet");
        }
    }

    public class WoodShield : IShield
    {
        public void BuildShield()
        {
            Console.WriteLine("Building Wood Shield");
        }
    }


    public class IronBreastPlate : IBreastPlate
    {
        public void BuildBreastPlate()
        {
            Console.WriteLine("Building Iron BreastPlate"); 
        }
    }

    public class WoodBreastPlate : IBreastPlate
    {
        public void BuildBreastPlate()
        {
            Console.WriteLine("Building Wood BreastPlate");
        }
    }


    public class IronArmorFactory : IArmorFactory
    {
        public IBreastPlate CreateBreastPlate()
        {
            return new IronBreastPlate();
        }

        public IHelmet CreateHelmet()
        {
            return new IronHemlet();    
        }

        public IShield CreateShield()
        {
            return new IronShield();    
        }
    }

    public class WoodArmorFactory : IArmorFactory
    {
        public IBreastPlate CreateBreastPlate()
        {
            return new WoodBreastPlate(); 
        }

        public IHelmet CreateHelmet()
        {
            return new WoodHelmet();    
        }

        public IShield CreateShield()
        {
            return new WoodShield(); 
        }
    }

    class Client
    {
        public void ClientOrder(IArmorFactory factory)
        { 
            var Helmet = factory.CreateHelmet();    
            var Shield =  factory.CreateShield();
            var BrestPlate = factory.CreateBreastPlate();
            Helmet.BuildHelmet(); 
            Shield.BuildShield();
            BrestPlate.BuildBreastPlate(); 

        
        }
    
    
    }






}
