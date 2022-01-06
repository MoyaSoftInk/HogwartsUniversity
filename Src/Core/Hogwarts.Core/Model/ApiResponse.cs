namespace Hogwarts.Core.Model
{
    using System.Net;

    public class ApiResponse<T>
    {
        public HttpStatusCode Code { get; set; }
        public string Description { get; set; }
        public T Structure { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(HttpStatusCode code, string description, T structure)
        {
            this.Code = code;
            this.Description = description;
            this.Structure = structure;
        }
    }
}
