using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayin_tarlası
{
    public partial class Form1 : Form
    {
        private const int GridSize = 10; // 10x10 grid
        private const int CellSize = 30; // Button size
        private const int MineCount = 20;
        private Button[,] buttons;
        private bool[,] mines;
        private bool[,] revealed;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            buttons = new Button[GridSize, GridSize];
            mines = new bool[GridSize, GridSize];
            revealed = new bool[GridSize, GridSize];
            GenerateGrid();
            PlaceMines();
        }

        private void GenerateGrid()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Size = new Size(CellSize, CellSize),
                        Location = new Point(i * CellSize, j * CellSize),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Tag = new Point(i, j)
                    };
                    buttons[i, j].MouseDown += Button_Click;
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void PlaceMines()
        {
            Random rnd = new Random();
            int placedMines = 0;

            while (placedMines < MineCount)
            {
                int x = rnd.Next(GridSize);
                int y = rnd.Next(GridSize);

                if (!mines[x, y])
                {
                    mines[x, y] = true;
                    placedMines++;
                }
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            Point location = (Point)button.Tag;
            int x = location.X, y = location.Y;

            if (e.Button == MouseButtons.Right)
            {
                ToggleFlag(button);
            }
            else if (e.Button == MouseButtons.Left)
            {
                RevealCell(x, y);
            }
        }

        private void ToggleFlag(Button button)
        {
            if (button.Text == "🚩")
                button.Text = "";
            else
                button.Text = "🚩";
        }

        private void RevealCell(int x, int y)
        {
            if (revealed[x, y] || buttons[x, y].Text == "🚩") return;

            revealed[x, y] = true;

            if (mines[x, y])
            {
                buttons[x, y].BackColor = Color.Red;
                buttons[x, y].Text = "💣";
                GameOver(false);
            }
            else
            {
                int adjacentMines = CountAdjacentMines(x, y);
                buttons[x, y].BackColor = Color.LightGray;

                if (adjacentMines > 0)
                {
                    buttons[x, y].Text = adjacentMines.ToString();
                }
                else
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int nx = x + dx, ny = y + dy;

                            if (nx >= 0 && nx < GridSize && ny >= 0 && ny < GridSize)
                            {
                                RevealCell(nx, ny);
                            }
                        }
                    }
                }
            }

            CheckWinCondition();
        }

        private int CountAdjacentMines(int x, int y)
        {
            int count = 0;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx, ny = y + dy;

                    if (nx >= 0 && nx < GridSize && ny >= 0 && ny < GridSize && mines[nx, ny])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void GameOver(bool won)
        {
            string message = won ? "Kazandınız!" : "Kaybettiniz!";
            MessageBox.Show(message, "Oyun Bitti");
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void CheckWinCondition()
        {
            int revealedCount = 0;

            foreach (var cell in revealed)
            {
                if (cell) revealedCount++;
            }

            if (revealedCount == GridSize * GridSize - MineCount)
            {
                GameOver(true);
            }
        }
    }
}