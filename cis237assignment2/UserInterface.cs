using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class UserInterface
    {
        public void PrintMaze(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintMazeSolved()
        {
            Console.WriteLine("Maze Solved!");
            Console.WriteLine();
        }

        public void StartNextMaze()
        {
            Console.WriteLine("Press any key to solve next maze.");
            Console.ReadLine();
        }
    }
}
