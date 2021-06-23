using System;
namespace CourseManager.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message)
        {
        }

        public StudentNotFoundException(string message, Exception e) : base(message, e)
        {

        }
    }
}
