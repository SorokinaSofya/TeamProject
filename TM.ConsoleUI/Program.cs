using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage.Models;
using System;
using TM.Core;
using TM.Core.Repositories;
using TM.Data;

namespace TM.ConsoleUI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var db = new DBRepository();
            var boss = new Boss { DepartmentName = Department.IT, Email = "test", Name = "Name", Password = "test" };
            db.AddNewBoss(boss);
        }
    }
}