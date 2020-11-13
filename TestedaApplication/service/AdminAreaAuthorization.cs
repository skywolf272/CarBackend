using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace TestedaApplication.service
{
    public class AreaAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AreaAuthorization(string _area, string _policy)
        {
            area = _area;
            policy = _policy;
        }
        public void Apply(ControllerModel controller)
        {
            if(controller.Attributes.Any(a =>
            a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any( r => 
                r.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && r.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
