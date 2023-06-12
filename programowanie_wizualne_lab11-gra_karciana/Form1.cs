using static System.Formats.Asn1.AsnWriter;

namespace programowanie_wizualne_lab11_gra_karciana
{
    public partial class Form1 : Form
    {
        Button start;
        RadioButton wojna1;
        RadioButton wojna2;
        RadioButton oczko;
        Panel gamePanel;
        Label gracz;
        Label bot;
        Label kartaGracza;
        Label kartaBota;
        Label wynikGracza;
        int wynikG = 0;
        Label wynikBota;
        int wynikB = 0;
        Button rozdanie;
        List<int> talia = new List<int>();
        public Form1()
        {
            InitializeComponent();
            wojna1 = new RadioButton
            {
                Text = "WOJNA I",
                Font = new Font("Segoe UI", 15),
                Height = 50,
                Width = 250,
                Location = new Point(10, 50)
            };
            this.Controls.Add(wojna1);

            wojna2 = new RadioButton
            {
                Text = "WOJNA II",
                Font = new Font("Segoe UI", 15),
                Height = 50,
                Width = 250,
                Location = new Point(10, 150)
            };
            this.Controls.Add(wojna2);

            oczko = new RadioButton
            {
                Text = "OCZKO",
                Font = new Font("Segoe UI", 15),
                Height = 50,
                Width = 200,
                Location = new Point(10, 250)
            };
            this.Controls.Add(oczko);

            start = new Button
            {
                Text = "START",
                Font = new Font("Segoe UI", 15),
                Height = 80,
                Width = 200,
                Location = new Point(10, 350)
            };
            start.Click += new EventHandler(StartButtonHandler);
            this.Controls.Add(start);
        }
        private void StartButtonHandler(object sender, EventArgs e)
        {
            if (wojna2.Checked == true)
            {
                setupGamePanel();
            }
        }
        
        private void setupGamePanel()
        {
            gamePanel = new Panel();
            gamePanel.Location = new Point(300, 15);
            gamePanel.Size = new Size(850, 900);
            gamePanel.BackColor = Color.White;
            this.Size = new Size(gamePanel.Width + 350, gamePanel.Height + 150);
            this.Controls.Add(gamePanel);

            gracz = new Label();
            gracz.Location = new Point(15, 15);
            gracz.Size = new Size(100, 30);
            gracz.Text = "Gracz";
            gracz.Font = new Font("Segoe UI", 10);
            gamePanel.Controls.Add(gracz);

            kartaGracza = new Label();
            kartaGracza.Location = new Point(15, 60);
            kartaGracza.Size = new Size(228, 380);
            kartaGracza.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\karta.png");
            gamePanel.Controls.Add(kartaGracza);

            wynikGracza = new Label();
            wynikGracza.Location = new Point(400, 180);
            wynikGracza.Size = new Size(200, 150);
            wynikGracza.Text = "Wynik Gracza: \n" + wynikG.ToString();
            wynikGracza.Font = new Font("Segoe UI", 10);
            gamePanel.Controls.Add(wynikGracza);

            bot = new Label();
            bot.Location = new Point(15, 465);
            bot.Size = new Size(100, 30);
            bot.Text = "Bot";
            bot.Font = new Font("Segoe UI", 10);
            gamePanel.Controls.Add(bot);

            wynikBota = new Label();
            wynikBota.Location = new Point(400, 620);
            wynikBota.Size = new Size(200, 150);
            wynikBota.Text = "Wynik Bota: \n" + wynikB.ToString();
            wynikBota.Font = new Font("Segoe UI", 10);
            gamePanel.Controls.Add(wynikBota);

            kartaBota = new Label();
            kartaBota.Location = new Point(15, 510);
            kartaBota.Size = new Size(228, 380);
            kartaBota.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\karta.png");
            gamePanel.Controls.Add(kartaBota);

            rozdanie = new Button();
            rozdanie.Location = new Point(650, 400);
            rozdanie.Size = new Size(150, 70);
            rozdanie.Font = new Font("Segoe UI", 10);
            rozdanie.Text = "Rozdanie";
            rozdanie.Click += new EventHandler(setupRozdanie);
            gamePanel.Controls.Add(rozdanie);

        }

        private void setupRozdanie(object sender, EventArgs e)
        {
            Random rand = new Random();
            int g;
            int b;
            if(talia.Count != 52)
            {
                while (true)
                {
                    g = rand.Next(52) +1;
                    if (!talia.Contains(g))
                    {
                        talia.Add(g);
                        break;
                    }
                }

                while (true)
                {
                    b = rand.Next(52) +1;
                    if (!talia.Contains(b))
                    {
                        talia.Add(b);
                        break;
                    }
                }

                switch (g)
                {
                    case 1:
                        kartaGracza.Text = "2 trefl";
                        break;
                    case 2:
                        kartaGracza.Text = "2 pik";
                        break;
                    case 3:
                        kartaGracza.Text = "2 karo";
                        break;
                    case 4:
                        kartaGracza.Text = "2 kier";
                        break;
                    case 5:
                        kartaGracza.Text = "3 trefl";
                        break;
                    case 6:
                        kartaGracza.Text = "3 pik";
                        break;
                    case 7:
                        kartaGracza.Text = "3 karo";
                        break;
                    case 8:
                        kartaGracza.Text = "3 kier";
                        break;
                    case 9:
                        kartaGracza.Text = "4 trefl";
                        break;
                    case 10:
                        kartaGracza.Text = "4 pik";
                        break;
                    case 11:
                        kartaGracza.Text = "4 karo";
                        break;
                    case 12:
                        kartaGracza.Text = "4 kier";
                        break;
                    case 13:
                        kartaGracza.Text = "5 trefl";
                        break;
                    case 14:
                        kartaGracza.Text = "5 pik";
                        break;
                    case 15:
                        kartaGracza.Text = "5 karo";
                        break;
                    case 16:
                        kartaGracza.Text = "5 kier";
                        break;
                    case 17:
                        kartaGracza.Text = "6 trefl";
                        break;
                    case 18:
                        kartaGracza.Text = "6 pik";
                        break;
                    case 19:
                        kartaGracza.Text = "6 karo";
                        break;
                    case 20:
                        kartaGracza.Text = "6 kier";
                        break;
                    case 21:
                        kartaGracza.Text = "7 trefl";
                        break;
                    case 22:
                        kartaGracza.Text = "7 pik";
                        break;
                    case 23:
                        kartaGracza.Text = "7 karo";
                        break;
                    case 24:
                        kartaGracza.Text = "7 kier";
                        break;
                    case 25:
                        kartaGracza.Text = "8 trefl";
                        break;
                    case 26:
                        kartaGracza.Text = "8 pik";
                        break;
                    case 27:
                        kartaGracza.Text = "8 karo";
                        break;
                    case 28:
                        kartaGracza.Text = "8 kier";
                        break;
                    case 29:
                        kartaGracza.Text = "9 trefl";
                        break;
                    case 30:
                        kartaGracza.Text = "9 pik";
                        break;
                    case 31:
                        kartaGracza.Text = "9 karo";
                        break;
                    case 32:
                        kartaGracza.Text = "9 kier";
                        break;
                    case 33:
                        kartaGracza.Text = "10 trefl";
                        break;
                    case 34:
                        kartaGracza.Text = "10 pik";
                        break;
                    case 35:
                        kartaGracza.Text = "10 karo";
                        break;
                    case 36:
                        kartaGracza.Text = "10 kier";
                        break;
                    case 37:
                        kartaGracza.Text = "J trefl";
                        break;
                    case 38:
                        kartaGracza.Text = "J pik";
                        break;
                    case 39:
                        kartaGracza.Text = "J karo";
                        break;
                    case 40:
                        kartaGracza.Text = "J kier";
                        break;
                    case 41:
                        kartaGracza.Text = "Q trefl";
                        break;
                    case 42:
                        kartaGracza.Text = "Q pik";
                        break;
                    case 43:
                        kartaGracza.Text = "Q karo";
                        break;
                    case 44:
                        kartaGracza.Text = "Q kier";
                        break;
                    case 45:
                        kartaGracza.Text = "K trefl";
                        break;
                    case 46:
                        kartaGracza.Text = "K pik";
                        break;
                    case 47:
                        kartaGracza.Text = "K karo";
                        break;
                    case 48:
                        kartaGracza.Text = "K kier";
                        break;
                    case 49:
                        kartaGracza.Text = "A trefl";
                        break;
                    case 50:
                        kartaGracza.Text = "A pik";
                        break;
                    case 51:
                        kartaGracza.Text = "A karo";
                        break;
                    case 52:
                        kartaGracza.Text = "A kier";
                        break;
                }

                switch (b)
                {
                    case 1:
                        kartaBota.Text = "2 trefl";
                        break;
                    case 2:
                        kartaBota.Text = "2 pik";
                        break;
                    case 3:
                        kartaBota.Text = "2 karo";
                        break;
                    case 4:
                        kartaBota.Text = "2 kier";
                        break;
                    case 5:
                        kartaBota.Text = "3 trefl";
                        break;
                    case 6:
                        kartaBota.Text = "3 pik";
                        break;
                    case 7:
                        kartaBota.Text = "3 karo";
                        break;
                    case 8:
                        kartaBota.Text = "3 kier";
                        break;
                    case 9:
                        kartaBota.Text = "4 trefl";
                        break;
                    case 10:
                        kartaBota.Text = "4 pik";
                        break;
                    case 11:
                        kartaBota.Text = "4 karo";
                        break;
                    case 12:
                        kartaBota.Text = "4 kier";
                        break;
                    case 13:
                        kartaBota.Text = "5 trefl";
                        break;
                    case 14:
                        kartaBota.Text = "5 pik";
                        break;
                    case 15:
                        kartaBota.Text = "5 karo";
                        break;
                    case 16:
                        kartaBota.Text = "5 kier";
                        break;
                    case 17:
                        kartaBota.Text = "6 trefl";
                        break;
                    case 18:
                        kartaBota.Text = "6 pik";
                        break;
                    case 19:
                        kartaBota.Text = "6 karo";
                        break;
                    case 20:
                        kartaBota.Text = "6 kier";
                        break;
                    case 21:
                        kartaBota.Text = "7 trefl";
                        break;
                    case 22:
                        kartaBota.Text = "7 pik";
                        break;
                    case 23:
                        kartaBota.Text = "7 karo";
                        break;
                    case 24:
                        kartaBota.Text = "7 kier";
                        break;
                    case 25:
                        kartaBota.Text = "8 trefl";
                        break;
                    case 26:
                        kartaBota.Text = "8 pik";
                        break;
                    case 27:
                        kartaBota.Text = "8 karo";
                        break;
                    case 28:
                        kartaBota.Text = "8 kier";
                        break;
                    case 29:
                        kartaBota.Text = "9 trefl";
                        break;
                    case 30:
                        kartaBota.Text = "9 pik";
                        break;
                    case 31:
                        kartaBota.Text = "9 karo";
                        break;
                    case 32:
                        kartaBota.Text = "9 kier";
                        break;
                    case 33:
                        kartaBota.Text = "10 trefl";
                        break;
                    case 34:
                        kartaBota.Text = "10 pik";
                        break;
                    case 35:
                        kartaBota.Text = "10 karo";
                        break;
                    case 36:
                        kartaBota.Text = "10 kier";
                        break;
                    case 37:
                        kartaBota.Text = "J trefl";
                        break;
                    case 38:
                        kartaBota.Text = "J pik";
                        break;
                    case 39:
                        kartaBota.Text = "J karo";
                        break;
                    case 40:
                        kartaBota.Text = "J kier";
                        break;
                    case 41:
                        kartaBota.Text = "Q trefl";
                        break;
                    case 42:
                        kartaBota.Text = "Q pik";
                        break;
                    case 43:
                        kartaBota.Text = "Q karo";
                        break;
                    case 44:
                        kartaBota.Text = "Q kier";
                        break;
                    case 45:
                        kartaBota.Text = "K trefl";
                        break;
                    case 46:
                        kartaBota.Text = "K pik";
                        break;
                    case 47:
                        kartaBota.Text = "K karo";
                        break;
                    case 48:
                        kartaBota.Text = "K kier";
                        break;
                    case 49:
                        kartaBota.Text = "A trefl";
                        break;
                    case 50:
                        kartaBota.Text = "A pik";
                        break;
                    case 51:
                        kartaBota.Text = "A karo";
                        break;
                    case 52:
                        kartaBota.Text = "A kier";
                        break;
                }

                if (g > b)
                {
                    wynikG++;
                    wynikGracza.Text = "Wynik Gracza: \n" + wynikG.ToString();
                }
                else
                {
                    wynikB++;
                    wynikBota.Text = "Wynik Bota: \n" + wynikB.ToString();
                }

            }
            else
            {
                if (wynikG > wynikB)
                {
                    MessageBox.Show("Wygrana!", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    talia.Clear();
                    wynikB = 0;
                    wynikG = 0;
                    wynikBota.Text = "Wynik Bota: \n" + wynikB.ToString();
                    wynikGracza.Text = "Wynik Gracza: \n" + wynikG.ToString();
                    kartaBota.Text = "";
                    kartaGracza.Text = "";
                    return;
                }
                else if(wynikB > wynikG)
                {
                    MessageBox.Show("Przegrana!", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    talia.Clear();
                    wynikB = 0;
                    wynikG = 0;
                    wynikBota.Text = "Wynik Bota: \n" + wynikB.ToString();
                    wynikGracza.Text = "Wynik Gracza: \n" + wynikG.ToString();
                    kartaBota.Text = "";
                    kartaGracza.Text = "";
                    return;
                }
                else
                {
                    MessageBox.Show("Remis!", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    talia.Clear();
                    wynikB = 0;
                    wynikG = 0;
                    wynikBota.Text = "Wynik Bota: \n" + wynikB.ToString();
                    wynikGracza.Text = "Wynik Gracza: \n" + wynikG.ToString();
                    kartaBota.Text = "";
                    kartaGracza.Text = "";
                    return;
                }
            }
        }
    }
}
