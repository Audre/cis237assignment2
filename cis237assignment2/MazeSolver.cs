using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool mazeSolved;


        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class.
            //It is possible that you will not need these class level ones and can get all of the work done
            //with the local ones. Regardless of how you implement it, here are the class level assignments.
            //Feel free to remove the class level variables and assignments if you determine that you don't need them.
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            this.mazeSolved = false;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int xCoord, int yCoord)
        {
            //bool mazeSolved = false;


            //Implement maze traversal recursive call

            if (!mazeSolved)
            {
                if (maze[xCoord, yCoord] == '.')
                {
                    maze[xCoord, yCoord] = 'X';
                    if (xCoord == maze.GetLength(0) - 1 || yCoord == maze.GetLength(1) - 1 || yCoord == 0 || xCoord == 0)
                    {
                        mazeSolved = true;   
                        PrintMaze(maze);                     
                    }
                    else
                    {
                        PrintMaze(maze);
                        mazeTraversal(xCoord, yCoord - 1);
                        mazeTraversal(xCoord + 1, yCoord);
                        mazeTraversal(xCoord - 1, yCoord);
                        mazeTraversal(xCoord, yCoord + 1);

                        maze[xCoord, yCoord] = '0';

                    }
                }


            }
        }

        private void PrintMaze(char[,] maze)
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
    }
}
