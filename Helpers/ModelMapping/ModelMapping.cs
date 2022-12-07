using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ModelUtility
{
    public class ModelMapping
    {
        public TResult Mapping<T, TResult>(T Model, TResult Result)
            where T : class, new()
            where TResult : class, new()
        {
            PropertyInfo[] T_properties = typeof(T).GetProperties();
            PropertyInfo[] TResult_properties = typeof(TResult).GetProperties();

            foreach (var prop in TResult_properties)
            {
                if (T_properties.Contains(prop))
                {
                    prop.SetValue(Result, prop.GetValue(Model));
                }
            }
            return Result;
        }

        public TResult Mapping<T, TResult>(T Model, TResult Result, object[] ModelExclude)
            where T : class, new()
            where TResult : class, new()
        {
            PropertyInfo[] T_properties = typeof(T).GetProperties();
            PropertyInfo[] TResult_properties = typeof(TResult).GetProperties();

            foreach (var prop in TResult_properties)
            {
                var value = prop.GetValue(Model);
                if (ModelExclude.Contains(value))
                {
                    continue;
                }
                if (T_properties.Contains(prop))
                {
                    prop.SetValue(Result, value);
                }
            }
            return Result;
        }
    }
}
