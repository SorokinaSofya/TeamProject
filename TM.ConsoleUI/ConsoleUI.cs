using System;
using Storage.Models;
using TM.Core;
using TM.Core.Models;
using TM.Core.Repositories;
using TM.Core.Services;

namespace TM.ConsoleUI
{
    public class ConsoleUI
    {
        private GoalManager _goalManager;
        private ExecutorManager _executorManager;
        private GoalExecutorRepository _goalExecutorRepository;

        public ConsoleUI(GoalManager goalManager, ExecutorManager executorManager,
            GoalExecutorRepository goalExecutorRepository)
        {
            _goalManager = goalManager;
            _executorManager = executorManager;
            _goalExecutorRepository = goalExecutorRepository;
        }

        private DateTime ReadDate()
        {
            Console.WriteLine("Введите дату завершения задачи");
            DateTime Date = DateTime.Now;
            while (true)
            {
                try
                {
                    Date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели дату в неправильном формате");
                    Console.WriteLine("Введите дату завершения задачи");
                }
            }

            return Date;
        }

        private PriorityType ReadPriority()
        {
            Console.WriteLine("Введите приоритет задачи");
            PriorityType Priority;
            while (true)
            {
                var tmpPriority = Console.ReadLine();
                try
                {
                    Priority = GetPriority(tmpPriority);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели приоритет в неправильном формате");
                }
            }

            return Priority;
        }

        private int ReadId()
        {
            Console.WriteLine("Введите ID искомого элемента");
            while (true)
            {
                try
                {
                    var id = int.Parse(Console.ReadLine());
                    return id;
                }
                catch (Exception)
                {
                    Console.WriteLine("Вы ввели ID в неправильном формате");
                }
            }
        }

        private Goal FindGoal(int id)
        {
            Goal goal;
            while (true)
            {
                try
                {
                    goal = _goalManager.Get(id);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Такого ID не существует");
                    id = ReadId();
                }
            }

            return goal;
        }

        public void AddGoal()
        {
            var goal = new Goal();
            Console.WriteLine("Введите название задачи");
            goal.Title = Console.ReadLine();
            Console.WriteLine("Введите описание задачи");
            goal.Description = Console.ReadLine();
            goal.Deadline = ReadDate();
            goal.Priority = ReadPriority();
            _goalManager.Add(goal);
            Console.WriteLine("Задача {0} успешно добавлена...", goal.Title);
        }

        public void GetAllGoals()
        {
            var goals = _goalManager.GetAll();
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine(Builder.Show(goals[i]));
            }
        }

        public void GoalGetDone()
        {
            var goal = FindGoal(ReadId());
            goal = _goalManager.GetDone(goal);
            Console.WriteLine("Данные успешно сохранены");
        }

        public Goal EditGoal()
        {
            var goal = FindGoal(ReadId());
            Console.WriteLine("Введите новые данные задачи...");
            Console.WriteLine("Введите название задачи, eсли хотите оставить прежнее, нажмите Enter");
            var tmpName = Console.ReadLine();
            if (tmpName != "")
            {
                goal.Title = tmpName;
            }

            Console.WriteLine("Введите описание задачи, если хотите оставить прежнее, нажмите Enter");
            var tmpText = Console.ReadLine();
            if (tmpText != "")
            {
                goal.Description = tmpText;
            }

            goal.Deadline = ReadDate();
            goal.Priority = ReadPriority();
            _goalManager.Edit(goal);
            Console.WriteLine("Задача {0} успешно изменена...", goal.Id);
            return goal;
        }

        public void GetGoal()
        {
            var goal = FindGoal(ReadId());
            Console.WriteLine(Builder.Show(goal));
        }

        public void DeleteGoal()
        {
            var goal = FindGoal(ReadId());
            _goalManager.Delete(goal);
            Console.WriteLine("Задача уcпешно удалена");
        }

        private Executor FindExecutor(int id)
        {
            Executor executor;
            while (true)
            {
                try
                {
                    executor = _executorManager.Get(id);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Такого ID не существует");
                    id = ReadId();
                }
            }

            return executor;
        }

        public void AddExecutor()
        {
            var executor = new Executor();
            Console.WriteLine("Введите имя исполнителя");
            executor.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию исполнителя");
            executor.Surname = Console.ReadLine();
            _executorManager.Add(executor);
            Console.WriteLine("Исполнитель {0} {1} успешно добавлен...", executor.Name, executor.Surname);
        }

        public void EditExecutor()
        {
            var executor = FindExecutor(ReadId());
            Console.WriteLine("Введите новые данные исполнителя...");
            Console.WriteLine("Введите имя исполнителя, eсли хотите оставить прежнее, нажмите Enter");
            var tmpName = Console.ReadLine();
            if (tmpName != "")
            {
                executor.Name = tmpName;
            }

            Console.WriteLine("Введите фамилию исполнителя, если хотите оставить прежнюю, нажмите Enter");
            var tmpSurname = Console.ReadLine();
            if (tmpSurname != "")
            {
                executor.Surname = tmpSurname;
            }

            _executorManager.Edit(executor);
            Console.WriteLine("Новые данные исполнителя {0} {1} успешно сохранены...", executor.Name, executor.Surname);
        }

        public void GetAllExecutors()
        {
            var executors = _executorManager.GetAll();

            for (int i = 0; i < executors.Count; i++)
            {
                Console.WriteLine(ExecutorStringBuilder.Show(executors[i]));
            }
        }

        public void DeleteExecutor()
        {
            var executor = FindExecutor(ReadId());
            _executorManager.Delete(executor.Id);
            Console.WriteLine("Исполнитель успешно удален");
        }

        public void GetExecutor()
        {
            var executor = FindExecutor(ReadId());
            Console.WriteLine(ExecutorStringBuilder.Show(executor));
        }

        public void AddGoalsExecutor()
        {
            Console.WriteLine("Исполнитель: ");
            var executor = FindExecutor(ReadId());
            Console.WriteLine("Задача: ");
            var goal = FindGoal(ReadId());
            _goalExecutorRepository.AddGoalsExecutor(goal, executor);
            Console.WriteLine("Задача успешно назначена");
        }

        public void RemoveGoalsExecutor()
        {
            Console.WriteLine("Исполнитель: ");
            var executor = FindExecutor((ReadId()));
            Console.WriteLine("Задача: ");
            var goal = FindGoal(ReadId());
            _goalExecutorRepository.RemoveGoalsExecutor(goal, executor);
            Console.WriteLine("Задача успешно снята");
        }

        public PriorityType GetPriority(string tmpPriority)
        {
            PriorityType priority;
            switch (tmpPriority.ToLower())
            {
                case "high":
                    priority = Core.Models.PriorityType.High;
                    break;
                case "middle":
                    priority = Core.Models.PriorityType.Middle;
                    break;
                case "low":
                    priority = Core.Models.PriorityType.Low;
                    break;
                default:
                    throw new Exception();
            }

            return priority;
        }
    }
}