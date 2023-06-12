using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _08_mvvm_contacts
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        // -------- Binding Properties
        public IEnumerable<Contact> Contacts => contacts;
        public Contact SelectedContact { get; set; }

        public ViewModel()
        {
            contacts.Add(new Contact() { Name = "Nastya", Surname = "Gogol", Age = 10, Phone = "+39090898857", IsBlocked = false });
            contacts.Add(new Contact() { Name = "Viktor", Surname = "Fedor", Age = 20, Phone = "440-44-66", IsBlocked = true });
            contacts.Add(new Contact() { Name = "Taras", Surname = "Tymo", Age = 18, Phone = "+39090565765", IsBlocked = false });
        }

        // -------- Presentation Logic
        public void Dublicate()
        {
            if (SelectedContact != null)
                // TODO: make deep copy
                contacts.Add(SelectedContact); // shallow copy
        }

        public void Remove()
        {
            if (SelectedContact != null)
                contacts.Remove(SelectedContact);
        }
    }
}
