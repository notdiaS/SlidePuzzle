using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SlidePuzzle
{
    public partial class SolutionForm : Form
    {
        private List<int[,]> solutionSteps;
        private int currentStep;
        private TableLayoutPanel puzzlePanel; // Yeni eklenen kontrol

        public SolutionForm(List<int[,]> steps)
        {
            InitializeComponent();
            solutionSteps = steps;
            currentStep = 0;
            InitializePuzzlePanel(); // Puzzle panelini baþlat
            ShowStep();
        }

        // Puzzle panelini baþlatan yardýmcý yöntem
        private void InitializePuzzlePanel()
        {
            puzzlePanel = new TableLayoutPanel();
            puzzlePanel.Dock = DockStyle.Fill;
            puzzlePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.Controls.Add(puzzlePanel);
        }

        private void ShowStep()
        {
            int[,] board = solutionSteps[currentStep];
            int size = board.GetLength(0);

            // Clear previous controls
            puzzlePanel.Controls.Clear();
            puzzlePanel.ColumnStyles.Clear();
            puzzlePanel.RowStyles.Clear();

            // Create columns and rows for the puzzle panel
            for (int i = 0; i < size; i++)
            {
                puzzlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
                puzzlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
            }

            // Add textboxes for the current step
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;
                    textBox.Text = (board[i, j] == 0) ? "" : board[i, j].ToString();
                    textBox.ReadOnly = true;
                    puzzlePanel.Controls.Add(textBox, j, i);
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currentStep < solutionSteps.Count - 1)
            {
                currentStep++;
                ShowStep();
            }
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (currentStep > 0)
            {
                currentStep--;
                ShowStep();
            }
        }
    }
}
