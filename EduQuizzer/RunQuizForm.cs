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
using EduQuizzer.Timing;

namespace EduQuizzer
{
    public partial class RunQuizForm : Form
    {
        public Quiz RunningQuiz { get; private set; }

        public int SelectedQuestion { get; private set; }

        private ButtonGroup QuestionButtons { get; set; }

        public Question CurrentQuestion { get; private set; }

        private List<Question> QuestionTemp { get; set; } // Przechowuje oryginalną kolejność pytań na liście

        private CheckBoxGroup CurrentQuestionAnswerCheckboxes { get; set; }
        private List <Label> CurrentQuestionAnswerLabels { get; set; }

        public CountdownTimer Timer;

        public RunQuizForm(Quiz q)
        {
            InitializeComponent();

            RunningQuiz = q;

            // Zachowanie oryginalnej kolejności pytań
            QuestionTemp = new List<Question>();
            foreach(Question question in RunningQuiz.Questions)
            {
                QuestionTemp.Add(question);
            }

            ShuffleQuestions();

            QuestionButtons = new ButtonGroup(RunningQuiz.QuestionsCount);
            Text = RunningQuiz.Title;
            SelectedQuestion = QuestionButtons.SelectedIndex;

            if(RunningQuiz.TimeLimited)
            {
                Timer = new CountdownTimer(RunningQuiz.TimeLimit);
                Timer.TimerTicked += UpdateTime;
                Timer.CountdownFinished += EndQuiz;
                DisplayTime();
            }
            else
            {
                MinutesLabel.Text = "";
                SecondsLabel.Text = "";
                ColonLabel.Text = "";
            }
        }

        private void RunQuizFormLoad(object sender, EventArgs e)
        {
            QuestionButtons.AddToPanel(ControlPanel, 10);
            QuestionButtons.SelectedButtonChanged += SelectedQuestionChanged;

            ReloadQuestionPanel();

            if(RunningQuiz.TimeLimited)
            {
                Timer.Start();
            }
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

        private void UpdateTime(object sender, EventArgs e)
        {
            DisplayTime();
        }

        private void EndQuiz(object sender, EventArgs e)
        {
            // Zakończenie quizu poprzez naciśnięcie przycisku
            if (sender is Button)
            {
                DialogResult confirm = MessageBox.Show("Czy na pewno chcesz zakończyć quiz?", "Potwierdź zakończenie quizu", MessageBoxButtons.OKCancel);

                if (confirm == DialogResult.OK)
                {
                    if (Timer != null)
                    {
                        Timer.Reset();
                    }

                    int score = RunningQuiz.Score(RunningQuiz.NegativePoints);
                    int max_points = RunningQuiz.MaxPoints();
                    int percent = score * 100 / max_points;

                    DialogResult result = MessageBox.Show(string.Format("Zdobytych punktów: {0} ({1}%)", score, percent), "Podsumowanie");
                    Close();
                }
            }

            // Zakończenie quizu poprzez zdarzenie timera (koniec czasu)
            if (sender is CountdownTimer)
            {
                int score = RunningQuiz.Score(RunningQuiz.NegativePoints);
                int max_points = RunningQuiz.MaxPoints();
                int percent = score * 100 / max_points;

                DialogResult result = MessageBox.Show(string.Format("Zdobytych punktów: {0} ({1}%)", score, percent), "Koniec czasu!");
                Close();
            }

            // Przywrócenie oryginalnej kolejności listy pytań
            RunningQuiz.Questions.Clear();
            foreach (Question question in QuestionTemp)
            {
                RunningQuiz.Questions.Add(question);
            }
        }

        private void ShuffleQuestions()
        {
            Random random = new Random();

            // Potasowanie referencji do obiektów pytań w liście RunningQuiz.Questions
            for(int i = 0; i < RunningQuiz.QuestionsCount; i++)
            {
                int position = random.Next(RunningQuiz.QuestionsCount - 2);

                Question q = RunningQuiz.Questions[position + 1];
                RunningQuiz.Questions[position + 1] = RunningQuiz.Questions[position];
                RunningQuiz.Questions[position] = q;
            }
        }

        /*
         * 
         * TODO - deaktywacja (i ponowna aktywacja) quizu w momentach, w których nie powinno być możliwe jego uzupełnianie
         * 
         * 1 - deaktywacja checkboxów bieżącego pytania
         * 2 - deaktywacja przycisków przełączania pytań
         * 
         */

        private void Deactivate()
        {

        }

        private void Activate()
        {

        }

        private void ReloadQuestionPanel()
        {
            QuestionPanel.Controls.Clear();

            Question q = RunningQuiz.Questions[SelectedQuestion];

            QuizTitleLabel.Text = RunningQuiz.Title;
            QuestionContentBox.Text = q.Content;

            if (q is SingleSelectionQuestion || q is BinaryQuestion)
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

            if (q is MultiSelectionQuestion)
            {
                CurrentQuestionAnswerCheckboxes = new CheckBoxGroup(q.AnswersCount, CheckBoxGroupBehavior.MultiSelection);
                QuestionTypeLabel.Text = "Zaznacz wszystkie prawidłowe odpowiedzi";
            }

            CurrentQuestionAnswerCheckboxes.SelectedIndices = q.GivenAnswers;

            CurrentQuestionAnswerLabels = new List<Label>(q.AnswersCount);

            int label_top = 80;
            for (int i = 0; i < q.AnswersCount; i++)
            {
                CurrentQuestionAnswerLabels.Add(new Label());
                CurrentQuestionAnswerLabels[i].Text = q.Answers[i];
                CurrentQuestionAnswerLabels[i].Left = 520;
                CurrentQuestionAnswerLabels[i].Top = label_top;
                label_top += 30;
                QuestionPanel.Controls.Add(CurrentQuestionAnswerLabels[i]);
            }

            QuestionPanel.Controls.Add(QuizTitleLabel);
            QuestionPanel.Controls.Add(QuestionContentBox);
            QuestionPanel.Controls.Add(QuestionTypeLabel);

            CurrentQuestionAnswerCheckboxes.AddToPanel(QuestionPanel, 900, 50, 30);
        }

        private void DisplayTime()
        {
            string minutes;
            if (Timer.MinutesLeft < 10)
            {
                minutes = string.Format("0{0}", Timer.MinutesLeft);
            }
            else
            {
                minutes = Convert.ToString(Timer.MinutesLeft);
            }
            MinutesLabel.Text = minutes;

            ColonLabel.Text = ":";

            string seconds;
            if (Timer.SecondsLeft < 10)
            {
                seconds = string.Format("0{0}", Timer.SecondsLeft);
            }
            else
            {
                seconds = Convert.ToString(Timer.SecondsLeft);
            }
            SecondsLabel.Text = seconds;
        }
    }
}
