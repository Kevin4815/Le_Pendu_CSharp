using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWordCategory : MonoBehaviour
{
    public ListData m_ListWords;
    public InstantiateButtonCategory m_InstantiateButtonCategory;
    public List<Button> m_Buttons;

    public static string m_ButtonName;

    public List<string> m_ListOfListData;
    public List<List<string>> m_ListOfCutWords;

    public List<string> m_Sport;
    public List<string> m_Cinema;
    public List<string> m_Country;
    public List<string> m_Cars;
    public List<string> m_Cook;


    void Start()
    {
        PutStringDataWordsInList();
        ButtonEvent();
    }

    public void ButtonEvent()
    {
        m_InstantiateButtonCategory.m_Buttons[0].onClick.AddListener(delegate { ChooseList(m_ListOfCutWords[0], "Score_sport", m_InstantiateButtonCategory.m_Buttons[0]); });
        m_InstantiateButtonCategory.m_Buttons[1].onClick.AddListener(delegate { ChooseList(m_ListOfCutWords[1], "Score_cinéma", m_InstantiateButtonCategory.m_Buttons[1]); });
        m_InstantiateButtonCategory.m_Buttons[2].onClick.AddListener(delegate { ChooseList(m_ListOfCutWords[2], "Score_country", m_InstantiateButtonCategory.m_Buttons[2]); });
        m_InstantiateButtonCategory.m_Buttons[3].onClick.AddListener(delegate { ChooseList(m_ListOfCutWords[3], "Score_cars", m_InstantiateButtonCategory.m_Buttons[3]); });
        m_InstantiateButtonCategory.m_Buttons[4].onClick.AddListener(delegate { ChooseList(m_ListOfCutWords[4], "Score_cook", m_InstantiateButtonCategory.m_Buttons[4]); });
    }

    public void PutStringDataWordsInList()
    {
        m_ListOfListData = new List<string>() { m_ListWords.m_SportsWords, m_ListWords.m_CinemaWords, m_ListWords.m_CountryWords, m_ListWords.m_MarkWords, m_ListWords.m_CookWords };
        m_ListOfCutWords = new List<List<string>> { m_Sport, m_Cinema, m_Country, m_Cars, m_Cook };

        for (int i = 0; i < m_ListOfListData.Count; i++)
        {
            m_ListOfCutWords[i] = CountNbOfWords(m_ListOfListData[i]);
        }
    }

    //Get the string with the words and turns them into a list
    public List<string> CountNbOfWords(string words)
    {
        List<string> ListWords = words.Split(' ').ToList();

        for (int i = 0; i < ListWords.Count; i++)
        {
            ListWords[i] = ListWords[i].ToUpper();
        }

        return ListWords;
    }

   public static void ChooseList(List<string> list, string save, Button btn)
    {
        //The next scen is loaded on click
        LoadScene.LoadMainScene();
        CreateWordList.m_Wordshoosen = list;

        m_ButtonName = btn.name;
        GameScore.m_NbWordFind = PlayerPrefs.GetInt(save); //Get the score in memory
    }
}
