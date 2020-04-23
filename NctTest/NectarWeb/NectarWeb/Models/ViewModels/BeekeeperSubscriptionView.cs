using NectarWeb.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace NectarWeb.Models.ViewModels
{
  public class BeekeeperSubscriptionView
  {
    [Display(Name = "Nom")]
    [Required(ErrorMessage = "Le nom est obligatoire")]
    public string LastName { get; set; }

    [Display(Name = "Prénom")]
    [Required(ErrorMessage = "Le prénom est obligatoire")]
    public string FirstName { get; set; }

    [Display(Name = "Code postal")]
    //[RegularExpression("/^(?:[0-8]\\d|9[0-8])\\d{3}$/", ErrorMessage = "Veuillez rentrer un code postal valide")]
    [StringLength(5, ErrorMessage = "Veuillez rentrer un code postal")]
    [Required(ErrorMessage = "Le code postal est obligatoire")]
    public string PostalCode { get; set; }

    [Display(Name = "Téléphone")]
    [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Veuillez rentrer un numéro de téléphone valide")]
    [Required(ErrorMessage = "Le numéro de téléphone est obligatoire")]
    public string PhoneNumber { get; set; }

    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Veuillez rentrer une adresse e-mail valide")]
    [Required(ErrorMessage = "L'e-mail est obligatoire")]
    public string Email { get; set; }
  }
}
