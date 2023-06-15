using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class ReceiverService : IReceiverService
    {
        readonly IReceiverRepository _ReceiverRepository;

        public ReceiverService(IReceiverRepository ReceiverRepository)
        {
           this._ReceiverRepository = ReceiverRepository;
        }
        public IEnumerable<Receiver> GetAll()
        {
            return _ReceiverRepository.GetAll();
        }

        public Receiver Get(string id)
        {
            return _ReceiverRepository.Get(id);
        }

        public Receiver Save(Receiver receiver)
        {
            _ReceiverRepository.Save(receiver);
            return receiver;
        }

        public Receiver Update(string id, Receiver receiver)
        {
            return _ReceiverRepository.Update(id, receiver);
        }

        public bool Delete(string id)
        {
            return _ReceiverRepository.Delete(id);
        }

    }
}
