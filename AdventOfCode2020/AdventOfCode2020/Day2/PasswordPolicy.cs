namespace AdventOfCode2020.Day2
{
    using System.Linq;

    public class PasswordPolicy
    {
        public Policy Policy { get; set; }
        public string Password { get; set; }

        public PasswordPolicy()
        {
            Policy = new Policy();
        }

        public bool IsValid()
        {
            int count = Password.Count( c => c == Policy.Character );
            return count >= Policy.MinOccurrences && count <= Policy.MaxOccurrences;
        }

        public bool IsValidPart2()
        {
            int valids = 0;
            if( Password[Policy.MinOccurrences - 1] == Policy.Character ) valids++;
            if( Password[Policy.MaxOccurrences - 1] == Policy.Character ) valids++;
            return valids == 1;
        }
    }
}
