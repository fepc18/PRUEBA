using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Response;

namespace ServicesABC.Interfaces
{
    interface IServices
    {
        ValidateStatus StateService { get; }
    }
}