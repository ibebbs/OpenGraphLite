using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGraphLite
{
    public class Values : IEnumerable<Value>
    {
        private readonly IReadOnlyCollection<Value> _values;

        internal Values(IEnumerable<Value> values)
        {
            _values = (values ?? Array.Empty<Value>()).ToArray();
        }

        public IEnumerable<Value> GetPropertyValues(string property)
        {
            return _values
                .Where(value => value.Property.Equals(property, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerator<Value> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_values).GetEnumerator();
        }
    }
}
