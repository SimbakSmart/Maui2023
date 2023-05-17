namespace Contact.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void btnCanelContact_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("..");
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }
}