using AutoMapper;
using SampleCQRS.Application.CQRSInfrastructure;
using SampleCQRS.Application.Repositories;
using SampleCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Handle(CreateProductCommand request)
        {

        }

        public async Task HandleAsync(CreateProductCommand request)
        {
            var product = _mapper.Map<Product>(request);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
