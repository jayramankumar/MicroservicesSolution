using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Mapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderPesponse>
    {
        private readonly IOrderPepository _orderRepository;

        public CheckoutOrderHandler(IOrderPepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<OrderPesponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntiry = OrderMapper.Mapper.Map<Order>(request);
            if(orderEntiry == null)
            {
                throw new ApplicationException("not mapped");
            }

            var newOrder = await _orderRepository.AddAsync(orderEntiry);

            var orderResponse = OrderMapper.Mapper.Map<OrderPesponse>(newOrder);
            return orderResponse;
        }
    }
}
