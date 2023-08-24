using ShuttleApi.ShuttleMicroservice.Common.Utilities;

namespace ShuttleApi.ShuttleMicroservice.Common.Exceptions.Shuttle
{
    public class CreateErrorException : BaseException
    {
        public CreateErrorException()
        {
            ErrorMessage = "Something wrong with creating entity";
        }
    }
}
