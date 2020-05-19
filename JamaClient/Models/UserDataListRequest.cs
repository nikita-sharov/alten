using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JamaClient.Models
{
    public class UserDataListRequest
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
