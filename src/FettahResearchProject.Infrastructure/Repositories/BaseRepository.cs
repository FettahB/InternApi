using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Infrastructure.Repositories
{
    public class BaseRepository<T> : BaseRepository<T> where T : class
    {
    }
}
