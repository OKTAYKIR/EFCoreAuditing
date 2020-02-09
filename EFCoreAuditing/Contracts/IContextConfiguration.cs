using EFCoreAuditing.Models;

namespace EFCoreAuditing.Contracts
{
    public interface IContextConfiguration
    {
        DataStoreType Type { get; }
    }
}
