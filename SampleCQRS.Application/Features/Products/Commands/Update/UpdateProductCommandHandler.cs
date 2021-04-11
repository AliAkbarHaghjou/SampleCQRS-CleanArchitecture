using AutoMapper;
using SampleCQRS.Application.CQRSInfrastructure;
using SampleCQRS.Application.Repositories;
using SampleCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Handle(UpdateProductCommand command)
        {
            var product = _mapper.Map<Product>(command);
            _unitOfWork.Products.Update(product);
            _unitOfWork.Commit();
        }

        public Task HandleAsync(UpdateProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
