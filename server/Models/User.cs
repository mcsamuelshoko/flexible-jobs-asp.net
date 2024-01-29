using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class User
    {
        public required string Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastUpdatedAt { get; set; }
        [DataType(DataType.ImageUrl)]
        public string? Avatar { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set;}
        public string? Role { get; set; }//- type<string>[admin, employer, employee],
        public string? Status { get; set; }//- status<string>[active, banned]

    }
}
