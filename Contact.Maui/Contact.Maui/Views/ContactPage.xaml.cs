


namespace Contact.Maui.Views;

using Contact.Maui.Models;
using Contact = Contact.Maui.Models.Contact;
public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
        List<Contact> contacts = ContactRepository.GetContacts();
        listContacts.ItemsSource = contacts;
    }


   

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       if(listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}
