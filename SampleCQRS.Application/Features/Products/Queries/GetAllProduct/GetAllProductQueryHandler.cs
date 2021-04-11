using AutoMapper;
using SampleCQRS.Application.CQRSInfrastructure;
using SampleCQRS.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryResponse : IQueryHandler<GetAllProductQuery, List<GetAllProductQuery>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductQueryResponse(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<GetAllProductQuery> Handle(GetAllProductQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllProductQuery>> HandleAsync(GetAllProductQuery query)
        {
            var productList = await _unitOfWork.Products.GetAllAsync();
            var mappedProduct = _mapper.Map<List<GetAllProductQuery>>(productList);
            return mappedProduct;
        }
    }
}
