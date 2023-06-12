using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace _07_collection_binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // INotifyCollectionChanged
        ObservableCollection<string> models = null;
        ObservableCollection<Student> students = null;

        public MainWindow()
        {
            InitializeComponent();

            models = new ObservableCollection<string>()
            {
                "Audi A6",
                "VW Toureg",
                "Toyota RAV4",
                "Nissan Almera"
            };
            students = new ObservableCollection<Student>()
            {
                new Student() {Name = "Igor", AverageMark = 10, Birthdate = new DateOnly(2004, 3, 5) },
                new Student() {Name = "Viktoria", AverageMark = 8.8, Birthdate = new DateOnly(2010, 5, 5) },
                new Student() {Name = "Oleg", AverageMark = 11.1, Birthdate = new DateOnly(2001, 6, 10) }
            };

            modelsComboBox.Items.Clear();

            // load data to ComboBox - manually mode
            //foreach (var m in models)
            //{
            //    modelsComboBox.Items.Add(m);
            //}

            // bind collection to the ComboBox - auto mode
            modelsComboBox.ItemsSource = models;

            studentsList.ItemsSource = students;
            studentsList.DisplayMemberPath = "ShortInfo";
        }

        private void AddModelBtnClick(object sender, RoutedEventArgs e)
        {
            string model = modelTxtBox.Text;
            // TODO: add validations

            // add new model to the list

            models.Add(model); // notify
        }

        private void RemoveModelBtnClick(object sender, RoutedEventArgs e)
        {
            // check if selected item exists
            if (modelsComboBox.SelectedItem != null)
                // remove selected item
                models.RemoveAt(modelsComboBox.SelectedIndex); // notify
        }

        private void ChangeMarkBtnClick(object sender, RoutedEventArgs e)
        {
            if (studentsList.SelectedItem == null) return;

            double newMark = double.Parse(markTxtBox.Text);

            // change student's mark
            Student selected = studentsList.SelectedItem as Student;

            selected.AverageMark = newMark;
            selected.Name += "!";
        }

        private void ShowMarkBtnClick(object sender, RoutedEventArgs e)
        {
            if (studentsList.SelectedItem != null)
            {
                var student = (Student)studentsList.SelectedItem;
                MessageBox.Show("Student mark: " + student.AverageMark);
            }
        }
    }
}
