using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ChooseWordLengthAdultList : MonoBehaviour
{
    public InstantiateButtonWordLength m_InstantiateButtonWordLength;

    public CreateWordList m_WordList;
    public List<Button> m_Buttons;
    public static List<string> ListChoosen;
    public static string m_ClickedLetter;
    public Transform m_Panel;

    void Start()
    {
        ObjectListInButtonList();
        StartCoroutine(PanelAnimation());
        ButtonEvent();
    }

    public void ObjectListInButtonList()
    {
        for (int i = 0; i < m_InstantiateButtonWordLength.m_ButtonsObject.Count; i++)
        {
            Button btn = m_InstantiateButtonWordLength.m_ButtonsObject[i].GetComponent<Button>();
            m_Buttons.Add(btn);
        }
    }

    public void ButtonEvent()
    {
        //On click of a button, the list only retrieves the words of the chosen size
        m_Buttons[0].onClick.AddListener(delegate { ChooseWordCategory.ChooseList(m_WordList.ThreeOrFour, "Score_3_4_letters", m_Buttons[0]); });
        m_Buttons[1].onClick.AddListener(delegate { ChooseWordCategory.ChooseList(m_WordList.FiveOrSix, "Score_3_4_letters", m_Buttons[1]); });
        m_Buttons[2].onClick.AddListener(delegate { ChooseWordCategory.ChooseList(m_WordList.SevenOrHeight, "Score_7_8_letters", m_Buttons[2]); });
        m_Buttons[3].onClick.AddListener(delegate { ChooseWordCategory.ChooseList(m_WordList.NineOrTen, "Score_9_10_letters", m_Buttons[3]); });
        m_Buttons[4].onClick.AddListener(delegate { ChooseWordCategory.ChooseList(m_WordList.MoreOfTen, "Score_More_letters", m_Buttons[4]); });
    }

    public IEnumerator PanelAnimation()
    {
        Vector3 Gotoposition = new Vector3(0.74f, 0.74f, 0.74f);
        float elapsedTime = 0;
        float duration = 1f;
        Vector3 currentPos = m_Panel.transform.localScale;

        while (elapsedTime < duration)
        {
            if (m_Panel.transform.localScale.x <= 1)
            {
                m_Panel.transform.localScale = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;

            }
            yield return null;
        }
    }
}