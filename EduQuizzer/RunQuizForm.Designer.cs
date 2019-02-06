namespace EduQuizzer
{
    partial class RunQuizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionPanel = new System.Windows.Forms.Panel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.endQuizButton = new System.Windows.Forms.Button();
            this.QuizTitleLabel = new System.Windows.Forms.Label();
            this.QuestionContentBox = new System.Windows.Forms.TextBox();
            this.QuestionTypeLabel = new System.Windows.Forms.Label();
            this.QuestionPanel.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionPanel.Controls.Add(this.QuestionTypeLabel);
            this.QuestionPanel.Controls.Add(this.QuestionContentBox);
            this.QuestionPanel.Controls.Add(this.QuizTitleLabel);
            this.QuestionPanel.Location = new System.Drawing.Point(6, 6);
            this.QuestionPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.Size = new System.Drawing.Size(951, 261);
            this.QuestionPanel.TabIndex = 0;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.panel1);
            this.ControlPanel.Location = new System.Drawing.Point(6, 269);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(951, 79);
            this.ControlPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.previousButton);
            this.panel1.Controls.Add(this.nextButton);
            this.panel1.Controls.Add(this.endQuizButton);
            this.panel1.Location = new System.Drawing.Point(328, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 29);
            this.panel1.TabIndex = 3;
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(2, 2);
            this.previousButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(95, 26);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "<< Poprzednie";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.PreviousButtonClicked);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(198, 2);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(95, 26);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Następne >>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButtonClicked);
            // 
            // endQuizButton
            // 
            this.endQuizButton.Location = new System.Drawing.Point(100, 2);
            this.endQuizButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.endQuizButton.Name = "endQuizButton";
            this.endQuizButton.Size = new System.Drawing.Size(95, 26);
            this.endQuizButton.TabIndex = 2;
            this.endQuizButton.Text = "Zakończ quiz";
            this.endQuizButton.UseVisualStyleBackColor = true;
            this.endQuizButton.Click += new System.EventHandler(this.EndQuiz);
            // 
            // QuizTitleLabel
            // 
            this.QuizTitleLabel.AutoSize = true;
            this.QuizTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.QuizTitleLabel.Location = new System.Drawing.Point(6, 6);
            this.QuizTitleLabel.Name = "QuizTitleLabel";
            this.QuizTitleLabel.Size = new System.Drawing.Size(0, 25);
            this.QuizTitleLabel.TabIndex = 1;
            // 
            // QuestionContentBox
            // 
            this.QuestionContentBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.QuestionContentBox.Enabled = false;
            this.QuestionContentBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.QuestionContentBox.Location = new System.Drawing.Point(11, 67);
            this.QuestionContentBox.Multiline = true;
            this.QuestionContentBox.Name = "QuestionContentBox";
            this.QuestionContentBox.ReadOnly = true;
            this.QuestionContentBox.Size = new System.Drawing.Size(500, 180);
            this.QuestionContentBox.TabIndex = 2;
            // 
            // QuestionTypeLabel
            // 
            this.QuestionTypeLabel.AutoSize = true;
            this.QuestionTypeLabel.Location = new System.Drawing.Point(526, 46);
            this.QuestionTypeLabel.Name = "QuestionTypeLabel";
            this.QuestionTypeLabel.Size = new System.Drawing.Size(0, 13);
            this.QuestionTypeLabel.TabIndex = 3;
            // 
            // RunQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(962, 353);
            this.ControlBox = false;
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.QuestionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunQuizForm";
            this.Text = "RunQuizForm";
            this.Load += new System.EventHandler(this.RunQuizFormLoad);
            this.QuestionPanel.ResumeLayout(false);
            this.QuestionPanel.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel QuestionPanel;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button endQuizButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Label QuizTitleLabel;
        private System.Windows.Forms.TextBox QuestionContentBox;
        private System.Windows.Forms.Label QuestionTypeLabel;
    }
}