using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.util
{
    class NavigationGrid
    {
        private World World;

        public NavigationGrid(World world)
        {
            this.World = world;
        }

        public void Create(Graphics g)
        {
            float numOfCells = 50;
            float cellSize = World.Width / numOfCells;
            Pen p = new Pen(Color.LightGray, 2);
            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }
    }
}
