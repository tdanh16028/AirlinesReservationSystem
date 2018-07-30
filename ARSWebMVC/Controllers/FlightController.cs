using ARSWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ARSWebMVC.Controllers.ARSMVCUtilities;

namespace ARSWebMVC.Controllers
{
    public class FlightController : Controller
    {
        private static readonly int MAX_NUMBER_OF_ROUTE_ALLOW_WHEN_SEARCHING_ROUTE = 10;
        private static readonly int MAX_NUMBER_OF_STOPS_ALLOW_WHEN_SEARCHING_ROUTE = 10;

        DBUserEntities db = new DBUserEntities();
        List<Route> dbRoutes;
        List<City> dbCities;
        List<FlightSchedule> dbFlightSchedule;

        private void InitDB()
        {
            if (dbRoutes == null) dbRoutes = ARSMVCUtilities.GetDB().Routes.ToList();
            if (dbCities == null) dbCities = ARSMVCUtilities.GetDB().Cities.ToList();
            if (dbFlightSchedule == null) dbFlightSchedule = ARSMVCUtilities.GetDB().FlightSchedules.ToList();
        }

        // GET: Flight
        public ActionResult Index()
        {
            // AutoGenerateTicket();
            return RedirectToAction("Index", "Home");
        }

        private void AutoGenerateTicket()
        {
            // Lay danh sách người dùng
            List<Profile> lstProfile = ARSMVCUtilities.GetDB().Profiles.ToList();
            List<AirplaneClass> lstAirplaneClass = ARSMVCUtilities.GetDB().AirplaneClasses.ToList();

            // Lấy danh sách chuyến bay, route, city
            InitDB();

            Random rnd = new Random();
            bool skipThisCustomer = false;
            DateTime currentDate = DateTime.Now;
            int count = 1;

            // Chạy từng ngày bắt đầu từ hôm nay tới 15 ngày tiếp theo
            for (int i = 0; i < 15; i++)
            {
                currentDate = DateTime.Now.AddDays(i);

                // Lặp qua từng người
                foreach (Profile profile in lstProfile)
                {
                    // 30% khach dat ve
                    if (rnd.Next(1, 4) != 3) continue;

                    int tryChooseFromToCount = 0;

                    // Lấy random ID của điểm đến + điểm kết thúc
                    int cityAID, cityBID;
                    Dictionary<int, List<Route>> dictListRoute;

                    do
                    {
                        cityAID = rnd.Next(1, 28);
                        do
                        {
                            cityBID = rnd.Next(1, 28);
                        } while (cityAID == cityBID);

                        // Truyền vào hàm ChooseRoute
                        ChooseRoute(cityAID, cityBID);

                        // Lấy kết quả từ Session[SessionKey.ListPossibleRoute]
                        dictListRoute = (Dictionary<int, List<Route>>)Session[SessionKey.ListPossibleRoute];

                        // Nếu có tuyến đường, chọn ngẫu nhiên một trong số đó lưu vào Session[SessionKey.ChosenRouteID] = dictRouteID;
                        if (dictListRoute.Count > 0)
                        {
                            int tryChooseRouteCount = 0;
                            Dictionary<int, List<FlightSchedule>> dictListFlightSchedule;

                            do
                            {
                                Session[SessionKey.ChosenRouteID] = rnd.Next(0, dictListRoute.Count);

                                // - Tạo Ticket mới với các thông số ngẫu nhiên
                                Ticket ticket = GetDB().Tickets.Create();
                                // new Ticket()
                                //{
                                ticket.ID = 0;
                                ticket.TicketCode = DateTime.Now.Ticks.ToString();
                                ticket.Status = "";
                                ticket.ChildrenCount = rnd.Next(0, 3);
                                ticket.AdultCount = rnd.Next(1, 5);
                                ticket.SeniorCount = rnd.Next(0, 3);
                                ticket.AirplaneClassID = 1;
                                ticket.OrderDate = currentDate;
                                ticket.TotalCost = 0;
                                //};
                                if (ticket.TicketCode.Length > 16) ticket.TicketCode = ticket.TicketCode.Substring(ticket.TicketCode.Length - 16);

                                // - Ngày khởi hành bắt đầu từ hôm nay
                                DateTime departureDate = currentDate.AddDays(rnd.Next(0, (int)(DateTime.Now - currentDate).TotalDays + 1));

                                // - Gọi hàm ChooseFlightSchedule, truyền tham số vào
                                ChooseFlightSchedule(ticket, departureDate);

                                // - Lấy danh sách chuyến bay từ Session[SessionKey.ListPossibleFlightSchedule]
                                dictListFlightSchedule = (Dictionary<int, List<FlightSchedule>>)Session[SessionKey.ListPossibleFlightSchedule];

                                if (dictListFlightSchedule.Count > 0)
                                {
                                    // - Chọn ngẫu nhiên một trong các chuyến đó
                                    int totalSeat = ticket.ChildrenCount + ticket.AdultCount + ticket.SeniorCount;
                                    int seatClassID = rnd.Next(1, 4);
                                    List<List<FlightSchedule>> lstListFS;

                                    if (seatClassID == 1)
                                    {
                                        lstListFS = dictListFlightSchedule.Values.Where(lFS => lFS.TrueForAll(fs => fs.FirstSeatAvail >= totalSeat)).ToList();
                                    }
                                    else if(seatClassID == 2)
                                    {
                                        lstListFS = dictListFlightSchedule.Values.Where(lFS => lFS.TrueForAll(fs => fs.BusinessSeatAvail >= totalSeat)).ToList();
                                    } else
                                    {
                                        lstListFS = dictListFlightSchedule.Values.Where(lFS => lFS.TrueForAll(fs => fs.ClubSeatAvail >= totalSeat)).ToList();
                                    }

                                    if (lstListFS.Count == 0)
                                    {
                                        tryChooseRouteCount++;
                                        if (tryChooseRouteCount >= 10) skipThisCustomer = true;
                                        continue;
                                    }

                                    int lstFSChoice = rnd.Next(0, lstListFS.Count);
                                    string status = (rnd.Next(0, 2) == 1) ? "Blocked" : "Reserved";
                                    ticket.Status = status;

                                    // - Sử dụng code trong hàm PreviewTicket và AddTicket để thêm mới ticket, status ngẫu nhiên Block hoặc Reserved
                                    ticket.ProfileID = profile.ID;
                                    ticket.Profile = profile;
                                    ticket.FlightSchedules = lstListFS[lstFSChoice];
                                    ticket.AirplaneClassID = seatClassID;
                                    AirplaneClass airplaneClass = lstAirplaneClass.Find(ac => ac.ID == seatClassID);
                                    ticket.AirplaneClass = airplaneClass;

                                    double priceRate = ticket.AirplaneClass.PriceRate;
                                    double basePrice = ticket.FlightSchedules.Sum(fs => fs.Route.BasePrice);
                                    ticket.TotalCost = Math.Round(basePrice * priceRate * totalSeat, 2);

                                    try
                                    {
                                        ARSMVCUtilities.GetDB().Tickets.Add(ticket);
                                        ARSMVCUtilities.GetDB().SaveChanges();

                                        // - Random Cancelled vé
                                        bool cancelled = (rnd.Next(1, 11) == 1) ? true : false;
                                        if (cancelled)
                                        {
                                            ticket.Status = "Cancelled";
                                        }

                                        // Gen ticket code
                                        ticket.TicketCode = "#" + ticket.ID.ToString();
                                        ARSMVCUtilities.GetDB().Entry(ticket).State = System.Data.Entity.EntityState.Modified;
                                        ARSMVCUtilities.GetDB().SaveChanges();

                                        Console.WriteLine("#{0:0000}: Add ticket success.", count++);
                                    }
                                    catch (Exception ex)
                                    {
                                        while (ex.InnerException != null) ex = ex.InnerException;
                                        Console.WriteLine("#{0:0000}: Add ticket failed. Error: {1}", count++, ex.Message);
                                    }

                                    db.Entry(ticket).State = System.Data.Entity.EntityState.Detached;
                                }
                                else
                                {
                                    tryChooseRouteCount++;
                                }

                                if (tryChooseRouteCount >= 10) skipThisCustomer = true;
                            } while (dictListFlightSchedule.Count == 0 && !skipThisCustomer);

                        }
                        else
                        {
                            tryChooseFromToCount++;
                        }

                        // Nếu không có quay lại bước random ID
                        // Nếu quá số lần thử, bỏ qua người này
                        if (tryChooseFromToCount >= 10) skipThisCustomer = true;
                    } while (dictListRoute.Count == 0 && !skipThisCustomer);

                }

            }
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
            if (fromCityID == toCityID)
            {
                TempData["ChooseFromToError"] = "Origin and destination city must be difference";
                return RedirectToAction("CheckingAvailability", "Home");
            }

            InitDB();

            Dictionary<int, List<Route>> dictListRoute = FindAllPossibleRoute(fromCityID, toCityID);

            // Save dictionary to SESSION
            Session[SessionKey.ListPossibleRoute] = dictListRoute;

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
            Session[SessionKey.ChosenRouteID] = dictRouteID;
            
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
        public ActionResult ChooseFlightSchedule(int page)
        {
            if (Session[SessionKey.ListPossibleFlightSchedule] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(Session[SessionKey.ListPossibleFlightSchedule]);
        }

        // POST: Flight/ChooseFlightSchedule
        [HttpPost]
        public ActionResult ChooseFlightSchedule(Ticket ticket, DateTime departureDate)
        {
            if (ticket.AdultCount == 0 && ticket.SeniorCount == 0)
            {
                ViewBag.InputPassengerError = "At least one adult or senior passenger is required to block/buy a ticket";
                return View("InputPassengerInfo", ticket);
            }

            Session[SessionKey.Ticket] = ticket;
            int dictRouteID = (int)Session[SessionKey.ChosenRouteID];
            List<Route> lstRoute = ((Dictionary<int, List<Route>>)Session[SessionKey.ListPossibleRoute])[dictRouteID];

            InitDB();

            List<List<FlightSchedule>> lstFinalFlightSchedule = new List<List<FlightSchedule>>();

            //DateTime start = DateTime.Now;

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
                if (lstRoute.Count > 1)
                {
                    // Neu co nhieu hon 1 chang bay thi moi tim tiep
                    RecursiveFindPossibleFlightSchedule(fs.DepartureDate, totalSeat, lstRoute, 0, ref lstCurrentTryFS, ref lstFinalFlightSchedule);
                }
                else
                {
                    // Neu chi co 1 chang bay thi them danh sach hien tai vao luon
                    lstFinalFlightSchedule.Add(lstCurrentTryFS);
                }
            }

            //List<List<FlightSchedule>> lstFSOfEachRoute = new List<List<FlightSchedule>>();
            //foreach (Route route in lstRoute)
            //{
            //    lstFSOfEachRoute.Add(
            //        dbFlightSchedule.Where(
            //            fs => fs.RouteID == route.ID &&
            //            fs.DepartureDate >= departureDate
            //        )
            //        .OrderBy(fs => fs.DepartureDate)
            //        .ToList()
            //    );
            //}

            //List<FlightSchedule> lstCurrentFS;
            //int[] aryCurrentFSIndex = new int[lstRoute.Count];
            //aryCurrentFSIndex.Initialize();

            //while (aryCurrentFSIndex[0] != lstFSOfEachRoute[0].Count)
            //{
            //    lstCurrentFS = new List<FlightSchedule>();

            //    aryCurrentFSIndex[lstRoute.Count - 1]++;
            //    for (int currentRouteIndex = lstRoute.Count - 1; currentRouteIndex > 0; currentRouteIndex--)
            //    {
            //        if (aryCurrentFSIndex[currentRouteIndex] == lstFSOfEachRoute[currentRouteIndex].Count)
            //        {
            //            aryCurrentFSIndex[currentRouteIndex] = 0;
            //            aryCurrentFSIndex[currentRouteIndex - 1]++;
            //        }
            //    }

            //    if (aryCurrentFSIndex[0] == lstFSOfEachRoute[0].Count) break;

            //    for (int currentRouteIndex = 0, maxRouteIndex = lstRoute.Count - 1; currentRouteIndex <= maxRouteIndex; currentRouteIndex++)
            //    {
            //        int currentFSIndex = aryCurrentFSIndex[currentRouteIndex];
            //        List<FlightSchedule> lstFSOfCurrentRoute = lstFSOfEachRoute[currentRouteIndex];
            //        lstCurrentFS.Add(lstFSOfCurrentRoute[currentFSIndex]);
            //    }

            //    lstFinalFlightSchedule.Add(lstCurrentFS);
            //}

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

            // Get limit the first 30 flight schedule
            if (lstFinalFlightSchedule.Count > 30) lstFinalFlightSchedule.RemoveRange(30, lstFinalFlightSchedule.Count - 30);

            //DateTime end = DateTime.Now;
            //Session["Time"] = ((end - start).TotalSeconds);

            // Gan them du lieu len cho day du + chuyen vao Dictionary
            Dictionary<int, List<FlightSchedule>> dictListFlightSchedule = new Dictionary<int, List<FlightSchedule>>();
            int i = 0;
            foreach (List<FlightSchedule> lstFS in lstFinalFlightSchedule)
            {
                foreach (FlightSchedule fs in lstFS)
                {
                    fs.Route = dbRoutes.Find(r => r.ID == fs.RouteID);
                    fs.Route.CityA = dbCities.Find(c => c.ID == fs.Route.CityAID);
                    fs.Route.CityB = dbCities.Find(c => c.ID == fs.Route.CityBID);
                }

                dictListFlightSchedule.Add(i++, lstFS);
            }

            // Neu danh sach cac su lua chon cuoi cung khong co item nao nghia la
            // khong tim ra duoc chuyen bay nao phu hop
            if (dictListFlightSchedule.Count == 0)
            {
                // Neu khong du chuyen bay thi hien thong bao khong du chuyen bay
                ViewBag.ChooseRouteError = "Cannot find any flight schedule suitable for you. Please change your criteria or choose another route.";
                return View("ChooseRoute", Session[SessionKey.ListPossibleRoute]);
            }

            Session[SessionKey.ListPossibleFlightSchedule] = dictListFlightSchedule;
            return View(dictListFlightSchedule);
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

            //RecursiveFindPossibleRoute(cityAID, cityBID, ref lstRoute, ref lstListRoute);

            //// Sort from shortest way to longest way
            //lstListRoute.Sort(delegate (List<Route> lstX, List<Route> lstY)
            //{
            //    return lstX.Sum(x => x.SkyMiles).CompareTo(lstY.Sum(y => y.SkyMiles));
            //});

            //// Get limit first 10 shortest route
            //if (lstListRoute.Count > 10) lstListRoute.RemoveRange(10, lstListRoute.Count - 10);

            List<List<int>> lstListCitiesIDAtStopLevel = new List<List<int>>() { new List<int>() { cityAID } };
            List<List<Route>> lstSequenceOfTryingRoute = new List<List<Route>>();
            RecursiveFindRoute(cityBID, ref lstListCitiesIDAtStopLevel, ref lstSequenceOfTryingRoute, ref lstListRoute);

            // Get City object for all route
            foreach (List<Route> lstRouteItem in lstListRoute)
            {
                foreach (Route route in lstRouteItem)
                {
                    route.CityA = dbCities.Where(c => c.ID == route.CityAID).SingleOrDefault();
                    route.CityB = dbCities.Where(c => c.ID == route.CityBID).SingleOrDefault();
                }
            }

            // Add to queue
            int i = 0;
            foreach (List<Route> lstRouteItem in lstListRoute)
            {
                dictListRoute.Add(i++, lstRouteItem);
            }

            return dictListRoute;
        }

        /// <summary>
        /// Use to find all possible route to move from A -> B (Limit at <code>MAX_NUMBER_OF_ROUTE_ALLOW_WHEN_SEARCHING</code> routes)
        /// </summary>
        /// <param name="toCityID">The ID of final destination city (city B)</param>
        /// <param name="lstListCitiesIDAtStopLevel">In the first time using, give this param a <code>new List<List<int>>() { new List<int>() { ID of the starting city here } }</code></param>
        /// <param name="lstSequenceOfTryingRoute">Give this param a new instance of its type</param>
        /// <param name="lstSequenceOfRouteFinal">Give this param a new instance of its type. This list will store all the possible found route</param>
        private void RecursiveFindRoute(
            int toCityID, 
            ref List<List<int>> lstListCitiesIDAtStopLevel, 
            ref List<List<Route>> lstSequenceOfTryingRoute, 
            ref List<List<Route>> lstSequenceOfRouteFinal
        )
        {
            InitDB();

            // Lay danh sach thanh pho o StopLevel cao nhat hien tai
            int currentStopLevel = lstListCitiesIDAtStopLevel.Count - 1;
            List<int> lstFromCityID = lstListCitiesIDAtStopLevel[currentStopLevel];

            // Tao ra danh sach city cua StopLevel tiep theo
            List<int> lstNextStopLevelCityID = new List<int>();

            // Tao ra danh sach route cua StopLevel tiep theo
            List<Route> lstNextStopLevelRoute = new List<Route>();

            foreach (int fromCityID in lstFromCityID)
            {

                Route directRoute = dbRoutes.Find(r => r.CityAID == fromCityID && r.CityBID == toCityID && r.IsActive);
                if (directRoute != null)
                {
                    // Tim duoc duong di truc tiep tu FROM toi TO
                    // Neu danh sach trying route khong co phan tu nao nghia la day la lan dau tien
                    if (lstSequenceOfTryingRoute.Count == 0)
                    {
                        // Them truc tiep tuyen duong nay vao danh sach moi va add no vao final
                        lstSequenceOfRouteFinal.Add(new List<Route>() { directRoute });
                    }
                    else
                    {
                        // Neu danh sach trying co phan tu nghia la day la lan thu 2 tro di ham nay duoc goi (da co 1 stop tro len)

                        // Danh sach tuyen duong nguoc
                        // Dung de truy nguoc ra tuyen duong da~ dan~ toi' day, sau do dao nguoc lai de ra tuyen duong dung
                        List<List<Route>> lstListSequenceOfRouteReverse = new List<List<Route>>();
                        lstListSequenceOfRouteReverse.Add(new List<Route>() { directRoute }); // Add tuyen duong cuoi cung vao lam tuyen duong dau tien (dao nguoc)

                        // Danh sach route luc nao cung nho hon danh sach cityID 1 index
                        // lstCityID:   0   1   2   3
                        // lstRoute :     0   1   2
                        // Phai bo qua luon stop level hien tai (cao nhat) cua danh sach route
                        // Vi tuyen duong nay da dan den dich nen no khong nam trong danh sach route trying nua

                        for (int iCSL = currentStopLevel - 1; iCSL >= 0; iCSL--)
                        {
                            // Dung de luu nhung tuyen duong moi duoc copy ra
                            List<List<Route>> lstListRRCopy = new List<List<Route>>();

                            // Lap qua tung tuyen duong dao nguoc
                            foreach (List<Route> lstSequenceOfRouteReverse in lstListSequenceOfRouteReverse)
                            {
                                // Lay thanh pho khoi hanh cua tuyen duong cuoi cung trong danh sach dao nguoc hien tai
                                int cityAID = lstSequenceOfRouteReverse.Last().CityAID;

                                // Tim cac route trong danh sach route trying o stoplevel dang xet,
                                // lay ra nhung route nao co CityBID == ID cua thanh pho khoi hanh vua lay o tren
                                List<Route> lstRouteCanGoto = lstSequenceOfTryingRoute[iCSL].Where(r => r.CityBID == cityAID).ToList();

                                // Lap qua tung route tim duoc
                                for (int iRCG = lstRouteCanGoto.Count - 1; iRCG >= 0; iRCG--)
                                {
                                    if (iRCG == 0)
                                    {
                                        // Neu da la route cuoi cung trong danh sach CanGoto thi add truc tiep vao tuyen duong dao nguoc luon
                                        lstSequenceOfRouteReverse.Add(lstRouteCanGoto[iRCG]);
                                    } else
                                    {
                                        // Neu khong phai la route cuoi cung trong ds CG, thi phai copy tuyen duong dao nguoc hien tai ra
                                        // De nhung route sau con co tuyen duong goc ma gan' them vao
                                        List<Route> lstRRCopy = new List<Route>(lstSequenceOfRouteReverse);
                                        lstRRCopy.Add(lstRouteCanGoto[iRCG]);

                                        // Add tuyen duong dao nguoc moi copy vao danh sach nhung tuyen duong dao nguoc
                                        lstListRRCopy.Add(lstRRCopy);
                                    }
                                }
                            }

                            // Cap nhat danh sach cac tuyen duong dao nguoc (them nhung tuyen duong vua copy ra vao danh sach goc)
                            lstListSequenceOfRouteReverse.AddRange(lstListRRCopy);
                        }

                        // Sau khi truy nguoc lai het cac stop level, ta se co mot danh sach cac tuyen duong dao nguoc
                        // Lap qua tung tuyen duong dao nguoc nay
                        foreach (List<Route> lstSequenceOfRouteReverse in lstListSequenceOfRouteReverse)
                        {
                            // Dao nguoc lai de co duoc thu tu dung
                            lstSequenceOfRouteReverse.Reverse();

                            // Add tuyen duong dung nay vao danh sach cuoi cung
                            lstSequenceOfRouteFinal.Add(lstSequenceOfRouteReverse);
                        }
                                                
                    }

                    // Sau khi di duoc toi day thi ta da co duoc mot so tuyen duong trong danh sach final roi
                    // Sort lai tui no theo thu tu tang dan skymiles
                    lstSequenceOfRouteFinal.Sort(delegate (List<Route> lstX, List<Route> lstY)
                    {
                        return lstX.Sum(x => x.SkyMiles).CompareTo(lstY.Sum(y => y.SkyMiles));
                    });

                    // Neu vuot qua so luong tuyen duong toi da cho phep thi return luon
                    if (lstSequenceOfRouteFinal.Count >= MAX_NUMBER_OF_ROUTE_ALLOW_WHEN_SEARCHING_ROUTE)
                    {
                        lstSequenceOfRouteFinal.RemoveRange(MAX_NUMBER_OF_ROUTE_ALLOW_WHEN_SEARCHING_ROUTE, lstSequenceOfRouteFinal.Count - MAX_NUMBER_OF_ROUTE_ALLOW_WHEN_SEARCHING_ROUTE);
                        return;
                    }

                    // Nhay sang thanh pho tiep theo trong danh sach
                    continue;
                }

                // Neu khong tim duoc duong di truc tiep thi tim danh sach cac thanh pho ma FROM co the di chuyen den
                List<int> lstNextTryingCityID = dbRoutes.Where(r => r.CityAID == fromCityID && r.IsActive).Select(r => r.CityBID).ToList();

                // Loc bo nhung thanh pho bi trung lai voi StopLevel hien tai (listFromCityID hien tai) va StopLevel tiep theo (moi tao)
                // Add nhung thanh pho khong trung vao StopLevel tiep theo
                lstNextStopLevelCityID.AddRange(
                    lstNextTryingCityID.Where(id => 
                        !lstFromCityID.Contains(id) && 
                        !lstNextStopLevelCityID.Contains(id)
                    ).ToList()
                );

                // Add nhung route nay vao danh sach nhung route cua StopLevel tiep theo
                lstNextStopLevelRoute.AddRange(dbRoutes.Where(r => r.CityAID == fromCityID && r.IsActive).ToList());

            }

            // Khi ra toi day la da lap qua het nhung thanh pho o stop level hien tai roi
            // Da luu het danh sach thanh pho o stop level tiep theo
            lstListCitiesIDAtStopLevel.Add(lstNextStopLevelCityID);

            // Da luu het danh sach nhung route tu stop level hien tai toi stop level tiep theo
            lstSequenceOfTryingRoute.Add(lstNextStopLevelRoute);

            // Goi lai chinh ham nay de tiep tuc tim kiem neu so luong stops chua vuot qua so luong toi da cho phep
            if (currentStopLevel >= MAX_NUMBER_OF_STOPS_ALLOW_WHEN_SEARCHING_ROUTE) return;
            RecursiveFindRoute(toCityID, ref lstListCitiesIDAtStopLevel, ref lstSequenceOfTryingRoute, ref lstSequenceOfRouteFinal);

        }

        private void RecursiveFindPossibleRoute(int cityAID, int cityBID, ref List<Route> lstRoute, ref List<List<Route>> lstListRoute, List<int> lstLimitID = null)
        {

            Route route = dbRoutes.Where(r => r.CityAID == cityAID && r.CityBID == cityBID && r.IsActive).SingleOrDefault();
            if (route != null)
            {
                lstRoute.Add(route);
                lstListRoute.Add(lstRoute);
                return;
            }

            if (lstLimitID == null)
            {
                lstLimitID = new List<int>();
                GetPossibleCityAID(cityBID, ref lstLimitID);
            }

            // Lay danh sach cac tuyen duong co the di tiep
            List<Route> lstTryRoute = dbRoutes.Where(r => r.CityAID == cityAID && lstLimitID.Contains(r.CityBID) && r.IsActive).ToList();

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
        private void GetPossibleCityAID(int cityBID, ref List<int> lstResult)
        {
            if (lstResult == null) lstResult = new List<int>();

            // Copy to new list because cannot use ref variable in lambda expression
            List<int> lstPassed = new List<int>(lstResult);

            List<int> lstCityAID = dbRoutes.Where(r => 
                r.CityBID == cityBID && 
                !lstPassed.Contains(r.CityAID) &&
                r.IsActive
            ).Select(r => r.CityAID).ToList();

            lstResult.AddRange(lstCityAID);

            foreach (int id in lstCityAID)
            {
                GetPossibleCityAID(id, ref lstResult);
            }

        }


    }
}