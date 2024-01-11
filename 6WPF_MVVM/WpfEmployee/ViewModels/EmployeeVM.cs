using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfApplication1.ViewModels;
using WpfEmployee.Entities;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM : INotifyPropertyChanged
    {
        private NorthwindContext context = new NorthwindContext();
        private List<EmployeeModel> employees;
        private EmployeeModel selectedItem;
        private List<string> titles;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EmployeeVM()
        {
            employees = LoadEmployees();
            titles = LoadTitles();
        }


        public List<EmployeeModel> EmployeesList
        {
            get { return employees; }

        }

        public List<string> ListTitle { 
            get { return titles; } 
        }  

        public EmployeeModel SelectedItem
        {
            get { return selectedItem; }
            
        }

        private List<string> LoadTitles()
        {
            return context.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }

        public DelegateCommand SaveCommand
        {
            get { return addCommand = addCommand ?? new DelegateCommand(UpdateEmployee); }
        }

        private void UpdateEmployee()
        {
            Employee employee = new Employee();
            EmployeeModel employeeModel = new EmployeeModel(employee);
            employees.Add(employeeModel);

            selectedItem = employeeModel;
            OnPropertyChanged("SelectedItem");
            OnPropertyChanged("Employees");

        }

        private List<EmployeeModel> LoadEmployees()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var item in context.Employees)
            {
                localCollection.Add(new EmployeeModel(item));

            }

            return localCollection;

        }

    }
}
