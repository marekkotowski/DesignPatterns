using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod;
using Singelton;
using Builder;
using Prototype;
using AbstractFactory;



namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethodTest();
            //SingeltonTest();
            //BuilderTest();
            //PrototypeTest(); 
            AbstractFactoryTest(); 

            Console.WriteLine("End Program");
            Console.ReadLine(); 
        }


        static void FactoryMethodTest()
        {
            Console.WriteLine("Factory Test:");
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


        static void SingeltonTest()
        {
            Console.WriteLine("Singleton Test:");
            SingeltonModel sInstance1 = SingeltonModel.GetInstance("Instance 1");
            SingeltonModel sInstance2 = SingeltonModel.GetInstance("Instance 2");
            SingeltonModel sInstance3 = SingeltonModel.GetInstance("Instance 3");

            Console.WriteLine(SingeltonModel.SomeFunctionWrite());

            Console.WriteLine(nameof(sInstance3));
        }

        static void BuilderTest()
        {
            Console.WriteLine("Builder Test:");
            //without Director
            var houseBuilder = new HouseBulder();
            houseBuilder.BuildFloor("wood");
            houseBuilder.BuildWalls("stone");
            houseBuilder.BuildDoors(4, "wood");
            houseBuilder.BuildRoof("shingle");
            houseBuilder.BuildWindows(8);

            Console.WriteLine("Construction componets:");
            foreach (object part in houseBuilder.GetHouse().ListParts())
            {
                Console.WriteLine($"\t-{part}");
            }


            //with Director 
            var Director = new DirectorModel();
            Director.SetBuilder = houseBuilder;
            Director.BuildSmallWoodHouse();

            Console.WriteLine("Small wood house construction componets:");
            foreach (object part in houseBuilder.GetHouse().ListParts())
            {
                Console.WriteLine($"\t-{part}");
            }


            Director.BuildBigStoneHouse();
            Console.WriteLine("Big stone house construction componets:");
            foreach (object part in houseBuilder.GetHouse().ListParts())
            {
                Console.WriteLine($"\t-{part}");
            }

            Director.BuildSmallHouse("concrete");
            Console.WriteLine("Small concrete house construction componets:");
            foreach (object part in houseBuilder.GetHouse().ListParts())
            {
                Console.WriteLine($"\t-{part}");
            }
        }

        static void PrototypeTest()
        {
            IList<IWarrriorPrototype> warriors = new List<IWarrriorPrototype>(); 

            IWarrriorPrototype FranceWarrior = new WarriorModel() { Attack = 20, Defence = 20, Speed = 10, Country="France"};
            warriors.Add(FranceWarrior);

            IWarrriorPrototype BritshWarrior = FranceWarrior.CloneWarrior();
            BritshWarrior.Country = "Britain";
            BritshWarrior.Defence = 25;
            warriors.Add(BritshWarrior);

            IWarrriorPrototype GermanWarrior = FranceWarrior.CloneWarrior();
            GermanWarrior.Country = "Germany";
            GermanWarrior.Attack = 30;
            warriors.Add(GermanWarrior);


            foreach (IWarrriorPrototype _warrior in warriors)
            {
                Console.WriteLine($"Warrior: Country={_warrior.Country}, Attack={_warrior.Attack}, Defence={_warrior.Defence}, Speed={_warrior.Speed}");
            }        
        }

        static void AbstractFactoryTest()
        {
            Client WoodKnight = new Client();
            WoodKnight.ClientOrder(new WoodArmorFactory());

            Client IronKnight = new Client(); 
            IronKnight.ClientOrder(new IronArmorFactory()); 


        }
    }
}
