using System.Collections.Generic;
using Storage.Models;
using TM.Core.Repositories;

namespace TM.Core.Services
{
    public class ExecutorManager : IExecutorManager
    {
        private readonly ExecutorDBRepository _executorRepository;
        public ExecutorManager(ExecutorDBRepository executorRepository)
        {
            _executorRepository = executorRepository;
        }
        public Executor Add(Executor executor)
        {
            _executorRepository.Add(executor);
            return executor;
        }

        public Executor Get(int id)
        {
            var executor = _executorRepository.Get(id);
            return executor;
        }

        public List<Executor> GetAll()
        {
            var executors = _executorRepository.GetAll();
            return executors;
        }
        public Executor Edit(Executor executor)
        {
            _executorRepository.Edit(executor);
            return executor;
        }
        public Executor Delete(int id)
        {
            var executor = _executorRepository.Delete(id);
            return executor;
        }
    }
}