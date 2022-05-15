using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;
using System.Xml.Serialization;

public class MainPendu : MonoBehaviour
{
    Stream stream;
    XmlSerializer xmlSer;
    TextMeshProUGUI m_TextWordFirstChar;
    TextMeshProUGUI m_TextButtonLetter;
    TextMeshProUGUI m_Message;

    public GameScore m_GameScore;
    public GameObject m_Tiret;
    public GameObject m_LettersAlpha;
    public GameObject m_EndCanvas;

    public List<GameObject> m_Guess;
    public List<GameObject> m_Letters;
    public List<string> m_ListOfSelectedCategory;

    public TextMeshProUGUI m_Score;
    public TextMeshProUGUI m_NbWordsPlay;

    public Transform m_Container;
    public Transform m_ContainerLetters;
    public Transform m_BackgroundEnd;

    public Button m_Restart;
    public Button m_Exit;

    public static int m_NbWordTried;
    public static int selectedWord;

    public string m_WordListSaved = "";
    int j = 65;

    void Start()
    {
        OnClick.m_FindLetters = 0;
        OnClick.m_WrongLetters = 0;
        OnClick.m_ClickedLetter = " ";
        GameScore.m_WordIsFind = false;

        if (File.Exists(ChooseWordCategory.m_ButtonName + ".txt"))
        {
            m_ListOfSelectedCategory = SerializeList.Deserialize(ChooseWordCategory.m_ButtonName + ".txt");
        }
        else
        {
            m_ListOfSelectedCategory = CreateWordList.m_Wordshoosen;
        }

        m_NbWordTried = m_ListOfSelectedCategory.Count;

        selectedWord = UnityEngine.Random.Range(0, m_ListOfSelectedCategory.Count - 1);

        StartCoroutine(DisplayFirstLetter());
        CreateTiretsOfHiddenWord();
        CreateAlphaLetters();
    }

    void Update()
    {
        MainGame();
    }

    public void MainGame()
    {
        if (OnClick.m_Click == true && m_ListOfSelectedCategory.Count > 0)
        {
            char letter = char.Parse(OnClick.m_ClickedLetter);

            for (int i = 0; i < m_ListOfSelectedCategory[selectedWord].Length; i++)
            {
                if (m_ListOfSelectedCategory[selectedWord][i] == letter)
                {
                    m_TextWordFirstChar = m_Guess[i].GetComponentInChildren<TextMeshProUGUI>();
                    m_TextWordFirstChar.text = letter.ToString();
                }
            }
            m_Message = m_EndCanvas.GetComponentInChildren<TextMeshProUGUI>();
            LoseOrWine();
            DisabledFindLetters(OnClick.m_ClickedLetter);
        }

        //Display number of words to find and score of words already finded
        m_Score.text = "Score : " + GameScore.m_NbWordFind;
        m_NbWordsPlay.text = "Mots restants : " + m_NbWordTried;
    }

    public void CreateTiretsOfHiddenWord()
    {
        for (int i = 0; i < m_ListOfSelectedCategory[selectedWord].Length; i++)
        {
            if(m_ListOfSelectedCategory[selectedWord][i] == '-')
            {
                OnClick.m_FindLetters += 1;
                m_Tiret.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
            else
            {
                m_Tiret.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            }
            m_Guess.Add(Instantiate(m_Tiret, m_Container));
        }
    }

    public void CreateAlphaLetters()
    {
        for (int i = 0; i < 26; i++)
        {
            m_Letters.Add(Instantiate(m_LettersAlpha, m_ContainerLetters));
            m_TextButtonLetter = m_Letters[i].GetComponentInChildren<TextMeshProUGUI>();

            int c = j;
            char convertToChar = (char)c;
            j++;

            m_TextButtonLetter.text = convertToChar.ToString();
            m_Letters[i].GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            m_Letters[i].name = m_TextButtonLetter.text;
        }
    }


    //The first and the last letter of the word are displayed
    public IEnumerator DisplayFirstLetter()
    {
        yield return new WaitForEndOfFrame();

        if (Menu.m_Adult == true)
        {
            char letter = m_ListOfSelectedCategory[selectedWord][0];

            ShowFirstOrLastChar(letter);
        }
        else
        {
            char firstLetter = m_ListOfSelectedCategory[selectedWord][0];
            char lastLetter = m_ListOfSelectedCategory[selectedWord][m_ListOfSelectedCategory[selectedWord].Length - 1];

            ShowFirstOrLastChar(firstLetter);
            ShowFirstOrLastChar(lastLetter);
        }
    }

    public void ShowFirstOrLastChar(char letter)
    {
        for (int i = 0; i < m_ListOfSelectedCategory[selectedWord].Length; i++)
        {
            if (m_ListOfSelectedCategory[selectedWord][i] == letter)
            {
                m_TextWordFirstChar = m_Guess[i].GetComponentInChildren<TextMeshProUGUI>();
                m_TextWordFirstChar.text = letter.ToString();
                OnClick.m_FindLetters++;
            }
        }
        DisabledFindLetters(letter.ToString());
    }

    //The letter already clicked becomes disabled
    public void DisabledFindLetters(string letter)
    {
        for (int i = 0; i < m_Letters.Count; i++)
        {
            if (m_Letters[i].name == letter)
            {
                m_Letters[i].GetComponentInChildren<OnClick>().enabled = false;
                m_Letters[i].GetComponentInChildren<Image>().color = Color.grey;
            }
        }
    }

    //At the end of the game the alphabet letters are disabled for prevent error
    public void DisabledLettersEndGame()
    {
        for (int i = 0; i < m_Letters.Count; i++)
        {
            m_Letters[i].GetComponentInChildren<OnClick>().enabled = false;
        }
    }

    public IEnumerator EndAnimation()
    {
        Vector3 Gotoposition = new Vector3(1f, 1f, 1f);
        float elapsedTime = 0;
        float duration = 1f;
        Vector3 currentPos = m_BackgroundEnd.transform.localScale;

        while (elapsedTime < duration)
        {
            if (m_BackgroundEnd.transform.localScale.x <= 1)
            {
                m_BackgroundEnd.transform.localScale = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;

            }
            yield return null;
        }
    }

    public void LoseOrWine()
    {
        if (OnClick.m_WrongLetters >= 9)
        {
            EndActions("Vous avez perdu... Le mots était " + m_ListOfSelectedCategory[selectedWord] + ".");
        }
        else if (OnClick.m_FindLetters >= m_ListOfSelectedCategory[selectedWord].Length)
        {
            EndActions("Vous avez gagné !");
            GameScore.m_WordIsFind = true;
        }
    }

    //If all of words has been played
    public void EndActions(string message)
    {   
        if(CreateWordList.m_Wordshoosen.Count < 2)
        {
            m_Restart.GetComponent<Image>().color = Color.grey;
            m_Restart.enabled = false;
            m_Message.text = message + "\nVous avez joué tous les mots disponibles";
            EndMessage();
        }
        else
        {
            m_Message.text = message;
            EndMessage();
        }
    }

    //Display the canvas message
    public void EndMessage()
    {
        m_EndCanvas.SetActive(true);
        StartCoroutine(EndAnimation());
        DisabledLettersEndGame();
    }
}
