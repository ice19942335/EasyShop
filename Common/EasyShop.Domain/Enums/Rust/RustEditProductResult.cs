using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.Enums.Rust
{
    public enum RustEditProductResult
    {
        Success,
        Failed,
        NotFound,
        Default,
        DateHaveToBeBiggerThanCurrentMoment
    }
}
