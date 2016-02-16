// Audre Staffen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class UserInterface
    {
        // Traverses through each element in the array and prints to the screen. The array has
        // to be a 2D array and can be of any size. j corresponds to the xCoords (right and left)
        // in the array and i corresponds to the yCoords (up and down).
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

        // Prints to the screen that the maze is solved.
        public void PrintMazeSolved()
        {
            Console.WriteLine("Maze Solved!");
            Console.WriteLine();
        }

        // Prints to the screen a message to the user to press a key to solve the next maze and waits for user input.
        public void StartNextMaze()
        {
            Console.WriteLine("Press any key to solve next maze.");
            Console.ReadLine();
        }

        public void PrintMazeNotSolved()
        {
            Console.WriteLine("Maze cannot be solved!");
            Console.WriteLine();
        }
    }
}
