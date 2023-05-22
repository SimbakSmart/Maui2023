using Contact.Maui.ViewModels;

namespace Contact.Maui.Views_MVM;


[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage_MVVM : ContentPage
{
    private readonly ContactViewModel contactViewModel;

    public EditContactPage_MVVM(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        this.contactViewModel = contactViewModel;
        this.BindingContext = this.contactViewModel;
    }

    public string ContactId
    {
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int contactId))
            {
                LoadContact(contactId);
            }
        }
    }

    private async void LoadContact(int contactId)
    {
        await this.contactViewModel.LoadContact(contactId);
    }
}