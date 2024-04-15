using System.ComponentModel.DataAnnotations;

namespace University.DataModels
{
    public interface IPerson : IId
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string MiddleName { get; }

        public string PhoneNumber { get; }

        public string Email { get; }
    }
}
