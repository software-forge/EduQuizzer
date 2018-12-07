using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EduQuizzer
{
    public partial class EditQuizForm : Form
    {
        /*
            Quiz aktualnie edytowany 
        */
        public Quiz EditedQuiz { get; private set; }
        public int EditedQuestion { get; set; }

        private int SelectedQuestionIndex { get; set; }

        private NewQuestionForm NewQuestionForm;

        /*
            Parametry nowego pytania 
        */
        public int QuestionType { get; set; }
        public int AnswersCount { get; set; }

        public EditQuizForm(Quiz q)
        {
            InitializeComponent();
            EditedQuiz = q;

            QuestionType = 0;
            AnswersCount = 3;
        }

        private void QuizEditorForm_Load(object sender, EventArgs e)
        {
            // Wypełnienie formularza zgodnie z wartościami elementów obiektu EditedQuiz
            QuizTitleBox.Text = EditedQuiz.Title;
            SelectedQuestionIndex = 0;
            RefreshListView();
        }

        private void QuestionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QuestionsList.SelectedIndices.Count > 0)
                SelectedQuestionIndex = QuestionsList.SelectedIndices[0];
            else
                SelectedQuestionIndex = 0;
            RefreshLabel();
        }

        private void RemoveQuestionButton_Click(object sender, EventArgs e)
        {

        }

        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            NewQuestionForm = new NewQuestionForm();
            NewQuestionForm.FormClosing += AddQuestion;

            Hide();
            NewQuestionForm.Show();
        }

        private void RefreshLabel()
        {
            SelectedQuestionLabel.Text = string.Format("Pytanie: {0}", EditedQuiz.Questions[SelectedQuestionIndex].Number);
        }

        private void RefreshListView()
        {
            QuestionsList.Items.Clear();
            foreach (Question q in EditedQuiz.Questions)
                QuestionsList.Items.Add(Convert.ToString(q.Number));
            QuestionsList.Refresh();
        }

        private void RefreshQuestionPanel()
        {
            /* 
                TODO - zapełnienie panelu edycji w zależności od zaznaczonego na liście pytania
            */

        }

        private void AddQuestion(Object sender, FormClosingEventArgs e)
        {
            if (NewQuestionForm.Cancelled)
                return;

            QuestionType = NewQuestionForm.QuestionType;
            AnswersCount = NewQuestionForm.AnswerCount;

            switch(QuestionType)
            {
                case 0:
                    EditedQuiz.Questions.Add(new SingleSelectionQuestion(AnswersCount, 0));
                    break;
                case 1:
                    EditedQuiz.Questions.Add(new MultiSelectionQuestion(AnswersCount));
                    break;
                case 2:
                    EditedQuiz.Questions.Add(new BinaryQuestion(false));
                    break;
            }

            EditedQuestion = EditedQuiz.Questions.Count - 1;
            EditedQuiz.Questions[EditedQuestion].Number = EditedQuestion + 1;

            RefreshListView();
            RefreshQuestionPanel();

            Show();
        }

        private void SaveQuizButton_Click(object sender, EventArgs e)
        {
            // Zapisanie danych z elementów formularza do pól obiektu
            if (QuizTitleBox.Text.Equals(""))
                EditedQuiz.Title = "<nowy quiz>";
            else
                EditedQuiz.Title = QuizTitleBox.Text;

            // Zamknięcie formularza
            Close();
        }


    }
}
