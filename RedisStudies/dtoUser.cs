using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisStudies
{
    public class dtoUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<dtoAddres> Addresses { get; set; }
    }
}
