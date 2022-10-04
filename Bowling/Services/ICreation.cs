using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Services
{
    public interface ICreation
    {
        T Create<T>(T List);
    }
}
