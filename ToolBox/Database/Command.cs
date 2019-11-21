using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Database
{
    public class Command
    {
        internal string Query { get; private set; }
        internal Dictionary<string, object> Parameters { get; private set; }

        public Command(string query)
        {
            Parameters = new Dictionary<string, object>();
            Query = query;
        }

        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
