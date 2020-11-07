using NectarWeb.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace NectarWeb.Models.ViewModels
{
  public class SearchBeekeeperView
  {
    [Display(Name = "Avez-vous identifié un essaim ?")]
    public SwarmType SwarmType { get; set; }

    [Display(Name ="Dans quelle commune se situe l'essaim ? (code postal)")]
    //[RegularExpression("/^(?:[0-8]\\d|9[0-8])\\d{3}$/", ErrorMessage = "Veuillez rentrer un code postal valide")]
    [StringLength(5, ErrorMessage = "Veuillez rentrer un code postal")]
    [Required(ErrorMessage = "Le code postal est obligatoire")]
    public string PostalCode { get; set; }

    [Display(Name ="Quel est votre numéro de téléphone ?")]
    [RegularExpression("^(?:(?:\\+|00)33|0)\\s*[1-9](?:[\\s.-]*\\d{2}){4}$", ErrorMessage = "Veuillez rentrer un numéro de téléphone valide")]
    [Required(ErrorMessage = "Le numéro de téléphone est obligatoire")]
    public string PhoneNumber { get; set; }

    [Display(Name ="Quelle est votre adresse mail ?")]
    [EmailAddress(ErrorMessage = "Veuillez rentrer une adresse e-mail valide")]
    [Required(ErrorMessage = "L'e-mail est obligatoire")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Vous devez accepter les termes")]
    [Display(Name = "Valider les ")]
    public bool ApproveCGU { get; set; }
  }
}
