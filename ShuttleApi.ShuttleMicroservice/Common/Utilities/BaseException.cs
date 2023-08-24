namespace ShuttleApi.ShuttleMicroservice.Common.Utilities
{
    public class BaseException : Exception
    {
        public string ErrorMessage { get; set; }
    }
}
