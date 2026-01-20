using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.FilterPipeline.Filters
{

    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("OnActionExecuted : Executed action method");
           
        }

        public void OnActionExecuting(ActionExecutingContext context)//hemin istediyimiz action olur
        {
            _logger.LogInformation("OnActionExecuting : Executing action method");
            //demeli burda real example var 
            //guya ki hemin action method uchun name constraint'i var
            //ve biz bunu filter sayesinde yoxlaya bilerik
            var queryParams = context.HttpContext.Request.Query;
            var routeParams = context.RouteData.Values;
            //ilk once method icra olunarken methoda gelen query params ve route params alib console'a log edirik
            _logger.LogInformation("Query Parameters : {QueryParams}", queryParams);
            _logger.LogInformation("Route Parameters : {RouteParams}", routeParams);
            //daha sonra query params'in icinde name olub olmadigini yoxlayiriq
            //eger name olmasa  filter sayesinde bir result cixara bilerik console'a 
            if (!queryParams.ContainsKey("name"))
            {
                context.Result = new BadRequestObjectResult("Missing required name query param");
            }
        }
    }
}
