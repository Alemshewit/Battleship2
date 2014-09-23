using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Grid
    {
        public enum PlaceShipDirection
        {
            Horizontal, 
            Vertical
        }
        //define properties
        public Point[,] Ocean {get; set;}
        public List<Ship> ListOfShips {get; set;}
        public bool AllShipsDestroyed { get { return ListOfShips.All(x => x.IsDestroyed); } }
        public int CombatRound = 0;

    //define constructor
    public Grid()
    {
        Random rng = new Random();

        //itialize the ocean   
        this.Ocean = new Point [10, 10];
        for (int x = 0; x <= 9; x++)
        {
            for (int y = 0; y <= 9; y++)
            {
                this.Ocean[x, y] = new Point(x, y, Point.Pointstatus.Empty);
            }
        }

        PlaceShipDirection direction = (PlaceShipDirection)rng.Next(0, 2);

        this.ListOfShips =  new List<Ship>();

        Ship shipCarrier = new Ship(Ship.ShipType.Carrier);
        ListOfShips.Add(shipCarrier);
        Ship shipBattleship = new Ship(Ship.ShipType.Battleship);
        ListOfShips.Add(shipBattleship);
        Ship shipCruiser = new Ship(Ship.ShipType.Cruiser);
        ListOfShips.Add(shipCruiser);
        Ship shipSubmarine = new Ship(Ship.ShipType.Submarine);
        ListOfShips.Add(shipSubmarine);
        Ship shipMinesweeper = new Ship(Ship.ShipType.Minesweeper);
        ListOfShips.Add(shipMinesweeper);


        for (int i = 0; i < ListOfShips.Count - 1; i++)
        {
            int xPoint = rng.Next(0, 10);
            int yPoint = rng.Next(0, 10);
            PlaceShipDirection placeDir = (PlaceShipDirection)rng.Next(0,2);
            if(Ocean[xPoint, yPoint].Status == Point.Pointstatus.Empty)
            {
                PlaceShip(ListOfShips[rng.Next(0, ListOfShips.Count - 1)], placeDir, xPoint, yPoint);
            }
        }
    }

     public void PlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
     {
         for (int i = 0; i < shipToPlace.Length - 1; i++)
         {	
      
           Point thePoint = Ocean[startX, startY]; 
              // Point.Pointstatus = Ship.ShipType;
             thePoint.Status = Point.Pointstatus.Ship;

             shipToPlace.OccupiedPoints.Add(thePoint);

             if(direction == PlaceShipDirection.Horizontal)
               {
                   startX ++;
               }
               else
               {
                   startY ++;
               }
			}
     }

    public void DisplayOcean()
    {
        Console.WriteLine("0   1  2  3  4  5  6  7  8  9  X");
        Console.WriteLine("=================================");

        for (int i = 0; i <= 9; i++)
			{
			    Console.Write(i + "||");

            for (int j = 0; j <= 9; j++)
                {
                    if(Ocean[j, i].Status == Point.Pointstatus.Empty)
                    {
                        Console.Write("[ ]");
                    }
                    else if (Ocean[j, i].Status == Point.Pointstatus.Ship)
                    {
                        Console.Write("[S]");
                    }
                    else if (Ocean[j, i].Status == Point.Pointstatus.Hit)
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write("[O]");
                    }
                }
            Console.WriteLine();
            }
    }
        

    public void Target(int x, int y)
    {
        Point aPoint = Ocean[x, y];

        if(aPoint.Status == Point.Pointstatus.Ship)
        {
            aPoint.Status = Point.Pointstatus.Hit;
            Console.WriteLine("Boom! you just hit");
        }
        else if(aPoint.Status == Point.Pointstatus.Empty)
        {
            aPoint.Status = Point.Pointstatus.Miss;
            Console.WriteLine("You missed! Try again.");
        }
    }

     public void PlayGame()
     {

         while(!AllShipsDestroyed )
         {
            
             Console.WriteLine("Enter your x cordinate");
             string userX = Console.ReadLine();
             Console.WriteLine("Enter your y cordinate");
             string userY = Console.ReadLine();
             while(!"0123456789".Contains(userX) && !"0123456789".Contains(userY))
             {
                 Console.WriteLine("Enter a proper digit for the X coordinate");
                 userX = Console.ReadLine();
                 Console.WriteLine("Enter a proper digit for the Y coordinate");
                 userY = Console.ReadLine();
             }

             Target(int.Parse(userX), int.Parse(userY));
             CombatRound ++;
         }
         Console.WriteLine("You WIN!");
     }

    }
}

