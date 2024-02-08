namespace ConvertToASCII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image= new Bitmap(ofd.FileName);
                gray();
            }
        }

        public void gray()
        {
            var temp = (Bitmap)pictureBox1.Image;
            Bitmap bit = (Bitmap)temp.Clone();
            Color c;
            for(int i=0; i < bit.Width; i++)
            {
                for(int j =0; j < bit.Height; j++)
                {
                    c = (bit.GetPixel(i, j)); 
                    byte gray =(byte)((c.R + c.B + c.G) / 3);
                    bit.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox2.Image = (Bitmap)bit.Clone();
        }
    }
}
