using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebApp
{
    public static class StaticDetails
    {
        public static string APIBaseURL = "https://localhost:44379/";
        public static string NationalParkAPIPath = APIBaseURL + "api/v1/nationalparks";
        public static string TrailAPIBaseURL = APIBaseURL + "api/v1/trails";
    }
}
