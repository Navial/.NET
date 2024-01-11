using System.ComponentModel;

namespace exam_septembre_2022.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        private int productId;
        private string productName;
        private string supplierContactName;
        private string quantityPerUnit;

        public int ProductId
        {
            get => productId;
            set
            {
                if (productId != value)
                {
                    productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }
            }
        }

        public string ProductName
        {
            get => productName;
            set
            {
                if (productName != value)
                {
                    productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        public string SupplierContactName
        {
            get => supplierContactName;
            set
            {
                if (supplierContactName != value)
                {
                    supplierContactName = value;
                    OnPropertyChanged(nameof(SupplierContactName));
                }
            }
        }

        public string QuantityPerUnit
        {
            get => quantityPerUnit;
            set
            {
                if (quantityPerUnit != value)
                {
                    quantityPerUnit = value;
                    OnPropertyChanged(nameof(QuantityPerUnit));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
