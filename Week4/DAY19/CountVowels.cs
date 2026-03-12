using System;

class Program
{
    static void Main()
    {
        string text = "Programming";
        int result = CountVowels(text);
        Console.WriteLine("Vowel Count: " + result);
    }

    static int CountVowels(string text)
    {
        int count = 0;
        text = text.ToLower();

        foreach (char c in text)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                count++;
            }
        }

        return count;
    }
}
