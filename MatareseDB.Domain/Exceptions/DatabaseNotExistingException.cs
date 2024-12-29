using MatareseDB.Domain.Resources;

namespace MatareseDB.Domain.Exceptions
{
    public class DatabaseNotExistingException : Exception
    {
        public DatabaseNotExistingException() : base(ExceptionTexts.DatabaseNotExistingException_Message) { }
    }
}
