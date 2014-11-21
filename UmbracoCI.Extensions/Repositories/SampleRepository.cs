using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using UmbracoCI.Extensions.Models;

namespace UmbracoCI.Extensions.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private UmbracoDatabase _db;

        public SampleRepository(Umbraco.Core.Persistence.UmbracoDatabase db) {
            _db = db;
        }

        public IEnumerable<Enquiry> GetAll()
        {
            return _db.Fetch<Enquiry>(string.Empty);
        }

        public Enquiry Get(int id)
        {
            return _db.Fetch<Enquiry>("WHERE id = @0", id).FirstOrDefault();
        }

        public bool Update(Enquiry poco)
        {
            using (var trx = _db.GetTransaction())
            {
                try { 
                    _db.Save(poco);
                    trx.Complete();
                    return true;
                }
                catch
                {
                    _db.AbortTransaction();
                    return false;
                }
            }
        }

        public bool Delete(Enquiry poco)
        {
            using (var trx = _db.GetTransaction())
            {
                try
                {
                    _db.Delete<Enquiry>(poco);
                    trx.Complete();
                    return true;
                }
                catch
                {
                    _db.AbortTransaction();
                    return false;
                }
            }
        }

        public bool Create(Enquiry poco)
        {
            using (var trx = _db.GetTransaction())
            {
                try
                {
                    _db.Insert("Enquiry", "ID", poco);
                    trx.Complete();
                    return true;
                }
                catch
                {
                    _db.AbortTransaction();
                    return false;
                }
            }
        }
    }
}
