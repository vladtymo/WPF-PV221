using PropertyChanged;

namespace _08_mvvm_contacts
{
    [AddINotifyPropertyChangedInterface]
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public bool IsBlocked { get; set; }

        [DependsOn("Name", "Surname", "Phone", "IsBlocked")]
        public string ShortInfo => $"{Name} {Surname} : {Phone} {(IsBlocked ? "X" : "")}";

        public override string ToString()
        {
            return $"{Name} {Surname} : {Phone}";
        }
    }
}
