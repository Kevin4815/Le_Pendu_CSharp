using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangMan : MonoBehaviour
{
    public List<Sprite> m_HangManSprites;
    public Image m_HangMan;

    private void Update()
    {
        //Change the picture of de hangman to the numbers of errors
        m_HangMan.sprite = m_HangManSprites[OnClick.m_WrongLetters];
    }
}
