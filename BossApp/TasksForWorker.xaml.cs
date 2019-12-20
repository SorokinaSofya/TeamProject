using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для TasksForWorker.xaml
    /// </summary>
    public partial class TasksForWorker : Window
    {
        DBRepository _db;
        Executor worker;
        public TasksForWorker(DBRepository db, string email)
        {
            InitializeComponent();
            _db = db;
            TasksField.ItemsSource = _db.GetAll().Select(o => o.Id + o.Title);
            worker = db.ReturnWorker(email);
            NameField.Text = worker.Name;
            EmailField.Text = worker.Email;
            DepField.Text = worker.DepartmentName.ToString();
            PositionField.Text = worker.Position;
            
        }

        private void TasksField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = _db.ReturnTask(worker.Id);
            var str = $"Title: {task.Title} Description: {task.Description} Deadline: {task.Deadline}";
            MessageBox.Show(str);
        }
    }
}
