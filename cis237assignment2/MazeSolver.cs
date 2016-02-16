// Audre Staffen

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
            // Boolean that is true when the maze is solved. This is set to false here
            // so that when the next maze to be solved is called, the boolean is reset to
            // false and the recursive call can solve the maze. 
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
        {   //Implement maze traversal recursive call

            // mazeSolved starts out as false and is reset to false when SolveMaze method is called.
            // If this is not here, the recursive calls don't stop until all the periods 
            // are found, resulting in most Xs changing to 0s.
            if (!mazeSolved) 
            {   
                // This is so the solver only traverses to the array elements that are a '.' 
                // and not the walls which are '#'. 
                if (maze[xCoord, yCoord] == '.') 
                {
                    // Changes the '.' to 'X'. 
                    maze[xCoord, yCoord] = 'X';

                    // Base case - checks if the position is along the outside wall, position 0 or 11 for x or y. If this is true
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
                        // Prints maze - X is put at the current position, then calls mazeTraversal to move through the array. To
                        // move left or right, the x coordinate is increased or decreased. To move up or down, the y coordinate is 
                        // increased or decreased. The coordinates start at the passed in value (in this case [1,1]). The first 
                        // mazeTraversal is called, decreasing the yCoord by 1 (moving to the down). The yCoord continues to decrease
                        // (calling the first mazeTraversal method) until the new position is not a period. If the position 
                        // is not a period, it steps back to the prior position and calls the next mazeTraveral after the last call. After 
                        // all 4 mazeTraversal calls, a dead end has been reached and the position must backtrack, turning the Xs into 0s until 
                        // another period is found. The first mazeTraversal call is started again, working down from the top of the mazeTraversals, 
                        // until reaching another dead end. 
                        ui.PrintMaze(maze);
                        // Up
                        mazeTraversal(xCoord, yCoord - 1);
                        // Right
                        mazeTraversal(xCoord + 1, yCoord);
                        // Left
                        mazeTraversal(xCoord - 1, yCoord);
                        // Down
                        mazeTraversal(xCoord, yCoord + 1);

                        // When at this point, all the mazeTraversals have been called, meaning a dead end has been reached and must backtrack. 
                        // When backtracking, the Xs backtracked over are turned into 0s. 
                        maze[xCoord, yCoord] = '0';

                        // If the the exit cannot be found, the x and y coordinates will eventually make it back to [1,1]. If the coordinates 
                        // are [1,1] and mazeSolved is not true, then the maze could not be solved. Prints letting the user know 
                        // that the maze could not be solved. 
                        if (xCoord == 1 && yCoord == 1 && !mazeSolved)
                        {
                            ui.PrintMazeNotSolved();
                        }
                    }
                }


            }
        }
    }
}
