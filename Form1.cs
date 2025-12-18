namespace Hexagons
{
    public partial class Form1 : Form
    {
        int size = 25;
        double innerRadius = 25 * Math.Sqrt(3) / 2;

        Point centre = new Point(200, 200);
        List<Hex> hexes = new List<Hex>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Hex tempHex = new Hex(centre);
            hexes.Add(tempHex);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Hex h in hexes)
                {
                h.DrawHex(e.Graphics, centre, size, new Pen(Color.Black, 2));
            }
        }
    }
}
