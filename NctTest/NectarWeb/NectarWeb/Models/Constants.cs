using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NectarWeb.Models.Constants
{
  public enum SwarmType
  {
    [Display(Name = "Abeilles")]
    Bee = 1, 
    [Display(Name = "Guêpes")]
    Wasp = 2, 
    [Display(Name = "Frelons")]
    Hornet = 3
  }
}
