using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ControlSystem
{
    public class DataBase
    {
        public MySqlConnection connectionMySQL;
        //адаптер, служит для выполнения SQL-запросов
        public MySqlDataAdapter adapterMySQL;

        //конструктор класса
        public DataBase() 
        {
            connectionMySQL = new MySqlConnection();
            adapterMySQL = null;
        }

        //метод осуществляет подключение к базе данных
        public void connect(string conectionString) 
        {
            try
            {
                //считываем файл с настройками подключения
                string str = File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "config.cfg"));
                connectionMySQL.ConnectionString = str;

                //подключаемся к базе
                connectionMySQL.Open();
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
            
            adapterMySQL = new MySqlDataAdapter("Select * from " + tableName, connectionMySQL);
            
            adapterMySQL.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            
            MySqlCommandBuilder bulder = new MySqlCommandBuilder(adapterMySQL);
            adapterMySQL.InsertCommand = bulder.GetInsertCommand();
            adapterMySQL.Fill(DataSetDB);
            
            adapterMySQL.Update(DataSetDB.Tables[0]);

            return DataSetDB.Tables[0];
        }

        //метод осуществляющий прерывание соединения с БД
        public void connectionClose()
        {
            connectionMySQL.Close();
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
                adapterMySQL = new MySqlDataAdapter(textSql, connectionMySQL);
                adapterMySQL.Fill(dt);
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
            sql("CREATE TABLE IF NOT EXISTS t_user (id_user int AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), password VARCHAR(255), role VARCHAR(1));");

            //Создаем таблицу "курс" если она не существует
            sql("CREATE TABLE IF NOT EXISTS course (id_course int AUTO_INCREMENT PRIMARY KEY, name VARCHAR(50));");

            //создаем таблицу "тема", если она не существует
            sql("CREATE TABLE IF NOT EXISTS topic (id_topic int AUTO_INCREMENT PRIMARY KEY, name VARCHAR(50), time int, id_course int, count int);");

            //создаем таблицу "вопрос", если она не существует
            sql("CREATE TABLE IF NOT EXISTS question (id_que int AUTO_INCREMENT PRIMARY KEY, text VARCHAR(255), type VARCHAR(3), count int, id_topic int);");

            //создаем таблицу "ответ", если она не существует
            sql("CREATE TABLE IF NOT EXISTS answer (id_answ int AUTO_INCREMENT PRIMARY KEY, text VARCHAR(255), id_que int, point int);");

            sql("CREATE TABLE IF NOT EXISTS coordinates (id_coord int AUTO_INCREMENT PRIMARY KEY, axisX VARCHAR(255), axisY VARCHAR(255),  type VARCHAR(20), points int, id_que int);");

            sql("CREATE TABLE IF NOT EXISTS result (id_result int AUTO_INCREMENT PRIMARY KEY, id_course int, id_topic int, id_user int, points int, date DATE, time TIME);");
        }

    }
}
