using System.Collections.Generic;

namespace EduQuizzer
{
    public interface IScorable
    {
        int Score();
    }

    public abstract class Question : IScorable
    {
        // TODO - ustawianie numeru porządkowego pytania
        public int Number { get; set; }

        public string Content { get; set; }
        public List <string> Answers { get; set; }

        public Question(int answer_count)
        {
            Content = "<nowe pytanie>";
            Answers = new List <string>(answer_count);
            for (int i = 0; i < answer_count; i++)
                Answers.Add(string.Format("<odpowiedź {0}>", i + 1));
        }

        public abstract int Score();
    }

    public class MultiSelectionQuestion : Question
    {
        private List <int> correct_answers;
        public List <int> CorrectAnswers
        {
            get
            {
                return correct_answers;
            }
            set
            {
                if(value.Count <= Answers.Capacity)
                {
                    bool in_range;
                    foreach (int i in value)
                    {
                        in_range = (i > -1 && i < Answers.Capacity);
                        if (in_range && !correct_answers.Contains(i))
                            correct_answers.Add(i);
                    }
                }
            }
        }

        private List <int> given_answers;
        public List <int> GivenAnswers
        {
            get
            {
                return given_answers;
            }
            set
            {
                if(value.Count <= Answers.Capacity)
                {
                    bool in_range;
                    foreach (int i in value)
                    {
                        in_range = (i > -1 && i < Answers.Capacity);
                        if (in_range && !given_answers.Contains(i))
                            given_answers.Add(i);
                    }
                }
            }
        }

        public MultiSelectionQuestion(int answer_count) : base(answer_count)
        {
            CorrectAnswers = new List <int>(answer_count);
            GivenAnswers = new List <int>(answer_count);
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
        protected int correct_answer;
        public virtual int CorrectAnswer
        {
            get
            {
                return correct_answer;
            }
            set
            {
                if (value > -1 && value < Answers.Capacity)
                    correct_answer = value;
            }
        }

        protected int given_answer = -1;
        public virtual int GivenAnswer
        {
            get
            {
                return given_answer;
            }
            set
            {
                if (value > -1 && value < Answers.Capacity)
                    given_answer = value;
            }
        }

        public SingleSelectionQuestion(int answer_count) : base(answer_count) {}

        public SingleSelectionQuestion(int answer_count, int correct) : base(answer_count)
        {
            CorrectAnswer = correct;
        }

        public override int Score()
        {
            if (GivenAnswer == CorrectAnswer)
                return 1;
            return 0;
        }
    }

    public class BinaryQuestion : SingleSelectionQuestion
    {
        public override int CorrectAnswer {
            get
            {
                return correct_answer;
            }
            set
            {
                if (value == 0 || value == 1)
                    correct_answer = value;
            }
        }
        public override int GivenAnswer
        {
            get
            {
                return given_answer;
            }
            set
            {
                if (value == 0 || value == 1)
                    given_answer = value;
            }
        }

        public BinaryQuestion(bool correct) : base(2)
        {
            Answers[0] = "Nie";
            Answers[1] = "Tak";

            if (correct)
                CorrectAnswer = 1;
            else
                CorrectAnswer = 0;
        }
    }

    public class Quiz : IScorable
    {
        public string Title { get; set; } 
        public List <Question> Questions { get; set; }

        public Quiz()
        {
            Title = "<nowy quiz>";
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
