using MatareseDB.Domain.Resources;

namespace MatareseDB.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(ExceptionTexts.NotFoundException_Message) { }
    }
}
