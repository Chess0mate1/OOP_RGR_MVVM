using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Factory
{
    internal class ProductVMsCreator
    {
        public List<ProductVM> Create()
        {
            List<ProductVM> Products = new();

            Products.AddRange(new List<ProductVM>()
            {
                new(
                   new()
                   {
                       Id = 0,
                       Name = "Heavy",
                       Count = 3,
                       Price = 55400,
                       Image = "Resources\\Images\\Heavy.png"
                   }
                ),
                new(
                   new()
                   {
                       Id = 1,
                       Name = "Les Paul",
                       Count = 8,
                       Price = 41000,
                       Image = "Resources\\Images\\LesPaul.png"
                   }
                ),
                new(
                   new()
                   {
                       Id = 2,
                       Name = "PRS",
                       Count = 10,
                       Price = 44400,
                       Image = "Resources\\Images\\PRS.png"
                   }
                ),
                new(
                   new()
                   {
                       Id = 3,
                       Name = "PRS",
                       Count = 27,
                       Price = 32000,
                       Image = "Resources\\Images\\SG.png"
                   }
                ),
                new(
                   new()
                   {
                       Id = 4,
                       Name = "Stratocaster",
                       Count = 25,
                       Price = 25000,
                       Image = "Resources\\Images\\Stratocaster.png"
                   }
                ),
                new(
                   new()
                   {
                       Id = 5,
                       Name = "SuperStrat",
                       Count = 7,
                       Price = 52400,
                       Image = "Resources\\Images\\SuperStrat.png"
                   }
                ),
                new(
                   new()
                   {
                       Id = 6,
                       Name = "Telecaster",
                       Count = 20,
                       Price = 31000,
                       Image = "Resources\\Images\\Telecaster.png"
                   }
                )
            });

            return Products;
        } 
    }
}
