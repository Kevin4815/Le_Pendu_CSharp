using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseListType : MonoBehaviour
{
    public Button m_RandomWords;
    public Button m_ByCategory;

    void Start()
    {
        m_RandomWords.onClick.AddListener(LoadRandomList);
        m_ByCategory.onClick.AddListener(LoadCategoryList);
    }

    public void LoadRandomList()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadCategoryList()
    {
        SceneManager.LoadScene(2);
    }
}
