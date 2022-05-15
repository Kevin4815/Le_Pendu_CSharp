using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public MainPendu m_MainPendu;
    public static int m_NbWordFind;
    public static bool m_WordIsFind;

    public static string test = "";

    public Dictionary<string, string> m_Data = new Dictionary<string, string>();

    public void Start()
    {
        m_Data = new Dictionary<string, string>()
        {
            { "Cinéma", "Score_cinéma" },
            { "Sport", "Score_sport" },
            { "Pays", "Score_country" },
            { "Voiture", "Score_cars"},
            { "Cuisine", "Score_cook"},
            { "3 à 4 lettres", "Score_3_4_letters"},
            { "5 à 6 lettres", "Score_5_6_letters"},
            { "7 à 8 lettres", "Score_7_8_letters"},
            { "9 à 10 lettres", "Score_9_10_letters" },
            { "Plus de lettres", "Score_More_letters" },
            { "Child", "Score_easyWords" }
        };
    }
    public void WordIsFind()
    {
        if (m_WordIsFind == true)
        {
            m_NbWordFind++;

            foreach (KeyValuePair<string, string> item in m_Data)
            {
                if (ChooseWordCategory.m_ButtonName == item.Key)
                {
                    PlayerPrefs.SetInt(item.Value, m_NbWordFind);
                }
            }
        }
    }
}

