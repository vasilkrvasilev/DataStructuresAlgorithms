using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TrieNode
{
    /// <summary>
    /// The character for the TrieNode.
    /// </summary>
    public char Character { get; private set; }

    /// <summary>
    /// Children Character->TrieNode map.
    /// </summary>
    public IDictionary<char, TrieNode> Children { get; private set; }

    /// <summary>
    /// Boolean to indicate whether the root to this node forms a word.
    /// </summary>
    public bool IsWord { get; set; }

    /// <summary>
    /// The count of words for the TrieNode.
    /// </summary>
    public int WordCount { get; set; }

    /// <summary>
    /// Constructor for character.
    /// </summary>
    /// <param name="character">The character for the TrieNode.</param>
    /// <param name="children">Children of TrieNode.</param>
    /// <param name="isWord">If root TrieNode to this TrieNode is a word.</param>
    /// <param name="wordCount"></param>
    public TrieNode(char character, IDictionary<char, TrieNode> children,
        bool isWord, int wordCount)
    {
        this.Character = character;
        this.Children = children;
        this.IsWord = isWord;
        this.WordCount = wordCount;
    }

    /// <summary>
    /// For readability.
    /// </summary>
    /// <returns>Character.</returns>
    public override string ToString()
    {
        return this.Character.ToString();
    }

    public override bool Equals(object obj)
    {
        TrieNode that;
        bool areEqual = obj != null && (that = obj as TrieNode) != null && that.Character == this.Character;
        return areEqual;
    }

    public override int GetHashCode()
    {
        return this.Character.GetHashCode();
    }
}