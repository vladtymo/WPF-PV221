using System.Windows.Markup;
using System.Windows.Media;

namespace _06_bindings
{
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
}
