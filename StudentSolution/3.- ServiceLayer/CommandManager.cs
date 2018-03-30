using System;
using System.Collections.Generic;
using System.IO;
using StudentSolution.Entity;

namespace StudentSolution
{
    class CommandManager
    {
        StudentRepository _repository = StudentRepository.Instance;
        LoadFile _loadFile = new LoadFile();

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
            _repository.AddRange(_loadFile.Execute(fileName));

            var s = _repository.SearchByStudentName(name);
            Console.WriteLine($"{s.StudentType},{s.StudentName},{s.Gender},{s.TimeStamp}");
        }
        void executeLoadAndSearchByStudentType(string[] args)
        {
            string fileName = args[0], type = args[1].Split('=')[1];
            _repository.Clear();
            _repository.AddRange(_loadFile.Execute(fileName));

            var studentSearch = _repository.SearchByStudentType((StudentType)Enum.Parse(typeof(StudentType), type));
            foreach(var s in studentSearch)
            Console.WriteLine($"{s.StudentType},{s.StudentName},{s.Gender},{s.TimeStamp}");
        }
        void executeLoadAndSearchByStudentTypeAndGender(string[] args)
        {
            string fileName = args[0], type = args[1].Split('=')[1], gender = args[2].Split('=')[1];
            _repository.Clear();
            _repository.AddRange(_loadFile.Execute(fileName));

            var studentSearch = _repository.SearchByStudentTypeAndGender((StudentType)Enum.Parse(typeof(StudentType),type), (Gender)Enum.Parse(typeof(Gender),gender));
            foreach (var s in studentSearch)
                Console.WriteLine($"{s.StudentType},{s.StudentName},{s.Gender},{s.TimeStamp}");
        }
    }
}
