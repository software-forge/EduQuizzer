using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuizzer
{ 
    public partial class NewQuestionForm : Form
    {
        public int QuestionType { get; set; }
        public int AnswerCount { get; set; }

        public bool Cancelled { get; set; }

        public NewQuestionForm()
        {
            InitializeComponent();

            // Wartości domyślne parametrów nowego pytania
            QuestionType = 0;
            AnswerCount = 3;

            Cancelled = false;
        }

        private void EditQuestionForm_Load(object sender, EventArgs e)
        {
            questionTypeBox.SelectedIndex = QuestionType;
            SetAnswersNumberBox();
        }

        private void SetAnswersNumberBox()
        {
            switch (QuestionType)
            {
                case 0:
                    answersNumberBox.Enabled = true;
                    answersNumberBox.Minimum = 3;
                    answersNumberBox.Maximum = 6;
                    answersNumberBox.Value = 3;
                    break;
                case 1:
                    answersNumberBox.Enabled = true;
                    answersNumberBox.Minimum = 3;
                    answersNumberBox.Maximum = 6;
                    answersNumberBox.Value = 3;
                    break;
                case 2:
                    answersNumberBox.Enabled = false;
                    answersNumberBox.Minimum = 2;
                    answersNumberBox.Maximum = 2;
                    answersNumberBox.Value = 2;
                    break;
            }
        }

        private void QuestionTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestionType = questionTypeBox.SelectedIndex;
            SetAnswersNumberBox();
        }

        private void AnswersNumberBox_ValueChanged(object sender, EventArgs e)
        {
            AnswerCount = (int) answersNumberBox.Value;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            Close();
        }
    }
}
