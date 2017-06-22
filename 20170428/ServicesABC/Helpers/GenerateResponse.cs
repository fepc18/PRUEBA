using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Response;
using Models.Response;

namespace ServicesABC.Helpers
{
    public static class HlpGenerateResponse
    {
        public static ResponseStatus GeneratePostResponse(string code, string detail, string iosId, string messageError, string registerAfected)
        {
            ResponseStatus response = new ResponseStatus();
            response.Status.Code = code;
            response.Status.Detail = detail;
            response.Status.ServerId = "654987";
            response.Status.IosId = iosId;
            response.Status.MessageError = messageError;
            response.Result.Add("RegisterAfected", registerAfected);
            return response;
        }
        public static ResponseStatus GenerateGetResponse(string code, string detail, string iosId, string messageError, string registerAfected)
        {
            ResponseStatus response = new ResponseStatus();
            response.Status.Code = code;
            response.Status.Detail = detail;
            response.Status.ServerId = "654987";
            response.Status.IosId = iosId;
            response.Status.MessageError = messageError;
            return response;
        }
    }
}