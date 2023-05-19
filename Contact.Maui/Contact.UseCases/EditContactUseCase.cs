
using Contact.UseCases.Interfaces;
using Contact.UseCases.PluginInterfaces;

namespace Contact.UseCases
{
    using Contact = Contact.CoreBusiness.Contact;
    public class EditContactUseCase : IEditContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public EditContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(int contactId, Contact contact)
        {
            await this.contactRepository.UpdateContactAsync(contactId, contact);
        }
    }
}
