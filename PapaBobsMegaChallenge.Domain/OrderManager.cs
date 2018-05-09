using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.Domain.Interfaces;

namespace PapaBobsMegaChallenge.Domain
{
    public class OrderManager
    {
        private static IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public static void CreateOrder(DTO.OrderDTO dtoOrder)
        {
            if (dtoOrder.Name.Trim().Length == 0)
                throw new Exception("Name is a required field");
            if (dtoOrder.Address.Trim().Length == 0)
                throw new Exception("Address is a required field");
            if (dtoOrder.Zip_Code.Trim().Length == 0)
                throw new Exception("Zip Code is a required field");
            if (dtoOrder.Phone.Trim().Length == 0)
                throw new Exception("Phone Number is a required field");
            if (dtoOrder.Size == null)
                throw new Exception("Please Choose a Pizza Size");

            dtoOrder.OrderId = Guid.NewGuid();
            dtoOrder.Total_Cost = PizzaPriceManager.CalculateCost(dtoOrder);
            _orderRepository.CreateOrder(dtoOrder);
        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            
             return _orderRepository.GetOrders();
           
        }

        public static void CompleteOrder (Guid orderId)
        {
            _orderRepository.CompleteOrder(orderId);
        }
          
    }
}
