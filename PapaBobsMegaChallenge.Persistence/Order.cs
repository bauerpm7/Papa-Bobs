//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PapaBobsMegaChallenge.Persistence
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public System.Guid OrderId { get; set; }
        public DTO.Enums.SizeType Size { get; set; }
        public DTO.Enums.CrustType Crust { get; set; }
        public bool Pepperoni { get; set; }
        public bool Sausage { get; set; }
        public bool Onion { get; set; }
        public bool Green_Pepper { get; set; }
        public decimal Total_Cost { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip_Code { get; set; }
        public string Phone { get; set; }
        public DTO.Enums.PaymentType Payment_Type { get; set; }
        public bool Completed { get; set; }
    }
}
