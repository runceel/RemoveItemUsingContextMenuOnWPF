using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp21
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static object GetParentDataContext(DependencyObject obj)
        {
            return obj.GetValue(ParentDataContextProperty);
        }

        public static void SetParentDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(ParentDataContextProperty, value);
        }

        public static readonly DependencyProperty ParentDataContextProperty =
            DependencyProperty.RegisterAttached("ParentDataContext", 
                typeof(object), 
                typeof(MainWindow), 
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
    }

    public class MainWindowViewModel : BindableBase
    {
        private DelegateCommand<Item> _deleteCommand;
        public DelegateCommand<Item> DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand<Item>(ExecuteDeleteCommand));

        private void ExecuteDeleteCommand(Item parameter)
        {
            Items.Remove(parameter);
        }

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>(Enumerable.Range(1, 100).Select(_ => new Item()));
    }

    public class Item
    {
        public string Text { get; } = Guid.NewGuid().ToString();
    }
}
