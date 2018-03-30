using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using StudentSolution.Entity;

namespace StudentSolution
{
    class LoadFile
    {
        public IEnumerable<Student> Execute(string fileName)
        {
            using (StreamReader readFile = new StreamReader(fileName))
            {
                string line; string[] row;
                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    yield return Student.Create(
                        studentType: (StudentType)Enum.Parse(typeof(StudentType), row[0]),
                        studentName: row[1],
                        gender: (Gender)Enum.Parse(typeof(Gender), row[2]),
                        timeStamp: row[3]);
                }
            }
        }
    }
}
