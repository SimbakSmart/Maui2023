

namespace Contact.UseCases
{
    using Contact.UseCases.PluginInterfaces;
    using Contact = Contact.CoreBusiness.Contact;
    public class ViewContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public ViewContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await this.contactRepository.GetContactsAsync(filterText);
        }
    }
}
