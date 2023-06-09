namespace _06_bindings
{
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
