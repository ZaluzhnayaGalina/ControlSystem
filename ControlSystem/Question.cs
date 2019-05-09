using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ControlSystem
{
    public enum type
    {
        text = 1,
        graph = 2,
        graphVar = 3
    }

    public class Question
    {
        public type type;
        public string que_id;
        public string questionText;
        public List<Answer> answers;
    }

    public class Questions
    {
        public List<Question> QuestionsList;
        public TimeSpan time;

        public static int[] generateSeqOfQue(string topic, DataBase workBase) // ГЕНЕРИРУЕТСЯ ПОСЛЕДОВАТЕЛЬНОСТЬ ВОПРОСОВ (СЛУЧАЙНО)
        {
            int numbOfQue = 0;
            int number = 0;

            string sql = "SELECT DISTINCT q.id_que, q.text, q.type, t.count FROM question q, topic t WHERE " +
             "t.name = '" + topic + "' " +
             "AND q.id_topic = t.id_topic";

            DataTable dt1 = workBase.sql(sql);
            numbOfQue = Convert.ToInt32(dt1.Rows[0][3].ToString());

            if (dt1.Rows.Count < numbOfQue)
            {
                return null;
            }
            number = dt1.Rows.Count;
            int[] sequence = new int[numbOfQue];

            var random = new Random();
            var numbers = Enumerable.Range(0, number).OrderBy(n => random.Next()).ToArray();

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = Convert.ToInt32(numbers[i]);
            }
            return sequence;
        }

        public static Questions questionsCreate(string topic, int[] seq, DataBase workBase)//СЧИТЫВАНИЕ ВОПРОСОВ
        {
            Questions res = new Questions();
            List<Question> que1 = new List<Question>();

            res.QuestionsList = new List<Question>();

            string sql = "SELECT DISTINCT q.id_que, q.text, q.type, t.time FROM question q, topic t WHERE " +
                         "t.name = '" + topic + "' " +
                         "AND q.id_topic = t.id_topic";

            DataTable dt1 = workBase.sql(sql);

            res.time = new TimeSpan(0, Convert.ToInt32(dt1.Rows[0][3].ToString()), 0);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Question newQuestion = new Question();
                newQuestion.answers = new List<Answer>();

                newQuestion.que_id = dt1.Rows[i][0].ToString();
                newQuestion.questionText = dt1.Rows[i][1].ToString();

                DataTable dt2 = new DataTable();

                if (dt1.Rows[i][2].ToString() == "t")
                {
                    newQuestion.type = type.text;
                }
                else if (dt1.Rows[i][2].ToString() == "g1")
                {
                    newQuestion.type = type.graph;
                }
                else if (dt1.Rows[i][2].ToString() == "gN")
                {
                    newQuestion.type = type.graphVar;
                }

                if (dt1.Rows[i][2].ToString() == "t")
                {
                    sql = "SELECT DISTINCT a.text, a.point FROM question q, answer a " +
                        " WHERE q.id_que = " + dt1.Rows[i][0] +
                        " AND a.id_que = q.id_que";
                    dt2 = workBase.sql(sql);

                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        Answer newAnswer = new Answer();
                        newAnswer.aswerText = dt2.Rows[j][0].ToString();
                        newAnswer.point = Convert.ToInt32(dt2.Rows[j][1]);

                        newQuestion.answers.Add(newAnswer);
                    }
                }
                else if (dt1.Rows[i][2].ToString() == "g1" || dt1.Rows[i][2].ToString() == "gN")
                {
                    sql = "SELECT DISTINCT c.axisX, c.axisY, c.type, c.points FROM question q, coordinates c " +
                          " WHERE q.id_que = " + dt1.Rows[i][0] +
                          " AND c.id_que = q.id_que";
                    dt2 = workBase.sql(sql);

                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        Answer newAnswer = new Answer();
                        newAnswer.aswerText = dt2.Rows[j][0] + "+" + dt2.Rows[j][1] + "+" + dt2.Rows[j][2];
                        newAnswer.point = Convert.ToInt32(dt2.Rows[j][3]);

                        newQuestion.answers.Add(newAnswer);
                    }
                }

                que1.Add(newQuestion);
            }

            for (int i = 0; i < seq.Count(); i++)
            {
                res.QuestionsList.Add(que1[seq[i]]);
            }
            return res;
        }
    }

    public class Answer
    {
        public int point;
        public string aswerText;
    }

    public class UserAnswer
    {
        public int questionNumber;
        public int points;
        public int realPoints;
    }
}
