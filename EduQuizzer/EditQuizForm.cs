using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace EduQuizzer
{
    public partial class EditQuizForm : Form
    {
        // Quiz aktualnie edytowany
        public Quiz EditedQuiz { get; private set; }

        // Indeks aktualnie edytowanego pytania
        public int EditedQuestionIndex { get; set; }

        private NewQuestionForm NewQuestionForm;
        
        // Parametry nowego pytania 
        public int QuestionType { get; set; }
        public int AnswersCount { get; set; }

        // Obiekty interfejsu użytkownika należące do panelu edycji pytania 
        private TextBox ContentBox { get; set; }
        private List <TextBox> AnswerBoxes { get; set; }
        private CheckBoxGroup CheckBoxGroup { get; set; }

        public EditQuizForm(Quiz q)
        {
            InitializeComponent();

            EditedQuiz = q;
            EditedQuestionIndex = -1; // Wartość domyślna, żaden element listy nie zaznaczony

            NegativePointsCheckbox.Checked = q.NegativePoints;
            TimeLimitedCheckbox.Checked = q.TimeLimited;
        }

        /*
            Metody obsługi zdarzeń kontrolek formularza 
        */

        // DONE
        private void QuizEditorFormLoad(object sender, EventArgs e)
        {
            QuizTitleBox.Text = EditedQuiz.Title;
            RefreshListView();
            RefreshLabel();
            RefreshQuestionPanel();
        }

        // DONE
        private void QuizEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateQuizData();
        }

        // DONE
        private void QuestionsListSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuizData();

            if (QuestionsList.SelectedIndices.Count > 0)
                EditedQuestionIndex = QuestionsList.SelectedIndices[0];
            else
                EditedQuestionIndex = -1;

            RefreshLabel();
            RefreshQuestionPanel();
        }

        // DONE
        private void RemoveQuestionButtonClick(object sender, EventArgs e)
        {
            if(EditedQuestionIndex > -1)
            {
                EditedQuiz.Questions.RemoveAt(EditedQuestionIndex);
                EditedQuestionIndex = -1;

                for (int i = 0; i < EditedQuiz.QuestionsCount; i++)
                    EditedQuiz.Questions[i].Number = i + 1;

                RefreshListView();
                RefreshLabel();
                RefreshQuestionPanel();
            }
        }

        // DONE
        private void AddQuestionButtonClick(object sender, EventArgs e)
        {
            if(EditedQuiz.QuestionsCount < Quiz.MaxQuestions)
            {
                UpdateQuizData();

                NewQuestionForm = new NewQuestionForm();
                NewQuestionForm.FormClosing += AddQuestion;

                Hide();
                NewQuestionForm.Show();
            }
            else
            {
            // TODO - jakiś dialog

            if(Debugger.IsAttached)
            {
                Debug.WriteLine("Osiągnięto maksymalną ilość pytań!");
            }
            }
            
        }

        // DONE
        private void SaveQuizButtonClick(object sender, EventArgs e)
        {
            UpdateQuizData();
            Close();
        }

        /*
            Metody prywatne odświeżające elementy interfejsu 
        */

        // DONE
        private void RefreshLabel()
        {
            if (EditedQuiz.Questions.Count == 0)
                SelectedQuestionLabel.Text = "Brak pytań";
            else if (EditedQuestionIndex == -1)
                SelectedQuestionLabel.Text = "Pytanie:";
            else
                SelectedQuestionLabel.Text = string.Format("Pytanie: {0}", EditedQuiz.Questions[EditedQuestionIndex].Number);
        }

        // DONE
        private void RefreshListView()
        {
            QuestionsList.Items.Clear();

            foreach (Question q in EditedQuiz.Questions)
                QuestionsList.Items.Add(string.Format("Pytanie {0}", q.Number));

            QuestionsList.Refresh();
        }

        // DONE
        private void RefreshQuestionPanel()
        {
            EditQuestionPanel.Controls.Clear();

            // Żadne pytanie nie jest zaznaczone
            if (EditedQuestionIndex == -1)
                return;

            // Nie ma żadnych pytań
            if (EditedQuiz.QuestionsCount == 0)
                return;

            Question q = EditedQuiz.Questions[EditedQuestionIndex];

            ContentBox = new TextBox();
            ContentBox.Text = q.Content;
            ContentBox.Left = 10;
            ContentBox.Top = 10;
            ContentBox.Multiline = true;
            ContentBox.Width = 420;
            ContentBox.Height = 100;
            EditQuestionPanel.Controls.Add(ContentBox);

            AnswerBoxes = new List <TextBox> (q.AnswersCapacity);

            int answerbox_top = 90;
            for(int i = 0; i < q.AnswersCapacity; i++)
            {
                TextBox t = new TextBox();
                t.Top = (answerbox_top += 30);
                t.Left = 10;
                t.Width = 380;
                t.Text = q.Answers[i];

                if (q is BinaryQuestion)
                    t.Enabled = false;
                    
                AnswerBoxes.Add(t);
            }   

            if(q is MultiSelectionQuestion)
            {
                CheckBoxGroup = new CheckBoxGroup(q.AnswersCapacity, q.CorrectAnswers, CheckBoxGroupBehavior.MultiSelection);

                //Debug.Write("Indices passed to CheckBox group: ");
                //foreach (int i in CheckBoxGroup.SelectedIndices)
                //    Debug.Write(string.Format("{0} ", i));
                //Debug.WriteLine("");
            }

            if(q is SingleSelectionQuestion || q is BinaryQuestion)
            {
                CheckBoxGroup = new CheckBoxGroup(q.AnswersCapacity, q.CorrectAnswers, CheckBoxGroupBehavior.SingleSelection);
            }

            // Dodanie kontrolek do panelu

            EditQuestionPanel.Controls.Add(ContentBox);

            for(int i = 0; i < q.AnswersCapacity; i++)
                EditQuestionPanel.Controls.Add(AnswerBoxes[i]);

            CheckBoxGroup.AddToPanel(EditQuestionPanel, 400, 90, 30);
        }

        // DONE
        private void UpdateQuizData()
        {
            EditedQuiz.Title = QuizTitleBox.Text;

            // Żadne pytanie nie jest zaznaczone
            if (EditedQuestionIndex == -1)
                return;

            // Nie ma żadnych pytań
            if (EditedQuiz.QuestionsCount == 0)
                return;

            EditedQuiz.Questions[EditedQuestionIndex].Content = ContentBox.Text;

            for (int i = 0; i < AnswerBoxes.Count; i++)
                EditedQuiz.Questions[EditedQuestionIndex].SetAnswerContent(AnswerBoxes[i].Text, i);

            EditedQuiz.Questions[EditedQuestionIndex].CorrectAnswers = CheckBoxGroup.SelectedIndices;
        }

        // DONE
        private void AddQuestion(object sender, FormClosingEventArgs e)
        {
            if (NewQuestionForm.Cancelled)
                return;

            QuestionType = NewQuestionForm.QuestionType;
            AnswersCount = NewQuestionForm.AnswerCount;

            Question q;

            switch(QuestionType)
            {
                case 0:
                    q = new SingleSelectionQuestion(AnswersCount);
                    q.Number = EditedQuiz.Questions.Count + 1;
                    EditedQuiz.Questions.Add(q);
                    break;
                case 1:
                    q = new MultiSelectionQuestion(AnswersCount);
                    q.Number = EditedQuiz.Questions.Count + 1;
                    EditedQuiz.Questions.Add(q);
                    break;
                case 2:
                    q = new BinaryQuestion();
                    q.Number = EditedQuiz.Questions.Count + 1;
                    EditedQuiz.Questions.Add(q);
                    break;
            }

            Show();
            RefreshListView();
            RefreshLabel();
        }

        private void NegativePointsChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            EditedQuiz.NegativePoints = checkBox.Checked;
        }

        private void TimeLimitedCheckedChanged(object sender, EventArgs e)
        {
            EditedQuiz.TimeLimited = TimeLimitedCheckbox.Checked;
        }
    }
}
