using exam_septembre_2022.Models;
using exam_septembre_2022.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace exam_septembre_2022.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductModel> _products;
        private ObservableCollection<ProductSalesModel> _salesTotals;
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

        public ObservableCollection<ProductSalesModel> SalesTotals
        {
            get => _salesTotals;
            set
            {
                _salesTotals = value;
                OnPropertyChanged(nameof(SalesTotals));
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
                    SupplierContactName = p.Supplier.ContactName,
                    QuantityPerUnit = p.QuantityPerUnit
                })
                .ToListAsync();

            Products = new ObservableCollection<ProductModel>(productEntities);
            LoadSalesTotals();

        }

        private async void LoadSalesTotals()
        {
            var salesTotals = await _context.OrderDetails
                .Include(od => od.Product)
                .Where(od => !od.Product.Discontinued) 
                .GroupBy(od => od.ProductId)
                .Select(g => new ProductSalesModel
                {
                    ProductId = g.Key,
                    TotalSales = g.Sum(od => od.Quantity * od.UnitPrice)
                })
                .ToListAsync();

            SalesTotals = new ObservableCollection<ProductSalesModel>(salesTotals);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
