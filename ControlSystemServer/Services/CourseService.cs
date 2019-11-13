using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ControlSystem.Model;
using Microsoft.Extensions.Configuration;

namespace ControlSystemServer.Services
{
    public class CourseService : ICourseService
    {
        private string _connectionString;
        public CourseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }
        public void ChangeCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void CreateCourse(Course course)
        {
            if (course.Id == Guid.Empty)
                course.Id = Guid.NewGuid();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    var commandInsertCourse = new SqlCommand("Insert into Course (ID,Name,CreatedByID) values(@ID,@Name,@CreatedByID)", connection, transaction);
                    commandInsertCourse.Parameters.AddWithValue("ID", course.Id);
                    commandInsertCourse.Parameters.AddWithValue("Name", course.Name);
                    commandInsertCourse.Parameters.AddWithValue("CreatedById", course.CreatedBy.ID);
                    commandInsertCourse.ExecuteNonQuery();
                    foreach (var topic in course.Topics)
                    {
                        if (topic.Id == Guid.Empty)
                            topic.Id = Guid.NewGuid();
                        var commandInsertTopic = new SqlCommand("Insert into Topics (ID,Name,Time,CourseID) values(@ID,@Name,@Time,@CourseID)", connection, transaction);
                        commandInsertTopic.Parameters.AddWithValue("ID", topic.Id);
                        commandInsertTopic.Parameters.AddWithValue("Name", topic.Name);
                        commandInsertTopic.Parameters.AddWithValue("Time", topic.Time);
                        commandInsertTopic.Parameters.AddWithValue("CouerseID", course.Id);
                        commandInsertTopic.ExecuteNonQuery();
                        foreach (var question in topic.Questions)
                        {
                            if (question.Id == Guid.Empty)
                                question.Id = Guid.NewGuid();
                            var commandInsertQuestion = new SqlCommand("Insert into Topics (ID,Text,TopicID) values(@ID,@Text,@TopicID)", connection, transaction);
                            commandInsertQuestion.Parameters.AddWithValue("ID", question.Id);
                            commandInsertQuestion.Parameters.AddWithValue("Text", question.Text);
                            commandInsertQuestion.Parameters.AddWithValue("TopicID", topic.Id);
                            commandInsertQuestion.ExecuteNonQuery();
                            foreach (var answer in question.Answers)
                            {
                                if (answer.Id == Guid.Empty)
                                    answer.Id = Guid.NewGuid();
                                var answerInsertQuestion = new SqlCommand("Insert into Answers (ID,Text,Point,QuestionID) values (@ID,@Text,@Point,@QuestionID)", connection, transaction);
                                answerInsertQuestion.Parameters.AddWithValue("ID", answer.Id);
                                answerInsertQuestion.Parameters.AddWithValue("Text", answer.Text);
                                answerInsertQuestion.Parameters.AddWithValue("Point", answer.Point);
                                answerInsertQuestion.Parameters.AddWithValue("QuestionID", question.Id);
                                answerInsertQuestion.ExecuteNonQuery();
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                }


            }
        }

        public List<Topic> GetAllTopics()
        {
            throw new NotImplementedException();
        }

        public Course GetCourse(Guid CourseID)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}
