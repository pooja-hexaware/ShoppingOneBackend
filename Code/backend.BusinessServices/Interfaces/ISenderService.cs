using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface ISenderService
    {      
        IEnumerable<Sender> GetAll();
        Sender Get(string id);
        Sender Save(Sender sender);
        Sender Update(string id, Sender sender);
        bool Delete(string id);

    }
}
