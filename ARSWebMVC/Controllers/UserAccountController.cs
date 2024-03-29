﻿using ARSWebMVC.Controllers;
using ARSWebMVC.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ARSWebMVC.Controllers.ARSMVCUtilities;

namespace eProject_main.Controllers
{
    public class UserAccountController : Controller
    {
        private DBUserEntities db = new DBUserEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        //GET: Customer/Login
        public ActionResult Login()
        {
            return View();
        }

        //GET: Customer/LoginPartial
        public ActionResult LoginPartial()
        {
            return PartialView("Login");
        }



        // POST: Customer/Login
        [HttpPost]
        public ActionResult Login(LoginModels profile)
        {
            string action = "Index";
            string controller = "Home";
            object routeValue = null;

            if (Session["lastPageVisit"] != null)
            {
                Dictionary<String, Object> lastPageVisit = (Dictionary<String, Object>)Session["lastPageVisit"];
                action = lastPageVisit["actionName"].ToString();
                controller = lastPageVisit["controllerName"].ToString();
                routeValue = lastPageVisit.ContainsKey("routeValue") ? lastPageVisit["routeValue"] : null;
            }

            // Check user exist
            if (profile.UserID != null && profile.Password != null)
            {
                var inputPasswordMD5 = CreateMD5(profile.Password);
                var res = ARSMVCUtilities.GetDB().Profiles.Where(s => s.UserID == profile.UserID && s.Password == inputPasswordMD5).SingleOrDefault();
                if (res != null)
                {
                    Profile userProfile = new Profile()
                    {
                        ID = res.ID,
                        UserID = res.UserID,
                        FirstName = res.FirstName,
                        LastName = res.LastName,
                        EmailAddress = res.EmailAddress,
                        PhoneNumber = res.PhoneNumber,
                        Address = res.Address,
                        Sex = Convert.ToBoolean(res.Sex),
                        Age = Convert.ToInt32(res.Age),
                        CreditCard = res.CreditCard,
                        SkyMiles = Convert.ToInt32(res.SkyMiles)
                    };
                    Session[SessionKey.UserProfile] = userProfile;

                    return RedirectToAction(action, controller, routeValue);
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid Username or Password!";
                    return View(profile);
                }
            }
            else
            {
                return View(profile);
            }
        }

        public ActionResult Logout()
        {
            // Set session = null
            Session[SessionKey.UserProfile] = null;
            // Return to homepage
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login");
            Profile userProfile = (Profile)Session[SessionKey.UserProfile];
            return View(userProfile);
        }
        [HttpPost]
        public ActionResult ChangePassword([Bind(Include = "UserID,Password")] Profile profile, FormCollection form)
        {
            var oldpass = Convert.ToString(form["old_password"]);
            var cfpass = Convert.ToString(form["confirm_password"]);
            var rs = ARSMVCUtilities.GetDB().Profiles.SingleOrDefault(s => s.UserID == profile.UserID);
            if (rs != null)
            {
                if (rs.Password != CreateMD5(oldpass))
                {
                    ViewBag.ErrorOld_password = "Old password is invalid";
                }
                else if (cfpass != profile.Password)
                {
                    ViewBag.ErrorConfirm_password = "Password not match";
                }
                else if (oldpass == profile.Password)
                {
                    ViewBag.ErrorNew_password = "The new password must be different from the old password";
                }
                else
                {
                    rs.Password = CreateMD5(profile.Password);
                    ARSMVCUtilities.GetDB().SaveChanges();
                    return RedirectToAction("Profile");
                }
            }
            return View(profile);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "UserID,Password,FirstName,LastName,Address,PhoneNumber,EmailAddress,Sex,Age,CreditCard")] Profile profile, FormCollection form)
        {
            string cfpass = Convert.ToString(form["txtConfirmPassword"]);

            if (ModelState.IsValid == true)
            {
                var rs = ARSMVCUtilities.GetDB().Profiles.Where(s => s.UserID == profile.UserID).SingleOrDefault();
                if (rs != null)
                {
                    ViewBag.MessageForUsername = "Username is used";
                    return View();
                }
                else if (profile.Password.ToString() != cfpass)
                {
                    ViewBag.ErrorConfirmPassword = "Password not match";
                    return View();
                }
                else
                {
                    profile.Password = CreateMD5(profile.Password);
                    profile.IsActive = true;
                    ARSMVCUtilities.GetDB().Profiles.Add(profile);
                    ARSMVCUtilities.GetDB().SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(profile);

        }
        public ActionResult EditProfile()
        {
            // If user is not loged in, redirect to login page
            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login");

            // Show User Profile
            Profile userProfile = (Profile)Session[SessionKey.UserProfile];
            return View(userProfile);
        }

        //POST: Customer/Profile
        [HttpPost]
        public ActionResult EditProfile([Bind(Include = "UserID,FirstName,LastName,Address,PhoneNumber,EmailAddress,Sex,Age,CreditCard")]Profile profile, FormCollection form)
        {
            // If user is not loged in, redirect to login page
            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login");
            // Show User Profile


            Profile rs = ARSMVCUtilities.GetDB().Profiles.SingleOrDefault(s => s.UserID == profile.UserID);
            var cfpassword = Convert.ToString(form["txtConfirmPassword"]);
            var cfpasswordMD5 = CreateMD5(cfpassword);
            if (cfpasswordMD5 == rs.Password.ToString())
            {
                if (rs != null)
                {
                    rs.FirstName = profile.FirstName;
                    rs.LastName = profile.LastName;
                    rs.Address = profile.Address;
                    rs.PhoneNumber = profile.PhoneNumber;
                    rs.EmailAddress = profile.EmailAddress;
                    rs.Sex = profile.Sex;
                    rs.Age = profile.Age;
                    rs.CreditCard = profile.CreditCard;
                    ARSMVCUtilities.GetDB().SaveChanges();
                }

                Session[SessionKey.UserProfile] = rs;

                return RedirectToAction("Profile");
            }
            ViewBag.ErrorConfirmPassword = "Invalid Password";
            return View(profile);


        }

        public new ActionResult Profile()
        {
            // If user is not loged in, redirect to login page
            if (Session[SessionKey.UserProfile] == null) return RedirectToAction("Login");

            // Show User Profile
            Profile userProfile = (Profile)Session[SessionKey.UserProfile];
            return View(userProfile);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
