using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService<T> where T : BaseEntity
    {
        
        public BaseService(Context context)
        {
            
        }
    }
}
