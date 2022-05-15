using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SerializeList : MonoBehaviour
{
    public void Serialize()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
        using (TextWriter writer = new StreamWriter(Environment.CurrentDirectory +"\\" + ChooseWordCategory.m_ButtonName + ".txt"))
        {
            serializer.Serialize(writer, CreateWordList.m_Wordshoosen);
            Debug.Log(ChooseWordCategory.m_ButtonName);
        }
    }

    public static List<string> Deserialize(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
        FileStream stream = new FileStream(fileName, FileMode.Open);
        return (List<string>)serializer.Deserialize(stream);
    }
}
