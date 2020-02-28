using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    class AddContactViewModel
    {
        public Contact Addedcontact { get; set; } = new Contact();
        public ObservableCollection<Contact> ContactList { get; set; }
        public AddContactViewModel (ObservableCollection<Contact> contactList) {
            this.ContactList = contactList;

        }

        public ICommand AddContactCommand => new Command(AddContact);

        public  void AddContact()
        {
            ContactList.Add(Addedcontact);
          

        }
    }
}
