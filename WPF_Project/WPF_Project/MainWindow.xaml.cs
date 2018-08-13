using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static ObservableCollection<Department> departments = new ObservableCollection<Department>();
        public MainWindow()
        {
            InitializeComponent();
            Controls();
        }
        /// <summary>
        /// Обработка контролов
        /// </summary>
        private void Controls()
        {
            boxofDeparments.SelectionChanged += BoxofDeparments_SelectionChanged;
            changeDepartmentBtn.Click += ChangeDepartmentBtn_Click;
            boxofEmployees.SelectionChanged += BoxofEmployees_SelectionChanged;
            btnNewEmporDep.Click += BtnNewEmporDep_Click;
        }
        /// <summary>
        /// Окно для добавления сотрудников и отделов
        /// </summary>
        AddWindow window;
        /// <summary>
        /// Вызов формы с добавлением сотрудников и отделов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewEmporDep_Click(object sender, RoutedEventArgs e)
        {
            window = new AddWindow();
            window.Owner = this;
            window.Show();
        }
        /// <summary>
        /// Смена отдела у сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {
            if(boxofDepstoChange.SelectedItem!=null)
                (boxofDepstoChange.SelectedItem as Department).AddEmployee((boxofDeparments.SelectedItem as Department).EmpChangeDep(boxofEmployees.SelectedItem as Employee));
        }
        /// <summary>
        /// Добавляет список отделов в комбобокс для смены отдела(по выбору сотрудника)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxofEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            boxofDepstoChange.ItemsSource = departments;
        }
        /// <summary>
        /// Событие, добавляющее в правый листбокс список сотрудников в данном отделе(срабатывает по выбору отдела в левой форме)
        /// </summary>
        private void BoxofDeparments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            boxofEmployees.ItemsSource = (boxofDeparments.SelectedItem as Department).Employees;
        }
        /// <summary>
        /// Изначальный список отделов и сотрудников, задание
        /// 1) Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Init_Click(object sender, RoutedEventArgs e)
        {
            if (boxofDeparments.ItemsSource == null)
            {
                boxofDeparments.ItemsSource = departments;
            }
            else
            {
                return;
            }
                departments.Add(new Department("Стажеры"));
                int numOfDepartments = 10;
                for (int i = 0; i < numOfDepartments; i++)
                {
                    departments.Add(new Department($"Отдел_{i}"));
                }
                int numOfStartEmployees = 10;
                foreach (Department department in departments)
                {
                    ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
                    for (int i = 0; i < numOfStartEmployees; i++)
                    {
                        employees.Add(new Employee(
                            $"Имя_{i}",
                            $"Фамилия_{i}_{department.DepartmentName}ов",
                            (i + 1) * 10000));
                    }
                    department.AddEmployees(employees);
                }
        }
    }
}

