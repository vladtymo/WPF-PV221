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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _06_bindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(viewModel.Student.ToString());
        }
    }

    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        // all properties to bind from XAML
        // ! we can bind ONLY to a public property

        public Student Student { get; set; }
        public string Title { get; set; }

        // Color: DarkGray or LightGray
        // ternary operator: (condition) ? value : value
        [DependsOn("IsDarkTheme")]
        public Color Color => IsDarkTheme ? Colors.DarkGray : Colors.LightGray; // readonly

        public bool IsDarkTheme { get; set; } // auto change

        public ViewModel()
        {
            Student = new() { Name = "Oleg", AverageMark = 10.4F };
            Title = "Hello Bindings!";
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public float AverageMark { get; set; }

        public override string ToString()
        {
            return $"{Name} {AverageMark}";
        }
    }
}
