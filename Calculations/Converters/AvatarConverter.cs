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

            GetImages(avatarModel, avatar);
            GetTags(avatarModel, avatar);

            avatar.PublishDate = 0;
            if (avatarModel.SharePoints != null)
            {
                avatar.SharePoints = (int)avatarModel.SharePoints;
            }

            return avatar;
        }

        private static void GetTags(DBConnection.Avatar avatarModel, AvatarModel avatar)
        {
            var AvatarToTagsUrl = avatarModel.Avatar_To_Tag;
            List<string> tags = new List<string>();
            foreach (var AvatarToTagUrl in AvatarToTagsUrl)
            {
                tags.Add(AvatarToTagUrl.Tag.Name);
            }
            avatar.Tags = tags.ToArray();
        }

        private static void GetImages(DBConnection.Avatar avatarModel, AvatarModel avatar)
        {
            var AvatarToImagesUrl = avatarModel.Avatar_To_ImageUrl;
            List<string> images = new List<string>();
            foreach (var AvatarToImageUrl in AvatarToImagesUrl)
            {
                images.Add(AvatarToImageUrl.ImageUrl.Url);
            }
            avatar.ImagesUrl = images.ToArray();
        }

    }
}
