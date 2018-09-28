﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class DBUser
    {
        public List<HelperTable> AllUserInfo()
        {

            using (var db = new DB())
            {

                List<HelperTable> AllUserInfo = db.User.Select(k => new HelperTable
                {

                    Id = k.Id,
                    Userlvl = k.Userlvl,
                    Email = k.Email,
                    Name = k.Name,
                    Surname = k.Surname,
                    Password = k.Password,
                    Address = k.Address,
                    ZipCode = k.Mail.ZipCode,
                    Area = k.Mail.Area
                }).ToList();

                return AllUserInfo;
            }

        }

        public bool SaveUserToDB(HelperTable InUser)
        {
            var NewUserRad = new User()
            {

                Userlvl = InUser.Userlvl,
                Email = InUser.Email,
                Name = InUser.Name,
                Surname = InUser.Surname,
                Password = InUser.Password,
                Address = InUser.Address

            };
            using (var db = new DB())
            {
                try
                {
                    var CheckZipcode = db.Mail.FirstOrDefault(m => m.ZipCode == InUser.ZipCode);
                    if (CheckZipcode == null)
                    {
                        var NewMailRad = new Mail()
                        {
                            ZipCode = InUser.ZipCode,
                            Area = InUser.Area
                        };
                        NewUserRad.Mail = NewMailRad;
                    }
                    else
                    {

                        NewUserRad.Mail = CheckZipcode;
                    }
                    db.User.Add(NewUserRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }

            }

        }

        public bool DeleteUser(int Id)
        {
            using (var db = new DB())
            {
                try
                {
                    var DeleteUserRad = db.User.FirstOrDefault(u => u.Id == Id);
                    db.User.Remove(DeleteUserRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception error) { return false; }
            }

        }

        public HelperTable GetUserInfo(int id)
        {
            var db = new DB();
            var oneUser = db.User.Find(id);
            if (oneUser == null)
            {
                return null;

            }
            else
            {
                var oneUserOuptput = new HelperTable()
                {
                    Id = oneUser.Id,
                    Userlvl = oneUser.Userlvl,
                    Email = oneUser.Email,
                    Name = oneUser.Name,
                    Surname = oneUser.Surname,
                    Password = oneUser.Password,
                    Address = oneUser.Address,
                    ZipCode = oneUser.Mail.ZipCode,
                    Area = oneUser.Mail.Area

                };
                return oneUserOuptput;
            }
        }
    }
}