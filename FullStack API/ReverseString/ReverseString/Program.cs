namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            string reverseThisString = "Hi! My name is Aarshdeep";

            #region method 1
            //convert string to a char array
            char[] characterInString = reverseThisString.ToCharArray();

            for (int i = 0, j = characterInString.Length - 1; i < j; i++, j--)
            {
                //swap i with j
                characterInString[i] = reverseThisString[j];

                //swap j with i
                characterInString[j] = reverseThisString[i];
            }
            //Display the reverse string
            Console.WriteLine(new string(characterInString));
            #endregion

            #region method 2
            //use  Reverse() method provided by LINQ
            IEnumerable<char> reversedString = reverseThisString.ToCharArray().Reverse();

            Console.WriteLine(new string(reversedString.ToArray()));
            #endregion

        }
    }
}