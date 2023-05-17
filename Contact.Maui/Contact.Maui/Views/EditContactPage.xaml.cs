
namespace Contact.Maui.Views;

using Contact.Maui.Models;
using Contact = Contact.Maui.Models.Contact;
[QueryProperty(nameof(ContactId),"Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

  
    public string ContactId 
    {

        set 
        {  
            contact = ContactRepository.GetContactById(int.Parse(value));
        }
    }

    
}