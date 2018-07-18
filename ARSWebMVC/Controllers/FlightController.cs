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
        List<FlightSchedule> dbFlightSchedule;

        private void InitDB()
        {
            if (dbRoutes == null) dbRoutes = db.Routes.ToList();
            if (dbCities == null) dbCities = db.Cities.ToList();
            if (dbFlightSchedule == null) dbFlightSchedule = db.FlightSchedules.ToList();
        }

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
            InitDB();

            Dictionary<int, List<Route>> dictListRoute = FindAllPossibleRoute(fromCityID, toCityID);

            // Save dictionary to SESSION
            Session["DictListRoute"] = dictListRoute;

            return View(dictListRoute);
        }

        // GET: Flight/InputPassengerInfo
        public ActionResult InputPassengerInfo()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Flight/InputPassengerInfo
        [HttpPost]
        public ActionResult InputPassengerInfo(int dictRouteID)
        {
            Session["DictRouteIDChoice"] = dictRouteID;
            
            Ticket ticket = new Ticket()
            {
                ID = 0,
                TicketCode = "N/A",
                Status = "",
                ChildrenCount = 0,
                AdultCount = 0,
                SeniorCount = 0,
                AirplaneClassID = 1,
                OrderDate = DateTime.Now,
                TotalCost = 0
            };

            return View(ticket);
        }

        // GET: Flight/ChooseFlightSchedule
        public ActionResult ChooseFlightSchedule()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Flight/ChooseFlightSchedule
        [HttpPost]
        public ActionResult ChooseFlightSchedule(Ticket ticket, DateTime departureDate, DateTime returnDate)
        {
            Session["Ticket"] = ticket;
            int dictRouteID = (int)Session["DictRouteIDChoice"];
            List<Route> lstRoute = ((Dictionary<int, List<Route>>)Session["DictListRoute"])[dictRouteID];

            InitDB();

            List<List<FlightSchedule>> lstFinalFlightSchedule = new List<List<FlightSchedule>>();

            // Lay danh sach tat ca cac chuyen bay cua chang duong dau tien
            List<FlightSchedule> lstStartFlightSchedule = dbFlightSchedule.Where(
                    fs => fs.RouteID == lstRoute[0].ID &&
                    fs.DepartureDate >= departureDate
                )
                .OrderBy(fs => fs.DepartureDate)
                .ToList();

            int totalSeat = ticket.ChildrenCount + ticket.AdultCount + ticket.SeniorCount;

            // Tim ra tat ca cac danh sach chuyen bay phu hop voi yeu cau cua khach
            foreach (FlightSchedule fs in lstStartFlightSchedule)
            {
                List<FlightSchedule> lstCurrentTryFS = new List<FlightSchedule>() { fs };
                RecursiveFindPossibleFlightSchedule(fs.DepartureDate, totalSeat, lstRoute, 0, ref lstCurrentTryFS, ref lstFinalFlightSchedule);
            }

            // Loc ra danh sach nhung chuyen bay con du ghe
            lstFinalFlightSchedule = new List<List<FlightSchedule>>(
                lstFinalFlightSchedule.Where(lstFs =>
                    lstFs.Count == lstRoute.Count && (
                        lstFs.TrueForAll(fs => fs.FirstSeatAvail >= totalSeat) ||
                        lstFs.TrueForAll(fs => fs.BusinessSeatAvail >= totalSeat) ||
                        lstFs.TrueForAll(fs => fs.ClubSeatAvail >= totalSeat)
                    )
                ).ToList()
            );

            // Gan them du lieu len cho day du
            foreach (List<FlightSchedule> lstFS in lstFinalFlightSchedule)
            {
                foreach (FlightSchedule fs in lstFS)
                {
                    fs.Route = dbRoutes.Find(r => r.ID == fs.RouteID);
                    fs.Route.CityA = dbCities.Find(c => c.ID == fs.Route.CityAID);
                    fs.Route.CityB = dbCities.Find(c => c.ID == fs.Route.CityBID);
                }
            }

            // Neu danh sach cac su lua chon cuoi cung khong co item nao nghia la
            // khong tim ra duoc chuyen bay nao phu hop
            if (lstFinalFlightSchedule.Count == 0)
            {
                // Neu khong du chuyen bay thi hien thong bao khong du chuyen bay
                ViewBag.ChooseFlightScheduleError = "Cannot find any flight schedule suitable for you. Please change your criteria or choose another route.";
            }

            return View(lstFinalFlightSchedule);
        }

        private void RecursiveFindPossibleFlightSchedule(DateTime minDate, int minSeatAvail, List<Route> lstRoute, int currentRouteIndex, ref List<FlightSchedule> lstCurrentTryFS, ref List<List<FlightSchedule>> lstPossibleListFS)
        {
            // Di toi chang duong bay tiep theo
            currentRouteIndex++;

            // Tim tat ca chuyen bay cua chang duong nay
            // Dieu kien:
            // - Co ngay khoi hanh >= ngay khoi hanh cua chuyen bay truoc no
            // - Co du so luong ghe trong (hoac First, hoac Business hoac Club)
            List<FlightSchedule> lstFlightSchedule = dbFlightSchedule.Where(
                    fs => fs.DepartureDate >= minDate && 
                    fs.RouteID == lstRoute[currentRouteIndex].ID &&
                    (
                        fs.FirstSeatAvail >= minSeatAvail ||
                        fs.BusinessSeatAvail >= minSeatAvail ||
                        fs.ClubSeatAvail >= minSeatAvail
                    )
                )
                .OrderBy(fs => fs.DepartureDate)
                .ToList();

            if (lstFlightSchedule.Count > 0)
            {
                foreach (FlightSchedule fs in lstFlightSchedule)
                {
                    List<FlightSchedule> lstFS = new List<FlightSchedule>(lstCurrentTryFS);
                    lstFS.Add(fs);

                    if (currentRouteIndex == lstRoute.Count - 1)
                    {
                        lstPossibleListFS.Add(lstFS);
                    }
                    else
                    {
                        RecursiveFindPossibleFlightSchedule(fs.DepartureDate, minSeatAvail, lstRoute, currentRouteIndex, ref lstFS, ref lstPossibleListFS);
                    }
                }
            }
        }

        private Dictionary<int, List<Route>> FindAllPossibleRoute(int cityAID, int cityBID)
        {
            Dictionary<int, List<Route>> dictListRoute = new Dictionary<int, List<Route>>();
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
            int i = 0;
            foreach (List<Route> lstRouteItem in lstListRoute)
            {
                dictListRoute.Add(i++, lstRouteItem);
            }

            return dictListRoute;
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