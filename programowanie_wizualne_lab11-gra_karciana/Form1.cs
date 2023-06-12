using static System.Formats.Asn1.AsnWriter;

namespace programowanie_wizualne_lab11_gra_karciana
{
    public partial class Form1 : Form
    {
        Button start;
        RadioButton wojna1;
        RadioButton wojna2;
        RadioButton oczko;

        int Gracz_punkty;
        int Bot_punkty;
        Panel ControlPanel = new Panel();
        Label Numer_gracza = new Label();
        Label Numer_bota = new Label();
        Label Wynik_gracza = new Label();
        Label Wynik_bota = new Label();
        Button Next = new Button();
        List<int> list = new List<int>();

        TableLayoutPanel panel2;
        Button check;
        Label score;
        int sumOfPoints = 0;
        int sumOfOpponentPoints = 0;

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

            if (wojna2.Checked == true)
            {
                setupGamePanel();
            }

            if (wojna1.Checked == true)
            {
                Gracz_punkty = 0;
                Bot_punkty = 0;

                ControlPanel = new Panel();
                ControlPanel.Location = new Point(250, 20);
                ControlPanel.Size = new Size(328, 426);
                this.Controls.Add(ControlPanel);

                Numer_gracza.Location = new Point(120, 10);
                Numer_gracza.Size = new Size(200, 200);
                Numer_gracza.Font = new Font("Arial", 20);
                ControlPanel.Controls.Add(Numer_gracza);

                Numer_bota.Location = new Point(120, 220);
                Numer_bota.Size = new Size(200, 200);
                Numer_bota.Font = new Font("Arial", 20);
                ControlPanel.Controls.Add(Numer_bota);

                Wynik_gracza.Location = new Point(6, 85);
                Wynik_gracza.Size = new Size(108, 51);
                Wynik_gracza.Text = "0";
                Wynik_gracza.Font = new Font("Arial", 20);
                ControlPanel.Controls.Add(Wynik_gracza);

                Wynik_bota.Location = new Point(6, 320);
                Wynik_bota.Size = new Size(108, 51);
                Wynik_bota.Text = "0";
                Wynik_bota.Font = new Font("Arial", 20);
                ControlPanel.Controls.Add(Wynik_bota);

                Numer_gracza.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\karta.png");
                Numer_bota.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\karta.png");

                Next.Location = new Point(600, 200);
                Next.Text = "KOLEJNA";
                Next.Font = new Font("Arial", 10);
                Next.Size = new Size(108, 51);
                Next.Click += new EventHandler(Dobierz);
                this.Controls.Add(Next);
            }
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
                    Text = "SPRAWDZ",
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
            if (talia.Count != 52)
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
                else if (wynikB > wynikG)
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

        private void Dobierz(object sender, EventArgs e)
        {

            int Gracz;
            int Bot;
            if (list.Count != 52)
            {
                Random random = new Random();

                while (true)
                {
                    Gracz = random.Next(52) + 1;
                    if (!list.Contains(Gracz))
                    {
                        list.Add(Gracz);
                        break;
                    }
                }

                while (true)
                {
                    Bot = random.Next(52) + 1;
                    if (!list.Contains(Bot))
                    {
                        list.Add(Bot);
                        break;
                    }
                }

                switch (Gracz)
                {
                    case 1:
                        Numer_gracza.Text = "2 pik";
                        break;
                    case 2:
                        Numer_gracza.Text = "2 trefl";
                        break;
                    case 3:
                        Numer_gracza.Text = "2 karo";
                        break;
                    case 4:
                        Numer_gracza.Text = "2 kier";
                        break;
                    case 5:
                        Numer_gracza.Text = "3 pik";
                        break;
                    case 6:
                        Numer_gracza.Text = "3 trefl";
                        break;
                    case 7:
                        Numer_gracza.Text = "3 karo";
                        break;
                    case 8:
                        Numer_gracza.Text = "3 kier";
                        break;
                    case 9:
                        Numer_gracza.Text = "4 pik";
                        break;
                    case 10:
                        Numer_gracza.Text = "4 trefl";
                        break;
                    case 11:
                        Numer_gracza.Text = "4 karo";
                        break;
                    case 12:
                        Numer_gracza.Text = "4 kier";
                        break;
                    case 13:
                        Numer_gracza.Text = "5 pik";
                        break;
                    case 14:
                        Numer_gracza.Text = "5 trefl";
                        break;
                    case 15:
                        Numer_gracza.Text = "5 karo";
                        break;
                    case 16:
                        Numer_gracza.Text = "5 kier";
                        break;
                    case 17:
                        Numer_gracza.Text = "6 pik";
                        break;
                    case 18:
                        Numer_gracza.Text = "6 trefl";
                        break;
                    case 19:
                        Numer_gracza.Text = "6 karo";
                        break;
                    case 20:
                        Numer_gracza.Text = "6 kier";
                        break;
                    case 21:
                        Numer_gracza.Text = "7 pik";
                        break;
                    case 22:
                        Numer_gracza.Text = "7 trefl";
                        break;
                    case 23:
                        Numer_gracza.Text = "7 karo";
                        break;
                    case 24:
                        Numer_gracza.Text = "7 kier";
                        break;
                    case 25:
                        Numer_gracza.Text = "8 pik";
                        break;
                    case 26:
                        Numer_gracza.Text = "8 trefl";
                        break;
                    case 27:
                        Numer_gracza.Text = "8 karo";
                        break;
                    case 28:
                        Numer_gracza.Text = "8 kier";
                        break;
                    case 29:
                        Numer_gracza.Text = "9 pik";
                        break;
                    case 30:
                        Numer_gracza.Text = "9 trefl";
                        break;
                    case 31:
                        Numer_gracza.Text = "9 karo";
                        break;
                    case 32:
                        Numer_gracza.Text = "9 kier";
                        break;
                    case 33:
                        Numer_gracza.Text = "10 pik";
                        break;
                    case 34:
                        Numer_gracza.Text = "10 trefl";
                        break;
                    case 35:
                        Numer_gracza.Text = "10 karo";
                        break;
                    case 36:
                        Numer_gracza.Text = "10 kier";
                        break;
                    case 37:
                        Numer_gracza.Text = "walet pik";
                        break;
                    case 38:
                        Numer_gracza.Text = "walet trefl";
                        break;
                    case 39:
                        Numer_gracza.Text = "walet karo";
                        break;
                    case 40:
                        Numer_gracza.Text = "walet kier";
                        break;
                    case 41:
                        Numer_gracza.Text = "dama pik";
                        break;
                    case 42:
                        Numer_gracza.Text = "dama trefl";
                        break;
                    case 43:
                        Numer_gracza.Text = "dama karo";
                        break;
                    case 44:
                        Numer_gracza.Text = "dama kier";
                        break;
                    case 45:
                        Numer_gracza.Text = "król pik";
                        break;
                    case 46:
                        Numer_gracza.Text = "król trefl";
                        break;
                    case 47:
                        Numer_gracza.Text = "król karo";
                        break;
                    case 48:
                        Numer_gracza.Text = "król kier";
                        break;
                    case 49:
                        Numer_gracza.Text = "as pik";
                        break;
                    case 50:
                        Numer_gracza.Text = "as trefl";
                        break;
                    case 51:
                        Numer_gracza.Text = "as karo";
                        break;
                    case 52:
                        Numer_gracza.Text = "as kier";
                        break;
                }

                switch (Bot)
                {
                    case 1:
                        Numer_bota.Text = "2 pik";
                        break;
                    case 2:
                        Numer_bota.Text = "2 trefl";
                        break;
                    case 3:
                        Numer_bota.Text = "2 karo";
                        break;
                    case 4:
                        Numer_bota.Text = "2 kier";
                        break;
                    case 5:
                        Numer_bota.Text = "3 pik";
                        break;
                    case 6:
                        Numer_bota.Text = "3 trefl";
                        break;
                    case 7:
                        Numer_bota.Text = "3 karo";
                        break;
                    case 8:
                        Numer_bota.Text = "3 kier";
                        break;
                    case 9:
                        Numer_bota.Text = "4 pik";
                        break;
                    case 10:
                        Numer_bota.Text = "4 trefl";
                        break;
                    case 11:
                        Numer_bota.Text = "4 karo";
                        break;
                    case 12:
                        Numer_bota.Text = "4 kier";
                        break;
                    case 13:
                        Numer_bota.Text = "5 pik";
                        break;
                    case 14:
                        Numer_bota.Text = "5 trefl";
                        break;
                    case 15:
                        Numer_bota.Text = "5 karo";
                        break;
                    case 16:
                        Numer_bota.Text = "5 kier";
                        break;
                    case 17:
                        Numer_bota.Text = "6 pik";
                        break;
                    case 18:
                        Numer_bota.Text = "6 trefl";
                        break;
                    case 19:
                        Numer_bota.Text = "6 karo";
                        break;
                    case 20:
                        Numer_bota.Text = "6 kier";
                        break;
                    case 21:
                        Numer_bota.Text = "7 pik";
                        break;
                    case 22:
                        Numer_bota.Text = "7 trefl";
                        break;
                    case 23:
                        Numer_bota.Text = "7 karo";
                        break;
                    case 24:
                        Numer_bota.Text = "7 kier";
                        break;
                    case 25:
                        Numer_bota.Text = "8 pik";
                        break;
                    case 26:
                        Numer_bota.Text = "8 trefl";
                        break;
                    case 27:
                        Numer_bota.Text = "8 karo";
                        break;
                    case 28:
                        Numer_bota.Text = "8 kier";
                        break;
                    case 29:
                        Numer_bota.Text = "9 pik";
                        break;
                    case 30:
                        Numer_bota.Text = "9 trefl";
                        break;
                    case 31:
                        Numer_bota.Text = "9 karo";
                        break;
                    case 32:
                        Numer_bota.Text = "9 kier";
                        break;
                    case 33:
                        Numer_bota.Text = "10 pik";
                        break;
                    case 34:
                        Numer_bota.Text = "10 trefl";
                        break;
                    case 35:
                        Numer_bota.Text = "10 karo";
                        break;
                    case 36:
                        Numer_bota.Text = "10 kier";
                        break;
                    case 37:
                        Numer_bota.Text = "walet pik";
                        break;
                    case 38:
                        Numer_bota.Text = "walet trefl";
                        break;
                    case 39:
                        Numer_bota.Text = "walet karo";
                        break;
                    case 40:
                        Numer_bota.Text = "walet kier";
                        break;
                    case 41:
                        Numer_bota.Text = "dama pik";
                        break;
                    case 42:
                        Numer_bota.Text = "dama trefl";
                        break;
                    case 43:
                        Numer_bota.Text = "dama karo";
                        break;
                    case 44:
                        Numer_bota.Text = "dama kier";
                        break;
                    case 45:
                        Numer_bota.Text = "król pik";
                        break;
                    case 46:
                        Numer_bota.Text = "król trefl";
                        break;
                    case 47:
                        Numer_bota.Text = "król karo";
                        break;
                    case 48:
                        Numer_bota.Text = "król kier";
                        break;
                    case 49:
                        Numer_bota.Text = "as pik";
                        break;
                    case 50:
                        Numer_bota.Text = "as trefl";
                        break;
                    case 51:
                        Numer_bota.Text = "as karo";
                        break;
                    case 52:
                        Numer_bota.Text = "as kier";
                        break;
                }

                if (Gracz > Bot)
                {
                    Gracz_punkty++;
                    Wynik_gracza.Text = Gracz_punkty.ToString();
                }
                else
                {
                    Bot_punkty++;
                    Wynik_bota.Text = Bot_punkty.ToString();
                }
            }

            if (list.Count == 52)
            {
                MessageBox.Show("Wykorzystano cala talie!");
                list.Clear();
                Numer_gracza.Text = "";
                Numer_bota.Text = "";
                this.Controls.Remove(Next);
                this.Controls.Remove(ControlPanel);
                Gracz = Convert.ToInt32(Wynik_gracza.Text);
                Bot = Convert.ToInt32(Wynik_bota.Text);
                if (Gracz > Bot)
                {
                    MessageBox.Show("Wygrales!");
                }
                else if (Bot > Gracz)
                {
                    MessageBox.Show("Przegrales!");
                }
                else
                {
                    MessageBox.Show("Remis!");
                }

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
                    case 13: //król
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
                        cardName = "król";
                        break;
                    case 14:
                        sumOfPoints += 11;
                        cardName = "as";
                        break;
                }
            }

            if (IsScoreOk() == false)
            {
                MessageBox.Show("Przeciwnik skonczyl juz runde", "Zamknij okno");
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
                message = "Przegrales\nCzy chcesz zagrac jeszcze raz?";
            }
            else if (sumOfPoints == sumOfOpponentPoints)
            {
                message = "Remis\nCzy chcesz zagraæ jeszcze raz?";
            }
            else
            {
                message = "Wygrales\nCzy chcesz zagrac jeszcze raz?";
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