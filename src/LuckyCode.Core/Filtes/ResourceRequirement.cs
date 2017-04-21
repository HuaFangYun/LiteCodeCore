using Microsoft.AspNetCore.Authorization;

namespace LuckyCode.Core.Filtes
{
    public static class Policies
    {
        public const string CanViewUsers = "CanViewUsers";
        
    }
    public class ResourceRequirement:IAuthorizationRequirement
    {
        public ResourceRequirement() { }
        public ResourceRequirement(string area, string controller, string action)
        {
            Area = area;
            Controller = controller;
            Action = action;
        }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
