﻿namespace BLL.Interfaces.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string GithubLink { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
