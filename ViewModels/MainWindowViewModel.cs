using Sokoban.Commands;
using Sokoban.Models;
using Sokoban.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Sokoban.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Command startGameCommand;
        private KeyValuePair<int, Level> selectedLevel;
        private bool isVisiable = true;
        public bool IsVisiable
        {
            get
            {
                return isVisiable;
            }
            set
            {
                isVisiable = value;
                OnPropertyChanged("IsVisiable");
            }
        }
        public MainWindowViewModel()
        {
            foreach(var level in Levels.levelsDictionary)
            {
                if(Properties.Settings.Default.CompleteLevels.Contains(level.Key.ToString())) Levels.levelsDictionary[level.Key].IsComplete = true;
            }
        }
        public KeyValuePair<int, Level> SelectedLevel {
            get 
            {
                return selectedLevel;
            }
            set
            {
                selectedLevel = value;
            } 
        }
        public Command StartGameCommand
        {
            get
            {
                return startGameCommand??
                  (startGameCommand = new Command(obj =>
                  {
                      if (SelectedLevel.Value != null)
                      {
                          GameWindow win = new GameWindow(SelectedLevel.Value);
                          win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                          IsVisiable = false;
                          win.ShowDialog();
                          if(win.DialogResult == true)
                          {
                              Properties.Settings.Default.CompleteLevels += $"{SelectedLevel.Key} ";
                              Properties.Settings.Default.Save();
                              Levels.levelsDictionary[SelectedLevel.Key].IsComplete = true;
                          }
                          IsVisiable = true;
                      }
                  }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
