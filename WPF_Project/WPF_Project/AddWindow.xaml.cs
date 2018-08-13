using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Project
{
    /// <summary>
    /// Предусмотреть возможность создания новых сотрудников и департаментов. Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.
    /// </summary>
    public partial class AddWindow : Window
    {    
        public AddWindow()
        {
            InitializeComponent();
            Controls();
        }
        /// <summary>
        /// Метод для обработки контролов
        /// </summary>
        public void Controls()
        {
            btnAddEmp.Click += BtnAddEmp_Click;
            boxOfDepartments.ItemsSource = MainWindow.departments;
            btnAddDep.Click += BtnAddDep_Click;
        }
        /// <summary>
        /// Если нет такого отдела(названия), то добавляет новый отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddDep_Click(object sender, RoutedEventArgs e)
        {
            foreach(Department department in MainWindow.departments)
            {
                if (department.Equals(nameofDepBox.Text))
                {
                    return;
                }
            }
            MainWindow.departments.Add(new Department(nameofDepBox.Text));
        }
        /// <summary>
        /// Если такого сотрудника нет, то добавляем его в список(обязательно нужно указать отдел)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            if (familyBox.Text != null && nameBox.Text != null && salaryBox.Text != null)
            {
                bool salcheck = int.TryParse(salaryBox.Text, out int sal);
                if(!salcheck)
                {
                    return;
                }
                Employee employee = new Employee(familyBox.Text, nameBox.Text, sal);
                foreach(Department department in MainWindow.departments)
                {
                    foreach(Employee cycleEmployee in department.Employees)
                    {
                        if (cycleEmployee.Equals(employee))
                            return;
                    }
                }
                if(boxOfDepartments.SelectedItem!=null)
                    (boxOfDepartments.SelectedItem as Department).AddEmployee(employee);
            }
        }
    }
}
