using App;
using Storage.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TM.Core.Repositories;

namespace BossApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BossApp : Window
    {
        DBRepository _db;
        Boss boss;
        public BossApp(DBRepository db, Boss boss)
        {
            InitializeComponent();
            _db = db;
            WorkersBox.ItemsSource = _db.GetAllExecutors().Select(o => o.Email);
            this.boss = boss;
            NameField.Text = boss.Name;
            DepField.Text = boss.DepartmentName.ToString();
        }

        private void GiveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var giveATask = new GiveATask(_db, boss);
            giveATask.ShowDialog();
            Show();
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var registration = new Registration(_db);
            registration.ShowDialog();
            Show();
        }

        private void WorkersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hide();
            var tasksForWorker = new TasksForWorker(_db, WorkersBox.SelectedItem.ToString());
            tasksForWorker.ShowDialog();
            Show();
        }
    }
}
