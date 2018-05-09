using PapaBobsMegaChallenge.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.Persistence
{
    public class OrderRepository : IOrderRepository

    {

        public void CreateOrder(DTO.OrderDTO dtoOrder)
        {
            var db = new PapaBobsDBEntities();
            Order order = convertToEntity(dtoOrder);
            db.Orders.Add(order);
            db.SaveChanges();
        }
        private Order convertToEntity(DTO.OrderDTO dtoOrder)
        {
            var order = new Order();
            order.OrderId = dtoOrder.OrderId;
            order.Size = dtoOrder.Size;
            order.Crust = dtoOrder.Crust;
            order.Pepperoni = dtoOrder.Pepperoni;
            order.Sausage = dtoOrder.Sausage;
            order.Onion = dtoOrder.Onion;
            order.Green_Pepper = dtoOrder.Green_Pepper;
            order.Name = dtoOrder.Name;
            order.Address = dtoOrder.Address;
            order.Zip_Code = dtoOrder.Zip_Code;
            order.Phone = dtoOrder.Phone;
            order.Payment_Type = dtoOrder.Payment_Type;
            order.Completed = dtoOrder.Completed;
            order.Total_Cost = dtoOrder.Total_Cost;

            return order;
        }

        

        public List<DTO.OrderDTO> GetOrders()
        {
            var db = new PapaBobsDBEntities();
            var dbOrders = db.Orders.Where(p => p.Completed == false).ToList();

            var dtoOrders = convertToDTO(dbOrders);
            return dtoOrders;
        }
        
        public List<DTO.OrderDTO> convertToDTO(List<Order> dbOrders)

        {
            var dtoOrders = new List<DTO.OrderDTO>();
            foreach (var dbOrder in dbOrders)
            
            {
                var dtoOrder = new DTO.OrderDTO
                {
                    OrderId = dbOrder.OrderId,
                    Size = dbOrder.Size,
                    Crust = dbOrder.Crust,
                    Pepperoni = dbOrder.Pepperoni,
                    Sausage = dbOrder.Sausage,
                    Onion = dbOrder.Onion,
                    Green_Pepper = dbOrder.Green_Pepper,
                    Name = dbOrder.Name,
                    Address = dbOrder.Address,
                    Zip_Code = dbOrder.Zip_Code,
                    Phone = dbOrder.Phone,
                    Payment_Type = dbOrder.Payment_Type,
                    Total_Cost = dbOrder.Total_Cost
                };

                dtoOrders.Add(dtoOrder);
            }
            return dtoOrders;
        }

        public void CompleteOrder(Guid orderID)
        {
            var db = new PapaBobsDBEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderID);
            order.Completed = true;
            db.SaveChanges();
        }
    }

}
