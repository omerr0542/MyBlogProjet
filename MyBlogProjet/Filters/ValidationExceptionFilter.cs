using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyBlogProjet.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        // Burada daha önce istenilen ValidationException yakalama ve ModelState'e hata ekleme işlemi gerçekleştiriliyor.
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not ValidationException validationException)
            {
                return;
            }

            foreach (var error in validationException.Errors)
            {
                context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            var actionName = context.RouteData.Values["action"]?.ToString();
            context.Result = new ViewResult
            {
                ViewName = actionName
            };

            context.ExceptionHandled = true;
        }
    }
}
