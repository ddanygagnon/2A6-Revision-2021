namespace RévisionLib
{
    public class Fonctions
    {
        public static int Additionner(int n1, int n2)
            => n1 + n2;

        public static string FizzBuzz(int n)
        {
            bool estFizz = n % 3 == 0;
            bool estBuzz = n % 5 == 0;
            bool estFizzBuzz = n % 15 == 0;

            return
                estFizzBuzz ? "Fizz Buzz"
                : estFizz ? "Fizz"
                : estBuzz ? "Buzz"
                : "";
        }
    }
}
