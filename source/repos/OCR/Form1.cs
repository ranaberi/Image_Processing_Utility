namespace OCR
{
    public partial class Form1 : Form
    {
        public int[] F_Vertical_Proj;
        public int[] F_Horizontal_Proj;
        public int[] Ch_Vertical_Proj;
        public int[] Ch_Horizontal_Proj;
        public Bitmap F_Letter;
        public Bitmap Ch_Letter;

        public Form1()
        {
            InitializeComponent();
            F_Vertical_Proj = new int[pictureBox1.Width];
            F_Horizontal_Proj = new int[pictureBox1.Height];
            Ch_Vertical_Proj = new int[pictureBox2.Width];
            Ch_Horizontal_Proj = new int[pictureBox2.Height];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_Letter = new Bitmap(pictureBox1.Image);
            // Convert to Grayscale and make the vertical projection
            for (int i = 0; i < F_Letter.Width; i++)// Columns -- Width
            {
                F_Vertical_Proj[i] = 0;
                for (int j = 0; j < F_Letter.Height; j++) // Rows -- Height
                {
                    Color tmp = F_Letter.GetPixel(i, j);
                    int Gray_px = (tmp.R + tmp.G + tmp.B) / 3;

                    if (Gray_px < 128) F_Vertical_Proj[i]++;
                }
            }
            // Allignment
            int pivot = 0;
            for (int i = 0; i < F_Vertical_Proj.Length; i++)
                if (F_Vertical_Proj[i] != 0)
                {
                    pivot = i;
                    break;
                }

            for (int i = 0; i < F_Vertical_Proj.Length - pivot; i++)
                F_Vertical_Proj[i] = F_Vertical_Proj[pivot + i];

            for (int i = F_Vertical_Proj.Length - pivot; i < F_Vertical_Proj.Length; i++)
                F_Vertical_Proj[i] = 0;

            //Display
            textBox5.Text = "";
            String S = "";
            for (int i = 0; i < F_Vertical_Proj.Length; i++)
                S += F_Vertical_Proj[i].ToString() + "";
            textBox5.Text = S;

            F_Letter = new Bitmap(pictureBox1.Image);


            // Convert to Grayscale and make the horizontal projection
            for (int j = 0; j < F_Letter.Height; j++) // Rows -- Height
            {
                F_Horizontal_Proj[j] = 0;

                for (int i = 0; i < F_Letter.Width; i++)// Columns -- Width
                {
                    Color tmp = F_Letter.GetPixel(i, j);
                    int Gray_px = (tmp.R + tmp.G + tmp.B) / 3;

                    if (Gray_px < 128) F_Horizontal_Proj[j]++;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap Ch_Letter = new Bitmap(textBox1.Text);
            pictureBox2.Image = Ch_Letter;

            
            // Convert to Grayscale and make the vertical projection
            for (int i = 0; i < Ch_Letter.Width; i++)// Columns -- Width
            {
                Ch_Vertical_Proj[i] = 0;
                for (int j = 0; j < Ch_Letter.Height; j++) // Rows -- Height
                {
                    Color tmp = Ch_Letter.GetPixel(i, j);
                    int Gray_px = (tmp.R + tmp.G + tmp.B) / 3;

                    if (Gray_px < 128) Ch_Vertical_Proj[i]++;
                }
            }
            // Allignment
            int pivot = 0;
            for (int i = 0; i < Ch_Vertical_Proj.Length; i++)
                if (Ch_Vertical_Proj[i] != 0)
                {
                    pivot = i;
                    break;
                }

            for (int i = 0; i < Ch_Vertical_Proj.Length - pivot; i++)
                Ch_Vertical_Proj[i] = Ch_Vertical_Proj[pivot + i];

            for (int i = Ch_Vertical_Proj.Length - pivot; i < Ch_Vertical_Proj.Length; i++)
                Ch_Vertical_Proj[i] = 0;

            //Display
            textBox6.Text = "";
            String S = "";
            for (int i = 0; i < Ch_Vertical_Proj.Length; i++)
                S += Ch_Vertical_Proj[i].ToString() + "";
            textBox6.Text = S;


            int V_diff = 0;
            for( int i = 0; i < F_Vertical_Proj.Length; i++)
                V_diff += Math.Abs(F_Vertical_Proj[i] - Ch_Vertical_Proj[i]);
            textBox7.Text = V_diff.ToString();

            int H_Diff = 0;
            //
            //
            //

            int Ecu_Dist = (int) Math.Sqrt( V_diff* V_diff + H_Diff * H_Diff);
            textBox8.Text = Ecu_Dist.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
