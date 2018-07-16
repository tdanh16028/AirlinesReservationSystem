using ARSWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARSWebMVC.Controllers
{
    public class FlightController : Controller
    {
        DBUserEntities db = new DBUserEntities();
        List<Route> dbRoutes;
        List<City> dbCities;

        // GET: Flight
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Flight/ChooseRoute
        public ActionResult ChooseRoute()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Flight/ChooseRoute
        [HttpPost]
        public ActionResult ChooseRoute(int fromCityID, int toCityID)
        {
            dbRoutes = db.Routes.ToList();
            dbCities = db.Cities.ToList();

            Queue<List<Route>> queueListRoute = FindAllPossibleRoute(fromCityID, toCityID);

            return View(queueListRoute);
        }

        // GET: Flight/ChooseFlightSchedule
        public ActionResult ChooseFlightSchedule()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Flight/ChooseFlightSchedule
        [HttpPost]
        public ActionResult ChooseFlightSchedule(List<Route> lstRoute)
        {
            return View();
        }

        private Queue<List<Route>> FindAllPossibleRoute(int cityAID, int cityBID)
        {
            Queue<List<Route>> queueListRoute = new Queue<List<Route>>();
            List<List<Route>> lstListRoute = new List<List<Route>>();
            List<Route> lstRoute = new List<Route>();

            RecursiveFindPossibleRoute(cityAID, cityBID, ref lstRoute, ref lstListRoute);

            // Get City object for all route
            foreach (List<Route> lstRouteItem in lstListRoute)
            {
                foreach (Route route in lstRouteItem)
                {
                    route.CityA = dbCities.Where(c => c.ID == route.CityAID).SingleOrDefault();
                    route.CityB = dbCities.Where(c => c.ID == route.CityBID).SingleOrDefault();
                }
            }

            // Sort from shortest way to longest way
            lstListRoute.Sort(delegate (List<Route> lstX, List<Route> lstY)
            {
                return lstX.Sum(x => x.SkyMiles).CompareTo(lstY.Sum(y => y.SkyMiles));
            });

            // Add to queue
            foreach (List<Route> lstRouteItem in lstListRoute)
            {
                queueListRoute.Enqueue(lstRouteItem);
            }

            return queueListRoute;
        }

        private void RecursiveFindPossibleRoute(int cityAID, int cityBID, ref List<Route> lstRoute, ref List<List<Route>> lstListRoute, List<int> lstLimitID = null)
        {

            Route route = dbRoutes.Where(r => r.CityAID == cityAID && r.CityBID == cityBID).SingleOrDefault();
            if (route != null)
            {
                lstRoute.Add(route);
                lstListRoute.Add(lstRoute);
                return;
            }

            if (lstLimitID == null) lstLimitID = GetPossibleCityAID(cityBID);

            // Lay danh sach cac tuyen duong co the di tiep
            List<Route> lstTryRoute = dbRoutes.Where(r => r.CityAID == cityAID && lstLimitID.Contains(r.CityBID)).ToList();

            foreach (Route tryRoute in lstTryRoute)
            {
                // Da tung di qua diem nay roi thi khong quay lai nua
                if (lstRoute.Count > 0 && lstRoute.Where(r => r.CityAID == tryRoute.CityBID || r.CityBID == tryRoute.CityBID).Count() > 0) continue;

                // Copy danh sach cac diem da di qua vao mot list moi
                List<Route> lstCopyRoute = new List<Route>(lstRoute);
                // Add tuyen duong tiep theo vao danh sach da di qua
                lstCopyRoute.Add(tryRoute);

                // Di den diem tiep theo va tiep tuc tim tuyen duong di toi dich
                RecursiveFindPossibleRoute(tryRoute.CityBID, cityBID, ref lstCopyRoute, ref lstListRoute, lstLimitID);

                // Luc nay se co hai truong hop
                // - Tuyen duong nay co the dan toi dich
                // - Tuyen duong nay khong dan toi dich

                // Neu co the dan toi dich, thi khi tim duoc dich den no da add het toan bo hanh trinh vao list va add luon list vao queue roi
                // Khong can lam gi them o day nua

                // Neu khong the dan toi dich, thi cuoi cung no se ket thuc o vong foreach
                // Luc nay se co 2 truong hop:
                // - Diem cuoi cung khong co tuyen duong nao de di tiep
                // - Diem cuoi cung co tuyen duong de di tiep, nhung deu la nhung tuyen duong da di qua roi
            }

        }

        // Tim ra nhung thanh pho co the dan den B
        private List<int> GetPossibleCityAID(int cityBID)
        {
            List<int> lstResult = new List<int>();

            List<int> lstCityAID = dbRoutes.Where(r => r.CityBID == cityBID && !lstResult.Contains(r.CityAID) && !lstResult.Contains(cityBID)).Select(r => r.CityAID).ToList();
            lstResult.AddRange(lstCityAID);

            foreach (int id in lstCityAID)
            {
                lstResult.AddRange(GetPossibleCityAID(id));
            }

            return lstResult;
        }


    }
}