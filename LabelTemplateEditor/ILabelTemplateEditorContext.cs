using System;
using System.ComponentModel;
using System.Windows.Input;

namespace LabelTemplateEditor
{
   public interface ILabelTemplateEditorContext : INotifyPropertyChanged
   {
      string Template { get; set; }
      string Data { get; set; }
      string Filename { get; set; }
      string Status { get; set; }
      ICommand GenerateCommand { get; }
      ICommand ClearTemplateCommand { get; }
      ICommand ClearDataCommand { get; }
      EventHandler CloseWindowCommand { get; }
   }
}