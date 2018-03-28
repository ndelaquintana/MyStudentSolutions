using System;


namespace StudentSolution.Entity
{
    public class Student
    {
        public static Student Create(StudentType studentType, String studentName, Gender gender, String timeStamp) => new Student() { StudentType = studentType, StudentName = studentName, Gender = gender, Timestamp = timeStamp };

        private Student() { }
        public StudentType StudentType { get; set; }
        public String StudentName { get; set; }
        public Gender Gender { get; set; }
        public String Timestamp { get; set; }
    }
}
