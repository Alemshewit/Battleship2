using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid myGrid = new Grid();

            myGrid.DisplayOcean();
            myGrid.PlayGame();

        
            Console.ReadKey();
        }

        static void HighScores(int playerScore)
        {
            Console.WriteLine("Your name:");
            string playerName = Console.ReadLine();

            AlemEntities db = new AlemEntities();

            HighestScore newHighestScore = new HighestScore();
            newHighestScore.DateCreated = DateTime.Now;
            newHighestScore.Game = "Guess That Number";
            newHighestScore.Name = playerName;
            newHighestScore.Score = playerScore;

            db.HighestScores.Add(newHighestScore);

            db.SaveChanges();
        }

        static void DisplayHighestScore()
        {
            Console.Clear();
            Console.WriteLine("Guess That Number High Scores");
            Console.WriteLine("*****************************");

            AlemEntities db = new AlemEntities();
            List<HighestScore> highestScoreList = db.HighestScores
                .Where(x => x.Game == "Guess That Number")
                .OrderBy(x => x.Score).Take(10)
                .ToList();

            foreach (HighestScore highScore in highestScoreList)
            {
                Console.WriteLine("{0}. {1} - {2} on {3}",
                    highestScoreList.IndexOf(highScore) + 1,
                    highScore.Name,
                    highScore.Score,
                    highScore.DateCreated.Value.ToShortDateString());
            }
            Console.WriteLine("\n\n\n");


        }
    }
}
