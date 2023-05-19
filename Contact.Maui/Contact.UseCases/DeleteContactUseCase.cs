using Contact.UseCases.Interfaces;
using Contact.UseCases.PluginInterfaces;

namespace Contact.UseCases
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(int contactId)
        {
            await this.contactRepository.DeleteContactAsync(contactId);
        }
    }
}
