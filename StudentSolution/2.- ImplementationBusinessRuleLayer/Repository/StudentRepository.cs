using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using StudentSolution.Entity;
using System.Linq;

namespace StudentSolution
{
    public sealed class StudentRepository : IStudentRepository
    {
        const string _dupValMessage = "StudentList:DupVal";
        const string _noDataFoundMessage = "StudentList:NoDataFound";

        #region Campos...
        ConcurrentDictionary<string, Student> _studentList = new ConcurrentDictionary<string, Student>();
        object _myLock = new object();
        #endregion

        #region Implementación singleton (multiple threads and Lazy load)...
        static readonly Lazy<StudentRepository> _instance = new Lazy<StudentRepository>(()=>new StudentRepository());
        private StudentRepository() { }
        public static StudentRepository Instance => _instance.Value;
        #endregion

        #region Métodos (publicos)...
        public void Clear()
        {
            lock(new object())
                _studentList.Clear();
        }
        public void Add(Student student)
        {
            if (!_studentList.TryAdd(student.StudentName, student))
                throw new Exception($"{_dupValMessage}({student.StudentName})");
        }
        public void AddRange(IEnumerable<Student> studentList)
        {
            foreach (var student in studentList)
                if (!_studentList.TryAdd(student.StudentName, student))
                    throw new Exception($"{_dupValMessage}({student.StudentName})");
        }
        public void Remove(Student student)
        {
            Student studentRemove;
            if (!_studentList.TryRemove(student.StudentName, out studentRemove))
                throw new Exception($"{_noDataFoundMessage}({student.StudentName})");
        }

        /// <summary>
        /// Searh by StudentName and return a IEnumerable<Student> sorted alphabetically.
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public Student SearchByStudentName(string studentName)
        {
            Student studentSearch;
            if (_studentList.TryGetValue(studentName, out studentSearch)) return studentSearch;
            else return null;
        }

        /// <summary>
        /// Searh by StudentTye and return a IEnumerable<Student> sorted by date, most recent to least recent.
        /// </summary>
        /// <param name="studentType"></param>
        /// <returns></returns>
        public IEnumerable<Student> SearchByStudentType(StudentType studentType)
        {
            List<Student> studentSeach;
            lock (new object())
                studentSeach = _studentList.Values.Where(z => z.StudentType == studentType).ToList();
            return studentSeach.OrderByDescending(z => z.TimeStamp);
        }

        /// <summary>
        /// Searh by StudentTye and Gender, return a IEnumerable<Student> sorted by date, most recent to least recent.
        /// </summary>
        /// <param name="studentType"></param>
        /// <returns></returns>
        public IEnumerable<Student> SearchByStudentTypeAndGender(StudentType studentType, Gender genger)
        {
            List<Student> studentSeach;
            lock (new object())
                studentSeach = _studentList.Values.Where(z => z.StudentType == studentType & z.Gender == genger).ToList();
            return studentSeach.OrderByDescending(z => z.TimeStamp);
        }
        #endregion
    }
}

