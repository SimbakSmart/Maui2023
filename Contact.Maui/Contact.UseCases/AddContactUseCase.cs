using Contact.UseCases.Interfaces;
using Contact.UseCases.PluginInterfaces;

namespace Contact.UseCases
{
    using Contact = Contact.CoreBusiness.Contact;
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public AddContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(Contact contact)
        {
            await this.contactRepository.AddContactAsync(contact);
        }
    }
}
