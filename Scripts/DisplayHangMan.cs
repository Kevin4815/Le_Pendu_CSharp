using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHangMan : MonoBehaviour
{
    public GameObject m_HangManPictures;
    public OnClick m_OnClick;
    public bool m_FirstMistake = true;

    void Start()
    {
        m_HangManPictures.SetActive(false);
    }

    public void Update()
    {
        if (OnClick.m_Click == true)
        {
            if (m_FirstMistake == true)
            {
                OnClick.m_WrongLetters = 0;
                m_HangManPictures.SetActive(true);
                m_FirstMistake = false;
            }
        }
    }
}
