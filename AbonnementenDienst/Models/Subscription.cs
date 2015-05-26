using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AbonnementenDienst.Models
{
    /// <summary>
    /// Subscription model
    /// </summary>
    [MetadataType(typeof(SubscriptionMetaData))]
    public partial class Subscription
    {
        public int magazineID { get; set; }
        public DateTime from { get; set; }
        public DateTime until { get; set; }
    }

    /// <summary>
    /// Subscription metadata
    /// </summary>
    public class SubscriptionMetaData
    {
        public int magazineID { get; set; }

        [UIHint("DateTimeHelper")]
        [Display(Name = "Start abonnement op*", Description = "Waneer u het abonnement wil starten")]
        [Required(ErrorMessage = "U moet aangeven wanneer u het abonnement wilt starten.")]
        public DateTime from { get; set; }

        [UIHint("DateTimeHelper")]
        [Display(Name = "Stop abonnement op*", Description = "Waneer u het abonnement wil eindigen")]
        [Required(ErrorMessage = "U moet aangeven wanneer u het abonnement wilt eindigen.")]
        public DateTime until { get; set; }
    }
}