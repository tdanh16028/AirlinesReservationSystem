using ARSWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARSWebMVC.Controllers
{
    public class ARSMVCUtilities
    {
        private static DBUserEntities db = new DBUserEntities();

        static ARSMVCUtilities() {
            
        }

        public static DBUserEntities GetDB()
        {
            return db;
        }

        public static void RefreshDB()
        {
            db = new DBUserEntities();
        }

        public static class SessionKey
        {
            public static String Ticket => "Ticket";
            public static String UserProfile => "UserProfile";
            public static String ListFlightScheduleChosen => "lstFSChoice";
            public static String ListPossibleFlightSchedule => "dictListFS";
            public static String ChosenRouteID => "DictRouteIDChoice";
            public static String ListPossibleRoute => "DictListRoute";
        }
    }

}