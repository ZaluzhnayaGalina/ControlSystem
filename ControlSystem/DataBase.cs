using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ControlSystem
{
    public class DataBase
    {
        public SqlConnection connectionSql;
        //адаптер, служит для выполнения SQL-запросов
        public SqlDataAdapter adapterSql;

        //конструктор класса
        public DataBase() 
        {
            connectionSql = new SqlConnection();
            adapterSql = null;
        }

        //метод осуществляет подключение к базе данных
        public void connect(string conectionString) 
        {
            try
            {
                //считываем файл с настройками подключения
                string str = File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "config.cfg"));
                connectionSql.ConnectionString = str;
                
                //подключаемся к базе
                connectionSql.Open();
            }
            catch (Exception exp)
            {
                //если подключиться не удалось, показывает ошибку СУБД MySQL
                MessageBox.Show(exp.Message, "Exception", MessageBoxButtons.OK);
                Environment.Exit(1);
            }
        }

        public DataTable DbTableToDataGridView(string tableName)
        {
            DataSet DataSetDB = new DataSet();
            
            adapterSql = new SqlDataAdapter("Select * from " + tableName, connectionSql);
            
            adapterSql.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            
            SqlCommandBuilder bulder = new SqlCommandBuilder(adapterSql);
            adapterSql.InsertCommand = bulder.GetInsertCommand();
            adapterSql.Fill(DataSetDB);
            
            adapterSql.Update(DataSetDB.Tables[0]);

            return DataSetDB.Tables[0];
        }

        //метод осуществляющий прерывание соединения с БД
        public void connectionClose()
        {
            connectionSql.Close();
        }

        //метод возвращающий список названий столбцов указанной таблицы
        public List<string> getColumnName(string tableName)
        {
            //результарующий список
            List<string> result = new List<string>();

            DataTable dbTable = DbTableToDataGridView(tableName);

            for (int i = 0; i < dbTable.Columns.Count; i++)
            {
                result.Add(dbTable.Columns[i].ColumnName);
            }

            return result;
        }

        //метод выполняющий SQL-запрос, возвращает результирующую таблицу
        public DataTable sql(string textSql)
        {
            try{
                //результирующая таблица
                DataTable dt = new DataTable();
                //выполняем запрос и записывем результат
                adapterSql = new SqlDataAdapter(textSql, connectionSql);
                adapterSql.Fill(dt);
                return dt;
            }
            catch (Exception exp)
            {
                //если подключиться не удалось, показывает ошибку СУБД MySQL
                MessageBox.Show(exp.Message, "Exception", MessageBoxButtons.OK);
                return null;
            }
        }

        //метод возвращающий список названий всех курсов
        public List<string> getCourses()
        {
            //результат
            List<string> res = new List<string>();

            string sql = "SELECT DISTINCT c.name\n FROM course c";
            //результирующая таблица
            DataTable dt = this.sql(sql);

            //заполняем список названиями из полученной таблицы
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                res.Add(dt.Rows[i][0].ToString());
            }
            return res;
        }

        //метод удаляющий указанный курс
        public void deleteCourse(string courseName)
        {
            int courseId = getId("course", "name", courseName, "");

            sql("DELETE FROM course WHERE id_course = " + courseId + "");

            DataTable topicsForDelete = sql("SELECT t.name FROM topic t WHERE t.id_course = " + courseId);

            for (int i = 0; i < topicsForDelete.Rows.Count; i++)
            {
                string topicName = topicsForDelete.Rows[i][0].ToString();

                deleteTopic(topicName);
            }
        }

        //метод возвращающий список названий всех тем для указанного курса
        public List<string> getTopics(string course)
        {
            List<string> res = new List<string>();

            string sql = "SELECT c.id_course FROM course c WHERE c.name = '" + course + "'";
            DataTable dt = this.sql(sql);

            string sql1 = "SELECT t.name FROM topic t WHERE t.id_course = '" + dt.Rows[0][0] + "'";
            DataTable dt1 = this.sql(sql1);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                res.Add(dt1.Rows[i][0].ToString());
            }

            return res;
        }
        
        //метод удаляющий указанную тему
        public void deleteTopic(string topicName)
        {
            int topicId = getId("topic", "name", topicName, "");

            sql("DELETE FROM topic WHERE id_topic = "+ topicId +"");

            DataTable questionsForDelete = sql("SELECT q.id_que FROM question q WHERE q.id_topic = " + topicId);

            for (int i = 0; i < questionsForDelete.Rows.Count; i++)
            {
                int questionId = 0;

                Int32.TryParse(questionsForDelete.Rows[i][0].ToString(), out questionId);

                sql("DELETE FROM answer WHERE id_que = " + questionId + "");
                sql("DELETE FROM coordinates WHERE id_que = " + questionId + "");
                sql("DELETE FROM question WHERE id_que = " + questionId + "");
            }
        }

        //метод возвращающий ключ
        //принимает на вход: название таблицы, название поля(по которому ищем ключ), значение этого поля, дополнительные условия
        public int getId(string table, string field, string value, string condition)
        {
            int res = 0;

            string id = getColumnName(table)[0];

            string sql = "SELECT " + id +
                         " FROM " + table +
                         " WHERE " + field + " = '" + value + "'";

            if (condition != "")
            {
                sql += " AND " + condition;
            }

            DataTable dt = this.sql(sql);

            Int32.TryParse(dt.Rows[0][0].ToString(), out res);

            return res;
        }

        //метод возвращающий таблицу с результатами
        public List<List<string>> getResults()
        {
            List<List<string>> allResults = new List<List<string>>();

            DataTable students = sql("SELECT u.id_user, u.name FROM t_user u WHERE role = 0");

            for (int i = 0; i < students.Rows.Count; i++)
            {
                List<string> oneStudentResults = new List<string>();

                DataTable resultsTable = sql("SELECT c.name, t.name, r.points, r.date, r.time "+
                    "FROM course c, topic t, result r "+
                    "WHERE "+
                    "r.id_user = '" + students.Rows[i][0].ToString()+"' AND "+
                    "r.id_course = c.id_course AND " +
                    "r.id_topic = t.id_topic");

                for (int j = 0; j < resultsTable.Rows.Count; j++)
                {
                    string oneResult = "";
                    oneResult += resultsTable.Rows[j][0].ToString() + ", ";
                    oneResult += resultsTable.Rows[j][1].ToString() + ": ";
                    oneResult += resultsTable.Rows[j][2].ToString() + " баллов (";

                    string date = Convert.ToDateTime(resultsTable.Rows[j][3].ToString()).ToShortDateString();
                    oneResult += resultsTable.Rows[j][4].ToString() + " " + date + ")";


                    oneStudentResults.Add(oneResult);
                }
                oneStudentResults.Sort();
                oneStudentResults.Insert(0, students.Rows[i][1].ToString());

                allResults.Add(oneStudentResults);
            }
            return allResults;
        }

        public void createDatabase()
        {
            //создание если таблицы с пользователями, если она не существует
            sql(@"IF NOT EXISTS ( select * from sysobjects where name='t_user')
CREATE TABLE  t_user(id_user uniqueidentifier Primary KEY, name NVARCHAR(255), password NVARCHAR(255), role NVARCHAR(1))");

            //Создаем таблицу "курс" если она не существует
            sql(@"IF NOT EXISTS ( select * from sysobjects where name='course') CREATE TABLE 
course (id_course uniqueidentifier PRIMARY KEY, name NVARCHAR(50));");

            //создаем таблицу "тема", если она не существует
            sql(@"IF NOT EXISTS ( select * from sysobjects where name='topic') CREATE TABLE
topic (id_topic uniqueidentifier PRIMARY KEY, name NVARCHAR(50), time int, id_course uniqueidentifier FOREIGNKEY REFERENCES course(id_course), count int);");

            //создаем таблицу "вопрос", если она не существует
            sql(@"IF NOT EXISTS ( select * from sysobjects where name='question')
CREATE TABLE question (id_que uniqueidentifier PRIMARY KEY, text NVARCHAR(255), type NVARCHAR(3), count int, id_topic uniqueidentifier FOREIGNKEY REFERENCES topic(id_topic));");

            //создаем таблицу "ответ", если она не существует
            sql(@"IF NOT EXISTS ( select * from sysobjects where name='answer') CREATE TABLE
answer (id_answ uniqueidentifier PRIMARY KEY, text NVARCHAR(255), id_que uniqueidentifier FOREIGNKEY REFERENCES question(id_que), point int);");

            sql(@"IF NOT EXISTS ( select * from sysobjects where name='coordinates') CREATE TABLE
coordinates (id_coord uniqueidentifier PRIMARY KEY, axisX NVARCHAR(255), axisY NVARCHAR(255),  type NVARCHAR(20), points int, id_que uniqueidentifier FOREIGNKEY REFERENCES question(id_que));");

            sql(@"IF NOT EXISTS ( select * from sysobjects where name='result')  
CREATE TABLE result (id_result uniqueidentifier PRIMARY KEY, id_course uniqueidentifier FOREIGNKEY REFERENCES course(id_course), 
id_topic uniqueidentifier FOREIGNKEY REFERENCES topic(id_topic) int, id_user uniqueidentifier REFERENCES t_user(id_user), points int, date DATE, time TIME);");
        }

    }
}
