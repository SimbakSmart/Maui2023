namespace Contact.Maui.Views;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
        List<Contact> contacts = new List<Contact>()
        {
            new Contact
            {
             Name="John Doe",
             Email="jondoe@gmail.co"
            },
            new Contact
            {
             Name="Jane Doe",
             Email="JaneDoe@gmail.co"
            },
            new Contact
            {
             Name="Tom Hanks",
             Email="tomhanks@gmail.co"
            },
            new Contact
            {
             Name="Frank Liu",
             Email="franliu@gmail.co"
            },
        };
        listContacts.ItemsSource = contacts;
    }


    public class Contact
    {

        public string Name { get; set; }
        public string Email { get; set; }
    }

}
