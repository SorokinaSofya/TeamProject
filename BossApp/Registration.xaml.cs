using Storage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TM.Core.Repositories;

namespace App
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DBRepository _db;
        public Registration(DBRepository db)
        {
            InitializeComponent();
            _db = db;
        }

        private void SignUpField_Click(object sender, RoutedEventArgs e)
        {
            var name = NameField.Text;
            var department = DepField.Text;
            var position = PositionField.Text;
            var email = EmailField.Text;
            var password = PasswordField.Password;
            var worker = new Executor
            {
                Name = name,
                DepartmentName = Enum.Parse<Department>(department),
                Position = position,
                Email = email,
                Password = password
            };
            _db.AddNewWorker(worker);
            Close();
        }
    }
}
