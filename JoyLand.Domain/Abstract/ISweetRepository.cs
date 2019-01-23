using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoyLand.Domain.Entities;

namespace JoyLand.Domain.Abstract
{
    public interface ISweetRepository
    {
        IEnumerable<Sweet> Sweets { get; }
        void SaveSweet(Sweet sweet);
        Sweet DeleteSweet(int Id);
    }
}
