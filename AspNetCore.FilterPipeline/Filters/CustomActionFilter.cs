using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.FilterPipeline.Filters
{

    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)//sirf ozune aid olan sheyleri log etsin 
            //deye hemin custom class'in adini type olaraq ILogger'e gonderiririk.
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)//hemin istediyimiz action uje oldu.
            //Deyek ki ; hemin o action method ishledi, ona gelen parametrleri context'de aliriq
            //result'i/gelen arqumentleri hamisini context'den aliriq
            //qisaca action filter sirf bu context'in ustunde ishleyir
        {
            _logger.LogInformation("OnActionExecuted : Executed action method");
           
        }

        public void OnActionExecuting(ActionExecutingContext context)//hemin istediyimiz action olur
        {
            _logger.LogInformation("OnActionExecuting : Executing action method");
          
        }
    }
}
