namespace Gmtl.CodeWatch.Tests.Samples.PropertyNaming
{
    public class PropertyNamingInheritance : PropertyNamingInheritanceParent
    {
        public int ChildInt { get; set; }
        protected int ChildProtectedInt { get; set; }
    }

    public class PropertyNamingInheritanceParent
    {
        public int ParentInt { get; set; }
        protected int parentProtectedInt { get; set; }
    }
}