using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSolution;
using StudentSolution.Entity;

namespace ServiceLayerTest
{
    [TestClass]
    public class StudentRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            StudentRepository studentRepository = StudentRepository.Instance;
            studentRepository.Clear();
            var studentAdd = Student.Create(StudentType.Kinder, "Nelson", Gender.M, string.Empty);
            studentRepository.Add(studentAdd);
            var studentRequest = studentRepository.SearchByName("Nelson");
            Assert.AreEqual(studentAdd.StudentName, studentRequest.StudentName, null, "Los nombre no coinciden");
        }
    }
}
