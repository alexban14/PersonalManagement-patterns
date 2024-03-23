using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagement.Factories
{
    internal interface IFactory<T>
    {
        T Create(params object[] args);
    }
}
