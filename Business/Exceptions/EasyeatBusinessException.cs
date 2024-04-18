namespace easyeat.Business.Exceptions
{
    public class EasyeatBusinessException : Exception
    {
        public EasyeatBusinessException(string message) : base(message) { }

        public EasyeatBusinessException() : base() { }

        public EasyeatBusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
