using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class BaseManager
    {
        protected UnitOfWork uOW;

        public BaseManager(UnitOfWork uOW)
        {
            this.uOW = uOW;
        }
    }
}
