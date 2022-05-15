using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.IO;
using System;

public class OnClick : MonoBehaviour, IPointerDownHandler
{
    public static string m_ClickedLetter;
    public static bool m_Click = false;
    public static int m_WrongLetters;
    public static int m_FindLetters;

    public AudioClip m_Win;
    public AudioClip m_Lose;

    AudioSource m_Audio;
    private void Start()
    {
        AddPhysics2DRaycaster();
        m_Audio = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ListAlreadySaved();

        m_Click = true;
        m_ClickedLetter = eventData.pointerCurrentRaycast.gameObject.name;

        IsCorrectLetterOrNot();
        EndSong();
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void EndSong()
    {
        //Generates sound by checking if the game is won or lost
        if (m_WrongLetters >= 9)
        {
            m_Audio.PlayOneShot(m_Lose);
        }
        else if (m_FindLetters >= CreateWordList.m_Wordshoosen[MainPendu.selectedWord].Length)
        {
            m_Audio.PlayOneShot(m_Win);
        }
    }
    
    public void ListAlreadySaved()
    {
        if (File.Exists(ChooseWordCategory.m_ButtonName + ".txt"))
        {
            try
            {
                CreateWordList.m_Wordshoosen = SerializeList.Deserialize(ChooseWordCategory.m_ButtonName + ".txt");
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    public void IsCorrectLetterOrNot()
    {
        //Condition that count the number of errors and letters find
        if (!CreateWordList.m_Wordshoosen[MainPendu.selectedWord].Contains(m_ClickedLetter))
        {
            m_WrongLetters++;
        }
        else if (CreateWordList.m_Wordshoosen[MainPendu.selectedWord].Contains(m_ClickedLetter))
        {
            int nb = CreateWordList.m_Wordshoosen[MainPendu.selectedWord].Where(w => w == char.Parse(m_ClickedLetter)).Count();

            //Check the number of occurences of the letters in the word
            if (nb > 1)
            {
                m_FindLetters += nb;
            }
            else
            {
                m_FindLetters++;
            }
        }
    }
}

