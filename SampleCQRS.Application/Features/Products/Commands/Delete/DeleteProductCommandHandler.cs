using AutoMapper;
using SampleCQRS.Application.CQRSInfrastructure;
using SampleCQRS.Application.Repositories;
using SampleCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Handle(DeleteProductCommand command)
        {
        }

        public async Task HandleAsync(DeleteProductCommand command)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.id);
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Commit();
        }
    }
}
