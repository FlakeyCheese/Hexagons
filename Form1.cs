namespace Hexagons
{
    public partial class Form1 : Form
    {
        int size = 25;
        double innerRadius = 25 * Math.Sqrt(3) / 2;

        Point centre = new Point(500, 500);
        //Value tuple as key, Hex object as value
        Dictionary<(int q, int r), Hex> grid = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const double SQRT3 = 1.7320508075688772;  // sqrt(3)
            double hexWidth = SQRT3 * size;
            double hexHeight = 2.0 * size;
            //Create the central hexagon at (0,0)
            grid[(0, 0)] = new Hex(centre);
            //Create the surrounding hexagons
            for (int q = -4; q <= 4; q++)
            {
                for (int r = -4; r <= 4; r++)
                {
                    if (Math.Abs(q + r) <= 4 && !(q == 0 && r == 0))
                    {
                        // Pointy-top conversion
                        double x = centre.X + hexWidth * (q + r * 0.5);
                        double y = centre.Y + hexHeight * 0.75 * r;

                        grid[(q, r)] = new Hex(new Point((int)x, (int)y));
                    }
                }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ((q, r), data) in grid)
            {
                data.DrawHex(e.Graphics,  size, new Pen(Color.Black, 2));
            }
        }
    }
}
