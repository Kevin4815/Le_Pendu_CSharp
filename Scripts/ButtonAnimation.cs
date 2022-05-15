using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public Transform m_Container;
    public float m_Duration = 1f;
    Vector3 m_ContainerScale;

    void Start()
    {
        m_ContainerScale = m_Container.localScale;
        StartCoroutine(LoopAnimation());
    }

    //Buttons scale animation
    public IEnumerator BtnAnimation(Vector3 Gotoposition)
    {
        float elapsedTime = 0;
        float duration = m_Duration;
        Vector3 currentPos = m_Container.transform.localScale;

        while (elapsedTime < duration)
        {
            if (m_Container.transform.localScale.x <= 1)
            {
                m_Container.transform.localScale = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
    }

    public IEnumerator LoopAnimation()
    {
        StartCoroutine(BtnAnimation(new Vector3(m_ContainerScale.x - 0.10f, m_ContainerScale.y - 0.10f, m_ContainerScale.z - 0.10f)));
        yield return new WaitForSeconds(m_Duration);
        StartCoroutine(BtnAnimation(m_ContainerScale));
        yield return new WaitForSeconds(m_Duration);
        StartCoroutine(LoopAnimation());
    }
}
