using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobsMegaChallenge.Domain.Interfaces;
using PapaBobsMegaChallenge.DTO;
using PapaBobsMegaChallenge.Persistence;

namespace PapaBobsMegaChallenge.Domain
{
    public class PizzaPriceManager
    {
        private static IPriceRepository _priceRepository;

        public PizzaPriceManager(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }
        public static decimal CalculateCost(OrderDTO order)
        {
            decimal cost = 0M;
            PizzaPrice prices = getPizzaPrice();
            cost += calculateSizeCost(order, prices);
            cost += calculateCrustCost(order, prices);
            cost += calculateToppingsCost(order, prices);

            return cost;
        }

        private static decimal calculateSizeCost(OrderDTO order, PizzaPrice prices)
        {
            decimal cost = 0.0M;

            switch (order.Size)
            {
                case DTO.Enums.SizeType.Small:
                    cost = prices.SmallSizeCost;
                    break;

                case DTO.Enums.SizeType.Medium:
                    cost = prices.MediumSizeCost;
                    break;

                case DTO.Enums.SizeType.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;

            }

            return cost;
        }

        private static decimal calculateCrustCost(OrderDTO order, PizzaPrice prices)
        {
            decimal cost = 0.0M;
            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    cost = prices.RegularCrustCost;
                    break;

                case DTO.Enums.CrustType.Thin:
                    cost = prices.ThinCrustCost;
                    break;

                case DTO.Enums.CrustType.Thick:
                    cost = prices.ThickCrustCost;
                    break;

                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateToppingsCost(OrderDTO order, PizzaPrice prices)
        {
            var cost = 0.0M;

            cost += (order.Pepperoni) ? prices.PepperoniCost : 0M;
            cost += (order.Sausage) ? prices.SausageCost : 0M;
            cost += (order.Onion) ? prices.OnionCost : 0M;
            cost += (order.Green_Pepper) ? prices.GreenPepperCost : 0M;

            return cost;
        }

        private static PizzaPrice getPizzaPrice()
        {
            var pricesDTO = _priceRepository.GetPizzaPrice();
            if (pricesDTO == null) throw new ArgumentNullException(nameof(pricesDTO));
            var prices = AutoMapper.Mapper.Map<PizzaPriceDTO,PizzaPrice>(pricesDTO);
            return prices;
        }
    }

}
