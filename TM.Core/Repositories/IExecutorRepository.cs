using System.Collections.Generic;
using Storage.Models;

namespace TM.Core.Repositories
{
    public interface IExecutorRepository
    {
        Executor Add(Executor executor);
        Executor Delete(int id);
        Executor Edit(Executor executor);
        Executor Get(int id);
        List<Executor> GetAll();
    }
}