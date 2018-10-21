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

        #endregion

        #region C'tor

        public Rover(int x, int y, char heading)
        {
            X = x;
            Y = y;
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
                if (step == 'F' && Heading == Face.North)
                {
                    Y++;
                }
                else if (step == 'F' && Heading == Face.East)
                {
                    X++;
                }
                else if (step == 'B' && Heading == Face.South)
                {
                    Y--;
                }
                else if (step == 'B' && Heading == Face.West)
                {
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
            }
        }

        #endregion

        #region Properties

        public int X { get; set; }
        
        public int Y { get; set; }

        public Face Heading { get; set; }

        #endregion
    }
}
