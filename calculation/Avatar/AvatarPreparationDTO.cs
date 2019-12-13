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
