using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DemoSource;
using DemoTarget;

namespace DemoImplementation
{
    public class Solution
    {
        /// <summary>
        /// Mapowanie struktury złożonej z wielu obiektów na prostszą może zostać użyte w kilku
        /// przypadkach. 
        /// Jednym z nich jest potrzeba przekształcenia obiektów POCO na DTO w celu zwrócenia 
        /// ich z webowego api. Wtedy metoda pole SanitizedNameWithId przechowuje dane ze 
        /// zniwelowaną możliwością ataku XSS. 
        /// Natomiast jeśli poruszamy się w przestrzeni Entity Framework to klasa Person 
        /// i EmailAddress będą wtedy tabelami w bazie danych (tak samo jak klasa PersonWithEmail). 
        /// W takim przypadku chcemy przekształcić dane ze znormalizowanych tabel na jej 
        /// nieznormalizowaną wersję co może zakłucić integralność danych i wzmocni nadmiarowość 
        /// danych. 
        /// Jednakże taki rodzaj spłaszczonych danych dość dobrze nadaje się we wszelkiego 
        /// rodzaju systemach raportowych lub BI. 
        /// </summary>
        public IEnumerable<PersonWithEmail> Flatten(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                var sanitazedNameWithId = Sanitazing(person.Name, person.Id);

                foreach (var email in person.Emails)
                {
                    yield return new PersonWithEmail
                    {
                        SanitizedNameWithId = sanitazedNameWithId,
                        FormattedEmail = EmailFormatting(email.Email, email.EmailType)
                    };
                }
            }
        }

        private string Sanitazing(string name, string id)
        {
            var regex = new Regex("[^a-zA-Z0-9]");
            return regex.Replace($"{name}{id}", string.Empty);
        }

        private string EmailFormatting(string email, string type)
        {
            switch (type)
            {
                case "type1":
                    return $"{type}/{email}";
                case "type2":
                    return $"{email}/{type}";
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}