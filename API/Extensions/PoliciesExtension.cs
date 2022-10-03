using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using Core.Models.Identity;

namespace API.Extensions
{
    public static class PoliciesExtension
    {
        public static PoliciesDTO ConvertTagsToPolicies(this List<UserTag> tags)
        {
            PoliciesDTO policy = new PoliciesDTO() {
                CanCheckErrors = false
            };

            foreach (var userTag in tags)
                if (userTag.CanCheckErrors == true)
                    policy.CanCheckErrors = true;

            return policy;
        }
    }
}