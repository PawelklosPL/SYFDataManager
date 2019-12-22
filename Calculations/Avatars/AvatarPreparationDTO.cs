using Calculations.Avatars;
using Calculations.Converters;
using DBConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation.Avatar
{
    public class AvatarPreparationDTO
    {
        public List<AvatarModel> getAvatarsList(int avatarNumber)
        {
            List<AvatarModel> avatars = new List<AvatarModel>();

            for(int i = 0; i < avatarNumber; i++)
            {
                avatars.Add(dummyAvatar());
            }
            return avatars;
        }
        public bool createAvatar(AvatarModel avatar)
        {

            DBConnection.Avatar avatarDB = new DBConnection.Avatar();
            avatarDB.AuthorId = Int32.Parse(avatar.AuthorId);
            avatarDB.AuthorName = avatar.AuthorName;
            avatarDB.Description = avatar.Description;
            avatarDB.FolderName = avatar.FolderName;
            avatarDB.Name = avatar.Name;
            avatarDB.PublishDate = DateTime.Now;
            avatarDB.SharePoints = 0;

            ImageUrl imageUrl = new ImageUrl();
            imageUrl.Name = avatar.Name;
            imageUrl.Url = avatar.ImagesUrl[0];

            Avatar_To_ImageUrl avatarToImageUrl = new Avatar_To_ImageUrl();
            avatarToImageUrl.Avatar_Id = avatar.Id;
            avatarToImageUrl.ImageUrl_Id = imageUrl.Id;


            using (EntitiesSyf db = new EntitiesSyf())
            {
                var avatars = db.Set<DBConnection.Avatar>();
                avatars.Add(avatarDB);
                var imageUrls = db.Set<DBConnection.ImageUrl>();
                imageUrls.Add(imageUrl);
                var AvatarToImageUrls = db.Set<DBConnection.Avatar_To_ImageUrl>();
                AvatarToImageUrls.Add(avatarToImageUrl);
                db.SaveChanges();
            }

            return true;
        }
        private AvatarModel dummyAvatar()
        {
            AvatarModel avatar = new AvatarModel();
            avatar.Id = 1;
            avatar.Name = "Artwork Name";
            avatar.AuthorName = "Name";
            avatar.AuthorId = "1";
            avatar.FolderName = "FOLDER NAME";
            avatar.Description = "short Desc";
            avatar.PublishDate = 12345;
            avatar.ImagesUrl = new string[1] { "/assets/temp/1.jpg" };
            avatar.Tags = new string[1] { "tagi" };
            avatar.SharePoints = 333;
            avatar.Comment_Id = 15;
            avatar.CommentNumber = 24;
            return avatar;
        }
    }
}
