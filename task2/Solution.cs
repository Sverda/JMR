using System.Collections.Generic;
using System.Linq;
using Task2.DemoSource;

namespace Task2.Solution
{
    public class ToDo
    {
        public IEnumerable<(Account, Person)> MatchPersonToAccount(
            IEnumerable<Group> groups,
            IEnumerable<Account> accounts,
            IEnumerable<string> emails)
        {
            var personDict = new Dictionary<string, Person>();
            InitPersonDict(groups, personDict);
            return accounts.Select(a => (a, personDict[a.EmailAddress.Email]));
        }

        private void InitPersonDict(IEnumerable<Group> groups, Dictionary<string, Person> dict)
        {
            foreach (var group in groups)
            {
                foreach (var person in group.People)
                {
                    foreach (var email in person.Emails)
                    {
                        dict.Add(email.Email, person);
                    }
                }
            }
        }
    }
}