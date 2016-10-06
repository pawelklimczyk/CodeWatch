using System.Collections.Generic;

namespace Gmtl.CodeWatch.Tests.Samples.PropertyNaming
{
    public class PropertyNamingPublicLowercase
    {
        public string property1 { get; set; }
        public object property2 { get; set; }
        public List<object> property3 { get; set; }
        public bool property4 { get; set; }
    }

    public class PropertyNamingProtectedLowercase
    {
        protected string property1 { get; set; }
        protected object property2 { get; set; }
        protected List<object> property3 { get; set; }
        protected bool property4 { get; set; }
    }

    public class PropertyNamingPrivateLowercase
    {
        private string property1 { get; set; }
        private object property2 { get; set; }
        private List<object> property3 { get; set; }
        private bool property4 { get; set; }
    }
}