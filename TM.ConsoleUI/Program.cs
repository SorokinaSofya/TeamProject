using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TM.Core;
using TM.Core.Repositories;
using TM.Core.Services;
using TM.Data;

namespace TM.ConsoleUI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("TaskManager v1.0");
            Console.WriteLine("Initializing...");

            var serviceProvider = ConfigureServices();
            var consoleUi = serviceProvider.GetService<ConsoleUI>();
            Console.WriteLine("Complete");


            while (true)
            {
                var stringKey = Console.ReadLine();
                if (stringKey != "q" & stringKey != "quit" & stringKey != "exit")
                {
                    try
                    {
                        var key = Enum.Parse<ConsoleUiCommand>(stringKey, true);
                        switch (key)
                        {
                            case ConsoleUiCommand.AddGoal:
                                consoleUi.AddGoal();
                                break;
                            case ConsoleUiCommand.GetAllGoals:
                                consoleUi.GetAllGoals();
                                break;
                            case ConsoleUiCommand.EditGoal:
                                consoleUi.EditGoal();
                                break;
                            case ConsoleUiCommand.GetGoal:
                                consoleUi.GetGoal();
                                break;
                            case ConsoleUiCommand.DeleteGoal:
                                consoleUi.DeleteGoal();
                                break;
                            case ConsoleUiCommand.AddExecutor:
                                consoleUi.AddExecutor();
                                break;
                            case ConsoleUiCommand.EditExecutor:
                                consoleUi.EditExecutor();
                                break;
                            case ConsoleUiCommand.GetAllExecutors:
                                consoleUi.GetAllExecutors();
                                break;
                            case ConsoleUiCommand.DeleteExecutor:
                                consoleUi.DeleteExecutor();
                                break;
                            case ConsoleUiCommand.GetExecutor:
                                consoleUi.GetExecutor();
                                break;
                            case ConsoleUiCommand.AddGoalsExecutor:
                                consoleUi.AddGoalsExecutor();
                                break;
                            case ConsoleUiCommand.RemoveGoalsExecutor:
                                consoleUi.RemoveGoalsExecutor();
                                break;
                            case ConsoleUiCommand.GoalGetDone:
                                consoleUi.GoalGetDone();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    catch
                        (ArgumentException)
                    {
                        Console.WriteLine("Такой команды нет");
                    }
                }
                else break;
            }

            Console.WriteLine("Shutting down...");
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection().AddOptions();
            var builder = new ConfigurationBuilder()
                .SetBasePath(@"/Users/anast/source/repos/TaskManager/TaskManager/TM.Core/Services")
                .AddJsonFile("AppConfiguration.json");
            var appConfiguration = builder.Build();
            var version = appConfiguration["version"];
            if (version == "DB")
            {
                serviceCollection
                    .AddSingleton<DBContext>()
                    .AddSingleton<ExecutorManager>()
                    .AddSingleton<GoalExecutorRepository>()
                    .AddSingleton<ExecutorDBRepository>()
                    .AddSingleton<IGoalRepository, DBRepository>();
            }
            else
            {
                serviceCollection
                    .Configure<TextStorageConfig>(appConfiguration.GetSection("textStorage"))
                    .AddSingleton<TextStorage>()
                    .AddSingleton<IGoalRepository, GoalRepository>();
            }

            serviceCollection
                .AddSingleton<ConsoleUI>()
                .AddSingleton<GoalManager>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}