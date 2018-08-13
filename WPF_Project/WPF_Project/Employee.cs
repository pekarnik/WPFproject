using System.Collections;
using System.Collections.ObjectModel;
namespace WPF_Project
{
    /// <summary>
    /// Класс сотрудник
    /// </summary>
    class Employee
    {
        private string nameOfEmployee;
        public string EmployeeName
        {
            get => nameOfEmployee; private set => nameOfEmployee = value;
        }
        private string surnameOfEmployee;
        public string EmployeeSurname
        {
            get => surnameOfEmployee;set => surnameOfEmployee = value;
        }
        private int salary;
        public int Salary
        {
            get { return salary; }
            set { if (value > 0) salary = value; }
        }
        public Employee(string _employeeName, string _employeeSurname,int _salary)
        {
            EmployeeName = _employeeName;
            EmployeeSurname = _employeeSurname;
            Salary = _salary;
        }
        public override string ToString()
        {
            return surnameOfEmployee + " " + nameOfEmployee;
        }
        /// <summary>
        /// Проверка на равентство осуществляется только с полями Имя и Фамилия
        /// </summary>
        /// <param name="_employee"></param>
        /// <returns></returns>
        public bool Equals(Employee _employee)
        {
            if (nameOfEmployee.Equals(_employee.EmployeeName) && surnameOfEmployee.Equals(_employee.EmployeeSurname))
                return true;
            else
                return false;
                    
                
        }
    }
}