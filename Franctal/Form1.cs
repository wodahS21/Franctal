namespace Franctal
{
    using System.Drawing;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            // Establecer la profundidad del fractal
            int depth = 5;

            // Calcular los puntos del triángulo inicial
            Point[] points = new Point[] {
        new Point(50, 450),
        new Point(250, 50),
        new Point(450, 450)
    };

            // Dibujar el triángulo inicial
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawPolygon(Pens.Black, points);
                // Llamar a la función recursiva para dibujar el fractal
                DrawSierpinskiTriangle(g, depth, points);
            }
            pictureBox1.Image = bmp;
        }

        private void DrawSierpinskiTriangle(Graphics g, int depth, Point[] points)
        {
            if (depth == 0)
            {
                return;
            }

            // Calcular los puntos de los triángulos más pequeños
            Point[] p1 = new Point[] {
        points[0],
        new Point((points[0].X + points[1].X) / 2, (points[0].Y + points[1].Y) / 2),
        new Point((points[0].X + points[2].X) / 2, (points[0].Y + points[2].Y) / 2)
    };

            Point[] p2 = new Point[] {
        points[1],
        new Point((points[1].X + points[0].X) / 2, (points[1].Y + points[0].Y) / 2),
        new Point((points[1].X + points[2].X) / 2, (points[1].Y + points[2].Y) / 2)
    };

            Point[] p3 = new Point[] {
        points[2],
        new Point((points[2].X + points[0].X) / 2, (points[2].Y + points[0].Y) / 2),
        new Point((points[2].X + points[1].X) / 2, (points[2].Y + points[1].Y) / 2)
    };

            // Dibujar los triángulos más pequeños
            g.DrawPolygon(Pens.Black, p1);
            g.DrawPolygon(Pens.Black, p2);
            g.DrawPolygon(Pens.Black, p3);

            // Llamar a la función recursiva para los triángulos más pequeños
            DrawSierpinskiTriangle(g, depth - 1, p1);
            DrawSierpinskiTriangle(g, depth - 1, p2);
            DrawSierpinskiTriangle(g, depth - 1, p3);
        }
    }
}