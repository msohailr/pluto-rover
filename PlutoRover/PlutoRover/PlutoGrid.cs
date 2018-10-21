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

        /// <summary>
        /// Adds a unique obstacle
        /// </summary>
        /// <param name="x">The x-axis point</param>
        /// <param name="y">The y-axis point</param>
        public void AddObstacle(int x, int y)
        {
            if (!IsPointObstacle(x, y))
            {
                obstacles.Add(new GridObstacles { x = x, y = y });
            }
        }

        /// <summary>
        /// Check if the current point is an obstacle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsPointObstacle(int x, int y)
        {
            return obstacles.Exists(o => o.x == x && o.y == y);
        }

        /// <summary>
        /// Returns the current obstacle points. 
        /// This can be removed as if IsPointObstacle method returns true, the rover would know
        /// exactly where it has hit the obstacle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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
