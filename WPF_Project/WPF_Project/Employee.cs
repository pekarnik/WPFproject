namespace WPF_Project
{
    class Employee:Department
    {
        private string nameOfEmployee;
        public string EmployeeName
        {
            get=>nameOfEmployee;private set => nameOfEmployee = value;            
        }
        public Employee(string _nameOfEmployee,string _nameOfDepartment):base(_nameOfDepartment)
        {
            EmployeeName = _nameOfEmployee;
        }
    }
}