using System.Collections.Generic;
using System.Diagnostics;

namespace EduQuizzer
{
    public interface IScorable
    {
        int Score();
    }

    public abstract class Question : IScorable
    {
        // Numer porządkowy pytania
        private int _number;
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value > 1)
                    _number = value;
                else
                    _number = 1;
            }
        }

        // Treść pytania
        private string _content;
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

        // Lista stringów z treściami możliwych odpowiedzi
        public List <string> Answers;
        public int AnswersCapacity
        {
            get
            {
                return Answers.Capacity;
            }
        }
        public int AnswersCount
        {
            get
            {
                return Answers.Count;
            }
        }

        // Lista indeksów poprawnych odpowiedzi
        protected List <int> _correct_answers;
        public abstract List <int> CorrectAnswers { get; set; }

        // Lista indeksów odpowiedzi wskazanych jako poprawne
        protected List<int> _given_answers;
        public abstract List <int> GivenAnswers { get; set; }

        public void SetAnswer(string answer, int index)
        {
            if(index > -1 && index < AnswersCapacity)
            {
                if (answer.Equals(""))
                    Answers[index] = string.Format("Odpowiedź {0}", index + 1);
                else
                    Answers[index] = answer;
            }
        }

        public Question(int answer_count)
        {
            Content = "Treść pytania...";
            Answers = new List <string> (answer_count);
            for (int i = 0; i < AnswersCapacity; i++)
                Answers.Add(string.Format("Odpowiedź {0}", i + 1));
        }

        public abstract int Score();
    }

    public class MultiSelectionQuestion : Question
    {
        public override List <int> CorrectAnswers
        {
            get
            {
                return _correct_answers;
            }
            set
            {
                if (value.Capacity <= AnswersCapacity && value.Count <= AnswersCount)
                    _correct_answers = value;
            }
        }
        public override List <int> GivenAnswers
        {
            get
            {
                return _given_answers;
            }
            set
            {
                if (value.Capacity <= AnswersCapacity && value.Count <= AnswersCount)
                    _given_answers = value;

                Debug.Write("Indices passed to property: ");
                foreach (int i in value)
                    Debug.Write(string.Format("{0} ", i));
                Debug.WriteLine("");
            }
        }

        public MultiSelectionQuestion(int answer_count) : base(answer_count)
        {
            CorrectAnswers = new List <int> (answer_count);
            GivenAnswers = new List <int> (answer_count);
        }
        
        public override int Score()
        {
            int score = 0;
            foreach(int givenAnswer in GivenAnswers)
                if (CorrectAnswers.Contains(givenAnswer))
                    score++;
            return score;
        }
    }

    public class SingleSelectionQuestion : Question
    {
        public override List <int> CorrectAnswers
        {
            get
            {
                return _correct_answers;
            }
            set
            {
                if (value.Capacity == 1)
                    _correct_answers = value;
            }
        }
        public override List <int> GivenAnswers
        {
            get
            {
                return _given_answers;
            }
            set
            {
                if (value.Capacity == 1)
                    _given_answers = value;
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

        // TODO - Można uprościć
        public override int Score()
        {
            if (GivenAnswers.Count == 1)
            {
                if (CorrectAnswers.Contains(GivenAnswers[0]))
                    return 1;
                else
                    return 0;
            }
             
            // Nie udzielono odpowiedzi
            return 0;
        }
    }

    public class BinaryQuestion : SingleSelectionQuestion
    {
        public BinaryQuestion() : base(2)
        {
            SetAnswer("Tak", 0);
            SetAnswer("Nie", 1);
        }

        public BinaryQuestion(bool affirmative) : base(2)
        {
            SetAnswer("Tak", 0);
            SetAnswer("Nie", 1);

            CorrectAnswers.Clear();

            if (affirmative)
                CorrectAnswers.Add(0);
            else
                CorrectAnswers.Add(1);
        }
    }

    public class Quiz : IScorable
    {
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
        }


        public int Score()
        {
            int score = 0;
            foreach (Question q in Questions)
                score += q.Score();
            return score;
        }
    }
}
