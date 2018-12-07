using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EduQuizzer
{
    public partial class InitialForm : Form
    {
        public List <Quiz> Quizzes { get; set; }
        public int SelectedQuiz { get; set; }

        public InitialForm()
        {
            InitializeComponent();

            // Inicjalizacja pól klasy
            Quizzes = new List<Quiz>();
            SelectedQuiz = 0;

            // Wczytanie quizów z pliku
            LoadQuizzes();
        }

        /*
            Obsługa podstawowych zdarzeń formularza 
        */

        private void InitialForm_Closed(object sender, FormClosedEventArgs e)
        {

        }

        private void InitialForm_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            
        }

        private void InitialForm_Shown(object sender, EventArgs e)
        {

        }

        /*
            Obsługa zdarzeń kontrolek 
        */

        private void RunQuizButton_Click(object sender, EventArgs e)
        {

        }

        private void EditQuizButton_Click(object sender, EventArgs e)
        {
            if (Quizzes.Count < 1)
                return;

            Hide();
            EditQuizForm editForm = new EditQuizForm(Quizzes[SelectedQuiz]);
            editForm.FormClosed += BackToInitialForm;
            editForm.Show();
        }

        private void DeleteQuizButton_Click(object sender, EventArgs e)
        {
            if (Quizzes.Count < 1)
                return;

            // Wyświetlenie okna dialogowego z potwierdzeniem
            string caption = "Zatwierdź usunięcie quizu";
            string confirm = "Czy na pewno chcesz usunąć quiz o nazwie '" + Quizzes[SelectedQuiz].Title + "'?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if(MessageBox.Show(confirm, caption, buttons) == DialogResult.Yes)
            {
                Quizzes.RemoveAt(SelectedQuiz);
                SelectedQuiz = 0;
                RefreshListView();
                RefreshLabel();
            }
        }

        private void AddQuizButton_Click(object sender, EventArgs e)
        {
            Hide();
            Quizzes.Add(new Quiz());
            SelectedQuiz = Quizzes.Count - 1;
            EditQuizForm addForm = new EditQuizForm(Quizzes[SelectedQuiz]);
            addForm.FormClosed += BackToInitialForm;
            addForm.Show();
        }

        private void QuizzesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QuizzesList.SelectedIndices.Count > 0)
                SelectedQuiz = QuizzesList.SelectedIndices[0];
            else
                SelectedQuiz = 0;
            RefreshLabel();
        }

        /*
            Metody prywatne formularza 
        */

        private void RefreshLabel()
        {
            if (Quizzes.Count > 0)
                selectedLabel.Text = Quizzes[SelectedQuiz].Title;
            else
                selectedLabel.Text = "";
        }

        private void RefreshListView()
        {
            QuizzesList.Items.Clear();
            foreach (Quiz q in Quizzes)
                QuizzesList.Items.Add(q.Title);
            QuizzesList.Refresh();
        }

        // Obsługa zdarzenia zamknięcia formularza-dziecka i powrotu do bieżącego formularza
        private void BackToInitialForm(object sender, FormClosedEventArgs e)
        {
            // Odświeżenie elementów formularza
            RefreshListView();
            RefreshLabel();

            //Pokazanie formularza
            Show();
        }

        /*
            Metody dostępu do danych 
        */

        // Zapisanie quizów do pliku XML - TODO
        private void SaveQuizzes()
        {

        }

        // Wczytanie quizów z pliku XML - TODO
        private void LoadQuizzes()
        {

        }


    }
}
