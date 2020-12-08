using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public IEnumerable<PetPassport> Pets { get; set; }

        public User()
        {
            Pets = new List<PetPassport>();
        }
    }
}
