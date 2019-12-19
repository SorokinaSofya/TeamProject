using System.Collections.Generic;
using Storage.Models;

namespace TM.Core.Services
{
    public interface IExecutorManager
    {
        Executor Add(Executor executor);
        List<Executor> GetAll();
        Executor Edit(Executor executor);
        Executor Delete(int id);
        Executor Get(int id);
    }
}