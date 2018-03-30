using System;
using System.Windows;

namespace StudentSolution
{
    public class Program
    {
        static Application _application = new Application();
        static AppView _appView;

        [STAThread]
        static void Main(string[] args)
        {
            _appView = new AppView();
            _application.Run(_appView);
        }
    }

}