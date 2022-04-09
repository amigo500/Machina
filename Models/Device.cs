using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Machina.Models
{
    public class Device
    {
        public Guid DeviceId { get; set; }
        public string Name { get; set; }
        public string LatestData { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime LastUpdate { get; set; }
        public DeviceType Type { get; set; }
        public DeviceLocation Location { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DeviceStatus Status { get; set; }

        public string LastUpdateString =>
            LastUpdate.TimeOfDay == TimeSpan.Zero ?
                LastUpdate.Date.ToString("yyyy-MM-dd") :
                LastUpdate.ToString("yyyy-MM-dd, HH:mm");

        // public string StatusString => Status == DeviceStatus.Online ? "Online" : "Offline";
        public string StatusString
        {
            get
            {
                if (Status == DeviceStatus.Online)
                {
                    return "Online";
                }
                else if (Status == DeviceStatus.Offline)
                {
                    return "Offline";
                }
                else
                {
                    return "Unknown";
                }
            }
        }
    }
}
