using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Request
    {
        private Dictionary<string, object> _data;
        public Request()
        {
            this._data = new();
        }
        public void AddData(string key, object value)
        {
            this._data.Add(key, value);
        }
        public object GetData(string key)
        {
            if (this._data.ContainsKey(key))
                return this._data[key];

            return null;
        }
    }
}
