using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Exam_janvier_2023.Models;
using WpfApplication1.ViewModels;

namespace Exam_janvier_2023.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private NorthwindContext _context;
        private ProductModel _selectedProductModel;

        public ObservableCollection<ProductModel> ProductModels { get; private set; }
        public ObservableCollection<dynamic> ProductCountsByCountry { get; private set; }

        public ICommand RemoveProductCommand { get; private set; }

        public ProductModel SelectedProductModel
        {
            get => _selectedProductModel;
            set
            {
                if (_selectedProductModel != value)
                {
                    _selectedProductModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public ProductViewModel()
        {
            _context = new NorthwindContext();
            LoadProducts();
            LoadProductCountsByCountry();
            RemoveProductCommand = new DelegateCommand(RemoveSelectedProduct);
        }

        private void LoadProducts()
        {
            var productEntities = _context.Products.Where(p => !p.Discontinued).ToList();
            var productModels = productEntities.Select(p => new ProductModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryName = p.Category?.CategoryName,
                SupplierName = p.Supplier?.CompanyName
            }).ToList();

            ProductModels = new ObservableCollection<ProductModel>(productModels);
            OnPropertyChanged(nameof(ProductModels));
        }

        private void LoadProductCountsByCountry()
        {
            var productCounts = _context.Products
                .Where(p => p.OrderDetails.Any() && p.Supplier != null)
                .GroupBy(p => p.Supplier.Country)
                .Select(g => new
                {
                    Country = g.Key,
                    Count = g.Count()
                }).OrderByDescending(g => g.Count)
                .ToList();

            ProductCountsByCountry = new ObservableCollection<dynamic>(productCounts);
            OnPropertyChanged(nameof(ProductCountsByCountry));
        }

        private void RemoveSelectedProduct()
        {
            var productToRemove = _context.Products.FirstOrDefault(p => p.ProductId == SelectedProductModel.ProductId);
            if (productToRemove != null)
            {
                productToRemove.Discontinued = true;
                _context.SaveChanges();
                LoadProducts();
            }
        }
    }
}
