using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfAlpha
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Model model;
        private Command parseVkCommand;


        public Model MainModel
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        public Command ParseVkCommand
        {
            get
            {
                return parseVkCommand ??
                    (parseVkCommand = new Command(obj =>
                    {
                        model.OpenAndParseVk();
                    }));
            }
        }


        public MainViewModel()
        {
            model = new Model();
            OnPropertyChanged("Model");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
