
using Model.RequestService;
using Modelo.Seguridad;
using Models.Response;
using ServicesABC.Action;
using ServicesABC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesABC.Controllers
{
    public class SeguridadController : ApiController
    {
        [ActionName("Authenticate")]
        [Route("Seguridad/Authenticate/")]
        public IHttpActionResult Authenticate([FromBody] AuthenticateRequest dataDocument)      
        {
            try
            {
                if (Request.Headers.Authorization != null)
                {
                    var headerRequest = new HeaderRequest(Request.Headers.Accept.ToString(), Request.Headers.Authorization.Scheme, Request.Headers.Authorization.Parameter);
                    var action = new AuthenticateAction(headerRequest, dataDocument);
                    return Ok(action.ActionResult);
                }
                else
                {
                    HlpLog.Warning(eService.ServiceAuthentication, "", CodeMessages.InvalidHeaderParameters);
                    ResponseStatus response = HlpGenerateResponse.GeneratePostResponse("0400", HlpLog.GetEnumDescription(CodeMessages.InvalidHeaderParameters), "Undefined", string.Empty, "0");
                    response.Result.Add("Errors", HlpLog.GetEnumDescription(CodeMessages.InvalidHeaderParameters));
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                ResponseStatus response = HlpGenerateResponse.GeneratePostResponse("0500", HlpLog.GetEnumDescription(CodeMessages.InvalidHeaderParameters), "Undefined", string.Empty, "0");
                response.Result.Add("Errors", ex.Message);
                HlpLog.Error(eService.ServiceAuthentication, "", CodeMessages.InvalidHeaderParameters, ex);
                return Ok(response);
            }
        }
        
    }
}
