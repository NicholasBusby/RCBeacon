using System.Threading.Tasks;

namespace RCBeacon.SharedInterfaces
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }
}
