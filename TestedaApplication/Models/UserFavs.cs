using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TestedaApplication.Data.Models;

namespace TestedaApplication.Models
{
    public class UserFavs
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CarId { get; set; }
    }
}
