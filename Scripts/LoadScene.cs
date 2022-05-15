using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public List<string> m_WordAlreadyUsed;
    public Transform m_Panel;

    public void Restart()
    {
        //If the safeguard of list already exist
        if (File.Exists(ChooseWordCategory.m_ButtonName + ".txt"))
        {
             CreateWordList.m_Wordshoosen = SerializeList.Deserialize(ChooseWordCategory.m_ButtonName + ".txt");
        }
        else
        {
            //If the player passes to the next word, the last word play will be removed from the list
            CreateWordList.m_Wordshoosen.RemoveAt(MainPendu.selectedWord);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ReturnToMenu()
    {
        CreateWordList.m_Wordshoosen.RemoveAt(MainPendu.selectedWord);
        SceneManager.LoadScene(0);
        KeyBoardAnimation.m_FirstStart = true;
    }

    public static void LoadMainScene()
    {

        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public IEnumerator BtnAnimationGo()
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

