using AutoMapper;
using SampleCQRS.Application.CQRSInfrastructure;
using SampleCQRS.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryResponse : IQueryHandler<GetProductByIdQuery, GetProductByIdQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryResponse(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetProductByIdQuery Handle(GetProductByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<GetProductByIdQuery> HandleAsync(GetProductByIdQuery query)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(query.Id);
            var mappedProduct = _mapper.Map<GetProductByIdQuery>(product);
            return mappedProduct;
        }
    }
}
