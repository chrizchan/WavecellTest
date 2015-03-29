using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wavecell.Entities;
using Wavecell.Repository.Common;

namespace Wavecell.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

    }

    public interface IUserRepository : IRepository<User>
    {
        
    }
}
