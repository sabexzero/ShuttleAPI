using ShuttleApi.ShuttleMicroservice.Common.Utilities;

namespace ShuttleApi.ShuttleMicroservice.Common.Exceptions.Shuttle
{
    public class DeleteErrorException : BaseException
    {
        public DeleteErrorException()
        {
            ErrorMessage = "Something wrong with deleting entity";
        }
    }
}
