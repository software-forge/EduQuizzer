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
            this.endQuizButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.previousButton = new System.Windows.Forms.Button();
            this.ControlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionPanel.Location = new System.Drawing.Point(12, 12);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.Size = new System.Drawing.Size(1900, 500);
            this.QuestionPanel.TabIndex = 0;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.panel1);
            this.ControlPanel.Location = new System.Drawing.Point(12, 518);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(1900, 150);
            this.ControlPanel.TabIndex = 1;
            // 
            // endQuizButton
            // 
            this.endQuizButton.Location = new System.Drawing.Point(200, 3);
            this.endQuizButton.Name = "endQuizButton";
            this.endQuizButton.Size = new System.Drawing.Size(190, 50);
            this.endQuizButton.TabIndex = 2;
            this.endQuizButton.Text = "Zakończ quiz";
            this.endQuizButton.UseVisualStyleBackColor = true;
            this.endQuizButton.Click += new System.EventHandler(this.EndQuizButtonClicked);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(395, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(190, 50);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Następne >>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButtonClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.previousButton);
            this.panel1.Controls.Add(this.nextButton);
            this.panel1.Controls.Add(this.endQuizButton);
            this.panel1.Location = new System.Drawing.Point(655, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 55);
            this.panel1.TabIndex = 3;
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(5, 3);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(190, 50);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "<< Poprzednie";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.PreviousButtonClicked);
            // 
            // RunQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 679);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.QuestionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunQuizForm";
            this.Text = "RunQuizForm";
            this.Load += new System.EventHandler(this.RunQuizFormLoad);
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
    }
}