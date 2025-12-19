using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexagons
{
    internal class Hex
    {
        private Point centre;
        
        private int size;
        public Hex(Point centre)
        { 
            
            
            this.centre = centre;
        }
        public void DrawHex(Graphics g, int size, Pen pen)
        {
            
            pen = new Pen(Color.Black, 2);

            Point[] hexagonPoints = new Point[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i - Math.PI / 6; // Start at -30 degrees
                int x = centre.X + (int)(size * Math.Cos(angle));
                int y = centre.Y + (int)(size * Math.Sin(angle));
                hexagonPoints[i] = new Point(x, y);
            }

            g.DrawPolygon(pen, hexagonPoints);
        }
    }
}
