using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class SenderService : ISenderService
    {
        readonly ISenderRepository _SenderRepository;

        public SenderService(ISenderRepository SenderRepository)
        {
           this._SenderRepository = SenderRepository;
        }
        public IEnumerable<Sender> GetAll()
        {
            return _SenderRepository.GetAll();
        }

        public Sender Get(string id)
        {
            return _SenderRepository.Get(id);
        }

        public Sender Save(Sender sender)
        {
            _SenderRepository.Save(sender);
            return sender;
        }

        public Sender Update(string id, Sender sender)
        {
            return _SenderRepository.Update(id, sender);
        }

        public bool Delete(string id)
        {
            return _SenderRepository.Delete(id);
        }

    }
}
