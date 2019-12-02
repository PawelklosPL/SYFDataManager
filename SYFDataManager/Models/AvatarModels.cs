using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SYFDataManager.Models
{
    public class AvatarModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("AuthorName")]
        public string AuthorName { get; set; }
        [JsonProperty("AuthorId")]
        public string AuthorId { get; set; }
        [JsonProperty("FolderName")]
        public string FolderName { get; set; }
        [JsonProperty("ShortDescription")]
        public string ShortDescription { get; set; }
        [JsonProperty("PublishDate")]
        public int PublishDate { get; set; }
        [JsonProperty("imagesUrl")]
        public string[] imagesUrl { get; set; }
        [JsonProperty("tags")]
        public string[] tags { get; set; }
        [JsonProperty("sharePoint")]
        public int sharePoint { get; set; }
    }
}