using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Message
{
    static Dictionary<string, string> schiffer = new Dictionary<string, string>();
    static List<string> possibleMessages = new List<string>();
    static string code = string.Empty;
    static string message = string.Empty;
    static string currentMessage = string.Empty;

    public static void Main()
    {
        message = Console.ReadLine();
        code = Console.ReadLine();
        GenerateSchiffer(code);
        Decode(0, 1);
        PrintResult();
    }

    private static void PrintResult()
    {
        possibleMessages.Sort();
        Console.WriteLine(possibleMessages.Count);
        for (int count = 0; count < possibleMessages.Count; count++)
        {
            Console.WriteLine(possibleMessages[count]);
        }
    }

    private static void Decode(int index, int length)
    {
        if (index > message.Length)
        {
            return;
        }

        if (index + length > message.Length)
        {
            return;
        }

        string currentCode = message.Substring(index, length);
        if (schiffer.ContainsKey(currentCode))
        {
            currentMessage += schiffer[currentCode];
            Decode(index + length, 1);
            if (index + length == message.Length)
            {
                possibleMessages.Add(currentMessage);
            }

            if (currentMessage.Length > 0)
            {
                currentMessage = currentMessage.Substring(0, currentMessage.Length - schiffer[currentCode].Length);
            }

            Decode(index, length + 1);
        }
        else
        {
            Decode(index, length + 1);
        }
    }

    private static void GenerateSchiffer(string code)
    {
        int index = 0;
        while (index < code.Length)
        {
            string letterCode = string.Empty;
            string digitCode = string.Empty;
            while (char.IsLetter(code[index]))
            {
                letterCode += code[index];
                index++;
            }

            while (index < code.Length && char.IsDigit(code[index]))
            {
                digitCode += code[index];
                index++;
            }

            schiffer.Add(digitCode, letterCode);
        }
    }
}