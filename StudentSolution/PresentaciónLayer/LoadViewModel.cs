using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StudentSolution
{
    public class LoadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public List<string> MenuList { get; } = new List<string>
        {
            _loadMenu, _searchByStudentNameMenu, _searchByStudentTypeMenu
            
        };

        public String CurrentMenu
        {
            get => _currentMenu;
            set
            {
                if (!String.Equals(_currentMenu,value))
                {

                    _currentMenu = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentMenu)));
                }
            }
        }
    }
}
