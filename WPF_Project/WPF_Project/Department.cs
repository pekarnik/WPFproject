using System.Collections.ObjectModel;

namespace WPF_Project
{
    class Department
    {
        private string nameOfDepartment;
        public string DepartmentName
        {
            get
            {
                return nameOfDepartment;
            }
            protected set
            {
                nameOfDepartment = value;
            }
        }
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee>Employees
        {
            get => employees;set => employees = value;
        }
        public Department(string _nameOfDepartment)
        {
            DepartmentName = _nameOfDepartment;
            employees = new ObservableCollection<Employee>();
        }
        public void AddEmployee(Employee _employer)
        {
            employees.Add(_employer);
        }
        public void AddEmployees(ObservableCollection<Employee> list)
        {
            foreach(Employee employer in list)
            {
                AddEmployee(employer);
            }
        }
        /// <summary>
        /// Можно использовать как для увольнения сотрудника, так и для смены отдела им
        /// </summary>
        /// <param name="_employee"></param>
        /// <returns></returns>
        public Employee EmpChangeDep(Employee _employee)
        {
            Employees.Remove(_employee);
            return _employee;
        }
        public override string ToString()
        {
            return DepartmentName;
        }
        /// <summary>
        /// Проверка на равенство осуществляется только по названию отдела
        /// </summary>
        /// <param name="_department"></param>
        /// <returns></returns>
        public bool Equals(Department _department)
        {
            if(nameOfDepartment.Equals(_department.DepartmentName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Equals(string _department)
        {
            if (nameOfDepartment.Equals(_department))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}