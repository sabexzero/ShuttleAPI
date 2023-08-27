using ShuttleApi.ShuttleMicroservice.Common.Utilities;

namespace ShuttleApi.ShuttleMicroservice.Common.Exceptions.Shuttle
{
    public class ShuttleAlreadyExistException : BaseException
    {
        public ShuttleAlreadyExistException()
        {
            ErrorMessage = "Shuttle is already exists in db";
        }
    }
}
