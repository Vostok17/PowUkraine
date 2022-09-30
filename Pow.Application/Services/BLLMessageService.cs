using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pow.Application.Models;
using Pow.Domain;
using Pow.Infrastructure.Repositories;
using Pow.Infrastructure.Repositories.Interfaces;

namespace Pow.Application.Services
{
    public class BLLMessageService : IDisposable
    {
        private readonly IMapper _mapper;

        public BLLMessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        private IUnitOfWork UnitOfWork { get; }

        public async Task<int> Add(MessageBL messageBl)
        {
            var message = this._mapper.Map<Message>(messageBl);
            return await this.UnitOfWork.Messages.AddAsync(message);
        }

        public async Task<int> Update(MessageBL messageBl)
        {
            var message = this._mapper.Map<Message>(messageBl);
            return await this.UnitOfWork.Messages.UpdateAsync(message);
        }

        public async Task<int> Delete(string id)
        {
            return await this.UnitOfWork.Messages.DeleteAsync(id);
        }

        public IEnumerable<MessageBL> GetAll()
        {
            List<MessageBL> list = new List<MessageBL>();
            foreach (Message item in this.UnitOfWork.Messages.GetAllAsync().Result)
            {
                list.Add(this._mapper.Map<MessageBL>(item));
            }

            return list;
        }

        public MessageBL GetById(string id)
        {
            var message = this.UnitOfWork.Messages.GetByIdAsync(id).Result;
            return this._mapper.Map<MessageBL>(message);
        }

        public IEnumerable<MessageBL> GetByUser(string userId)
        {
            List<MessageBL> list = new List<MessageBL>();
            foreach (Message item in this.UnitOfWork.Messages.GetByUserIdAsync(userId).Result)
            {
                list.Add(this._mapper.Map<MessageBL>(item));
            }

            return list;
        }

        public void Dispose()
        {
            this.UnitOfWork.Dispose();
        }
    }
}
