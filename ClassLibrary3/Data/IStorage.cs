using System.Collections.Generic;
using TM.Core;

namespace TM.Data
{
    interface IStorage
    {
        void Rewrite(List<Goal> goals);
        int GetLastID();
        List<Goal> GetAll();

    }
}
