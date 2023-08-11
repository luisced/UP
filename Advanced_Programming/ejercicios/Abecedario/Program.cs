using System;

public class Program
{
    public static string lang(char s)
    {
        switch (char.ToUpper(s))
        {
            case 'A':
                return "@";
            case 'B':
                return "8";
            case 'C':
                return "(";
            case 'D':
                return "|)";
            case 'E':
                return "3";
            case 'F':
                return "#";
            case 'G':
                return "6";
            case 'H':
                return "[-]";
            case 'I':
                return "|";
            case 'J':
                return "_|";
            case 'K':
                return "|<";
            case 'L':
                return "1";
            case 'M':
                return "[]\\/[]";
            case 'N':
                return "[]\\[]";
            case 'O':
                return "0";
            case 'P':
                return "|D";
            case 'Q':
                return "(,)";
            case 'R':
                return "|Z";
            case 'S':
                return "$";
            case 'T':
                return "']['";
            case 'U':
                return "|_|";
            case 'V':
                return "\\/";
            case 'W':
                return "\\/\\/";
            case 'X':
                return "}{";
            case 'Y':
                return "`/";
            case 'Z':
                return "2";
            default:
                return s.ToString();
        }
    }

    public static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        foreach (char c in input)
        {
            Console.Write(lang(c));
        }
    }
}