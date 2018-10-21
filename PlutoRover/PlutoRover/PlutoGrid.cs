using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover
{
    public class PlutoGrid
    {
        #region Data

        struct GridObstacles
        {
            public int x;
            public int y;
        };

        private List<GridObstacles> obstacles = new List<GridObstacles>();

        #endregion
        
        #region C'tor

        public PlutoGrid (int gridX, int gridY)
        {
            GridX = gridX;
            GridY = gridY;
        }

        #endregion

        #region Public methods

        public void AddObstacle(int x, int y)
        {
            if (!IsPointObstacle(x, y))
            {
                obstacles.Add(new GridObstacles { x = x, y = y });
            }
        }

        public bool IsPointObstacle(int x, int y)
        {
            return obstacles.Exists(o => o.x == x && o.y == y);
        }

        public string ObstacleDetails(int x, int y)
        {
            if (IsPointObstacle(x, y))
            {
                var obstacle = obstacles.Find(o => o.x == x && o.y == y);
                return $"{obstacle.x}, {obstacle.y}";
            }

            return string.Empty;
        }

        #endregion

        #region Properties

        public int GridX { get; set; }

        public int GridY { get; set; }

        #endregion
    }
}
