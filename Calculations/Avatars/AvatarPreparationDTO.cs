using Calculations.Avatars;
using Calculations.Converters;
using DBConnection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Calculation.Avatar
{
    public class AvatarPreparationDTO
    {
        public object EntryState { get; private set; }

        public List<AvatarModel> getAvatarsList()
        {
            List<AvatarModel> avatarsList = new List<AvatarModel>();
            using (SyfDbEntities db = new SyfDbEntities())
            {
                foreach (var avatarDB in db.Avatars.ToList())
                {
                    avatarsList.Add(AvatarConverter.convertFromModel(avatarDB));
                }
            }

            return avatarsList;
        }

        public AvatarModel editAvatar(AvatarModel avatar)
        {

            //AvatarModel avatar = new AvatarModel();
            using (SyfDbEntities db = new SyfDbEntities())
            {

                var avataFromDB = db.Avatars.First(c => c.Id == avatar.Id);

                avataFromDB.AuthorName = avatar.AuthorName;
                avataFromDB.Description = avatar.Description;
                avataFromDB.FolderName = avatar.FolderName;
                avataFromDB.Name = avatar.Name;
                avataFromDB.SharePoints = avatar.SharePoints;


                RemoveImages(db, avataFromDB);
                db.SaveChanges();

                RemoveTags(db, avataFromDB);
                db.SaveChanges();

                List<Avatar_To_ImageUrl> avatarToImageUrlDBConnect = new List<Avatar_To_ImageUrl>();
                AddImages(avatar, avatarToImageUrlDBConnect);
                avataFromDB.Avatar_To_ImageUrl = avatarToImageUrlDBConnect;


                List<Avatar_To_Tag> avatarToTagDBConnect = new List<Avatar_To_Tag>();
                AddTags(avatar, avatarToTagDBConnect);
                avataFromDB.Avatar_To_Tag = avatarToTagDBConnect;


                db.Entry(avataFromDB).State = EntityState.Modified;
                db.SaveChanges();
            }

            return getAvatar(avatar.Id);
        }
        private void editImages(SyfDbEntities db, DBConnection.Avatar avatarToRemove, AvatarModel avatar, List<Avatar_To_ImageUrl> avatarToImageUrlDBConnect)
        {
            var avatarToImageUrls = avatarToRemove.Avatar_To_ImageUrl;
            foreach (var avatarToImageUrl in avatarToImageUrls)
            {
                ImageUrl image = avatarToImageUrl.ImageUrl;
                db.ImageUrls.Remove(image);
            }
            db.Avatar_To_ImageUrl.RemoveRange(avatarToImageUrls);


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

        public AvatarModel getAvatar(int AvatarId)
        {
            AvatarModel avatar = new AvatarModel();
            using (SyfDbEntities db = new SyfDbEntities())
            {
                avatar = AvatarConverter.convertFromModel(db.Avatars.First(c => c.Id == AvatarId));
            }

            return avatar;
        }
        public AvatarModel createAvatar(AvatarModel avatar)
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

            return getAvatar(avatarDB.Id);
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
                var avatarsDBConnection = db.Avatars.First(element => element.Id == avatarId);

               RemoveImages(db, avatarsDBConnection);
               db.SaveChanges();
             
               RemoveTags(db, avatarsDBConnection);
               db.SaveChanges();

               db.Avatars.Remove(avatarsDBConnection);
               db.SaveChanges();
            }
            return true;
        }
        public bool deleteMultipleAvatar(int[] avatarIds)
        {
            using (SyfDbEntities db = new SyfDbEntities())
            {
                foreach(int avatarId in avatarIds)
                {
                    var avatarsDBConnection = db.Avatars.First(element => element.Id == avatarId);

                    RemoveImages(db, avatarsDBConnection);
                    db.SaveChanges();

                    RemoveTags(db, avatarsDBConnection);
                    db.SaveChanges();

                    db.Avatars.Remove(avatarsDBConnection);
                    db.SaveChanges();
                }
            }
            return true;
        }
        private static void RemoveTags(SyfDbEntities db, DBConnection.Avatar avatarToRemove)
        {
            var avatarToTags = avatarToRemove.Avatar_To_Tag;
            foreach (var avatarToTag in avatarToTags)
            {
                Tag tag = avatarToTag.Tag;
                db.Tags.Remove(tag);
            }
            db.Avatar_To_Tag.RemoveRange(avatarToTags);
        }
        private static void RemoveImages(SyfDbEntities db, DBConnection.Avatar avatarToRemove)
        {
            var avatarToImageUrls = avatarToRemove.Avatar_To_ImageUrl;
            foreach (var avatarToImageUrl in avatarToImageUrls)
            {
                ImageUrl image = avatarToImageUrl.ImageUrl;
                db.ImageUrls.Remove(image);
            }
            db.Avatar_To_ImageUrl.RemoveRange(avatarToImageUrls);
        }
    }
}
