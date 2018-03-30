using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace StudentSolution
{
    class LoadViewModel : INotifyPropertyChanged
    {
        const string _loadExapleMessage = "Load example executed";
        const string _loadFileMessage = "Load file executed";

        #region Campos...
        RelayCommand _loadFileCommand, _loadExampleCommand;
        Service _service;
        String _message;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public LoadViewModel()
        {
            _loadFileCommand = new RelayCommand(executeLoadFile, () => true);
            _loadExampleCommand = new RelayCommand(executeLoadExample, () => true);
            _service = new Service();
        }

        #region Propiedades (públicas)...
        public string FileName { get; set; }
        public ICommand LoadFileCommand => _loadFileCommand;
        public ICommand LoadExampleCommand => _loadExampleCommand;
        public String Message
        {
            get => _message;
            private set
            {
                if (!String.Equals(_message,value))
                {
                    _message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
                }
            }

        }
        #endregion

        #region Propiedades (privadas)...
        void executeLoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (!String.IsNullOrEmpty(openFileDialog.FileName))
                    try
                    {
                        _service.StudentRepositoryLoadFile(openFileDialog.FileName);
                        sendMessage(_loadFileMessage);
                    } catch (Exception ex)
                    {
                        sendMessage(ex.Message);
                    }
            }
        }
        void executeLoadExample()
        {
            _service.StudentRepositoryLoadExample();
            sendMessage(_loadExapleMessage);
        }
        void sendMessage(String value)
        {
            Message = value;
            clearMessage();
        }
        async void clearMessage()
        {
            await Task.Delay(2000);
            Message = null;
        }

        #endregion

    }
}
