using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain
{
    static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
