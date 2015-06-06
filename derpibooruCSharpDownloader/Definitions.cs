using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derpibooruCSharpDownloader
{
    public class Representations
    {
        public string thumb_tiny { get; set; }
        public string thumb_small { get; set; }
        public string thumb { get; set; }
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string tall { get; set; }
        public string full { get; set; }
    }

    public class Search
    {
        public string id { get; set; }
        public int id_number { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<object> duplicate_reports { get; set; }
        public string file_name { get; set; }
        public string description { get; set; }
        public string uploader { get; set; }
        public string image { get; set; }
        public int score { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public int faves { get; set; }
        public int comment_count { get; set; }
        public string tags { get; set; }
        public List<string> tag_ids { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double aspect_ratio { get; set; }
        public string original_format { get; set; }
        public string mime_type { get; set; }
        public string sha512_hash { get; set; }
        public string orig_sha512_hash { get; set; }
        public string source_url { get; set; }
        public string license { get; set; }
        public Representations representations { get; set; }
        public bool is_rendered { get; set; }
        public bool is_optimized { get; set; }
        public byte[] downloadedImage { get; set; }
    }

    public class SearchContainer
    {
        public List<Search> search { get; set; }
        public int total { get; set; }
    }
}
