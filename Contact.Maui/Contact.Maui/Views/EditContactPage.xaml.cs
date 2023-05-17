
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

    private void btnCanelContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    public string ContactId 
    {

        set 
        {  
            contact = ContactRepository.GetContactById(int.Parse(value));
            lblName.Text = contact.Name;
        }
    }

    
}