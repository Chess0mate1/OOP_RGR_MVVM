using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.Notification;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOP_RGR_MVVM.ViewModels
{
    internal class ProductVM : NotificationObject
    {
        protected Product _product;
        private int _selectedCount;

        public int Id => _product.Id;
        public string Image => _product.Image;
        public string Name => _product.Name;
        public int Price => _product.Price;         
        public int Count
        {
            get => _product.Count;
            set
            {
                _product.Count = value;
                OnPropertyChanged();
            }
        }
        public int SelectedCount
        {
            get => _selectedCount;
            set
            {
                _selectedCount = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSelectedCountVisible));
            }
        }
        public bool IsSelectedCountVisible
            => _selectedCount > 0 ? true : false;

        public ProductVM(Product product, int selectedCount = 0)
        {
            _product = product;
            SelectedCount = selectedCount;
        }
    }
}
