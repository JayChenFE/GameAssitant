using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssitant.Applications.Tests
{
    public abstract class TestBase
    {
        public abstract string TestName { get; }
        public abstract void Execute();
    }
}
