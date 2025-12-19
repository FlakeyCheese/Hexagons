namespace Hexagons
{
    public partial class Form1 : Form
    {
        int size = 25;
        double innerRadius = 25 * Math.Sqrt(3) / 2;

        Point centre = new Point(200, 200);
        List<Hex> hexes = new List<Hex>();
        Dictionary<(int q, int r), Hex> grid = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grid[(0, 0)] = new Hex(centre);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ((q, r), data) in grid)
            {
                data.DrawHex(e.Graphics, centre, size, new Pen(Color.Black, 2));
            }
        }
    }
}
