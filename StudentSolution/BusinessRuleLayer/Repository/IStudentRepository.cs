using System.Collections.Generic;
using StudentSolution.Entity;

namespace StudentSolution
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void AddRange(IEnumerable<Student> studentList);
        void Remove(Student student);
        Student SearchByName(string studentName);
        IEnumerable<Student> SearchByStudentType(StudentType studentType);
        IEnumerable<Student> SearchByStudentTypeAndGender(StudentType studentType, Gender genger);
    }
}