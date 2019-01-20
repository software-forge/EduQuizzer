﻿namespace EduQuizzer
{
    partial class InitialForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.RunQuizButton = new System.Windows.Forms.Button();
            this.AddQuizButton = new System.Windows.Forms.Button();
            this.QuizzesList = new System.Windows.Forms.ListView();
            this.EditQuizButton = new System.Windows.Forms.Button();
            this.DeleteQuizButton = new System.Windows.Forms.Button();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RunQuizButton
            // 
            this.RunQuizButton.Location = new System.Drawing.Point(24, 454);
            this.RunQuizButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RunQuizButton.Name = "RunQuizButton";
            this.RunQuizButton.Size = new System.Drawing.Size(400, 44);
            this.RunQuizButton.TabIndex = 0;
            this.RunQuizButton.Text = "Uruchom";
            this.RunQuizButton.UseVisualStyleBackColor = true;
            this.RunQuizButton.Click += new System.EventHandler(this.RunQuizButtonClick);
            // 
            // AddQuizButton
            // 
            this.AddQuizButton.Location = new System.Drawing.Point(24, 621);
            this.AddQuizButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AddQuizButton.Name = "AddQuizButton";
            this.AddQuizButton.Size = new System.Drawing.Size(400, 44);
            this.AddQuizButton.TabIndex = 1;
            this.AddQuizButton.Text = "Dodaj quiz";
            this.AddQuizButton.UseVisualStyleBackColor = true;
            this.AddQuizButton.Click += new System.EventHandler(this.AddQuizButtonClick);
            // 
            // QuizzesList
            // 
            this.QuizzesList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.QuizzesList.HideSelection = false;
            this.QuizzesList.Location = new System.Drawing.Point(24, 23);
            this.QuizzesList.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.QuizzesList.MultiSelect = false;
            this.QuizzesList.Name = "QuizzesList";
            this.QuizzesList.Size = new System.Drawing.Size(396, 381);
            this.QuizzesList.TabIndex = 2;
            this.QuizzesList.UseCompatibleStateImageBehavior = false;
            this.QuizzesList.View = System.Windows.Forms.View.List;
            this.QuizzesList.SelectedIndexChanged += new System.EventHandler(this.QuizzesListSelectedIndexChanged);
            // 
            // EditQuizButton
            // 
            this.EditQuizButton.Location = new System.Drawing.Point(24, 510);
            this.EditQuizButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.EditQuizButton.Name = "EditQuizButton";
            this.EditQuizButton.Size = new System.Drawing.Size(400, 44);
            this.EditQuizButton.TabIndex = 3;
            this.EditQuizButton.Text = "Edytuj";
            this.EditQuizButton.UseVisualStyleBackColor = true;
            this.EditQuizButton.Click += new System.EventHandler(this.EditQuizButtonClick);
            // 
            // DeleteQuizButton
            // 
            this.DeleteQuizButton.Location = new System.Drawing.Point(24, 565);
            this.DeleteQuizButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DeleteQuizButton.Name = "DeleteQuizButton";
            this.DeleteQuizButton.Size = new System.Drawing.Size(400, 44);
            this.DeleteQuizButton.TabIndex = 4;
            this.DeleteQuizButton.Text = "Usuń";
            this.DeleteQuizButton.UseVisualStyleBackColor = true;
            this.DeleteQuizButton.Click += new System.EventHandler(this.DeleteQuizButtonClick);
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.AutoSize = true;
            this.SelectedLabel.Location = new System.Drawing.Point(24, 413);
            this.SelectedLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(0, 25);
            this.SelectedLabel.TabIndex = 5;
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 688);
            this.Controls.Add(this.SelectedLabel);
            this.Controls.Add(this.DeleteQuizButton);
            this.Controls.Add(this.EditQuizButton);
            this.Controls.Add(this.QuizzesList);
            this.Controls.Add(this.AddQuizButton);
            this.Controls.Add(this.RunQuizButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitialForm";
            this.Text = "EduQuizzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitialFormClosing);
            this.Load += new System.EventHandler(this.InitialFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunQuizButton;
        private System.Windows.Forms.Button AddQuizButton;
        private System.Windows.Forms.ListView QuizzesList;
        private System.Windows.Forms.Button EditQuizButton;
        private System.Windows.Forms.Button DeleteQuizButton;
        private System.Windows.Forms.Label SelectedLabel;
    }
}

