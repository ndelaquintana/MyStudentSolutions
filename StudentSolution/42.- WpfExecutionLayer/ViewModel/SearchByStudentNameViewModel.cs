using System;
using System.ComponentModel;
using System.Windows.Input;
using StudentSolution.Entity;

namespace StudentSolution
{
    public class SearchByStudentNameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Campos...
        Service _service = new Service();
        Student _student;
        String _studentName;
        RelayCommand _searchCommand;
        Boolean _isExecutedSearch = false;
        #endregion

        public SearchByStudentNameViewModel()
        {
            _searchCommand = new RelayCommand(_executeSearch, () => !String.IsNullOrEmpty(_studentName));
        }

        #region Propiedades (públicas)...
        public String StudentName
        {
            get => _studentName;
            set
            {
                if (!String.Equals(_studentName,value))
                {
                    _studentName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudentName)));
                    IsExecutedSearch = false;
                    _searchCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public Student Student
        {
            get => _student;
            private set
            {
                if (_student != value)
                {
                    _student = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudentName)));
                    IsExecutedSearch = false;
                }
            }
        }
        public Boolean IsExecutedSearch
        {
            get => _isExecutedSearch;
            set
            {
                if (_isExecutedSearch != value)
                {
                    _isExecutedSearch = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsExecutedSearch)));
                }
            }
        }
        #endregion

        #region Comandos...
        public ICommand SearchCommand => _searchCommand;
        #endregion

        void _executeSearch()
        {
            _student = _service.StudentRepositorySearchByName(_studentName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Student)));
            IsExecutedSearch = true;
        }
    }
}