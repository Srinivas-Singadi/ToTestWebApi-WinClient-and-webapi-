using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    public class RegisterUserController : ApiController
    {
        [HttpGet]
        public List<RegisterUserModel> Get()
        {
            List<RegisterUserModel> retList = null;
            try
            {
                TestWebApiEntities cntx = new TestWebApiEntities();
                
                var regUsers = cntx.RegisteredUsers.ToList();
                retList = new List<RegisterUserModel>();
                foreach (var item in regUsers)
                {
                    retList.Add(new RegisterUserModel()
                    {
                        AppID=item.AppID,
                        DeviceID=item.DeviceID,
                        Email=item.Email,
                        FirstName=item.FirstName,
                        LastName=item.LastName,
                        Mobile=item.Mobile
                    });
                }
                return retList;
            }
            catch(Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]


        //public int add(int a)
        //{
        //    int sum = a + 2;
        //}
        public RegisterUserModel Post(RegisterUserModel model)
        {
            
           // RegisterUserModel model1 = new RegisterUserModel();
            try
            {
                //model = new RegisterUserModel();
                TestWebApiEntities cntx = new TestWebApiEntities();
                var regUser = cntx.RegisteredUsers.Where(e => e.DeviceID == model.DeviceID).FirstOrDefault();
                if (regUser != null)
                {
                    //regUser.AppID = model.AppID;
                    //regUser.DeviceID = model.DeviceID;
                    regUser.Mobile = model.Mobile;
                    regUser.Email = model.Email;
                    regUser.FirstName = model.FirstName;
                    regUser.LastName = model.LastName;
                    regUser.Remark = model.Remark;
                    regUser.DateUpdate = DateTime.Now;
                    cntx.SaveChanges();
                }
                else
                {
                    cntx.RegisteredUsers.Add(new RegisteredUser()
                    { AppID = model.AppID, DeviceID = model.DeviceID, Mobile = model.Mobile,
                        Email = model.Email, FirstName = model.FirstName, LastName = model.LastName,
                        Remark = model.Remark, DateCreate = DateTime.Now, DateUpdate = DateTime.Now });
                }
                cntx.SaveChanges();
                return model;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

    }
}