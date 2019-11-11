using ControlSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlSystemServer.Services
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course GetCourse(Guid CourseID);
        List<Topic> GetAllTopics();
        void CreateCourse(Course course);
        void ChangeCourse(Course course);
    }
}
