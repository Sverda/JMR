using Task1.DemoSource;
using Task1.DemoImplementation;
using NUnit.Framework;

namespace Tests
{
    public class Task1
    {
        [Test]
        public void Flatten_Test()
        {
            var data = new[] {
                new Person()
                {
                    Id = "1",
                    Name = "name1",
                    Emails = new []
                    {
                        new EmailAddress()
                        {
                            Email = "email1@domain.pl",
                            EmailType = "type1"
                        },
                        new EmailAddress()
                        {
                            Email = "email2@domain.pl",
                            EmailType = "type1"
                        }
                    }
                }
            };
            var result = new Solution().Flatten(data);
            Assert.That(result, Has.Exactly(2).Items);
        }
    }
}