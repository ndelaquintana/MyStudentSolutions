using System;
using System.Collections.Generic;
using System.Linq;
using StudentSolution.Entity;
using System.Threading.Tasks;

namespace StudentSolution
{
    public class Service
    {
        LoadFile _loadFile = new LoadFile();
        CommandManager _commandManager = new CommandManager();
        StudentRepository _studentRepository = StudentRepository.Instance;
        BuildFileExample _buildFileExample = new BuildFileExample();
        CommandManagerExample _commandManagerExample = new CommandManagerExample();

        #region Servicios (consola)...
        public void ConsoleExecuteCommandLine(String[] args) => _commandManager.Execute(args);
        public void ConsoleExecuteSample() => _commandManagerExample.Execute();
        #endregion

        #region Servicios (varios)...
        public void StudentRepositoryLoadFile(String fileName)
        {
            _studentRepository.Clear();
            _studentRepository.AddRange(_loadFile.Execute(fileName));
        }
        public void StudentRepositoryLoadExample()
        {
            _buildFileExample.Execute();
            StudentRepositoryLoadFile(_buildFileExample.FileName);
        }
        public Student StudentRepositorySearchByName(String studentName) => _studentRepository.SearchByStudentName(studentName);
        public IEnumerable<Student> StudentRepositorySearchByType(StudentType studentType) => _studentRepository.SearchByStudentType(studentType);
        #endregion
    }
}
