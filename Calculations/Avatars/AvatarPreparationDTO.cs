﻿using Calculations.Avatars;
using Calculations.Converters;
using DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AvatarModel getAvatar(int AvatarId)
        {
            AvatarModel avatar = new AvatarModel();
            DBConnection.Avatar avatarDB = new DBConnection.Avatar();
            using (SyfDbEntities db = new SyfDbEntities())
            {
                avatarDB = db.Avatars.First(c => c.Id == AvatarId);
                avatar = AvatarConverter.convertFromModel(avatarDB);
            }

            return avatar;
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

            List<Avatar_To_ImageUrl> avatarToImageUrlDBConnect = new List<Avatar_To_ImageUrl>();
            AddImages(avatar, avatarToImageUrlDBConnect);
            avatarDB.Avatar_To_ImageUrl = avatarToImageUrlDBConnect;


            List<Avatar_To_Tag> avatarToTagDBConnect = new List<Avatar_To_Tag>();
            AddTags(avatar, avatarToTagDBConnect);
            avatarDB.Avatar_To_Tag = avatarToTagDBConnect;


            using (SyfDbEntities db = new SyfDbEntities())
            {
                var avatars = db.Set<DBConnection.Avatar>();
                avatars.Add(avatarDB);
                db.SaveChanges();
            }
            return true;
        }

        private static void AddImages(AvatarModel avatar, List<Avatar_To_ImageUrl> avatarToImageUrlDBConnect)
        {
            foreach (var imageurl in avatar.ImagesUrl)
            {
                ImageUrl imageUrl = new ImageUrl();
                imageUrl.Name = avatar.Name;
                imageUrl.Url = imageurl;

                Avatar_To_ImageUrl avatarToImage = new Avatar_To_ImageUrl();
                avatarToImage.ImageUrl = imageUrl;

                avatarToImageUrlDBConnect.Add(avatarToImage);
            }
        }

        private static void AddTags(AvatarModel avatar, List<Avatar_To_Tag> avatarToImageUrlDBConnect)
        {
            foreach (var tag in avatar.Tags)
            {
                Tag tagOb = new Tag();
                tagOb.Name = tag;

                Avatar_To_Tag avatarToTag = new Avatar_To_Tag();
                avatarToTag.Tag = tagOb;

                avatarToImageUrlDBConnect.Add(avatarToTag);
            }
        }

        public bool deleteAvatar(int avatarId)
         {
            using (SyfDbEntities db = new SyfDbEntities())
            {
                var avatarsDBConnection = db.Set<DBConnection.Avatar>();
                var avatarToRemove = avatarsDBConnection.First(avatar => avatar.Id == avatarId);

                //if(avatarToRemove.ImagesUrl_Id != 0)
                //{
                //    RemoveImages(db, avatarToRemove);
                //}
                //if (avatarToRemove.Tag_Id != 0)
                //{
                //    RemoveTags(db, avatarToRemove);
                //}
                avatarsDBConnection.Remove(avatarToRemove);
                db.SaveChanges();
            }
            return true;
        }
        private static void RemoveTags(SyfDbEntities db, DBConnection.Avatar avatarToRemove)
        {
            var avatarToTagsDBConnection = db.Set<DBConnection.Avatar_To_Tag>();
            var avatarToTags = avatarToTagsDBConnection.Where(element => element.Id == avatarToRemove.Tag_Id);
            foreach (var avatarToTag in avatarToTags)
            {
                int tagId = avatarToTag.Tag_Id;
                var tagAvatarDBConnection = db.Set<DBConnection.Tag>();
                var tag = tagAvatarDBConnection.First(element => element.Id == tagId);
                tagAvatarDBConnection.Remove(tag);
            }
            foreach (var avatarToTag in avatarToTags)
            {
                avatarToTagsDBConnection.Remove(avatarToTag);
            }
        }
        private static void RemoveImages(SyfDbEntities db, DBConnection.Avatar avatarToRemove)
        {
            var avatarToImageUrlsDBConnection = db.Set<DBConnection.Avatar_To_ImageUrl>();
            var avatarToImageUrls = avatarToImageUrlsDBConnection.Where(imateToAvatar => imateToAvatar.Id == avatarToRemove.ImagesUrl_Id);
            foreach (var avatarToImageUrl in avatarToImageUrls)
            {
                int imageId = avatarToImageUrl.ImageUrl_Id;
                var imagesDBConnection = db.Set<DBConnection.ImageUrl>();
                var image = imagesDBConnection.First(i => i.Id == imageId);
                imagesDBConnection.Remove(image);
            }
            foreach (var avatarToImageUrl in avatarToImageUrls)
            {
                avatarToImageUrlsDBConnection.Remove(avatarToImageUrl);
            }
        }
    }
}
