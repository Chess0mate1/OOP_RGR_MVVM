using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.ViewModels
{
    internal class CustomerVM
    {
        public ObservableCollection<StoreProductsVM> StoreProductsVM { get; set; } = new();

        //public ProductTypeSelectionVM ProductTypeSelectionVM { get; set; } = new();
        //public StoreProductsVM ActiveStoreProductsVM { get; set; }
        //public CartProductsVM CartProductsVM { get; set; }
        //public PaymentVM PaymentVM { get; set; }
        public ProductTypeSelectionVM ProductTypeSelectionVM { get; set; } = new();
        //public StoreProductsVM ActiveStoreProductsVM { get; set; }
        public CartProductsVM CartProductsVM { get; set; }
        public PaymentVM PaymentVM { get; set; }
    }
}
