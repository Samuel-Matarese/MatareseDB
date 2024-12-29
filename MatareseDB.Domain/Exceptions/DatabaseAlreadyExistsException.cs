using MatareseDB.Domain.Resources;

namespace MatareseDB.Domain.Exceptions
{
    public class DatabaseAlreadyExistsException : Exception
    {
        public DatabaseAlreadyExistsException() : base(ExceptionTexts.DatabaseAlreadyExistsException_Message) { }
    }
}
