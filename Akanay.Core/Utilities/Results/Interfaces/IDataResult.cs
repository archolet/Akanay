using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Core.Utilities.Results.Interfaces
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
