using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation.Avatar
{
    public class AvatarPreparationDTO
    {
        public List<AvatarModel> getAvatarsList()
        {
            List<AvatarModel> avatars = new List<AvatarModel>();
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            avatars.Add(dummyAvatar());
            return avatars;
        }
        private AvatarModel dummyAvatar()
        {
            AvatarModel avatar = new AvatarModel();
            avatar.Id = 1;
            avatar.AuthorName = "Name";
            avatar.AuthorId = "1";
            avatar.FolderName = "FOLDER NAME";
            avatar.ShortDescription = "short Desc";
            avatar.PublishDate = 12345;
            avatar.ImagesUrl = new string[1] { "/assets/temp/1.jpg" };
            avatar.Tags = new string[1] { "tagi" };
            avatar.SharePoint = 333;
            return avatar;
        }
    }
}
