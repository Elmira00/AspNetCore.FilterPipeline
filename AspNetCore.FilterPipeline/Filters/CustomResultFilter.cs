using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.FilterPipeline.Filters
{
    public class CustomResultFilter : IResultFilter
    {
        private readonly ILogger _logger;

        public CustomResultFilter(ILogger<CustomResultFilter> logger)
        {
            _logger = logger;
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            //burda ise example olaraq header ve method'lari aliriq onlar uzerinde emeliyyat edirik 
            var headers = context.HttpContext.Request.Headers;
            var method = context.HttpContext.Request.Method;
            //meselen headers'de esas TOKEN olur, content type ola bilir.
            _logger.LogInformation("HTTP Method : {Method}", method);
            _logger.LogInformation("Request Headers : {Headers}", headers);

            if (context.Result is ObjectResult result)
            {
                //burda hemin result'u alib deyisirik ozumuz , modify edirik.
                result.Value = new { Message = "This result was modified by a result filter", Original = result.Value };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("Result executed");
        }

    }
}
