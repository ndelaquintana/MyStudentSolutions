using System;
using System.IO;

namespace StudentSolution
{
    public class CommandManagerTest
    {
        void buildExampleCsv()
        {
            String name;
            Random random = new Random();
            string[] studentTypeArray = Enum.GetNames(typeof(Entity.StudentType));
            Func<String> getRandonTimeStamp = () => DateTime.Now.AddSeconds(random.Next(1000000)).ToString("yyyyMMddhhmmss");
            Func<String> getRandomStudentType = () => studentTypeArray[random.Next(4)];


            using (StreamWriter writer = new StreamWriter("example.csv"))
            {
                using (StreamReader reader = new StreamReader("NameF.txt"))
                    while ((name = reader.ReadLine()) != null)
                        writer.WriteLine($"{getRandomStudentType()},{name},F,{getRandonTimeStamp()}");

                using (StreamReader reader = new StreamReader("NameM.txt"))
                    while ((name = reader.ReadLine()) != null)
                        writer.WriteLine($"{getRandomStudentType()},{name},M,{getRandonTimeStamp()}");
            }
        }

        /// <summary>
        /// En una proxima version se incluira pre y post condiciones.
        /// </summary>
        public void Execute()
        {
            buildExampleCsv();
            CommandManager commandManager = new CommandManager();
            Console.WriteLine("SearchByName");
            commandManager.Execute("example.csv", "name=Leia");

            Console.WriteLine("\nSearchByType");
            commandManager.Execute("example.csv", "type=Kinder");

            Console.WriteLine("\nSearchByTypeAndGender");
            commandManager.Execute("example.csv", "type=Kinder", "gender=M");
        }
    }
}
