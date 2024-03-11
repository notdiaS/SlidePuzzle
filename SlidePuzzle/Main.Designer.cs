namespace SlidePuzzle
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateBoardButton = new Button();
            boardSizeBox = new TextBox();
            panel1 = new Panel();
            SolvePuzzleButton = new Button();
            panel2 = new Panel();
            outputLabel = new Label();
            inputLabel = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // CreateBoardButton
            // 
            CreateBoardButton.Location = new Point(141, 19);
            CreateBoardButton.Margin = new Padding(3, 4, 3, 4);
            CreateBoardButton.Name = "CreateBoardButton";
            CreateBoardButton.Size = new Size(71, 31);
            CreateBoardButton.TabIndex = 0;
            CreateBoardButton.Text = "Create";
            CreateBoardButton.UseVisualStyleBackColor = true;
            CreateBoardButton.Click += CreateBoardButton_Click;
            // 
            // boardSizeBox
            // 
            boardSizeBox.Location = new Point(3, 19);
            boardSizeBox.Margin = new Padding(3, 4, 3, 4);
            boardSizeBox.Name = "boardSizeBox";
            boardSizeBox.Size = new Size(130, 27);
            boardSizeBox.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(SolvePuzzleButton);
            panel1.Controls.Add(CreateBoardButton);
            panel1.Controls.Add(boardSizeBox);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 337);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 63);
            panel1.TabIndex = 2;
            // 
            // SolvePuzzleButton
            // 
            SolvePuzzleButton.Location = new Point(218, 19);
            SolvePuzzleButton.Margin = new Padding(3, 4, 3, 4);
            SolvePuzzleButton.Name = "SolvePuzzleButton";
            SolvePuzzleButton.Size = new Size(71, 31);
            SolvePuzzleButton.TabIndex = 2;
            SolvePuzzleButton.Text = "Solve";
            SolvePuzzleButton.UseVisualStyleBackColor = true;
            SolvePuzzleButton.Click += SolvePuzzleButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(outputLabel);
            panel2.Controls.Add(inputLabel);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(299, 53);
            panel2.TabIndex = 3;
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Dock = DockStyle.Right;
            outputLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            outputLabel.Location = new Point(150, 0);
            outputLabel.Name = "outputLabel";
            outputLabel.Padding = new Padding(11, 13, 11, 13);
            outputLabel.Size = new Size(149, 54);
            outputLabel.TabIndex = 1;
            outputLabel.Text = "Target State";
            // 
            // inputLabel
            // 
            inputLabel.AutoSize = true;
            inputLabel.Dock = DockStyle.Left;
            inputLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            inputLabel.Location = new Point(0, 0);
            inputLabel.Name = "inputLabel";
            inputLabel.Padding = new Padding(11, 13, 11, 13);
            inputLabel.Size = new Size(144, 54);
            inputLabel.TabIndex = 0;
            inputLabel.Text = "Initial State";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 400);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button CreateBoardButton;
        private TextBox boardSizeBox;
        private Panel panel1;
        private Panel panel2;
        private Label outputLabel;
        private Label inputLabel;
        private Button SolvePuzzleButton;
    }
}