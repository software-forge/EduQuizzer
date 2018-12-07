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
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedQuestionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveQuizButton
            // 
            this.SaveQuizButton.Location = new System.Drawing.Point(546, 316);
            this.SaveQuizButton.Name = "SaveQuizButton";
            this.SaveQuizButton.Size = new System.Drawing.Size(75, 23);
            this.SaveQuizButton.TabIndex = 0;
            this.SaveQuizButton.Text = "Zapisz";
            this.SaveQuizButton.UseVisualStyleBackColor = true;
            this.SaveQuizButton.Click += new System.EventHandler(this.SaveQuizButton_Click);
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
            this.QuestionsList.Size = new System.Drawing.Size(145, 191);
            this.QuestionsList.TabIndex = 4;
            this.QuestionsList.UseCompatibleStateImageBehavior = false;
            this.QuestionsList.SelectedIndexChanged += new System.EventHandler(this.QuestionsList_SelectedIndexChanged);
            // 
            // AddQuestionButton
            // 
            this.AddQuestionButton.Location = new System.Drawing.Point(91, 287);
            this.AddQuestionButton.Name = "AddQuestionButton";
            this.AddQuestionButton.Size = new System.Drawing.Size(70, 23);
            this.AddQuestionButton.TabIndex = 5;
            this.AddQuestionButton.Text = "+";
            this.AddQuestionButton.UseVisualStyleBackColor = true;
            this.AddQuestionButton.Click += new System.EventHandler(this.AddQuestionButton_Click);
            // 
            // RemoveQuestionButton
            // 
            this.RemoveQuestionButton.Location = new System.Drawing.Point(12, 287);
            this.RemoveQuestionButton.Name = "RemoveQuestionButton";
            this.RemoveQuestionButton.Size = new System.Drawing.Size(70, 23);
            this.RemoveQuestionButton.TabIndex = 6;
            this.RemoveQuestionButton.Text = "-";
            this.RemoveQuestionButton.UseVisualStyleBackColor = true;
            this.RemoveQuestionButton.Click += new System.EventHandler(this.RemoveQuestionButton_Click);
            // 
            // EditQuestionPanel
            // 
            this.EditQuestionPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.EditQuestionPanel.Location = new System.Drawing.Point(168, 73);
            this.EditQuestionPanel.Name = "EditQuestionPanel";
            this.EditQuestionPanel.Size = new System.Drawing.Size(453, 237);
            this.EditQuestionPanel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Edycja pytania";
            // 
            // SelectedQuestionLabel
            // 
            this.SelectedQuestionLabel.AutoSize = true;
            this.SelectedQuestionLabel.Location = new System.Drawing.Point(16, 271);
            this.SelectedQuestionLabel.Name = "SelectedQuestionLabel";
            this.SelectedQuestionLabel.Size = new System.Drawing.Size(0, 13);
            this.SelectedQuestionLabel.TabIndex = 9;
            // 
            // EditQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 345);
            this.Controls.Add(this.SelectedQuestionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EditQuestionPanel);
            this.Controls.Add(this.RemoveQuestionButton);
            this.Controls.Add(this.AddQuestionButton);
            this.Controls.Add(this.QuestionsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuizTitleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveQuizButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditQuizForm";
            this.Text = "Edycja quizu";
            this.Load += new System.EventHandler(this.QuizEditorForm_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SelectedQuestionLabel;
    }
}