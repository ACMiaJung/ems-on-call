using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace acemsoncall.web.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string MemberName { get; set; }
    }
}