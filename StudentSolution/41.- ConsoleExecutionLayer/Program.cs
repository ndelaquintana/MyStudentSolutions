using System.Collections.Generic;

namespace StudentSolution
{
    class Program
    {
        static Service _service = new Service();
        static void Main(string[] args)
        {
            //_service.ConsoleExecuteCommandLine(args);
            _service.ConsoleExecuteSample();
        }
    }
}
