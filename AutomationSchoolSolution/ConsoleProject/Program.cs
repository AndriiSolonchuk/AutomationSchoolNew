using System;
using ConsoleProject.Lessons.BugsVsDevs;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BugsVsDevs game = new BugsVsDevs();
            game.StartGame();
            Console.ReadLine();
        }
    }
}
