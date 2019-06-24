using System;
using System.Threading.Tasks;

namespace Kingpin.Tier.Contexts.Interfaces
{
    public interface IApplicationContext : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
