using System;
using System.Collections.Generic;
using System.IO;
using StudentSolution.Entity;

namespace StudentSolution
{
    public class CommandManager
    {
        StudentRepository _repository = StudentRepository.Instance;

        public void Execute(params String[] args)
        {
            if (args.Length == 2)
            {
                if (args[0].ToLower().EndsWith(".csv") & args[1].ToLower().StartsWith("name=")) executeLoadAndSearchByName(args);
                else if (args[0].ToLower().EndsWith(".csv") & args[1].ToLower().StartsWith("type=")) executeLoadAndSearchByStudentType(args);
            }
            if (args.Length == 3)
                if (args[0].ToLower().EndsWith(".csv") & args[1].ToLower().StartsWith("type=") & args[2].ToLower().StartsWith("gender=")) executeLoadAndSearchByStudentTypeAndGender(args);
        }

        void executeLoadAndSearchByName(string[] args)
        {
            string fileName = args[0], name = args[1].Split('=')[1];
            _repository.Clear();
            _repository.AddRange(loadFile(fileName));

            var s = _repository.SearchByName(name);
            Console.WriteLine($"{s.StudentType},{s.StudentName},{s.Gender},{s.Timestamp}");
        }
        void executeLoadAndSearchByStudentType(string[] args)
        {
            string fileName = args[0], type = args[1].Split('=')[1];
            _repository.Clear();
            _repository.AddRange(loadFile(fileName));

            var studentSearch = _repository.SearchByStudentType(Enum.Parse<StudentType>(type));
            foreach(var s in studentSearch)
            Console.WriteLine($"{s.StudentType},{s.StudentName},{s.Gender},{s.Timestamp}");
        }

        void executeLoadAndSearchByStudentTypeAndGender(string[] args)
        {
            string fileName = args[0], type = args[1].Split('=')[1], gender = args[2].Split('=')[1];
            _repository.Clear();
            _repository.AddRange(loadFile(fileName));

            var studentSearch = _repository.SearchByStudentTypeAndGender(Enum.Parse<StudentType>(type), Enum.Parse<Gender>(gender));
            foreach (var s in studentSearch)
                Console.WriteLine($"{s.StudentType},{s.StudentName},{s.Gender},{s.Timestamp}");
        }

        IEnumerable<Student> loadFile(string fileName)
        {
            using (StreamReader readFile = new StreamReader(fileName))
            {
                string line; string[] row;
                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    yield return Student.Create(
                        studentType: Enum.Parse<StudentType>(row[0]),
                        studentName: row[1],
                        gender: Enum.Parse<Gender>(row[2]),
                        timeStamp: row[3]);
                }
            }
        }
    }
}
