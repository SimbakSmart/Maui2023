

namespace Contact.UseCases
{
    using Contact.UseCases.Interfaces;
    using Contact.UseCases.PluginInterfaces;
    using Contact = Contact.CoreBusiness.Contact;
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        private readonly IContactRepository contactRepository;

        public ViewContactsUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await this.contactRepository.GetContactsAsync(filterText);
        }
    }
}
