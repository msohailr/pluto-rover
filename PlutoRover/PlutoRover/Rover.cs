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
                throw new Exception($"Invalid face heading symbol: {heading}");
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
                SaveCurrentState();
                
                if ((step == 'F' && Heading == Face.North || step == 'B' && Heading == Face.South))
                {
                    if (HittingObstacle(X, Y + 1))
                    {
                        break;
                    }

                    Y++;
                }
                else if ((step == 'F' && Heading == Face.South || step == 'B' && Heading == Face.North))
                {
                    if (HittingObstacle(X, Y - 1))
                    {
                        break;
                    }

                    Y--;
                }
                else if ((step == 'F' && Heading == Face.East || step == 'B' && Heading == Face.West))
                {
                    if (HittingObstacle(X + 1, Y))
                    {
                        break;
                    }

                    X++;
                }
                else if ((step == 'F' && Heading == Face.West || step == 'B' && Heading == Face.East))
                {
                    if (HittingObstacle(X - 1, Y))
                    {
                        break;
                    }

                    X--;
                }
                else if (step == 'R')
                {
                    // Turn right
                    Heading = (Heading + 1) > Face.West ? Face.North : Heading + 1;
                }
                else if (step == 'L')
                {
                    // Turn left
                    Heading = (Heading - 1) < Face.North ? Face.West : Heading - 1;
                }
                else
                {
                    ResetStateToPrevious();
                    throw new ArgumentOutOfRangeException("Rover has moved out of grid boundaries");
                }
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

        private void SaveCurrentState()
        {
            currentState = new Rover(X, Y, Heading.ToString()[0], Grid);
        }

        private void ResetStateToPrevious()
        {
            X = currentState.X;
            Y = currentState.Y;
            Heading = currentState.Heading;
            Grid = currentState.Grid;
        }

        private bool HittingObstacle(int x, int y)
        {
            if (Grid.IsPointObstacle(x, y))
            {
                ObstacleReport = $"Found obstacle at {{{Grid.ObstacleDetails(x, y)}}}";
                return true;
            }

            return false;
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
