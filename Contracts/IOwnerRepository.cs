using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);
        Owner GetOwnerWithDetails(Guid ownerId);

        //IEnumerable<Owner> GetAllOwners();
        //Owner GetOwnerById(Guid ownerId);
    }
}
