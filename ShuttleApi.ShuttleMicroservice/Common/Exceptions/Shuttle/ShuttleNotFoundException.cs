using ShuttleApi.ShuttleMicroservice.Common.Utilities;

namespace ShuttleApi.ShuttleMicroservice.Common.Exceptions.Shuttle
{
    public class ShuttleNotFoundException : BaseException
    {
        public ShuttleNotFoundException()
        {
            ErrorMessage = "Shuttle doesnt exist in db";
        }
    }
}
