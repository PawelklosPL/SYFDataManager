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
            //EntitiesDbModel model = new EntitiesDbModel();

            //DBConnection.Avatar avatarDB = AvatarConverter.convert(avatar);
            DBConnection.Avatar avatarDB = new DBConnection.Avatar();

            avatarDB.Name = "Nowe";
            avatarDB.FolderName = "axcvxcvasd";
            avatarDB.Description = "asdasdf vsd";
            avatarDB.AuthorName = "asdasda";
            avatarDB.Id = 132;

            using (EntitiesDbModel db = new EntitiesDbModel())
            {
                var customers = db.Set<DBConnection.Avatar>();
                customers.Add(avatarDB);
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
