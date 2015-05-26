using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace AbonnementenDienst.Models
{
    /// <summary>
    /// Model 
    /// </summary>
    [MetadataType(typeof(SubscriberMetaData))]
    public partial class Subscriber
    {
        public string salutation { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public string streetname { get; set; }
        public int number { get; set; }
        public string town { get; set; }
        public int postalcode { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
    }

    /// <summary>
    /// Metadata
    /// </summary>
    public class SubscriberMetaData
    {
        [Required(ErrorMessage = "U moet een aanspreking kiezen")]
        [UIHint("SalutationHelper")]
        [Display(Name = "Aanspreking*")]
        public string salutation { get; set; }

        [Required(ErrorMessage = "U moet uw voornaam opgeven") ]
        [Display(Name = "Voornaam*", Description = "Uw voornaam")]
        [StringLength(40, ErrorMessage = "Uw voornaam kan niet langer dan 40 tekens zijn." )]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Uw voornaam mag enkel nummers en letters bevatten, geen speciale tekens.")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "U moet uw naam opgeven")]
        [Display(Name = "Naam*", Description = "Uw naam")]
        [StringLength(40, ErrorMessage = "Uw naam kan niet langer dan 40 tekens zijn.")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Uw naam mag enkel nummers en letters bevatten, geen speciale tekens.")]
        public string name { get; set; }

        [Required(ErrorMessage = "U moet uw straanaam opgeven")]
        [RegularExpression("([a-zA-Z.&'-]+)", ErrorMessage = "De straatnaam mag geen nummers bevatten.")]
        [Display(Name = "Straatnaam*", Description = "De straatnaam waar het magazine moet worden geleverd" )]
        public string streetname { get; set; }

        [Required(ErrorMessage = "U moet uw huisnummer opgeven")]
        [RegularExpression("([a-zA-Z0-9 .]+)", ErrorMessage = "Het huisnummer mag geen speciale tekens bevatten.")]
        [Display(Name = "Huisnummer*", Description = "Uw huisnummer" )]
        public int number { get; set; }

        [Required(ErrorMessage = "U moet uw gemeente opgeven")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "De gemeente mag geen cijfers bevatten.")]
        [Display(Name = "Gemeente*", Description = "De gemeente waar de straat gelegen is" )]
        public string town { get; set; }

        [Required(ErrorMessage = "U moet uw postcode opgeven")]
        [RegularExpression("([0-9][0-9][0-9][0-9])", ErrorMessage = "De postcode moet uit exact 4 cijfers bestaan.")]
        [Display(Name = "Postcode*", Description = "De postcode van de gemeente" )]
        public int postalcode { get; set; }

        [Display(Name = "Telefoon", Description = "Uw vaste telefoonnummer" )]
        [RegularExpression("([0-9]+)", ErrorMessage = "Het telefoonnummer mag enkel uit cijfers bestaan.")]
        public string phone { get; set; }

        [Display(Name = "Mobiel", Description = "Het nummer van uw mobiele telefoon")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Het mobiel nummer mag enkel uit cijfers bestaan.")]
        public string mobile { get; set; }
    }
}