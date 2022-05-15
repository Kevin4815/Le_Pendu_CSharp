using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateWordList : MonoBehaviour
{
    public ListData m_ListWords;

    public static List<string> m_Words;
    public List<string> m_EasyWords;
    public static List<string> m_Wordshoosen;

    public List<string> ThreeOrFour;
    public List<string> FiveOrSix;
    public List<string> SevenOrHeight;
    public List<string> NineOrTen;
    public List<string> MoreOfTen;

    void Start()
    {
        //List of all words
        m_Words = CountNbOfWords(m_ListWords.m_Words);
        m_EasyWords = CountNbOfWords(m_ListWords.m_EasyWords);

        InstantiateListByLength(m_Words);
    }

    // List of all words
    public List<string> CountNbOfWords(string words)
    {
        List<string> ListWords = words.Split(' ').ToList();

        for (int i = 0; i < ListWords.Count; i++)
        {
            ListWords[i] = ListWords[i].ToUpper();
        }

        return ListWords;
    }

    // Length of each words
    public int CheckWordLength(string word)
    {
        List<string> wordLength = CountNbOfWords(word);
        int nbLetters = 0;

        for (int i = 0; i < wordLength.Count; i++)
        {
            for (int j = 0; j < word.Length; j++)
            {
                nbLetters++;
            }
        }

        return nbLetters;
    }

    // Put each words in the right list with her length
    public void InstantiateListByLength(List<string> word)
    {
        for (int i = 0; i < word.Count; i++)
        {
            int lenghtOfWord = CheckWordLength(m_Words[i]);

            if (lenghtOfWord == 3 || lenghtOfWord == 4)
            {
                ThreeOrFour.Add(word[i]);
            }
            else if (lenghtOfWord == 5 || lenghtOfWord == 6)
            {
                FiveOrSix.Add(word[i]);
            }
            else if (lenghtOfWord == 7 || lenghtOfWord == 8)
            {
                SevenOrHeight.Add(word[i]);
            }
            else if (lenghtOfWord == 9 || lenghtOfWord == 10)
            {
                NineOrTen.Add(word[i]);
            }
            else if (lenghtOfWord > 10)
            {
                MoreOfTen.Add(word[i]);
            }
        }
    }
}