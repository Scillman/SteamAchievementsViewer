using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamKit2X2.Internal.SteamAPI
{
    internal class IPublishedFileService
    {
        /// <summary>
        /// Performs a search query for published files
        /// </summary>
        /// <param name="key">Access key</param>
        /// <param name="query_type">enumeration EPublishedFileQueryType in clientenums.h</param>
        /// <param name="page">Current page</param>
        /// <param name="numperpage">(Optional) The number of results, per page to return.</param>
        /// <param name="creator_appid">App that created the files</param>
        /// <param name="appid">App that consumes the files</param>
        /// <param name="requiredtags">Tags to match on. See match_all_tags parameter below</param>
        /// <param name="excludedtags">(Optional) Tags that must NOT be present on a published file to satisfy the query.</param>
        /// <param name="match_all_tags">If true, then items must have all the tags specified, otherwise they must have at least one of the tags.</param>
        /// <param name="required_flags">Required flags that must be set on any returned items</param>
        /// <param name="omitted_flags">Flags that must not be set on any returned items</param>
        /// <param name="search_text">Text to match in the item's title or description</param>
        /// <param name="filetype">EPublishedFileInfoMatchingFileType</param>
        /// <param name="child_publishedfileid">Find all items that reference the given item.</param>
        /// <param name="days">If query_type is k_PublishedFileQueryType_RankedByTrend, then this is the number of days to get votes for [1,7].</param>
        /// <param name="include_recent_votes_only">If query_type is k_PublishedFileQueryType_RankedByTrend, then limit result set just to items that have votes within the day range given</param>
        /// <param name="totalonly">(Optional) If true, only return the total number of files that satisfy this query.</param>
        /// <param name="return_vote_data">Return vote data</param>
        /// <param name="return_tags">Return tags in the file details</param>
        /// <param name="return_kv_tags">Return key-value tags in the file details</param>
        /// <param name="return_previews">Return preview image and video details in the file details</param>
        /// <param name="return_children">Return child item ids in the file details</param>
        /// <param name="return_short_description">Populate the short_description field instead of file_description</param>
        public void QueryFiles(string key, uint query_type, uint page, /*OPTIONAL*/uint numperpage, uint creator_appid, uint appid, string requiredtags,
            /*NOT OPTINAL*/string excludedtags, /*OPTIONAL*/bool match_all_tags, string required_flags, string omitted_flags, string search_text,
            uint filetype, ulong child_publishedfileid, uint days, bool include_recent_votes_only, /*NOT OPTIONAL*/bool totalonly,
            bool return_vote_data, bool return_tags, bool return_kv_tags, bool return_previews, bool return_children, bool return_short_description)
        {
            // TO BE DONE (TODO)
        }
    }
}
