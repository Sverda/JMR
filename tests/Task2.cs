using Task2.DemoSource;
using Task2.Solution;
using NUnit.Framework;

namespace Tests
{
    public class Task2
    {
        [Test]
        public void Match_Test()
        {
            var groups = new[] {
                new Group
                {
                    Id = "1",
                    Label = "label1",
                    People = new []
                    {
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
                    }
                }, 
                new Group
                {
                    Id = "2",
                    Label = "label2",
                    People = new [] 
                    {
                        new Person()
                        {
                            Id = "2",
                            Name = "name2",
                            Emails = new []
                            {
                                new EmailAddress()
                                {
                                    Email = "email3@domain.pl",
                                    EmailType = "type2"
                                }
                            }
                        }
                    }
                }
            };
            var accounts = new[]
            {
                new Account
                {
                    Id = "1",
                    EmailAddress = new EmailAddress()
                    {
                        Email = "email1@domain.pl",
                        EmailType = "type1"
                    }
                },
                new Account
                {
                    Id = "2",
                    EmailAddress = new EmailAddress()
                    {
                        Email = "email2@domain.pl",
                        EmailType = "type1"
                    }
                },
                new Account
                {
                    Id = "3",
                    EmailAddress = new EmailAddress()
                    {
                        Email = "email3@domain.pl",
                        EmailType = "type2"
                    }
                }
            };
            var emails = new[]
            {
                "email1@domain.pl",
                "email2@domain.pl",
                "email3@domain.pl"
            };
            var result = new ToDo().MatchPersonToAccount(groups, accounts, emails);
            Assert.That(result, Has.Exactly(3).Items);
        }
    }
}