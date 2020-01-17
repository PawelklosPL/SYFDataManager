using Calculations.Avatars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Converters
{
    class AvatarConverter
    {
        public static DBConnection.Avatar convertToModel(AvatarModel avatarModel)
        {
            DBConnection.Avatar avatar = new DBConnection.Avatar();
            avatar.AuthorName = avatarModel.AuthorName;
            avatar.FolderName = avatarModel.FolderName;
            avatar.SharePoints = avatarModel.SharePoints;
            avatar.Description = avatarModel.Description;
            return avatar;
        }
        public static AvatarModel convertFromModel(DBConnection.Avatar avatarModel)
        {
            AvatarModel avatar = new AvatarModel();

            avatar.Id = avatarModel.Id;
            avatar.Name = avatarModel.Name;
            avatar.FolderName = avatarModel.FolderName;
            avatar.Description = avatarModel.Description;
            avatar.Comment_Id = 0;
            avatar.AuthorName = avatarModel.AuthorName;
            avatar.CommentNumber = 0;
            avatar.ImagesUrl = new string[1] { "/assets/temp/1.jpg" };
            avatar.Tags = new string[1] { "tagi" };

            avatar.PublishDate = 0;
            if (avatarModel.SharePoints != null)
            { 
                avatar.SharePoints = (int)avatarModel.SharePoints;
            }

            return avatar;
        }
  

    }
}
