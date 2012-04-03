
using System.Collections.Generic;
using System.Linq;

namespace Samsara.Framework.Util
{
    public class SQLUtil
    {
        public enum SearchQueryConditionsEnum
        {
            AND,
            OR
        }

        public static string strAnd = "AND";
        public static string strOr = "OR";

        public static string CreateSearchQueryCondition(string searchText, SearchQueryConditionsEnum searchOperator)
        {
            string logicOperator = null;

            searchText = ClearText(searchText);

            IList<string> words = searchText.Split(' ')
                .Where(x => x != null && x.Trim() != string.Empty)
                .Select(x => "\"" + x.Trim() + "\"").ToList();

            switch (searchOperator)
            {
                case SearchQueryConditionsEnum.AND:
                    logicOperator = strAnd;
                    break;
                case SearchQueryConditionsEnum.OR:
                    logicOperator = strOr;
                    break;
                default:
                    return null;
            }

            if (words.Count == 0)
                return "*";

            return string.Join(" " + logicOperator + " ", words.ToArray());
        }

        private static string ClearText(string searchText)
        {
            searchText = searchText.Replace("\"", "");

            return searchText;
        }
    }
}
