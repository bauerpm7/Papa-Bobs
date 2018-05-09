using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobsMegaChallenge.Domain.Interfaces
{
    public interface IPriceRepository
    {
        DTO.PizzaPriceDTO GetPizzaPrice();
    }
}

