using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (students.Count >= Capacity)
            {
                return "No seats in the classroom";
            }
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (!students.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return "Student not found";
            }
            students.Remove(students.Find(s => s.FirstName == firstName && s.LastName == lastName));
            return $"Dismissed student {firstName} {lastName}";
        }
        public string GetSubjectInfo(string subject)
        {
            if (!students.Any(s => s.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in students.Where(s => s.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount() => students.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
