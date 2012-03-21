
using System.Collections;
using System.Collections.Generic;
using NHibernate.Transform;

namespace Samsara.Persistance.NHibernate.Transformers
{
    public class NativeSQLTransformer : IResultTransformer
    {
        public IList TransformList(IList collection)
        {
            return collection;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            for (int i = 0; i < tuple.Length; i++)
            {
                result.Add(aliases[i], tuple[i]);
            }

            return result;
        }

    }
}
