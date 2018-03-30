using System;
using System.IO;

namespace StudentSolution
{
    class BuildFileExample
    {
        const string _formatTimeStamp = "yyyyMMddhhmmss";
        const string _fileNameExample = "example.csv";
        const string _fileNameStudentNameF = "NameF.txt";
        const string _fileNameStudentNameM = "NameM.txt";

        public String FileName => _fileNameExample;
        public void Execute()
        {
            String name;
            Random random = new Random();
            string[] studentTypeArray = Enum.GetNames(typeof(Entity.StudentType));
            Func<String> getRandonTimeStamp = () => DateTime.Now.AddSeconds(random.Next(1000000)).ToString(_formatTimeStamp);
            Func<String> getRandomStudentType = () => studentTypeArray[random.Next(4)];


            using (StreamWriter writer = new StreamWriter(_fileNameExample))
            {
                using (StreamReader reader = new StreamReader(_fileNameStudentNameF))
                    while ((name = reader.ReadLine()) != null)
                        writer.WriteLine($"{getRandomStudentType()},{name},F,{getRandonTimeStamp()}");

                using (StreamReader reader = new StreamReader(_fileNameStudentNameM))
                    while ((name = reader.ReadLine()) != null)
                        writer.WriteLine($"{getRandomStudentType()},{name},M,{getRandonTimeStamp()}");
            }
        }
    }
}
