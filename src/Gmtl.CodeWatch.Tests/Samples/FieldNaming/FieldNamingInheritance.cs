namespace Gmtl.CodeWatch.Tests.Samples.FieldNaming
{
    public class FieldNamingInheritance : FieldNamingInheritanceParent
    {
        public int ChildInt;
        protected int ChildProtectedInt;
    }

    public class FieldNamingInheritanceParent
    {
        public int ParentInt;
        protected int parentProtectedInt; 
    }
}