using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListData", menuName = "My Game/List Data")]
public class ListData : ScriptableObject
{
    //List of words for different game modes
    [TextArea]
    public string m_Words;

    [TextArea]
    public string m_EasyWords;

    [TextArea]
    public string m_SportsWords;

    [TextArea]
    public string m_CinemaWords;

    [TextArea]
    public string m_CountryWords;

    [TextArea]
    public string m_MarkWords;

    [TextArea]
    public string m_CookWords;
}
