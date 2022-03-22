namespace XMLProcessor.Server.Infrastructure.Exception
{
    public class XMLProcessorInfrastructureException : System.Exception
    {
        public XMLProcessorInfrastructureException()
        {

        }

        public XMLProcessorInfrastructureException(string errorMessage) : base(errorMessage)
        {

        }

        public XMLProcessorInfrastructureException(string errorMessage, System.Exception innerException) : base(errorMessage, innerException)
        {

        }
    }
}
