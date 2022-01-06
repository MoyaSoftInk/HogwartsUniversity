namespace Hogwarts.Core.EF.Filters
{
    using Microsoft.EntityFrameworkCore;
    using System.Web.Http.Filters;

    public class RequireDbContextAttribute : ActionFilterAttribute
    {
        private readonly DbContext context;

        public RequireDbContextAttribute(DbContext context)
        {
            this.context = context;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                this.context?.SaveChanges();
            }
            finally
            {
                this.context?.Dispose();
            }
        }
    }
}
