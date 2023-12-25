using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT.Travelako.Common.Helpers
{
    public static class GuidHelper
    {
        public static Guid NewGuid(string guid = null)
        {
            return string.IsNullOrWhiteSpace(guid) ? Guid.NewGuid() : new Guid(guid);
        }

        public static string ToShortString(this Guid id)
        {
            return Convert.ToBase64String(id.ToByteArray())
                    .Replace('+', '-')
                    .Replace('/', '_')
                    .Replace("=", "");
        }
    }
}
