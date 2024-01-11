using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WpfEmployee.Entities;

namespace WpfEmployee.Models
{
    class EmployeeModel : INotifyPropertyChanged
    {
        private Employee employee;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EmployeeModel(Employee employee)
        {
            this.employee = employee;
        }



        public int EmployeeId
        {
            get { return employee.EmployeeId; }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string LastName
        {
            get { return employee.LastName; }
            set
            {
                if (employee.LastName != value)
                {
                    employee.LastName = value;
                    OnPropertyChanged(nameof(LastName));
                    OnPropertyChanged(nameof(FullName)); // Mise à jour du FullName aussi
                }
            }

        }

        public string FirstName
        {
            get { return employee.FirstName; }
            set
            {
                if (employee.FirstName != value)
                {
                    employee.FirstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(FullName)); // Mise à jour du FullName aussi
                }
            }
        }

        public string? Title
        {
            get { return employee.Title; }
            set
            {
                if (employee.Title != value)
                {
                    employee.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string? TitleOfCourtesy
        {
            get { return employee.TitleOfCourtesy; }
            set
            {
                if (employee.TitleOfCourtesy != value)
                {
                    employee.TitleOfCourtesy = value;
                    OnPropertyChanged(nameof(TitleOfCourtesy));
                }
            }
        }

        public DateTime? BirthDate
        {
            get { return employee.BirthDate; }
            set
            {
                if (employee.BirthDate != value)
                {
                    employee.BirthDate = value;
                    OnPropertyChanged(nameof(BirthDate));
                }
            }
        }

        public string DisplayBirthDate
        {
            get { return BirthDate.HasValue ? BirthDate.Value.ToShortDateString() : string.Empty; }
        }

        public DateTime? HireDate
        {
            get { return employee.HireDate; }
            set
            {
                if (employee.HireDate != value)
                {
                    employee.HireDate = value;
                    OnPropertyChanged(nameof(HireDate));
                }
            }
        }
    }
}
