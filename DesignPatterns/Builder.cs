using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IHouseBuilder
    {
        void BuildWalls(string _material);
        void BuildFloor(string _material);
        void BuildRoof(string _material);
        void BuildWindows(int _nubmerOfWindows);
        void BuildDoors(int _numberOfDoors, string _material); 
    }


    public class HouseBulder : IHouseBuilder
    {
        private HouseModel House = new HouseModel();

        public HouseBulder()
        {
            this.Reset(); 
        }

        public void Reset()
        {
            this.House = new HouseModel(); 
        }
        public void BuildDoors(int _numberOfDoors, string _material)
        {
            this.House.Add($"{_numberOfDoors} {_material} doors");
        }

        public void BuildFloor(string _material)
        {
            this.House.Add($"{_material} floor");
        }

        public void BuildRoof(string _material)
        {
            this.House.Add($"{_material} roof");
        }

        public void BuildWalls(string _material)
        {
            this.House.Add($"{_material} walls");
        }

        public void BuildWindows(int _nubmerOfWindows)
        {
            this.House.Add($"{_nubmerOfWindows} windows");
        }

        public HouseModel GetHouse()
        {
            HouseModel BuiltHouse = this.House;
            this.Reset();
            return BuiltHouse; 
        }


        public List<object> HouseParts()
        {

            return this.House.ListParts(); 
        }
    }


    public class DirectorModel
    {
        private IHouseBuilder houseBuilder; 

        public IHouseBuilder SetBuilder
        {
            set { houseBuilder = value; }
        }

        public void BuildSmallWoodHouse()
        {
            this.houseBuilder.BuildDoors(1, "wood");
            this.houseBuilder.BuildFloor("wood");
            this.houseBuilder.BuildRoof("wood");
            this.houseBuilder.BuildWalls("wood");
            this.houseBuilder.BuildWindows(2);
        }

        public void BuildBigStoneHouse()
        {
            this.houseBuilder.BuildDoors(10, "wood");
            this.houseBuilder.BuildFloor("stone");
            this.houseBuilder.BuildRoof("thile");
            this.houseBuilder.BuildWalls("stone");
            this.houseBuilder.BuildWindows(20);
        }

        public void BuildBigHouse(string _material)
        {
            this.houseBuilder.BuildDoors(10, "wood");
            this.houseBuilder.BuildFloor(_material);
            this.houseBuilder.BuildRoof("thile");
            this.houseBuilder.BuildWalls(_material);
            this.houseBuilder.BuildWindows(20);
        }

        public void BuildSmallHouse(string _material)
        {
            this.houseBuilder.BuildDoors(2, "wood");
            this.houseBuilder.BuildFloor(_material);
            this.houseBuilder.BuildRoof("thile");
            this.houseBuilder.BuildWalls(_material);
            this.houseBuilder.BuildWindows(4);
        }


    }


    public class HouseModel
    { 
        private List<object> Parts =  new List<object>();

        public void Add(string _part)
        {
            this.Parts.Add(_part);
        }

        public List<object> ListParts()
        {
            return this.Parts; 
        }

    }



}
