using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("Password")]//no JsonIgnore because it ignores it both ways
        public string Password { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

    }
}
