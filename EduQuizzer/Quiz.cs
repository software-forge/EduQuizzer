using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EduQuizzer
{
    public interface IScorable
    {
        int Score(bool count_neg);
    }

    public abstract class Question : IScorable
    {
        private int number;

        /// <summary>
        /// Numer porządkowy pytania
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 1)
                    number = value;
                else
                    number = 1;
            }
        }

        private string _content;

        /// <summary>
        /// Treść pytania
        /// </summary>
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (value.Equals(""))
                    _content = "Treść pytania...";
                else
                    _content = value;
            }
        }

        /// <summary>
        /// Lista treści możliwych odpowiedzi
        /// </summary>
        public List <string> Answers;

        /// <summary>
        /// Przekierowanie do Answers.Capacity
        /// </summary>
        public int AnswersCapacity
        {
            get
            {
                return Answers.Capacity;
            }
        }

        /// <summary>
        /// Przekierowanie do Answers.Count
        /// </summary>
        public int AnswersCount
        {
            get
            {
                return Answers.Count;
            }
        }
 
        protected List <int> correct_answers, given_answers;

        /// <summary>
        /// Lista indeksów poprawnych odpowiedzi
        /// </summary>
        public abstract List <int> CorrectAnswers { get; set; }

        /// <summary>
        ///  Lista indeksów odpowiedzi wskazanych jako poprawne
        /// </summary>
        public abstract List <int> GivenAnswers { get; set; }

        /// <summary>
        /// Ustawia treść odpowiedzi o wskazanym indeksie
        /// </summary>
        /// <param name="content">Treść odpowiedzi</param>
        /// <param name="answer_index">Indeks odpowiedzi w liście Answers</param>
        public void SetAnswerContent(string content, int answer_index)
        {
            if(answer_index > -1 && answer_index < AnswersCapacity)
            {
                if (content.Equals(""))
                    Answers[answer_index] = string.Format("Odpowiedź {0}", answer_index + 1);
                else
                    Answers[answer_index] = content;
            }
        }

        /// <summary>
        /// Tworzy nowy obiekt klasy Question
        /// </summary>
        /// <param name="answer_count">Ilość możliwych do zaznaczenia odpowiedzi na pytanie</param>
        public Question(int answer_count)
        {
            Content = "Treść pytania...";
            Answers = new List <string> (answer_count);
            for (int i = 0; i < AnswersCapacity; i++)
            {
                Answers.Add(string.Format("Odpowiedź {0}", i + 1));
            }
        }

        /// <summary>
        /// Ilość punktów otrzymanych w wyniku odpowiedzi na pytanie
        /// </summary>
        /// <param name="negative">Informacja, czy przy punktacji stosować punkty ujemne</param>
        /// <returns>Otrzymane punkty</returns>
        public abstract int Score(bool negative);
    }

    public class MultiSelectionQuestion : Question
    {
        public override List <int> CorrectAnswers
        {
            get
            {
                return correct_answers;
            }
            set
            {
                if (value.Capacity <= AnswersCapacity && value.Count <= AnswersCount)
                    correct_answers = value;
            }
        }
        public override List <int> GivenAnswers
        {
            get
            {
                return given_answers;
            }
            set
            {
                if (value.Capacity <= AnswersCapacity && value.Count <= AnswersCount)
                    given_answers = value;
            }
        }

        public MultiSelectionQuestion(int answer_count) : base(answer_count)
        {
            CorrectAnswers = new List <int> (answer_count);
            GivenAnswers = new List <int> (answer_count);
        }
        
        public override int Score(bool count_neg)
        {
            int score = 0;

            if(GivenAnswers.Count > 0)
            {
                foreach (int givenAnswer in GivenAnswers)
                {
                    if (CorrectAnswers.Contains(givenAnswer))
                    {
                        score++;
                    }
                    else
                    {
                        if(count_neg)
                        {
                            score--;
                        }
                    }
                }

                GivenAnswers.Clear();
            }

            return score;
        }
    }

    public class SingleSelectionQuestion : Question
    {
        public override List <int> CorrectAnswers
        {
            get
            {
                return correct_answers;
            }
            set
            {
                if (value.Capacity == 1)
                {
                    correct_answers = value;
                }
            }
        }
        public override List <int> GivenAnswers
        {
            get
            {
                return given_answers;
            }
            set
            {
                if (value.Capacity == 1)
                {
                    given_answers = value;
                }
            }
        }

        public SingleSelectionQuestion(int answer_count) : base(answer_count)
        {
            CorrectAnswers = new List<int>(1);
            CorrectAnswers.Add(0);

            GivenAnswers = new List<int>(1);
        }

        public SingleSelectionQuestion(int answer_count, int correct) : base(answer_count)
        {
            CorrectAnswers = new List<int>(1);

            if (correct > -1 && correct < answer_count)
                CorrectAnswers.Add(correct);
            else
                CorrectAnswers.Add(0);

            GivenAnswers = new List<int>(1);
        }

        public override int Score(bool count_neg)
        {
            int score = 0;

            if (GivenAnswers.Count == 1)
            {
                if (CorrectAnswers.Contains(GivenAnswers[0]))
                {
                    score++;
                }
                else
                {
                    if(count_neg)
                    {
                        score--;
                    }
                }
                GivenAnswers.Clear();
            }

            return score;
        }
    }

    public class BinaryQuestion : SingleSelectionQuestion
    {
        public BinaryQuestion() : base(2)
        {
            SetAnswerContent("Tak", 0);
            SetAnswerContent("Nie", 1);
        }

        public BinaryQuestion(bool affirmative) : base(2)
        {
            SetAnswerContent("Tak", 0);
            SetAnswerContent("Nie", 1);

            CorrectAnswers.Clear();

            if (affirmative)
                CorrectAnswers.Add(0);
            else
                CorrectAnswers.Add(1);
        }
    }

    public class Quiz : IScorable
    {
        public const int MaxQuestions = 30;

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value.Equals(""))
                    _title = "Nowy quiz";
                else
                    _title = value;
            }
        }

        public bool NegativePoints { get; set; }

        public bool TimeLimited { get; set; }

        private int time_limit;

        /// <summary>
        /// Ograniczenie czasowe quizu w minutach
        /// </summary>
        public int TimeLimit
        {
            get
            {
                return time_limit;
            }
            set
            {
                if (value >= 5 && value <= 60 && value % 5 == 0)
                {
                    time_limit = value;
                }
            }
        }

        public List <Question> Questions { get; set; }
        public int QuestionsCount
        {
            get
            {
                return Questions.Count;
            }
        }

        public Quiz()
        {
            Title = "Nowy quiz";
            Questions = new List <Question>();
            NegativePoints = false;
            TimeLimit = 5;
            TimeLimited = false;
        }

        public int MaxPoints()
        {
            int points = 0;

            foreach(Question q in Questions)
            {
                points += q.CorrectAnswers.Count;
            }

            return points;
        }

        public int Score(bool count_neg)
        {
            int score = 0;
            foreach (Question q in Questions)
            {
                score += q.Score(count_neg);
            }
            return score;
        }
    }
}
