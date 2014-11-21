using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbracoCI.Extensions.Models;

namespace UmbracoCI.Extensions.Repositories
{
    interface ISampleRepository
    {
        IEnumerable<Enquiry> GetAll();
        Enquiry Get(int id);
        bool Update(Enquiry poco);
        bool Delete(Enquiry poco);
        bool Create(Enquiry poco);
    }
}
