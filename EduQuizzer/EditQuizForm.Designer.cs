namespace EduQuizzer
{
    partial class EditQuizForm
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
            this.SaveQuizButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.QuizTitleBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuestionsList = new System.Windows.Forms.ListView();
            this.AddQuestionButton = new System.Windows.Forms.Button();
            this.RemoveQuestionButton = new System.Windows.Forms.Button();
            this.EditQuestionPanel = new System.Windows.Forms.Panel();
            this.ContentLabel = new System.Windows.Forms.Label();
            this.SelectedQuestionLabel = new System.Windows.Forms.Label();
            this.NegativePointsCheckbox = new System.Windows.Forms.CheckBox();
            this.TimeLimitedCheckbox = new System.Windows.Forms.CheckBox();
            this.MinutesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveQuizButton
            // 
            this.SaveQuizButton.Location = new System.Drawing.Point(542, 27);
            this.SaveQuizButton.Name = "SaveQuizButton";
            this.SaveQuizButton.Size = new System.Drawing.Size(75, 23);
            this.SaveQuizButton.TabIndex = 0;
            this.SaveQuizButton.Text = "Zapisz";
            this.SaveQuizButton.UseVisualStyleBackColor = true;
            this.SaveQuizButton.Click += new System.EventHandler(this.SaveQuizButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tytuł";
            // 
            // QuizTitleBox
            // 
            this.QuizTitleBox.Location = new System.Drawing.Point(16, 29);
            this.QuizTitleBox.Name = "QuizTitleBox";
            this.QuizTitleBox.Size = new System.Drawing.Size(145, 20);
            this.QuizTitleBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pytania";
            // 
            // QuestionsList
            // 
            this.QuestionsList.Location = new System.Drawing.Point(16, 73);
            this.QuestionsList.MultiSelect = false;
            this.QuestionsList.Name = "QuestionsList";
            this.QuestionsList.Size = new System.Drawing.Size(145, 251);
            this.QuestionsList.TabIndex = 4;
            this.QuestionsList.UseCompatibleStateImageBehavior = false;
            this.QuestionsList.SelectedIndexChanged += new System.EventHandler(this.QuestionsListSelectedIndexChanged);
            // 
            // AddQuestionButton
            // 
            this.AddQuestionButton.Location = new System.Drawing.Point(91, 358);
            this.AddQuestionButton.Name = "AddQuestionButton";
            this.AddQuestionButton.Size = new System.Drawing.Size(70, 23);
            this.AddQuestionButton.TabIndex = 5;
            this.AddQuestionButton.Text = "+";
            this.AddQuestionButton.UseVisualStyleBackColor = true;
            this.AddQuestionButton.Click += new System.EventHandler(this.AddQuestionButtonClick);
            // 
            // RemoveQuestionButton
            // 
            this.RemoveQuestionButton.Location = new System.Drawing.Point(16, 358);
            this.RemoveQuestionButton.Name = "RemoveQuestionButton";
            this.RemoveQuestionButton.Size = new System.Drawing.Size(70, 23);
            this.RemoveQuestionButton.TabIndex = 6;
            this.RemoveQuestionButton.Text = "-";
            this.RemoveQuestionButton.UseVisualStyleBackColor = true;
            this.RemoveQuestionButton.Click += new System.EventHandler(this.RemoveQuestionButtonClick);
            // 
            // EditQuestionPanel
            // 
            this.EditQuestionPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.EditQuestionPanel.Location = new System.Drawing.Point(168, 73);
            this.EditQuestionPanel.Name = "EditQuestionPanel";
            this.EditQuestionPanel.Size = new System.Drawing.Size(453, 308);
            this.EditQuestionPanel.TabIndex = 7;
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Location = new System.Drawing.Point(165, 56);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(0, 13);
            this.ContentLabel.TabIndex = 8;
            // 
            // SelectedQuestionLabel
            // 
            this.SelectedQuestionLabel.AutoSize = true;
            this.SelectedQuestionLabel.Location = new System.Drawing.Point(16, 327);
            this.SelectedQuestionLabel.Name = "SelectedQuestionLabel";
            this.SelectedQuestionLabel.Size = new System.Drawing.Size(0, 13);
            this.SelectedQuestionLabel.TabIndex = 9;
            // 
            // NegativePointsCheckbox
            // 
            this.NegativePointsCheckbox.AutoSize = true;
            this.NegativePointsCheckbox.Location = new System.Drawing.Point(16, 390);
            this.NegativePointsCheckbox.Name = "NegativePointsCheckbox";
            this.NegativePointsCheckbox.Size = new System.Drawing.Size(96, 17);
            this.NegativePointsCheckbox.TabIndex = 10;
            this.NegativePointsCheckbox.Text = "Punkty ujemne";
            this.NegativePointsCheckbox.UseVisualStyleBackColor = true;
            this.NegativePointsCheckbox.CheckedChanged += new System.EventHandler(this.NegativePointsChanged);
            // 
            // TimeLimitedCheckbox
            // 
            this.TimeLimitedCheckbox.AutoSize = true;
            this.TimeLimitedCheckbox.Location = new System.Drawing.Point(400, 390);
            this.TimeLimitedCheckbox.Name = "TimeLimitedCheckbox";
            this.TimeLimitedCheckbox.Size = new System.Drawing.Size(133, 17);
            this.TimeLimitedCheckbox.TabIndex = 16;
            this.TimeLimitedCheckbox.Text = "Ograniczenie czasowe";
            this.TimeLimitedCheckbox.UseVisualStyleBackColor = true;
            this.TimeLimitedCheckbox.CheckedChanged += new System.EventHandler(this.TimeLimitedCheckedChanged);
            // 
            // MinutesUpDown
            // 
            this.MinutesUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MinutesUpDown.Location = new System.Drawing.Point(539, 390);
            this.MinutesUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MinutesUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MinutesUpDown.Name = "MinutesUpDown";
            this.MinutesUpDown.Size = new System.Drawing.Size(40, 20);
            this.MinutesUpDown.TabIndex = 17;
            this.MinutesUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MinutesUpDown.ValueChanged += new System.EventHandler(this.MinutesSettingChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "minut";
            // 
            // EditQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(629, 419);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MinutesUpDown);
            this.Controls.Add(this.TimeLimitedCheckbox);
            this.Controls.Add(this.NegativePointsCheckbox);
            this.Controls.Add(this.SelectedQuestionLabel);
            this.Controls.Add(this.ContentLabel);
            this.Controls.Add(this.EditQuestionPanel);
            this.Controls.Add(this.RemoveQuestionButton);
            this.Controls.Add(this.AddQuestionButton);
            this.Controls.Add(this.QuestionsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuizTitleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveQuizButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditQuizForm";
            this.Text = "Edycja quizu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizEditorFormClosing);
            this.Load += new System.EventHandler(this.QuizEditorFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveQuizButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QuizTitleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView QuestionsList;
        private System.Windows.Forms.Button AddQuestionButton;
        private System.Windows.Forms.Button RemoveQuestionButton;
        private System.Windows.Forms.Panel EditQuestionPanel;
        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.Label SelectedQuestionLabel;
        private System.Windows.Forms.CheckBox NegativePointsCheckbox;
        private System.Windows.Forms.CheckBox TimeLimitedCheckbox;
        private System.Windows.Forms.NumericUpDown MinutesUpDown;
        private System.Windows.Forms.Label label3;
    }
}