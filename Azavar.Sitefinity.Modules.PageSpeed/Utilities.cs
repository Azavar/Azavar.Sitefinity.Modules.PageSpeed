using System;
using System.Collections.Generic;

namespace Azavar.Sitefinity.Modules.PageSpeed
{
    public class Utilities
    {
        public static List<Uri> ParseUrisFromString(string uris)
        {
            var rawUris = uris.Split(',');

            var retUris = new List<Uri>();

            foreach (var rawUri in rawUris)
            {
                Uri uri;

                Uri.TryCreate(rawUri, UriKind.Absolute, out uri);

                if (uri != null)
                {
                    retUris.Add(uri);
                }
            }

            return retUris;
        }

        public static List<Guid> ParseGuidsFromString(string guids)
        {
            var stringGuids = guids.Split(',');

            var guidList = new List<Guid>();

            foreach (var stringGuid in stringGuids)
            {
                Guid outGuid;

                if (Guid.TryParse(stringGuid, out outGuid))
                    guidList.Add(outGuid);
            }

            return guidList;
        }

        public static string ShortenUrl(string url)
        {
            if (url.Length <= 60) return url;

            string shortenedUrl = url;            

            Uri uri;

            Uri.TryCreate(url, UriKind.Absolute, out uri);

            if (uri != null)
            {
                if (uri.PathAndQuery.Length > 40)
                    shortenedUrl = $"{uri.Scheme}://{uri.Host}/…{uri.PathAndQuery.Substring(uri.PathAndQuery.Length - 40)}";
            }

            return shortenedUrl;
        }
    }
}
