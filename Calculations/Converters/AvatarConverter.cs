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
        public static DBConnection.Avatar convert(AvatarModel avatarModel)
        {
            DBConnection.Avatar avatar = new DBConnection.Avatar();
            avatar.AuthorName = avatarModel.AuthorName;
            avatar.FolderName = avatarModel.FolderName;
            avatar.SharePoints = avatarModel.SharePoints;
            avatar.Description = avatarModel.Description;
            return avatar;
        }
    }
}
