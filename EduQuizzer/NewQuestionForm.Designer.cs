namespace EduQuizzer
{
    partial class NewQuestionForm
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
            this.questionTypeBox = new System.Windows.Forms.ComboBox();
            this.answersNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.answersNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // questionTypeBox
            // 
            this.questionTypeBox.FormattingEnabled = true;
            this.questionTypeBox.Items.AddRange(new object[] {
            "Jednokrotnego wyboru",
            "Wielokrotnego wyboru",
            "Binarne (tak/nie)"});
            this.questionTypeBox.Location = new System.Drawing.Point(115, 12);
            this.questionTypeBox.Name = "questionTypeBox";
            this.questionTypeBox.Size = new System.Drawing.Size(140, 21);
            this.questionTypeBox.TabIndex = 0;
            this.questionTypeBox.SelectedIndexChanged += new System.EventHandler(this.QuestionTypeBoxSelectedIndexChanged);
            // 
            // answersNumberBox
            // 
            this.answersNumberBox.Location = new System.Drawing.Point(115, 39);
            this.answersNumberBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.answersNumberBox.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.answersNumberBox.Name = "answersNumberBox";
            this.answersNumberBox.Size = new System.Drawing.Size(140, 20);
            this.answersNumberBox.TabIndex = 1;
            this.answersNumberBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.answersNumberBox.ValueChanged += new System.EventHandler(this.AnswersNumberBoxValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rodzaj pytania:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Liczba odpowiedzi:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 67);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(180, 67);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Dodaj";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // EditQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 102);
            this.ControlBox = false;
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.answersNumberBox);
            this.Controls.Add(this.questionTypeBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditQuestionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dodawanie pytania";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EditQuestionFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.answersNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox questionTypeBox;
        private System.Windows.Forms.NumericUpDown answersNumberBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button AddButton;
    }
}