using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.Persistence;

namespace PapaBobsMegaChallenge.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(DTO.OrderDTO dtoOrder);
        List<DTO.OrderDTO> GetOrders();
        void CompleteOrder(Guid orderId);
        List<DTO.OrderDTO> convertToDTO(List<Order> dbOrders);
    }
}
