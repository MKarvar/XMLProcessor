using System;


namespace XMLProcessor.Server.Application.Exceptions
{
    public class XMLProcessorApplicationException : Exception
    {
        public XMLProcessorApplicationException()
        {

        }

        public XMLProcessorApplicationException(string errorMessage) : base(errorMessage)
        {

        }

        public XMLProcessorApplicationException(string errorMessage, Exception innerException) : base(errorMessage, innerException)
        {

        }
    }
}
