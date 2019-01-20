using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

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
        }

    /*
        Obsługa podstawowych zdarzeń formularza 
    */

        private void InitialFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveQuizzes();
        }

        private void InitialFormLoad(object sender, EventArgs e)
        {
            // Wczytanie quizów z plików XML na osobnym wątku (żeby aplikacja nie była "zamrożona", jeżeli ta operacja zajmie długo)
            SelectedLabel.Text = "Wczytywanie quizów...";
            Thread loadThread = new Thread(new ThreadStart(LoadQuizzes));
            loadThread.Start();
        }


        /*
            Obsługa zdarzeń kontrolek 
        */

        private void RunQuizButtonClick(object sender, EventArgs e)
        {
            if (Quizzes.Count < 1)
                return;

            Hide();
            RunQuizForm runForm = new RunQuizForm(Quizzes[SelectedQuiz]);
            runForm.FormClosed += BackToInitialForm;
            runForm.Show();
        }

        private void EditQuizButtonClick(object sender, EventArgs e)
        {
            if (Quizzes.Count < 1)
                return;

            Hide();
            EditQuizForm editForm = new EditQuizForm(Quizzes[SelectedQuiz]);
            editForm.FormClosed += BackToInitialForm;
            editForm.Show();
        }

        private void DeleteQuizButtonClick(object sender, EventArgs e)
        {
            if (Quizzes.Count < 1)
                return;

            // Wyświetlenie okna dialogowego z potwierdzeniem
            string caption = "Zatwierdź usunięcie quizu";
            string confirm = "Czy na pewno chcesz usunąć quiz o nazwie '" + Quizzes[SelectedQuiz].Title + "'?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (MessageBox.Show(confirm, caption, buttons) == DialogResult.Yes)
            {
                Quizzes.RemoveAt(SelectedQuiz);
                SelectedQuiz = 0;
                RefreshListView();
                RefreshLabel();
            }
        }

        private void AddQuizButtonClick(object sender, EventArgs e)
        {
            Quizzes.Add(new Quiz());
            SelectedQuiz = Quizzes.Count - 1;

            Hide();
            EditQuizForm addForm = new EditQuizForm(Quizzes[SelectedQuiz]);
            addForm.FormClosed += BackToInitialForm;
            addForm.Show();
        }

        private void QuizzesListSelectedIndexChanged(object sender, EventArgs e)
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
            if(SelectedLabel.InvokeRequired)
            {
                // Wywołano z innego wątku
                SelectedLabel.Invoke((MethodInvoker) delegate
                {
                    if (Quizzes.Count > 0)
                        SelectedLabel.Text = Quizzes[SelectedQuiz].Title;
                    else
                        SelectedLabel.Text = "";
                });
            }
            else
            {
                // Wywołano z głównego wątku
                if (Quizzes.Count > 0)
                    SelectedLabel.Text = Quizzes[SelectedQuiz].Title;
                else
                    SelectedLabel.Text = "";
            }
        }

        private void RefreshListView()
        {
            if(QuizzesList.InvokeRequired)
            {
                // Wywołano z innego wątku
                QuizzesList.Invoke((MethodInvoker) delegate
                {
                    QuizzesList.Items.Clear();

                    foreach (Quiz q in Quizzes)
                        QuizzesList.Items.Add(q.Title);

                    QuizzesList.Refresh();
                });
            }
            else
            {
                // Wywołano z głównego wątku
                QuizzesList.Items.Clear();

                foreach (Quiz q in Quizzes)
                    QuizzesList.Items.Add(q.Title);

                QuizzesList.Refresh();
            }
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

        // Zapisanie quizów do pliku XML
        private void SaveQuizzes()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            XmlWriter writer = XmlWriter.Create("quizzes.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Quizzes");
            foreach(Quiz quiz in Quizzes)
            {
                writer.WriteStartElement("Quiz");
                writer.WriteAttributeString("title", quiz.Title);
                foreach(Question question in quiz.Questions)
                {
                    writer.WriteStartElement("Question");
                    for(int i = 0; i < question.AnswersCount; i++)
                    {
                        writer.WriteStartElement("Answer");
                        if (question.CorrectAnswers.Contains(i))
                            writer.WriteAttributeString("correct", "true");
                        else
                            writer.WriteAttributeString("correct", "false");
                        writer.WriteString(question.Answers[i]);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        // Wczytanie zapisanych quizów z pliku XML - TODO
        private void LoadQuizzes()
        {
            try
            {
                Quiz quiz = new Quiz();

                XmlReader reader = XmlReader.Create("quizzes.xml");
                reader.MoveToContent();
                while (reader.Read())
                {
                    switch(reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            break;
                        case XmlNodeType.Attribute:
                            break;
                        case XmlNodeType.Text:
                            break;
                        case XmlNodeType.EndElement:
                            break;
                    }
                }
                reader.Close();
            }
            catch(FileNotFoundException e)
            {
                if (Debugger.IsAttached)
                    Debug.WriteLine("Plik nie istnieje!");
            }
            
            RefreshListView();
            RefreshLabel();
        }
    }
}
