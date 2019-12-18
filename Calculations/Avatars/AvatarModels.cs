using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Avatars
{
    public class AvatarModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("AuthorName")]
        public string AuthorName { get; set; }
        [JsonProperty("AuthorId")]
        public string AuthorId { get; set; }
        [JsonProperty("FolderName")]
        public string FolderName { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("PublishDate")]
        public int PublishDate { get; set; }
        [JsonProperty("ImagesUrl")]
        public string[] ImagesUrl { get; set; }
        [JsonProperty("Tags")]
        public string[] Tags { get; set; }
        [JsonProperty("SharePoints")]
        public int SharePoints { get; set; }
        [JsonProperty("Comment_Id")]
        public int Comment_Id { get; set; }
        [JsonProperty("CommentNumber")]
        public int CommentNumber { get; set; }
    }
}
