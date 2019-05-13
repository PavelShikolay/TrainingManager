using System.Collections.Generic;

namespace BLL.Interfaces.Entities
{
    public class Group
    {
        public int Id { get; private set; }
        public int Name { get; set; }
        public int MentorId { get; set; }
        public List<User> Students
        {
            get
            {
                List<User> students = new List<User>();

                foreach (var student in Students)
                {
                    students.Add(new User()
                    {
                        Id = student.Id,
                        Role = student.Role,
                        Name = student.Name,
                        Surname = student.Surname,
                        Patronymic = student.Patronymic,
                        GithubLink = student.GithubLink,
                        Email = student.Email,
                        PhoneNumber = student.PhoneNumber,
                    });
                }

                return students;
            }
        }

        public void AddStudent(int studentId)
        {

        }
    }
}
