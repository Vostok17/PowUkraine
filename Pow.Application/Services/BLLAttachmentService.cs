using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pow.Application.Models;
using Pow.Domain;
using Pow.Infrastructure.Repositories.Interfaces;

namespace Pow.Application.Services
{
    public class BLLAttachmentService : IDisposable
    {
        private readonly IMapper _mapper;

        public BLLAttachmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        private IUnitOfWork UnitOfWork { get; }

        public async Task<int> Add(AttachmentBL attachmentBl)
        {
            var attachment = this._mapper.Map<Attachment>(attachmentBl);
            return await this.UnitOfWork.Attachments.AddAsync(attachment);
        }

        public async Task<int> Update(AttachmentBL attachmentBl)
        {
            var attachment = this._mapper.Map<Attachment>(attachmentBl);
            return await this.UnitOfWork.Attachments.UpdateAsync(attachment);
        }

        public async Task<int> Delete(string id)
        {
            return await this.UnitOfWork.Attachments.DeleteAsync(id);
        }

        public IEnumerable<AttachmentBL> GetAll()
        {
            List<AttachmentBL> list = new List<AttachmentBL>();
            foreach (Attachment item in this.UnitOfWork.Attachments.GetAllAsync().Result)
            {
                list.Add(this._mapper.Map<AttachmentBL>(item));
            }

            return list;
        }

        public IEnumerable<AttachmentBL> GetByMessageId(string messageId)
        {
            List<AttachmentBL> list = new List<AttachmentBL>();
            foreach (Attachment mark in this.UnitOfWork.Attachments.GetByMessageIdAsync(messageId).Result)
            {
                list.Add(this._mapper.Map<AttachmentBL>(mark));
            }

            return list;
        }

        public AttachmentBL GetById(string id)
        {
            var attachment = this.UnitOfWork.Attachments.GetByIdAsync(id);
            return this._mapper.Map<AttachmentBL>(attachment);
        }

        public void Dispose()
        {
            this.UnitOfWork.Dispose();
        }
    }
}
