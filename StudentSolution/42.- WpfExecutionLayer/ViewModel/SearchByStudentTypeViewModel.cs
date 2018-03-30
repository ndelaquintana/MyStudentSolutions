using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using StudentSolution.Entity;

namespace StudentSolution
{
    public class SearchByStudentTypeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Campos...
        Service _service = new Service();
        ObservableCollection<Student> _studentList = new ObservableCollection<Student>();
        List<StudentType> _studentTypeList = new List<StudentType>();
        StudentType _studentType = StudentType.High;
        RelayCommand _searchCommand;
        Boolean _isExecutedSearch = false;
        #endregion

        public SearchByStudentTypeViewModel()
        {
            _studentTypeList.AddRange((IEnumerable<StudentType>)Enum.GetValues(typeof(StudentType)));
            _searchCommand = new RelayCommand(_executeSearch, () => true);
        }

        #region Propiedades (públicas)...
        public IEnumerable<StudentType> StudentTypeList => _studentTypeList;
        public IEnumerable<Student> StudentList => _studentList;
        public StudentType StudentType
        {
            get => _studentType;
            set
            {
                if (_studentType != value)
                {
                    _studentType = value;
                    _studentList.Clear();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudentType)));
                    IsExecutedSearch = false;
                }
            }
        }
        public Boolean IsExecutedSearch
        {
            get => _isExecutedSearch;
            private set
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
            _studentList.Clear();
            foreach(var student in _service.StudentRepositorySearchByType(_studentType))
                _studentList.Add(student);
            IsExecutedSearch = true;
        }
    }
}