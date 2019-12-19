using Storage.Models;
using System;
using System.CodeDom.Compiler;
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
    /// Логика взаимодействия для WorkerApp.xaml
    /// </summary>
    public partial class WorkerApp : Window
    {
        DBRepository _db;
        Storage.Models.Executor _executor;
        public WorkerApp(DBRepository db, Storage.Models.Executor executor)
        {
            InitializeComponent();
            _db = db;
            _executor = executor;
            TasksField.ItemsSource = _db.GetAll().Select(o => o.Id + o.Title);
        }

        private void TasksField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var worker = _db.GetAllExecutors().Find(b => b.Email == TasksField.SelectedItem.ToString());
            NameField.Text = worker.Name;
            DepField.Text = worker.DepartmentName.ToString();
            PositionField.Text = worker.Position;
            var task = _db.ReturnTask(worker.Id);
            var str = $"Title: {task.Title} Description: {task.Description} Deadline: {task.Deadline}";
            MessageBox.Show(str);
        }
    }
}
