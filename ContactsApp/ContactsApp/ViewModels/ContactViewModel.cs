using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    class ContactViewModel : INotifyPropertyChanged
    {
        public  ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand DeleteElementCommand { get; set; }
        public ICommand GoToAddContactCommand { get; set; }
        public ICommand MoreOptionCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public ContactViewModel()
        {
           Contacts.Add(new Contact() { Name = "Franklin", Phone = "5658456" });
           Contacts.Add(new Contact() { Name = "Someone", Phone = "123456" });

            DeleteElementCommand = new Command<Contact>((param) => {
                Contacts.Remove(param);
            });

            GoToAddContactCommand = new Command(async() => {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(Contacts));
            });

            MoreOptionCommand = new Command <Contact>( async (Contactselected) => {
               var Selection = await App.Current.MainPage.DisplayActionSheet("Contact", "Cancel", null,
              "Number: " + $"{Contactselected.Phone}", "Edit");

                if(Selection == "Number: " + $"{Contactselected.Phone}")
                {
                    PhoneDialer.Open(Contactselected.Phone);
                }
                else if(Selection == "Edit")
                {
                   // await App.Current.MainPage.Navigation.PushAsync(new EditPage(Contactselected.Name));
                   //await App.Current.MainPage.Navigation.PushAsync(new EditPage(Contactselected.Phone));
                }
                
            });

        }

    }
}
