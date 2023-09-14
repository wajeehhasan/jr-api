using DATA.Models;

namespace DATA.Interface
{
    public interface ILocationOperations
    {
        Task<Location?> GetIpDetailsAsync(string ip_address);
    }
}
