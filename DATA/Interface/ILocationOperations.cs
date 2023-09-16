using DATA.Models;

namespace DATA.Interface
{
    public interface ILocationOperations
    {
        Task<GenericResultSet<Locations>> GetIpDetailsAsync(string ip_address);
    }
}
