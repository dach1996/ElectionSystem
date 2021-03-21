using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Dach.ElectionSystem.Utils.Filters
{
    public class ModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var a = context.ActionArguments.First().Value;
            var validatorContext = new ValidationContext(a);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(a, validatorContext, results, true);

            base.OnActionExecuting(context);
        }
    }

}
