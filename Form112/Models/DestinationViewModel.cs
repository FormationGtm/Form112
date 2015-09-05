using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form112.Models
{
    /// <summary>
    /// ViewModel qui récupère l'id de la croisière sélectionnée pour en afficher le détail à l'aide de la méthode Détails du Controller. 
    /// </summary>
	public class DestinationViewModel
	{
        public int DestinationChoice { get; set; }
	}
}