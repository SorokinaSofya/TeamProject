using App;
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

namespace BossApp
{
    /// <summary>
    /// Логика взаимодействия для TasksForWorker.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public DBRepository dBRepository;
        public SignIn()
        {
            InitializeComponent();
            dBRepository = new DBRepository();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if ((LoginField.Text != "") && (PasswordField.Password != ""))
            {
                if (dBRepository.GetAllBosses().Exists(a => a.Email == LoginField.Text && a.Password == PasswordField.Password))
                {
                    Hide();
                    var bossApp = new BossApp(dBRepository, dBRepository.GetAllBosses().Find(a => a.Email == LoginField.Text && a.Password == PasswordField.Password));
                    bossApp.ShowDialog();
                    Show();
                }
                else if (dBRepository.GetAllExecutors().Exists(a => a.Email == LoginField.Text && a.Password == PasswordField.Password))
                {
                    Hide();
                    var workerApp = new WorkerApp(dBRepository, dBRepository.GetAllExecutors().Find(a => a.Email == LoginField.Text && a.Password == PasswordField.Password));
                    workerApp.ShowDialog();
                    Show();
                }
            }
        }
    }
}
