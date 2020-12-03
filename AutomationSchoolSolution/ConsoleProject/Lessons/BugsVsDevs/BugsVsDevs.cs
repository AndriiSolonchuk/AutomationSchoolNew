using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Lessons.BugsVsDevs
{
    public class Bug
    {

    }

    public class Dev
    {
        public static Random RandomGen = new Random();
        private readonly string _name;
        public bool IsMotivated = false;
        public Dev(string name)
        {
            _name = name;
        }

        public void TryFixBug(List<Bug> bugs)
        {
            if (!bugs.Any())
            {
                return;
            }

            var randomValue = RandomGen.Next(100);//will return value 0..100

            if (randomValue <= 50 || IsMotivated)
            {
                var bug = bugs.First();
                bugs.Remove(bug);
                Console.WriteLine(_name + " fixed a bug");
                IsMotivated = false;
            }
            else
            {
                Console.WriteLine(_name + " created a bug");
                bugs.Add(new Bug());
            }
        }

        public void TakeAnAction(List<Bug> bugs)
        {
            Console.Write(_name + ", Take your action: 1 - try to fix a bug  2 - coffee time");
            var action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    TryFixBug(bugs);
                    break;
                case "2":
                    IsMotivated = true;
                    break;
                default:
                    TakeAnAction(bugs);
                    break;
            }
        }
    }

    public class BugsVsDevs
    {
        public List<Bug> Bugs = new List<Bug>
        {
            new Bug(),
            new Bug(),
            new Bug(),
            new Bug(),
            new Bug(),
            new Bug(),
            new Bug()
        };

        public List<Dev> Devs = new List<Dev>
        {
            new Dev("Roy"),
            new Dev("Tamara"),
            new Dev("Viktoria"),
            new Dev("Itay")
        };


        public void StartGame()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Turn: " + i);

                foreach (var dev in Devs)
                {
                    dev.TakeAnAction(Bugs);
                }
            }

            if (Bugs.Any())
            {
                Console.WriteLine("Bugs win, number of bugs:" + Bugs.Count);
            }
            else
            {
                Console.WriteLine("Dev wins! there are no bugs left!");
            }
        }
    }
}
