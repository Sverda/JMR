namespace DemoTarget
{
    public class PersonWithEmail
    {

        /// <summary>
        /// Contains only characters from english alphabet
        /// (a-z, both uppercase and lowercase) and numbers 0-9. 
        /// </summary>
        public string SanitizedNameWithId { get; set; }

        /// <summary>
        /// to be formatted based on email and email type
        /// </summary>
        public string FormattedEmail { get; set; }
    }
}