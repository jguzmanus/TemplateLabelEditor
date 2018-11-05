using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabelTemplateEditor
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
     
      public static readonly DependencyProperty LabelTemplateEditorContextProperty = DependencyProperty.Register(
         "LabelTemplateEditorContext", typeof(ILabelTemplateEditorContext), typeof(MainWindow), new PropertyMetadata(default(ILabelTemplateEditorContext)));

      public ILabelTemplateEditorContext LabelTemplateEditorContext
      {
         get { return (ILabelTemplateEditorContext) GetValue(LabelTemplateEditorContextProperty); }
         set { SetValue(LabelTemplateEditorContextProperty, value); }
      }
      public MainWindow()
      {
         InitializeComponent();
         var dc = new LabelTemplateEditorContext();
         
         DataContext = dc;
         Closed += dc.CloseWindowCommand;
      }
   }
}
