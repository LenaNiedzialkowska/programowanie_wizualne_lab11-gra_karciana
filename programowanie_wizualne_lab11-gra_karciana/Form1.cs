using static System.Formats.Asn1.AsnWriter;

namespace programowanie_wizualne_lab11_gra_karciana
{
    public partial class Form1 : Form
    {
        Button start;
        RadioButton wojna1;
        RadioButton wojna2;
        RadioButton oczko;

        TableLayoutPanel panel2;
        Button check;
        Label score;
        int sumOfPoints = 0;
        int sumOfOpponentPoints = 0;

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
            if (oczko.Checked == true)
            {
                foreach (var radioBtn in Controls.OfType<RadioButton>())
                    radioBtn.Hide();
                foreach (var btn in Controls.OfType<Button>())
                    btn.Hide();

                TableLayoutPanel panel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    ColumnCount = 1,
                    RowCount = 3
                };
                this.Controls.Add(panel);

                RowStyle row1 = new RowStyle
                {
                    SizeType = SizeType.Absolute,
                    Height = 50
                };
                panel.RowStyles.Add(row1);

                RowStyle row2 = new RowStyle
                {
                    SizeType = SizeType.Absolute,
                    Height = 200
                };
                panel.RowStyles.Add(row2);

                RowStyle row3 = new RowStyle
                {
                    SizeType = SizeType.AutoSize
                };
                panel.RowStyles.Add(row3);

                TableLayoutPanel panel1 = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    ColumnCount = 2,
                    RowCount = 1
                };
                panel.Controls.Add(panel1);

                score = new Label
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Top,
                    Text = "0",
                    Font = new Font("Segoe UI", 20),
                    Height = 50,
                    Width = 600
                };
                panel1.Controls.Add(score);

                check = new Button
                {
                    BackColor = Color.LightGray,
                    Dock = DockStyle.Top,
                    Text = "SPRAWDè",
                    Font = new Font("Segoe UI", 15),
                    Height = 40,
                    Width = 30
                };
                check.Click += new EventHandler(CheckButtonHandler);
                panel1.Controls.Add(check);

                Button draw = new Button
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Right,
                    Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\karta.png"),
                    Height = 200,
                    Width = 120
                };
                draw.Click += new EventHandler(DrawButtonHandler);
                panel.Controls.Add(draw, 0, 1);

                panel2 = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.Beige,
                    ColumnCount = 5,
                    RowCount = 2
                };
                panel.Controls.Add(panel2);
            }
        }
        private void DrawButtonHandler(object sender, EventArgs e)
        {
            string cardName = "";
            Random rand = new Random();

            int generatedCardForOpponent = rand.Next(2, 15);
            if (generatedCardForOpponent < 11)
            {
                sumOfOpponentPoints += generatedCardForOpponent;
            }
            else
            {
                switch (generatedCardForOpponent)
                {
                    case 11: //walet
                        sumOfOpponentPoints += 2;
                        break;
                    case 12: //dama
                        sumOfOpponentPoints += 3;
                        break;
                    case 13: //krÛl
                        sumOfOpponentPoints += 4;
                        break;
                    case 14: //as
                        sumOfOpponentPoints += 11;
                        break;
                }
            }

            int generatedCard = rand.Next(2, 15);
            if (generatedCard < 11)
            {
                sumOfPoints += generatedCard;
            }
            else
            {
                switch (generatedCard)
                {
                    case 11:
                        sumOfPoints += 2;
                        cardName = "walet";
                        break;
                    case 12:
                        sumOfPoints += 3;
                        cardName = "dama";
                        break;
                    case 13:
                        sumOfPoints += 4;
                        cardName = "krÛl";
                        break;
                    case 14:
                        sumOfPoints += 11;
                        cardName = "as";
                        break;
                }
            }

            if (IsScoreOk() == false)
            {
                MessageBox.Show("Przeciwnik skoÒczy≥ juø runde", "Zamknij okno");
                CheckButtonHandler(sender, e);
            }
            else
            {
                Label label = new Label
                {
                    Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\karta.png"),
                    Font = new Font("Segoe UI", 20),
                    Dock = DockStyle.Left,
                    Height = 170,
                    Width = 160
                };
                if (cardName == "")
                {
                    label.Text = generatedCard.ToString();
                }
                else
                {
                    label.Text = cardName;
                }
                panel2.Controls.Add(label);
                score.Text = sumOfPoints.ToString();
            }
        }
        private void CheckButtonHandler(object sender, EventArgs e)
        {
            string message;
            if ((sumOfPoints > 21 || sumOfPoints < sumOfOpponentPoints) && sumOfOpponentPoints <= 21)
            {
                message = "Przegra≥eú\nCzy chcesz zagraÊ jeszcze raz?";
            }
            else if (sumOfPoints == sumOfOpponentPoints)
            {
                message = "Remis\nCzy chcesz zagraÊ jeszcze raz?";
            }
            else
            {
                message = "Wygra≥eú\nCzy chcesz zagraÊ jeszcze raz?";
            }
            string title = "Zamknij okno";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                sumOfPoints = 0;
                sumOfOpponentPoints = 0;
                score.Text = sumOfPoints.ToString();
                panel2.Controls.Clear();
            }
            else
            {
                this.Close();
            }
        }
        private bool IsScoreOk()
        {
            if (sumOfPoints >= 21 || sumOfOpponentPoints >= 21)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}