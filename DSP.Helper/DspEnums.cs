using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSP.Helper
{
    public enum LoginStatus
    {
        NotFound,
        NotAllowed,
        Successful
    }

    public enum SearchStatus
    {
        NotFound,
        DiscountNotAllowed,
        DiscountAllowed
    }

    public enum DspPage
    {
        Login, Search
    }
}
