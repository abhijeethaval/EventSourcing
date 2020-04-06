using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sourcing.Domain
{
    public class Model
    {
        public Guid Id { get; set; }

        public List<(string, object)> ScalarProperties
        {
            get
            {
                var scalarProps = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.PropertyType == typeof(string) || !typeof(IEnumerable).IsAssignableFrom(p.PropertyType));
                
                return scalarProps
                    .OrderBy(p => p, new DisplayOrderComparer())
                    .Select(p => (p.Name, p.GetValue(this))).ToList();
            }
        }

        public class DisplayOrderComparer : IComparer<PropertyInfo>
        {
            public int Compare([AllowNull] PropertyInfo x, [AllowNull] PropertyInfo y)
            {
                var xOrder = x.GetCustomAttribute<DisplayAttribute>()?.Order;
                var yOrder = y.GetCustomAttribute<DisplayAttribute>()?.Order;
                if (xOrder.HasValue && yOrder.HasValue)
                {
                    if (xOrder > yOrder)
                    {
                        return 1;
                    }
                    else if(xOrder == yOrder)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }

                if (!xOrder.HasValue && !yOrder.HasValue)
                {
                    return 0;
                }

                if (xOrder.HasValue)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }


}
