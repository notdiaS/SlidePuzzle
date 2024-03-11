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
        private Button prevButton;
        private Button nextButton;
        private GroupBox groupBox1;
        private Button AutoButton;
        private TableLayoutPanel puzzlePanel;

        public SolutionForm(List<int[,]> steps)
        {
            InitializeComponent();
            solutionSteps = steps;
            currentStep = 0;
            InitializePuzzlePanel();
            ShowStep();
        }

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

            puzzlePanel.Controls.Clear();
            puzzlePanel.ColumnStyles.Clear();
            puzzlePanel.RowStyles.Clear();

            for (int i = 0; i < size; i++)
            {
                puzzlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
                puzzlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;
                    textBox.Text = (board[i, j] == 0) ? "" : board[i, j].ToString();
                    textBox.ReadOnly = true;
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.BackColor = Color.LightBlue;

                    if (currentStep > 0)
                    {
                        int[,] previousBoard = solutionSteps[currentStep - 1];
                        if (board[i, j] != previousBoard[i, j])
                        {
                            textBox.BackColor = Color.Yellow; // Örnek olarak sarý renk
                        }
                    }

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

        private void InitializeComponent()
        {
            prevButton = new Button();
            nextButton = new Button();
            groupBox1 = new GroupBox();
            AutoButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // prevButton
            // 
            prevButton.Dock = DockStyle.Left;
            prevButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            prevButton.Location = new Point(3, 23);
            prevButton.Name = "prevButton";
            prevButton.Size = new Size(100, 32);
            prevButton.TabIndex = 0;
            prevButton.Text = "Previous";
            prevButton.UseVisualStyleBackColor = true;
            prevButton.Click += PrevButton_Click;
            // 
            // nextButton
            // 
            nextButton.Dock = DockStyle.Right;
            nextButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            nextButton.Location = new Point(471, 23);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(100, 32);
            nextButton.TabIndex = 1;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += NextButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AutoButton);
            groupBox1.Controls.Add(nextButton);
            groupBox1.Controls.Add(prevButton);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 302);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(574, 58);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // AutoButton
            // 
            AutoButton.Location = new Point(229, 23);
            AutoButton.Name = "AutoButton";
            AutoButton.Size = new Size(94, 29);
            AutoButton.TabIndex = 3;
            AutoButton.Text = "Auto";
            AutoButton.UseVisualStyleBackColor = true;
            AutoButton.Click += AutoButton_Click;
            // 
            // SolutionForm
            // 
            ClientSize = new Size(574, 360);
            Controls.Add(groupBox1);
            Name = "SolutionForm";
            Text = "Slide Puzzle Solution";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private async void AutoButton_Click(object sender, EventArgs e)
        {
            int count = solutionSteps.Count;
            while (count != 0)
            {
                
                currentStep++;
                ShowStep();
                await Task.Delay(1000);
                count--;
            }
        }
    }
}
