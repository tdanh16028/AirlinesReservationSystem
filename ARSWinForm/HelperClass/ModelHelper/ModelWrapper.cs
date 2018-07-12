using ARSWinForm.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ARSWinForm.HelperClass.ModelHelper
{

    class AdminAccountWrapper : AbstractModelWrapper<AdminAccount>
    {
        public AdminAccountWrapper()
        {
            MODEL_API = APIWrapper<AdminAccount>.ARSAPI.ADMIN_ACCOUNT;
        }
    }

    class AirplaneWrapper : AbstractModelWrapper<Airplane>
    {
        public AirplaneWrapper()
        {
            MODEL_API = APIWrapper<Airplane>.ARSAPI.AIRPLANE;
        }
    }

    class AirplaneClassWrapper : AbstractModelWrapper<AirplaneClass>
    {
        public AirplaneClassWrapper()
        {
            MODEL_API = APIWrapper<AirplaneClass>.ARSAPI.AIRPLANE_CLASS;
        }
    }

    class AirplaneInfoWrapper : AbstractModelWrapper<AirplaneInfo>
    {
        public AirplaneInfoWrapper()
        {
            MODEL_API = APIWrapper<AirplaneInfo>.ARSAPI.AIRPLANE_INFO;
        }

        public new async Task<List<AirplaneInfo>> Get(string id)
        {
            APIWrapper<AirplaneInfo> apiWrapper = new APIWrapper<AirplaneInfo>(MODEL_API, id);
            HttpResponseMessage response = await apiWrapper.GET();

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                JArray parsed = JArray.Parse(responseData.ToString());
                List<AirplaneInfo> lstResult = new List<AirplaneInfo>();

                foreach (var pair in parsed)
                {
                    AirplaneInfo obj = ARSUtilities.JsonToObject<AirplaneInfo>(pair.ToString());
                    lstResult.Add(obj);
                }

                return lstResult;
            }

            return null;
        }

        public new async Task<List<AirplaneInfo>> Get(int id)
        {
            return await Get(id.ToString());
        }
    }

    class AirplaneTypeWrapper : AbstractModelWrapper<AirplaneType>
    {
        public AirplaneTypeWrapper()
        {
            MODEL_API = APIWrapper<AirplaneType>.ARSAPI.AIRPLANE_TYPE;
        }
    }

    class CityWrapper : AbstractModelWrapper<City>
    {
        public CityWrapper()
        {
            MODEL_API = APIWrapper<City>.ARSAPI.CITY;
        }
    }

    class FlightScheduleWrapper : AbstractModelWrapper<FlightSchedule>
    {
        public FlightScheduleWrapper()
        {
            MODEL_API = APIWrapper<FlightSchedule>.ARSAPI.FLIGHT_SCHEDULE;
        }
    }

    class ProfileWrapper : AbstractModelWrapper<Profile>
    {
        public ProfileWrapper()
        {
            MODEL_API = APIWrapper<Profile>.ARSAPI.PROFILE;
        }
    }

    class RouteWrapper : AbstractModelWrapper<Route>
    {
        public RouteWrapper()
        {
            MODEL_API = APIWrapper<Route>.ARSAPI.ROUTE;
        }
    }

    class TicketWrapper : AbstractModelWrapper<Ticket>
    {
        public TicketWrapper()
        {
            MODEL_API = APIWrapper<Ticket>.ARSAPI.TICKET;
        }
    }
    
}
