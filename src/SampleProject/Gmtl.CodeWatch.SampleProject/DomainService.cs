using System.Collections.Generic;

namespace Gmtl.CodeWatch.SampleProject
{
    public class DomainService
    {
        public List<DomainModel> GetElements()
        {
            try
            {
                //simulate returing data from database
                return new List<DomainModel>();
            }
            catch
            {
                return new List<DomainModel>();
            }
        }
    }
}