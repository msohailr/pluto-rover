using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover
{
    public enum Face
    {
        None = 0,
        North = 1,
        East = 2,
        South = 3,
        West = 4
    };

    public class Rover
    {
        #region Data

        private Rover currentState;

        #endregion

        #region C'tor

        public Rover(int x, int y, char heading, PlutoGrid grid)
        {
            X = x;
            Y = y;
            Grid = grid;
            Heading = heading == 'N' ? Face.North : heading == 'E' ? Face.East : heading == 'S' ? Face.South : heading == 'W' ? Face.West : Face.None;


            if (Heading == Face.None)
            {
                throw new ArgumentException($"Invalid face heading symbol: {heading}");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method parses the command and navigates the rover according to
        /// commands and current state
        /// </summary>
        /// <param name="command">The steps to perform in navigation</param>
        public void Navigate(string command)
        {
            foreach (char step in command)
            {
                switch (step)
                {
                    case 'R':
                        // Turn right
                        Heading = (Heading + 1) > Face.West ? Face.North : Heading + 1;
                        break;
                    case 'L':
                        // Turn left
                        Heading = (Heading - 1) < Face.North ? Face.West : Heading - 1;
                        break;
                    case 'F':
                    case 'B':
                        Move(step);
                        break;
                    default:
                        throw new ArgumentException("Invalid command");
                }

                // Break the loop if rover has hit obstacle
                if (!string.IsNullOrEmpty(ObstacleReport))
                {
                    break;
                }

                // Wrap around the grid if navigation has been successful
                WrapGrid();
            }
        }

        /// <summary>
        /// This method returns the current position and heading of the rover as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{X}, {Y}, facing {Heading.ToString()}";
        }

        #endregion

        #region Private Methods

        private bool HittingObstacle(int x, int y)
        {
            if (Grid.IsPointObstacle(x, y))
            {
                ObstacleReport = $"Found obstacle at {{{Grid.ObstacleDetails(x, y)}}}";
                return true;
            }

            return false;
        }

        /// <summary>
        /// Moves the rover according to step and current heading
        /// </summary>
        /// <param name="step">The step, either F or B</param>
        private void Move(char step)
        {
            if ((step == 'F' && Heading == Face.North || step == 'B' && Heading == Face.South))
            {
                if (!HittingObstacle(X, Y + 1))
                {
                    Y++;
                }
            }
            else if ((step == 'F' && Heading == Face.South || step == 'B' && Heading == Face.North))
            {
                if (!HittingObstacle(X, Y - 1))
                {
                    Y--;
                }
            }
            else if ((step == 'F' && Heading == Face.East || step == 'B' && Heading == Face.West))
            {
                if (!HittingObstacle(X + 1, Y))
                {
                    X++;
                }
            }
            else if ((step == 'F' && Heading == Face.West || step == 'B' && Heading == Face.East))
            {
                if (!HittingObstacle(X - 1, Y))
                {
                    X--;
                }
            }
        }

        /// <summary>
        /// If reaching out to the end of grid, wrap around the coordinates 
        /// according to which axis has gone out
        /// </summary>
        private void WrapGrid()
        {
            if (X < 0)
            {
                X = Grid.GridX;
            }
            else if (X > Grid.GridX)
            {
                X = 0;
            }
            if (Y < 0)
            {
                Y = Grid.GridY;
            }
            else if (Y > Grid.GridY)
            {
                Y = 0;
            }
        }
        
        #endregion

        #region Properties

        public int X { get; set; }
        
        public int Y { get; set; }
      
        public PlutoGrid Grid { get; set; }

        public Face Heading { get; set; }

        public string ObstacleReport { get; set; }
        #endregion
    }
}
