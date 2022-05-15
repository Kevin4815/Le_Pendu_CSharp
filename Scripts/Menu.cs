using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool m_Adult;

    public void Adult()
    {
        m_Adult = true;
        SceneManager.LoadScene(1);
    }

    public void Child()
    {
        m_Adult = false;
        
        SceneManager.LoadScene(4);
    }
}
