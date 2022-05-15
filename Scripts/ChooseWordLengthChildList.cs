using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWordLengthChildList : MonoBehaviour
{
    public CreateWordList m_WordList;
    public Button m_ChildButton;
    void Start()
    {
        //On click of child mode, the list only retrieves the words of for children
        m_ChildButton.onClick.AddListener(delegate { ChooseWordCategory.ChooseList(m_WordList.m_EasyWords, "Score_easyWords", m_ChildButton); });
    }
}
