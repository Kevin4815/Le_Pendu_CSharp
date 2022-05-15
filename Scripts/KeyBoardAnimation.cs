using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardAnimation : MonoBehaviour
{
    public Transform m_Container;
    public static bool m_FirstStart = true;
    void Start()
    {
        if(m_FirstStart == true)
        {
            StartCoroutine(KeyBoard());
        }
        else
        {
            m_Container.localScale = new Vector3(1.10f,1.10f,1.10f);
        }
        m_FirstStart = false;
    }

    public IEnumerator KeyBoard()
    {
        Vector3 Gotoposition = new Vector3(1.10f,1.10f,1.10f);
        Vector3 currentPos = m_Container.transform.localScale;
        float elapsedTime = 0;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            if (m_Container.transform.localScale.x <= 1.10f)
            {
                m_Container.transform.localScale = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;

            }
            yield return null;
        }
    }
}
