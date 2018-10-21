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

        public void Navigate(string command)
        {
            foreach (char step in command)
            {
                if (step == 'F' && Heading == 'N')
                {
                    Y++;
                }
                else if (step == 'F' && Heading == 'E')
                {
                    X++;
                }
                else if (step == 'B' && Heading == 'N')
                {
                    Y--;
                }
                else if (step == 'B' && Heading == 'W')
                {
                    X--;
                }
                else if (step == 'R')
                {
                    switch(Heading)
                    {
                        case 'N':
                            Heading = 'E';
                            break;
                        case 'E':
                            Heading = 'S';
                            break;
                        case 'S':
                            Heading = 'W';
                            break;
                        case 'W':
                            Heading = 'N';
                            break;
                    }
                }
                else if (step == 'L')
                {
                    switch (Heading)
                    {
                        case 'N':
                            Heading = 'W';
                            break;
                        case 'W':
                            Heading = 'S';
                            break;
                        case 'S':
                            Heading = 'E';
                            break;
                        case 'E':
                            Heading = 'N';
                            break;
                    }
                }
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
