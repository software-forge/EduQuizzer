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
        public Quiz RunningQuiz { get; private set; }

        public int SelectedQuestion { get; private set; }

        private ButtonGroup QuestionButtons { get; set; }

        public Question CurrentQuestion { get; private set; }

        private CheckBoxGroup CurrentQuestionAnswerCheckboxes { get; set; }
        private List <Label> CurrentQuestionAnswerLabels { get; set; }

        public RunQuizForm(Quiz q)
        {
            InitializeComponent();

            RunningQuiz = q;

            QuestionButtons = new ButtonGroup(RunningQuiz.QuestionsCount);
            Text = RunningQuiz.Title;
            SelectedQuestion = QuestionButtons.SelectedIndex;
        }

        private void RunQuizFormLoad(object sender, EventArgs e)
        {
            QuestionButtons.AddToPanel(ControlPanel, 10);
            QuestionButtons.SelectedButtonChangedEvent += SelectedQuestionChanged;

            ReloadQuestionPanel();
        }

        private void ReloadQuestionPanel()
        {
            QuestionPanel.Controls.Clear();

            Question q = RunningQuiz.Questions[SelectedQuestion];

            QuizTitleLabel.Text = RunningQuiz.Title;
            QuestionNumberLabel.Text = string.Format("Pytanie {0}", q.Number);
            QuestionContentBox.Text = q.Content;

            if(q is SingleSelectionQuestion || q is BinaryQuestion)
            {
                CurrentQuestionAnswerCheckboxes = new CheckBoxGroup(q.AnswersCount, CheckBoxGroupBehavior.SingleSelection);

                if (q is SingleSelectionQuestion)
                {
                    QuestionTypeLabel.Text = "Zaznacz prawidłową odpowiedź";
                }
                else
                {
                    QuestionTypeLabel.Text = "";
                }
            }

            if(q is MultiSelectionQuestion)
            {
                CurrentQuestionAnswerCheckboxes = new CheckBoxGroup(q.AnswersCount, CheckBoxGroupBehavior.MultiSelection);
                QuestionTypeLabel.Text = "Zaznacz wszystkie prawidłowe odpowiedzi";
            }

            CurrentQuestionAnswerCheckboxes.SelectedIndices = q.GivenAnswers;

            CurrentQuestionAnswerLabels = new List<Label>(q.AnswersCount);

            int label_top = 80;
            for(int i = 0; i < q.AnswersCount; i++)
            {
                CurrentQuestionAnswerLabels.Add(new Label());
                CurrentQuestionAnswerLabels[i].Text = q.Answers[i];
                CurrentQuestionAnswerLabels[i].Left = 520;
                CurrentQuestionAnswerLabels[i].Top = label_top;
                label_top += 30;
                QuestionPanel.Controls.Add(CurrentQuestionAnswerLabels[i]);
            }

            QuestionPanel.Controls.Add(QuizTitleLabel);
            QuestionPanel.Controls.Add(QuestionNumberLabel);
            QuestionPanel.Controls.Add(QuestionContentBox);
            QuestionPanel.Controls.Add(QuestionTypeLabel);

            CurrentQuestionAnswerCheckboxes.AddToPanel(QuestionPanel, 900, 50, 30);
        }

        public void SelectedQuestionChanged(object sender, SelectedButtonChangedEventArgs e)
        {
            RunningQuiz.Questions[SelectedQuestion].GivenAnswers = CurrentQuestionAnswerCheckboxes.SelectedIndices;

            SelectedQuestion = e.Selection;
            ReloadQuestionPanel();
        }

        private void NextButtonClicked(object sender, EventArgs e)
        {
            QuestionButtons.SelectNext();
        }

        private void PreviousButtonClicked(object sender, EventArgs e)
        {
            QuestionButtons.SelectPrevious();
        }

        
        private void EndQuiz(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                // Zakończenie quizu poprzez naciśnięcie przycisku

                DialogResult confirm = MessageBox.Show("Czy na pewno chcesz zakończyć quiz?", "Potwierdź zakończenie quizu", MessageBoxButtons.OKCancel);

                if (confirm == DialogResult.OK)
                {
                    // Punktacja quizu i wyświetlenie okna dialogowego z wynikiem
                    int score = RunningQuiz.Score();
                    int max_points = RunningQuiz.MaxPoints();
                    int percent = score * 100 / max_points;

                    DialogResult result = MessageBox.Show(string.Format("Zdobytych punktów: {0} ({1}%)", score, percent), "Podsumowanie");
                    Close();
                }
            }

            // TODO
            if(sender is Timer)
            {
                // Zakończenie quizu poprzez zdarzenie timera (koniec czasu)
            }
        }

    }
}
