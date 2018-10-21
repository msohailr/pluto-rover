using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover
{
    public class Rover
    {
        #region C'tor

        public Rover(int x, int y, char heading)
        {
            X = x;
            Y = y;
            Heading = heading;
        }

        #endregion

        #region Public Methods

        public void Navigate(char command)
        {
            if (command == 'F' && Heading == 'N')
            {
                Y++;
            }
        }

        #endregion

        #region Properties

        public int X { get; set; }
        
        public int Y { get; set; }

        public char Heading { get; set; }

        #endregion
    }
}
