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
using TM.Core;
using TM.Core.Repositories;

namespace App
{
    public partial class GiveATask : Window
    {
        DBRepository _db;
        Boss boss;
        public GiveATask(DBRepository db, Boss boss)
        {
            InitializeComponent();
            _db = db;
            this.boss = boss;
            EmailField.ItemsSource = _db.GetAllExecutors().Where(a => a.DepartmentName == boss.DepartmentName).Select(o => o.Email);
        }

        private void Give_Click(object sender, RoutedEventArgs e)
        {
            var title = TitleField.Text;
            var descroption = DescField.Text;
            var position = _db.GetAllExecutors().Find(o => o.Email == EmailField.Text).Position;
            var deadline = DeadlineField.SelectedDate;
            var task = new Goal
            {
                Title = title,
                Description = descroption,
                Deadline = deadline.Value,
            };
            _db.AddNewTask(task);
            Close();
        }
        
    }
}
