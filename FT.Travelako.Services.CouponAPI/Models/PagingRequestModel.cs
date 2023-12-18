using static FT.Travelako.Services.CouponAPI.Constants.ConfigurationConsts;

namespace FT.Travelako.Services.CouponAPI.Models
{
    public class PagingRequestModel
    {
        private int _page;
        private int _pageSize;

        /// <summary>
        /// Get and set Page
        /// </summary>
        public int Page
        {
            get
            {
                return _page <= 0 ? 1 : _page;
            }
            set
            {
                _page = value;
            }
        }

        /// <summary>
        /// Get and set PageSize
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize <= 0 ? AppDefaultValue.DefaultPageSize : _pageSize;
            }
            set
            {
                _pageSize = value > AppDefaultValue.DefaultPageSize ? AppDefaultValue.DefaultPageSize : value;
            }
        }
    }
}
