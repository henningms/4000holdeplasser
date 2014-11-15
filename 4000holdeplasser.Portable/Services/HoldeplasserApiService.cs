using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Holdeplasser.Portable.Services.Results;
using Newtonsoft.Json;
using Holdeplasser.Portable.Models;

namespace Holdeplasser.Portable.Services
{
    public class HoldeplasserApiService
    {
        #region Tips
        public static async Task<TipsResult> SearchTipsAsync(int tipsToRetrieve = 20, int pageOffset = 0, string searchQuery = null, long? tagId = null )
        {
            var httpClient = BuildHttpClient();
            var apiUrl = String.Format("https://4000holdeplasser.no/api/tips/search/?take={0}&offset={1}",
                tipsToRetrieve, pageOffset);

            if (!String.IsNullOrEmpty(searchQuery))
            {
                apiUrl += String.Format("&query={0}", searchQuery);
            }

            if (tagId != null)
            {
                apiUrl += String.Format("&tagId={0}", tagId);
            }

            try
            {
                var responseAsString = await httpClient.GetStringAsync(apiUrl);

                var tipsResult = JsonConvert.DeserializeObject<TipsResult>(responseAsString);

                return tipsResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SearchTipsAsync: " + ex.Message);
                return null;
            }
        }

        public static async Task<TipsResult> GetTipsForStopId(long stopId, int tipsToRetrieve = 20, int pageOffset = 0)
        {
            var httpClient = BuildHttpClient();

            var apiUrl = String.Format("https://4000holdeplasser.no/api/tips/{0}/?take={1}&offset={2}", stopId,
                tipsToRetrieve, pageOffset);

            try
            {
                var responseAsString = await httpClient.GetStringAsync(apiUrl);

                var tipsResult = JsonConvert.DeserializeObject<TipsResult>(responseAsString);

                return tipsResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetTipsForStopId: " + ex.Message);
                return null;
            }
        }
        #endregion

        #region GetStopsByArea
        public static async Task<IEnumerable<Stop>> GetStopsByAreaAsync(Coordinate maximum, Coordinate minimum)
        {
            return await GetStopsByAreaAsync(maximum.Latitude, maximum.Longitude, minimum.Latitude, minimum.Longitude);
        }

        public static async Task<IEnumerable<Stop>> GetStopsByAreaAsync(double latitudeMaximum, double longitudeMaximum,
            double latitudeMinimum, double longitudeMinimum)
        {
            var httpClient = BuildHttpClient();

            var cultureInfo = new CultureInfo("en-US");

            var apiUrl = String.Format("https://4000holdeplasser.no/api/stops/getStopsByArea/{0}/{1}/{2}/{3}",
                latitudeMaximum.ToString(cultureInfo), longitudeMaximum.ToString(cultureInfo), latitudeMinimum.ToString(cultureInfo), longitudeMinimum.ToString(cultureInfo));

            Debug.WriteLine(apiUrl);

            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);

                var listOfStops = JsonConvert.DeserializeObject<IEnumerable<Stop>>(response);

                return listOfStops;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("GetStopsByArea: " + exception.Message);

                return null;
            }
        }
        #endregion

        #region Helper methods

        private static HttpClient _httpClient;

        public static HttpClient BuildHttpClient()
        {
            if (_httpClient != null) return _httpClient;

            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return _httpClient;
        }
        #endregion
    }
}
