using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IReceiverService
    {      
        IEnumerable<Receiver> GetAll();
        Receiver Get(string id);
        Receiver Save(Receiver receiver);
        Receiver Update(string id, Receiver receiver);
        bool Delete(string id);

    }
}
