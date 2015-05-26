using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AbonnementenDienst.Models
{
    /// <summary>
    /// This class represents the publisher of a magazine.
    /// </summary>
    [MetadataType(typeof(PublisherMetaData))]
    public partial class Publisher
    {
        public int ID { get; set; }
        public string name { get; set; }
        public ICollection<Magazine> magazines { get; set; }
    }

    /// <summary>
    /// Metadata of the category
    /// </summary>
    public class PublisherMetaData
    {
        [Display(Name = "Uitgever")]
        public int ID { get; set; }

        [Required(ErrorMessage = "De uitgever moet een naam hebben")]
        [Display(Name = "Naam*")]
        public string name { get; set; }

        public ICollection<Magazine> magazines { get; set; }
    }
}