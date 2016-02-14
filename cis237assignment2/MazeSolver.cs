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
        UserInterface ui;


        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {
            ui = new UserInterface();
        }


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
            this.mazeSolved = false; // boolean that is true when the maze is solved.
            

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int xCoord, int yCoord)
        {   //Implement maze traversal recursive call

            // starts out as false and is reset to false when SolveMaze method is called
            // if this is not here, the recursive calls don't stop until all the periods 
            // are found, resulting in most Xs changing to 0s.
            if (!mazeSolved) 
            {   
                // this is so the solver only traverses to the array elements that are a '.' 
                if (maze[xCoord, yCoord] == '.') 
                {
                    // changes the '.' to 'X'
                    maze[xCoord, yCoord] = 'X';

                    // base case - checks if the position is along the outside wall, position 0 or 11 for x or y. if this is true
                    // then the maze has been solved and mazeSolved is set to true so that the recursive loop will not continue
                    // if there are still periods in the array. Prints out the last move of the solver, which is the solved maze,
                    // then prints out that the maze is solved.
                    if (xCoord == maze.GetLength(0) - 1 || yCoord == maze.GetLength(1) - 1 || yCoord == 0 || xCoord == 0)
                    {
                        mazeSolved = true;                    
                        ui.PrintMaze(maze);
                        ui.PrintMazeSolved();
                    }
                    else
                    {
                        // prints maze - X is put at the current position, then calls mazeTraversal to move through the array. to
                        // move left or right, the x coordinate is increased or decreased. to move up or down, the y coordinate is 
                        // increased or decreased. after it moves (starts with the first mazeTraversal call), then it starts back 
                        // at the top of the method, this time with the new y coordinate and the old x coordinate. it continues calling
                        // this first mazeTraversal until the new position is not a period. if the position it moved
                        // to is not a period, it steps back to the prior position and calls the next mazeTraveral after the last call. after it goes through 
                        // all 4 mazeTraversal calls, it has hit a dead end and must backtrack, turning the Xs into 0s until it can find
                        // another period, which it then starts calling the mazeTraversals again, starting from the top. 
                        ui.PrintMaze(maze);
                        mazeTraversal(xCoord, yCoord - 1);
                        mazeTraversal(xCoord + 1, yCoord);
                        mazeTraversal(xCoord - 1, yCoord);
                        mazeTraversal(xCoord, yCoord + 1);

                        // when it gets to this, all the mazeTraversals have been called, meaning it has hit a dead end and must backtrack
                        // when it backtracks, the Xs it backtracks over are turned into 0s. 
                        maze[xCoord, yCoord] = '0';

                    }
                }


            }
        }

        //private void PrintMaze(char[,] maze)
        //{
        //    for (int i = 0; i < maze.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < maze.GetLength(1); j++)
        //        {
        //            Console.Write(maze[i, j] + " ");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine();

        //}
    }
}
