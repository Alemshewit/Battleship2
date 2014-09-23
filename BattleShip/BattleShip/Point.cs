using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Point
    {
        public enum Pointstatus
        {
            Empty,
            Ship,
            Hit,
            Miss
        }

        public int X {get; set;}
        public int Y {get; set;}
        public Pointstatus Status { get; set; }

        //constructor
        public Point(int x, int y, Pointstatus p)
        {
            this.X = x;       
            this.Y = y;
            this.Status = p;
        }



    }
}
