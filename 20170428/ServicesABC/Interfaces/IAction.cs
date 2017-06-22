using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Response;
using Models.Response;

namespace ServicesABC.Interfaces
{
    interface IActions
    {
        ResponseStatus ActionResult { get; }
    }
}