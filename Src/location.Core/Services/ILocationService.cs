using location.Core.Entities;
using System.Threading.Tasks;

namespace location.Core.Services
{
    public interface ILocationService
    {
        Task<Address> Get(double latitude, double longitude, string locale);
    }
}