using System.Web;
using System.Web.Mvc;

namespace GiaiThuatToan_12_11_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
