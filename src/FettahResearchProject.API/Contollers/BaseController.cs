using FettahResearchProject.Application.ApiServices.Base.Response;
using Microsoft.AspNetCore.Mvc;

namespace FettahResearchProject.API.Contollers
{
    
    public class BaseController : ControllerBase
    {
        public IActionResult ReturnResponse<T>(T model) where T : ResponseBase
        {
            return model.StatusCode > 0 ? StatusCode((int)model.StatusCode, model) : BadRequest(value);
        }
    }
}
