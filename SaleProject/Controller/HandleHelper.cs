using DataObjectAccess;
using System.Data.Entity;
using System.Linq;

namespace Controller
{
    public class HandleHelper
    {
        private static SaleContext _SaleContext;

        public HandleHelper()
        {
            
        }

        public static SaleContext GetInstance()
        {
            if (_SaleContext == null)
            {
                _SaleContext = new SaleContext();
                _SaleContext.Database.CreateIfNotExists();
            }
            return _SaleContext;
        }

        public static void RevertChange()
        {
            var changedEntries = _SaleContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            
            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
