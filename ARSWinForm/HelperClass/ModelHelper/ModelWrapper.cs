using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
