using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Trie : ITrie
{
    /// <summary>
    /// Root TrieNode.
    /// </summary>
    private TrieNode rootTrieNode { get; set; }

    /// <summary>
    /// Create a new Trie instance.
    /// </summary>
    /// <param name="rootTrieNode">The root TrieNode.</param>
    public Trie(TrieNode rootTrieNode)
    {
        this.rootTrieNode = rootTrieNode;
    }

    /// <summary>
    /// Add a word to the Trie.
    /// </summary>
    public void AddWord(string word)
    {
        AddWord(this.rootTrieNode, word.ToCharArray());
    }

    /// <summary>
    /// Get all words in the Trie.
    /// </summary>
    public ICollection<string> GetWords()
    {
        var words = new List<string>();
        var buffer = new StringBuilder();
        this.GetWords(this.rootTrieNode, words, buffer);
        return words;
    }

    /// <summary>
    /// Get words for given prefix.
    /// </summary>
    public ICollection<string> GetWords(string prefix)
    {
        ICollection<string> words;
        if (string.IsNullOrEmpty(prefix))
        {
            words = this.GetWords();
        }
        else
        {
            var trieNode = this.GetTrieNode(prefix);
            words = new List<string>();
            if (trieNode != null)
            {
                var buffer = new StringBuilder();
                buffer.Append(prefix);
                this.GetWords(trieNode, words, buffer);
            }
        }

        return words;
    }

    /// <summary>
    /// Returns true or false if the word is present in the Trie.
    /// </summary>
    public bool HasWord(string word)
    {
        var trieNode = this.GetTrieNode(word);
        bool hasWord = trieNode != null && trieNode.IsWord;
        return hasWord;
    }

    /// <summary>
    /// Returns the count for the word in the Trie.
    /// </summary>
    public int WordCount(string word)
    {
        var trieNode = this.GetTrieNode(word);
        if (trieNode == null)
        {
            return 0;
        }
        else
        {
            return trieNode.WordCount;
        }
    }

    /// <summary>
    /// Get the equivalent TrieNode in the Trie for given prefix. 
    /// If prefix not present, then return null.
    /// </summary>
    private TrieNode GetTrieNode(string prefix)
    {
        var trieNode = this.rootTrieNode;
        foreach (var prefixChar in prefix.ToCharArray())
        {
            trieNode.Children.TryGetValue(prefixChar, out trieNode);
            if (trieNode == null)
            {
                break;
            }
        }

        return trieNode;
    }

    /// <summary>
    /// Recursive method to add word. Gets the first char of the word, 
    /// creates the child TrieNode if null, and recurses with the first
    /// char removed from the word. If the word length is 0, return.
    /// </summary>
    private void AddWord(TrieNode trieNode, char[] word)
    {
        if (word.Length == 0)
        {
            trieNode.IsWord = true;
            trieNode.WordCount++;
        }
        else
        {
            var symbol = Utilities.FirstChar(word);
            TrieNode child;
            trieNode.Children.TryGetValue(symbol, out child);
            if (child == null)
            {
                child = TrieFactory.GetTrieNode(symbol);
                trieNode.Children[symbol] = child;
            }

            var symbolRemoved = Utilities.FirstCharRemoved(word);
            this.AddWord(child, symbolRemoved);
        }
    }

    /// <summary>
    /// Recursive method to get all the words starting from given TrieNode.
    /// </summary>
    private void GetWords(TrieNode trieNode, ICollection<string> words,
        StringBuilder buffer)
    {
        if (trieNode.IsWord)
        {
            words.Add(buffer.ToString());
        }

        foreach (var child in trieNode.Children.Values)
        {
            buffer.Append(child.Character);
            this.GetWords(child, words, buffer);
            buffer.Length--;
        }
    }
}