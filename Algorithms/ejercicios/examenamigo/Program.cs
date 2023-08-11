namespace Examen
{
    class Program
    {
        static string[] nfl_teams;
        static char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
        static void Main(string[] args)
        {

            // digite el numero de equipos que quieres
            Console.WriteLine("Digite el numero de equipos que quieres");
            int num = Convert.ToInt32(Console.ReadLine());
            nfl_teams = new string[num];

            for (int i = 0; i < nfl_teams.Length; i++)
            {
                Console.WriteLine("Digite el nombre del equipo");
                nfl_teams[i] = Console.ReadLine();
            }


            Console.WriteLine("Los equipos son: ");
            for (int i = 0; i < nfl_teams.Length; i++)
            {
                Console.WriteLine(nfl_teams[i]);
            }

            search_team();
            count_vowels();
            reverse_team_less_vowels();

        }

        static void count_vowels()
        {
            int count_vowels = 0;

            foreach (char vocal in vocales)
            {
                for (int i = 0; i < nfl_teams.Length; i++)
                {
                    if (nfl_teams[i].Contains(vocal))
                    {
                        count_vowels++;

                    }
                }
            }
            Console.WriteLine($"El equipo con mas vocales es {nfl_teams.Max()} y tiene {count_vowels} vocales");
        }
        static void reverse_team_less_vowels()
        {
            string less_characters = nfl_teams.Min();
            string reverse_name = "";
            // reverse the team name with less characters
            for (int i = less_characters.Length - 1; i >= 0; i--)
            {
                reverse_name += less_characters[i];
            }
            Console.WriteLine($"El equipo con menos caracteres es {less_characters} y su nombre al reves es {reverse_name}");
        }

        static void search_team()
        {
            Console.WriteLine("Digite el nombre del equipo que desea buscar");
            string team = Console.ReadLine();
            for (int i = 0; i < nfl_teams.Length; i++)
            {
                if (nfl_teams[i] == team)
                {
                    Console.WriteLine($"El equipo {team} esta en la posicion {i + 1}");
                    break;
                }
                else
                {
                    Console.WriteLine("No se ha encontrado ese equipo");
                    break;
                }
            }
        }
    }

}