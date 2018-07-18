using ARSWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARSWebMVC.Controllers
{
    public class ARSMVCUtilities
    {
        private static readonly DBUserEntities db = new DBUserEntities();

        public static DBUserEntities GetDB()
        {
            return db;
        }
    }
}