using MonzoApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MonzoApi.Services.Helpers
{
    public class UrlHelper
    {
        public static string BuildApiUrl(string endpoint, Dictionary<string, string> queryValues, Pagination pagination = null)
        {
            var sb = new StringBuilder($"{endpoint}");

            if (queryValues.Any() || pagination != null)
            {
                sb.Append("?");

                if (pagination != null)
                {
                    queryValues = queryValues.Union(BuildPaginationQueryDictionary(pagination.From, pagination.To, pagination.Limit)).ToDictionary(k =>k.Key, v => v.Value);
                }

                sb.Append(GetQueryStringValues(queryValues));
            }

            return sb.ToString();
        }

        public static Dictionary<string, string> BuildPaginationQueryDictionary(DateTime? from, DateTime? to, int? limit)
        {
            var queryValues = new Dictionary<string, string>();

            if (from.HasValue)
            {
                queryValues.Add("since", from.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", DateTimeFormatInfo.InvariantInfo));
            }

            if (to.HasValue)
            {
                queryValues.Add("before", to.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", DateTimeFormatInfo.InvariantInfo));
            }

            if (limit.HasValue)
            {
                queryValues.Add("limit", limit.ToString());
            }

            return queryValues;
        }

        public static string GetQueryStringValues(Dictionary<string, string> values)
        {
            return string.Join("&", values.Select(item => $"{item.Key}={item.Value}"));
        }
    }
}
