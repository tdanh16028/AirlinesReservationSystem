using ARSWinForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARSWinForm.HelperClass.ModelHelper
{
    class AirplaneClassWrapper : AbstractModelWrapper<AirplaneClass>
    {
        public AirplaneClassWrapper()
        {
            LIST = APIWrapper<AirplaneClass>.ARSAPI.AIRPLANE_CLASSES;
        }
    }
}
