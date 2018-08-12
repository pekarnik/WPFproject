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
        public Department(string _nameOfDepartment)
        {
            DepartmentName = _nameOfDepartment;
        }
    }
}