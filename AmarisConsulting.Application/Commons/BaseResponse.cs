using System;
namespace AmarisConsulting.Application.Commons
{
	public class BaseResponse<T>
	{
		public bool IsSuccess { get; set; }
		public T? Data { get; set; }
		public string? Messages { get; set; }
	}
}

