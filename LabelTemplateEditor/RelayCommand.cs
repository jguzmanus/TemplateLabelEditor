using System;
using System.Windows.Input;

namespace LabelTemplateEditor
{
   public class RelayCommand : ICommand
   {
      private readonly Action _command;

      public RelayCommand(Action command)
      {
         _command = command;
      }
      public bool CanExecute(object parameter)
      {
         return true;
      }

      public void Execute(object parameter)
      {
         _command();
      }

      public event EventHandler CanExecuteChanged;
   }
}