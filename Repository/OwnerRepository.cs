using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        //public IEnumerable<Owner> GetAllOwners()
        //{
        //    return FindAll()
        //        .OrderBy(ow => ow.Name)
        //        .ToList();
        //}
        //public Owner GetOwnerById(Guid ownerId)
        //{
        //    return FindByCondition(owner => owner.OwnerId.Equals(ownerId))
        //        .FirstOrDefault();
        //}

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await FindAll()
                .OrderBy(ow => ow.Name)
                .ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerid)
        {
            return await FindByCondition(x => x.OwnerId.Equals(ownerid))
                .FirstOrDefaultAsync();
        }
    }
}
