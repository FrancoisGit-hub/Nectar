using NectarWeb.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NectarWeb.Models.ViewModels
{
  public class SearchBeekeeperView
  {
    [Display(Name = "Avez-vous identifié un essaim ?")]
    public SwarmType SwarmType { get; set; }

    [Display(Name ="Dans quelle commune se situe l'essaim ? (code postal)")]
    [StringLength(5, ErrorMessage = "Veuillez rentrer un code postal")]
    public string PostalCode { get; set; }

    [Display(Name ="Quel est votre numéro de téléphone ?")]
    [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Veuillez rentrer un numéro de téléphone valide")]
    public string PhoneNumber { get; set; }

    [Display(Name ="Quelle est votre adresse mail ?")]
    [EmailAddress(ErrorMessage = "Veuillez rentrer une adresse e-mail valide")]
    public string Email { get; set; }
  }
}
