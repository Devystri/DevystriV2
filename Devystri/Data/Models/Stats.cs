using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public enum Stats
    {
        [Display(Name = "Projet annulé")]
        CANCEL = 3,
        [Display(Name = "Non téléchargable")]
        NOT_DOWNLABLE = 1,
        [Display(Name = "Non commercialisé")]
        NOT_MARKETED = 2,
        [Display(Name = "Aucun")]
        NONE = 0
    }
    
}
