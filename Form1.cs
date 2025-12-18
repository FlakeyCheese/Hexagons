namespace Hexagons
{
    public partial class Form1 : Form
    {
        int size = 25;
        Point centre = new Point(200, 200);

        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
  Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

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
