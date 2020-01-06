﻿using Calculations.Avatars;
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
            List<AvatarModel> avatarsList = new List<AvatarModel>();

            using (SyfDbEntities db = new SyfDbEntities())
            {
                foreach(var avatar in db.Avatars)
                {
                    AvatarModel avatarModel = new AvatarModel();
                    avatarModel.Id = avatar.Id;
                    avatarModel.Name = avatar.Name;

                    string[] imagesUrl= new string[1];
                    imagesUrl[0] = avatar.ImagesUrl_Id.ToString();
                    avatarModel.ImagesUrl = new string[1] { "/assets/temp/1.jpg" };

                    avatarModel.Description = avatar.Description;
                    avatarModel.AuthorId = avatar.AuthorId.ToString();

                    string[] tags = new string[1];
                    tags[0] = avatar.Tag_Id.ToString();
                    avatarModel.Tags = tags;

                    if(avatar.SharePoints != null)
                    {
                        avatarModel.SharePoints = Convert.ToInt32(avatar.SharePoints);
                    }
                    avatarsList.Add(avatarModel);
                }
            }
               return avatarsList;
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

            Tag tag = new Tag();
            tag.Name = avatar.Tags[0];

            Avatar_To_Tag avatarToTag = new Avatar_To_Tag();


            using (SyfDbEntities db = new SyfDbEntities())
            {
                var avatars = db.Set<DBConnection.Avatar>();
                avatars.Add(avatarDB);

                var images = db.Set<DBConnection.ImageUrl>();
                images.Add(imageUrl);

                var tagAvatar = db.Set<DBConnection.Tag>();
                tagAvatar.Add(tag);


                db.SaveChanges();

                var AvatarToImageUrls = db.Set<DBConnection.Avatar_To_ImageUrl>();
                avatarToImageUrl.Avatar_Id = avatarDB.Id;
                avatarToImageUrl.ImageUrl_Id = imageUrl.Id;
                AvatarToImageUrls.Add(avatarToImageUrl);

                var AvatarToTag = db.Set<DBConnection.Avatar_To_Tag>();
                avatarToTag.Avatar_Id = avatarDB.Id;
                avatarToTag.Tag_Id = tag.Id;
                AvatarToTag.Add(avatarToTag);


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
