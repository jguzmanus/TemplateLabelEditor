using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using LabelTemplateEditor.Annotations;
using Neodynamic.SDK.Printing;

namespace LabelTemplateEditor
{
   [DataContract]
   internal class LabelTemplateEditorContext : ILabelTemplateEditorContext
   {
      private string _template;
      private string _data;
      private string _filename;
      private string _status;

      [DataMember]
      public string Template
      {
         get { return _template; }
         set { _template = value; OnPropertyChanged(nameof(Template)); }
      }
      [DataMember]
      public string Data
      {
         get { return _data; }
         set { _data = value; OnPropertyChanged(nameof(Data)); }
      }

      public string Filename
      {
         get { return _filename; }
         set { _filename = value; OnPropertyChanged(nameof(Filename)); }
      }

      public string Status
      {
         get { return _status; }
         set { _status = value; OnPropertyChanged(nameof(Status)); }
      }
      private static string AssemblyConfigFile
      {
         get
         {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var filename = Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(path) + ".cfg";
            return filename;
         }
      }
      public ICommand GenerateCommand => new RelayCommand(GenerateCmd);
      public ICommand ClearTemplateCommand => new RelayCommand(() => Template = "");
      public ICommand ClearDataCommand => new RelayCommand(() => Data = "");
      public EventHandler CloseWindowCommand { get; }

      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      public LabelTemplateEditorContext()
      {
         Template = "";
         Data = "";
         Filename = @"c:\temp\label.pdf";
         Status = "Ready";
         DeSerialize(AssemblyConfigFile);
         CloseWindowCommand += OnCloseWindowCommand;
         
      }

      private void OnCloseWindowCommand(object sender, EventArgs e)
      {
         var filename = AssemblyConfigFile;
         Serialize(filename);
      }

     

      private static byte[] GetBytes(string text)
      {
         var bytes = new byte[text.Length * sizeof(char)];
         Buffer.BlockCopy(text.ToCharArray(), 0, bytes, 0, bytes.Length);
         return bytes;
      }
      private async void GenerateCmd()
      {
         try
         {
            Status = "Working...";
            if (Template == string.Empty || Data == string.Empty)
            {
               Status = "Nothing to do.";
               return;
            }

            await GeneratePDF();
            System.Diagnostics.Process.Start(Filename);

            Status = "Success.";
         }
         catch (Exception e)
         {
            Status = e.Message;
         }
      }
    
      private Task GeneratePDF()
      {
         return Task.Run(() =>
         {
            var thermalLabel = new ThermalLabel();
            thermalLabel.LoadXmlTemplate(Template);
            var bytes = GetBytes(Data);

            using (var memory = new MemoryStream(bytes))
            {
               using (var dataset = new DataSet())
               {
                  using (var printer = new PrintJob())
                  {
                     dataset.ReadXml(memory);
                     thermalLabel.DataSource = dataset;
                     printer.PrintOrientation = PrintOrientation.Portrait;
                     printer.ExportToPdf(thermalLabel, Filename, 600);
                  }
               }
            }
         });
      }

      private void Serialize(string path)
      {
         using (var stream = File.Create(path))
         {
            var serializer = new DataContractSerializer(typeof(LabelTemplateEditorContext));
            serializer.WriteObject(stream, this);
         }
      }

      private void DeSerialize(string path)
      {
         try
         {
            using (var stream = File.OpenRead(path))
            {
               var serializer = new DataContractSerializer(typeof(LabelTemplateEditorContext));
               var obj = serializer.ReadObject(stream) as LabelTemplateEditorContext;
               Data = obj?.Data;
               Template = obj?.Template;
            }
         }
         catch (Exception e)
         {
            Status = e.Message;
         }
         
      }
   }

   
}
