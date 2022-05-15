using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickOnReturn : MonoBehaviour
{
    public Button m_Button;
    int m_SceneIndex;
    bool m_Return;
   
    void Start()
    {
        m_Return = false;
        m_SceneIndex = SceneManager.GetActiveScene().buildIndex;
        m_Button.onClick.AddListener(ReturnToPreviousScene);
    }

    private void Update()
    {
        if(m_SceneIndex == 3 && m_Return)
        {
            SceneManager.LoadScene(1);
        }
    }

    void ReturnToPreviousScene()
    {
        m_Return = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
