﻿// Audre Staffen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;
            const int ARRAY_SIZE = 12;

            /// <summary>
            /// Create a new instance of UserInterface.
            /// </summary>
            UserInterface ui = new UserInterface();

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '.' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1, ARRAY_SIZE);


            /// <summary>
            /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
            /// </summary>
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            // Pause maze solving until user presses key.
            ui.StartNextMaze();

            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose, int sizeOfMaze)
        {
            // create new instance of 2D array. sizeOfMaze is passed in as a parameter
            char[,] mazeTransposed = new char[sizeOfMaze, sizeOfMaze];

            //Write code here to create a transposed maze.
            // Traverses through the array. Has to be a 2D array. Assigns the values
            // to the new array. j is the xCoord (left and right) and i is the yCoord 
            // (up and down). The j and i are switched - i is now the xCoord and j is 
            // now the yCoord. Ex: maze[1,2] is now maze[2,1]. Returns the new maze.
            for (int i = 0; i < mazeToTranspose.GetLength(0); i++)
            {
                for (int j = 0; j < mazeToTranspose.GetLength(1); j++)
                {
                    mazeTransposed[j, i] = mazeToTranspose[i, j];
                }
            }
            return mazeTransposed;
        }
    }
}
