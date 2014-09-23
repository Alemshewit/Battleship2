using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Ship
    {
        public enum ShipType
        {
            Carrier, Battleship, Cruiser, Submarine, Minesweeper
        }

        public ShipType Type { get; set; }
        public List<Point> OccupiedPoints { get; set; }
        public int Length { get; set; }
        public bool IsDestroyed { get { return OccupiedPoints.All(x => x.Status == Point.Pointstatus.Hit); } }

        //constructor
       public Ship (ShipType typeOfShip)
       {
           this.OccupiedPoints = new List<Point>();
           this.Type = typeOfShip;
           switch (Type)
           {
               case ShipType.Carrier:
                   this.Length = 5;
                   break;
               case ShipType.Battleship:
                   this.Length = 4;
                   break;
               case ShipType.Cruiser:
                   this.Length = 3;
                   break;
               case ShipType.Submarine:
                   this.Length = 3;
                   break;
               case ShipType.Minesweeper:
                   this.Length = 2;
                   break;
               default:
                   break;
           }
           int[] shipLen = new int[] { 5, 4, 3, 3, 2 };
           OccupiedPoints = new List<Point>();
           this.Type = typeOfShip;
           this.Length = shipLen[(int)typeOfShip];
       }
    }
}
