using static System.Formats.Asn1.AsnWriter;

namespace programowanie_wizualne_lab11_gra_karciana
{
    public partial class Form1 : Form
    {
        Button start;
        RadioButton wojna1;
        RadioButton wojna2;
        RadioButton oczko;
        public Form1()
        {
            InitializeComponent();
            wojna1 = new RadioButton
            {
                Text = "WOJNA I",
                Font = new Font("Segoe UI", 20),
                Height = 50,
                Width = 200,
                Location = new Point(10, 50)
            };
            this.Controls.Add(wojna1);

            wojna2 = new RadioButton
            {
                Text = "WOJNA II",
                Font = new Font("Segoe UI", 20),
                Height = 50,
                Width = 200,
                Location = new Point(10, 150)
            };
            this.Controls.Add(wojna2);

            oczko = new RadioButton
            {
                Text = "OCZKO",
                Font = new Font("Segoe UI", 20),
                Height = 50,
                Width = 200,
                Location = new Point(10, 250)
            };
            this.Controls.Add(oczko);

            start = new Button
            {
                Text = "START",
                Font = new Font("Segoe UI", 20),
                Height = 50,
                Width = 200,
                Location = new Point(10, 350)
            };
            start.Click += new EventHandler(StartButtonHandler);
            this.Controls.Add(start);
        }
        private void StartButtonHandler(object sender, EventArgs e)
        {

        }
    }
}