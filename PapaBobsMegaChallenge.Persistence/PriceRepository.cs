using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PapaBobsMegaChallenge.Domain.Interfaces;
using PapaBobsMegaChallenge.DTO;

namespace PapaBobsMegaChallenge.Persistence
{
    
    public class PriceRepository : IPriceRepository
    {
       
        public PizzaPriceDTO GetPizzaPrice()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PizzaPriceDTO, PizzaPrice>());
            var db = new PapaBobsDBEntities();
            var prices = db.PizzaPrices.First();
            var dtoPrice = ConvertToDto(prices);
            return dtoPrice;
        }

        private static PizzaPriceDTO ConvertToDto(PizzaPrice pizzaPrice)
        {
            
            var dtoPrice = new PizzaPriceDTO();

            dtoPrice.SmallSizeCost = pizzaPrice.SmallSizeCost;
            dtoPrice.MediumSizeCost = pizzaPrice.MediumSizeCost;
            dtoPrice.LargeSizeCost = pizzaPrice.LargeSizeCost;
            dtoPrice.RegularCrustCost = pizzaPrice.RegularCrustCost;
            dtoPrice.ThinCrustCost = pizzaPrice.ThinCrustCost;
            dtoPrice.ThickCrustCost = pizzaPrice.ThickCrustCost;
            dtoPrice.PepperoniCost = pizzaPrice.PepperoniCost;
            dtoPrice.SausageCost = pizzaPrice.SausageCost;
            dtoPrice.OnionCost = pizzaPrice.OnionCost;
            dtoPrice.GreenPepperCost = pizzaPrice.GreenPepperCost;
            

            return dtoPrice;
        }
    }
}
