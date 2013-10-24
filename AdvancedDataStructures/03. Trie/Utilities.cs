using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class Utilities
{
    /// <summary>
    /// Gets the word with the first character removed.
    /// </summary>
    public static char[] FirstCharRemoved(char[] word)
    {
        char[] symbolRemoved = null;
        if (word.Length > 0)
        {
            symbolRemoved = new char[word.Length - 1];
            for (var count = 1; count < word.Length; count++)
            {
                symbolRemoved[count - 1] = word[count];
            }
        }

        return symbolRemoved;
    }

    /// <summary>
    /// Gets the first char of the word.
    /// </summary>
    public static char FirstChar(char[] word)
    {
        return word[0];
    }
}