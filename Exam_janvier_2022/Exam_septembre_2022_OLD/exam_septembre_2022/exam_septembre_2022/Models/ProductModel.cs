using System.ComponentModel;

namespace exam_septembre_2022.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        private int _productId;
        private string _productName;
        private string _supplierContactName;
        private string _quantityPerUnit;

        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public string SupplierContactName
        {
            get => _supplierContactName;
            set
            {
                _supplierContactName = value;
                OnPropertyChanged(nameof(SupplierContactName));
            }
        }

        public string QuantityPerUnit
        {
            get => _quantityPerUnit;
            set
            {
                _quantityPerUnit = value;
                OnPropertyChanged(nameof(QuantityPerUnit));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
