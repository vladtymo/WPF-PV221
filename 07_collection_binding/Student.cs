using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_collection_binding
{
    [AddINotifyPropertyChangedInterface]
    public class Student
    {
        public string Name { get; set; }
        public DateOnly Birthdate { get; set; }
        public double AverageMark { get; set; }

        [DependsOn("Name", "AverageMark")]
        public string ShortInfo => ToString();

        public override string ToString()
        {
            return $"{Name} with mark of {AverageMark}";
        }
    }
}
