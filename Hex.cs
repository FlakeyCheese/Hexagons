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
        public void DrawHex(Graphics g, int size)
        {            
            Pen pen = new Pen(Color.Black, 2);
            Point[] hexagonPoints = GetHexPoints(size);          
            g.DrawPolygon(pen, hexagonPoints);
        }
        public void FillHex(Graphics g, int size, Brush brush)
        {
            Point[] hexagonPoints = GetHexPoints(size);
            g.FillPolygon(brush, hexagonPoints);
        }
        private Point[] GetHexPoints(int size)
        {
            Point[] hexagonPoints = new Point[6];
            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i - Math.PI / 6; // Start at -30 degrees
                int x = centre.X + (int)(size * Math.Cos(angle));
                int y = centre.Y + (int)(size * Math.Sin(angle));
                hexagonPoints[i] = new Point(x, y);
            }
            return hexagonPoints;
        }
        public bool IsPointInHex(Point p, int size)
        {
            // Convert point to hexagonal coordinates
            double q = (Math.Sqrt(3) / 3 * (p.X - centre.X) - 1.0 / 3 * (p.Y - centre.Y)) / size;
            double r = (2.0 / 3 * (p.Y - centre.Y)) / size;
            // Convert to cube coordinates
            double x = q;
            double z = r;
            double y = -x - z;
            // Round to nearest hex
            int rx = (int)Math.Round(x);
            int ry = (int)Math.Round(y);
            int rz = (int)Math.Round(z);
            double x_diff = Math.Abs(rx - x);
            double y_diff = Math.Abs(ry - y);
            double z_diff = Math.Abs(rz - z);
            if (x_diff > y_diff && x_diff > z_diff)
                rx = -ry - rz;
            else if (y_diff > z_diff)
                ry = -rx - rz;
            else
                rz = -rx - ry;
            // Check if the rounded hex coordinates correspond to the original point
            return (rx == 0 && ry == 0 && rz == 0);
        }
    }
}
