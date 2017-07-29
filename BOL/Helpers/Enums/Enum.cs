using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Helpers.Enums
{
    class Enum
    {
    }
    public enum LoggedInnMessage : int
    {
        Success = 1,
        Failure = 2
    }
    public enum UserRole
    {
        Empty = 0,
        Admin = 1,
        Customer = 2
    }

    public enum Invoice
    {
        INV=1
    }
}
