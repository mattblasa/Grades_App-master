using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class SimpleClassOrig
    {
        public int addSomething(int someNum1, int someNum2)
        {
            var Something = someNum1 + someNum2;
            return Something;
        }
    }
}
