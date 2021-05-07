using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenChargeApiClient
{
    public interface IOpenChargeHttpClient
    {
        Task<IList<OpenChargerResponse>> GetChargers(string boundingBox);
    }
}