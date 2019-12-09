namespace Calculation.Avatar
{
    public class AvatarModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public string FolderName { get; set; }
        public string ShortDescription { get; set; }
        public int PublishDate { get; set; }
        public string[] ImagesUrl { get; set; }
        public string[] Tags { get; set; }
        public int SharePoint { get; set; }
    }
}