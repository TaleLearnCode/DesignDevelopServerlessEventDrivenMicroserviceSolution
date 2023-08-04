using System.Runtime.Serialization;

namespace BuildingBlocks.Core.Exceptions;

[Serializable]
public class BatchSizeTooLargeException : Exception
{

	public BatchSizeTooLargeException() : base("Message is too large for the batch and cannot be sent.") { }

	public BatchSizeTooLargeException(string message) : base(message) { }

	public BatchSizeTooLargeException(string message, Exception innerException) : base(message, innerException) { }

	public BatchSizeTooLargeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

}