using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SlidePuzzle
{
    public partial class Main : Form
    {
        List<TextBox> startTextBoxesList = new List<TextBox>();
        List<TextBox> goalTextBoxesList = new List<TextBox>();

        private const int boardMargin = 10;


        public Main()
        {
            InitializeComponent();
        }

        private void CreateBoardButton_Click(object sender, EventArgs e)
        {
            int size;
            if (int.TryParse(boardSizeBox.Text, out size))
            {
                if (size >= 3 && size <= 10)
                {
                    ClearTextBoxes();


                    CreatePuzzleBoard(size, 0, startTextBoxesList);


                    CreatePuzzleBoard(size, size * (60 + boardMargin), goalTextBoxesList);

                    AdjustFormSize(size);
                }
                else
                {
                    MessageBox.Show("Tahta min 3x3 , max 10x10 olmalýdýr.");
                }
            }
            else
            {
                MessageBox.Show("Geçersiz tahta boyutu.");
            }
        }


        private void CreatePuzzleBoard(int size, int loffSet, List<TextBox> textBoxList)
        {
            int textBoxSize = 50;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Width = textBoxSize;
                    textBox.Height = textBoxSize;
                    textBox.Left = loffSet + j * (textBoxSize + boardMargin);
                    textBox.Top = 100 + i * (textBoxSize + boardMargin);
                    textBox.Text = $"{i * size + j + 1}";
                    textBox.Tag = new Point(i, j);
                    textBoxList.Add(textBox);
                    this.Controls.Add(textBox);
                }
            }
        }



        private void ClearTextBoxes()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is TextBox)
                {
                    this.Controls.RemoveAt(i);
                }
            }
        }

        private void AdjustFormSize(int size)
        {
            int formWidth = 2 * (size * (50 + boardMargin) + 2 * boardMargin);
            int formHeight = (2 * size * (50 + boardMargin) + 3 * boardMargin);
            this.ClientSize = new Size(formWidth, formHeight);
        }


        private void SolvePuzzleButton_Click(object sender, EventArgs e)
        {
            int size = int.Parse(boardSizeBox.Text);

            int[,] startBoard = GetBoardFromTextBoxes(startTextBoxesList, size);
            int[,] goalBoard = GetBoardFromTextBoxes(goalTextBoxesList, size);

            List<int[,]> solution = SlidePuzzleSolver.Solve(startBoard, goalBoard);

            if (solution.Count == 0)
            {
                MessageBox.Show("Çözüm Yok!");
            }
            else
            {
                SolutionForm solutionForm = new SolutionForm(solution);
                solutionForm.ShowDialog();
            }
        }
        private int[,] GetBoardFromTextBoxes(List<TextBox> textBoxList, int size)
        {
            int[,] board = new int[size, size];
            foreach (TextBox textBox in textBoxList)
            {
                Point point = (Point)textBox.Tag;
                int value = int.Parse(textBox.Text);
                board[point.X, point.Y] = value;
            }
            return board;
        }
    }
}
