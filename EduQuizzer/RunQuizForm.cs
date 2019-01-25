using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuizzer
{
    public partial class RunQuizForm : Form
    {
        public Quiz QuizRunning { get; private set; }

        public int SelectedQuestion { get; private set; }

        private ButtonGroup QuestionButtons { get; set; }

        public RunQuizForm(Quiz q)
        {
            InitializeComponent();

            QuizRunning = q;

            QuestionButtons = new ButtonGroup(QuizRunning.QuestionsCount);
            Text = QuizRunning.Title;
            SelectedQuestion = QuestionButtons.SelectedIndex;
        }

        private void RunQuizFormLoad(object sender, EventArgs e)
        {
            QuestionButtons.AddToPanel(ControlPanel, 10);
            QuestionButtons.SelectionChangedEvent += SelectedQuestionChanged;
        }

        // TODO - zapełnienie panelu QuestionPanel danymi dla pytania q.Questions[SelectedQuestion]
        private void ReloadQuestionPanel() {}

        public void SelectedQuestionChanged(object sender, SelectedButtonChangedArgs e)
        {
            SelectedQuestion = e.Selection;
            ReloadQuestionPanel();

            if (Debugger.IsAttached)
            {
                Debug.WriteLine(string.Format("Indeks zaznaczonego przycisku: {0} (SelectedButtonChangedArgs)", e.Selection));
                Debug.WriteLine(string.Format("Indeks zaznaczonego pytania: {0} (RunQuizForm)", SelectedQuestion));
            }
        }

        private void NextButtonClicked(object sender, EventArgs e)
        {
            QuestionButtons.SelectNext();
        }

        private void PreviousButtonClicked(object sender, EventArgs e)
        {
            QuestionButtons.SelectPrevious();
        }

        // TODO
        private void EndQuizButtonClicked(object sender, EventArgs e) {}

    }
}
