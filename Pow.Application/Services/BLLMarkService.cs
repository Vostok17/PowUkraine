using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pow.Application.Models;
using Pow.Domain;
using Pow.Infrastructure.Repositories.Interfaces;

namespace Pow.Application.Services
{
    public class BLLMarkService : IDisposable
    {
        private readonly IMapper _mapper;

        public BLLMarkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        private IUnitOfWork UnitOfWork { get; }

        public async Task<int> Add(MarkBL markBl)
        {
            var mark = this._mapper.Map<Mark>(markBl);
            return await this.UnitOfWork.Marks.AddAsync(mark);
        }

        public async Task<int> Update(MarkBL markBl)
        {
            var mark = this._mapper.Map<Mark>(markBl);
            return await this.UnitOfWork.Marks.UpdateAsync(mark);
        }

        public async Task<int> Delete(string id)
        {
            return await this.UnitOfWork.Marks.DeleteAsync(id);
        }

        public IEnumerable<MarkBL> GetAll()
        {
            List<MarkBL> list = new List<MarkBL>();
            foreach (Mark item in this.UnitOfWork.Marks.GetAllAsync().Result)
            {
                list.Add(this._mapper.Map<MarkBL>(item));
            }

            return list;
        }

        public MarkBL GetByMessage(string messageId)
        {
            var mark = this.UnitOfWork.Marks.GetByMessageIdAsync(messageId);
            return this._mapper.Map<MarkBL>(mark);
        }

        public MarkBL GetById(string id)
        {
            var mark = this.UnitOfWork.Marks.GetByIdAsync(id).Result;
            return this._mapper.Map<MarkBL>(mark);
        }

        public void Dispose()
        {
            this.UnitOfWork.Dispose();
        }
    }
}
