using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // public ProductService(IMapper mapper , IProductRepository repository)
        // {
        //     _mapper = mapper;
        //     _productRepository=repository ?? throw new ArgumentException(nameof(repository));
        // }


        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery  = new GetProductsQuery();
            if(productsQuery == null)
                throw new ApplicationException($"Entity could not be loaded");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productsQuery  = new GetProductByIdQuery(id.Value);
            if(productsQuery == null)
                throw new ApplicationException($"Entity could not be loaded");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        // public async Task<ProductDTO> GetProductCategory(int? id)
        // {
        //     var productsQuery  = new GetProductByIdQuery(id.Value);
        //     if(productsQuery == null)
        //         throw new ApplicationException($"Entity could not be loaded");
        //     var result = await _mediator.Send(productsQuery);
        //     return _mapper.Map<ProductDTO>(result);
        // }

        public async Task Add(ProductDTO productdto)
        {
            var productcommand = _mapper.Map<ProductCreateCommand>(productdto);
            await _mediator.Send(productcommand);
        }

        public async Task Update(ProductDTO productdto)
        {
            var productcommand = _mapper.Map<ProductUpdateCommand>(productdto);
            await _mediator.Send(productcommand);
        }

        public async Task Remove(int? id)
        {
            var productcommand = new ProductRemoveCommand(id.Value);
            if(productcommand==null)
                throw new ApplicationException($"Entity could not be loaded");

            await _mediator.Send(productcommand);
        }
    }
}