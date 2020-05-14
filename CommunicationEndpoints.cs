using System.Collections.Generic;

namespace Burak.Authorization
{
    public class CommunicationEndpoints
    {
        public class CommunicationEndPoints
        {
            public string NotificationServiceBaseUrl { get; set; }
            public string EmployeeEndPointTemplate { get; set; }
            public string NotificationEndPointTemplate { get; set; }
            public string CustomerEndPointTemplate { get; set; }
            public string CustomerAddressEndPointTemplate { get; set; }
            public IList<EndPoint> BrandBaseEndPoints { get; set; }
        }

        public class EndPoint
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string BaseEndPoint { get; set; }
        }
    }
}
