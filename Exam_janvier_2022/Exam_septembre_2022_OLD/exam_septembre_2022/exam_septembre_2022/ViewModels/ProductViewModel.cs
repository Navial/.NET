using exam_septembre_2022.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using exam_septembre_2022.Entities;
using Microsoft.EntityFrameworkCore;

namespace exam_septembre_2022.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductModel> _products;
        private ProductModel _selectedProduct;
        private readonly NorthwindContext _context;

        public ProductViewModel()
        {
            _context = new NorthwindContext();
            LoadProducts();
        }

        public ObservableCollection<ProductModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private async void LoadProducts()
        {
            var productEntities = await _context.Products
                .Select(p => new ProductModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SupplierContactName = p.Supplier.ContactName, // Ajustez en fonction de votre modèle de données
                    QuantityPerUnit = p.QuantityPerUnit
                })
                .ToListAsync();

            Products = new ObservableCollection<ProductModel>(productEntities);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
