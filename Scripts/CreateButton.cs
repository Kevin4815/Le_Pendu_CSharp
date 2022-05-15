using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateButton : MonoBehaviour
{
     public Transform m_Container;
     public GameObject m_ButtonPrefab;
     public List<string> m_ButtonName = new List<string>();
     public List<GameObject> m_ButtonsObject = new List<GameObject>();
     public List<Button> m_Buttons = new List<Button>();
     public static List<string> m_IndexOfButtonListFinished = new List<string>();

    public CreateButton(Transform container, GameObject btnPrefab, List<string> btnName, List<GameObject> btnObject, List<Button> btn)
    {
        m_Container = container;
        m_ButtonPrefab = btnPrefab;
        m_ButtonName = btnName;
        m_ButtonsObject = btnObject;
        m_Buttons = btn;
    }

     void Awake()
     {
         CreateButtons();
         AddIndexOfFinishedList();
         LoadIndexOfCompletedListButton();
     }

     //Instantiate the list of buttons for the category section
     public void CreateButtons()
     {
         for (int i = 0; i < 5; i++)
         {
             GameObject button = Instantiate(m_ButtonPrefab, m_Container);
             button.GetComponentInChildren<TextMeshProUGUI>().text = m_ButtonName[i];
             button.name = m_ButtonName[i];
             m_ButtonsObject.Add(button);
         }

         for (int i = 0; i < m_ButtonsObject.Count; i++)
         {
             Button btn = m_ButtonsObject[i].GetComponent<Button>();
             m_Buttons.Add(btn);
         }
     }

     //Add the index of the finished list to save them if the game is quit and then restart
     public void AddIndexOfFinishedList()
     {
         if (CreateWordList.m_Wordshoosen != null)
         {
             if (CreateWordList.m_Wordshoosen.Count == 0)
             {
                 int index = m_Buttons.FindIndex(a => a.name == ChooseWordCategory.m_ButtonName);

                 m_IndexOfButtonListFinished.Add(index.ToString());
                 Serialize();
             }
         }
     }

     //Recover buttons whose list is finished to make them unusable
     public virtual void LoadIndexOfCompletedListButton()
     {
         if (File.Exists("listTestInt" + ".txt"))
         {
             try
             {
                 m_IndexOfButtonListFinished = SerializeList.Deserialize("listTestInt" + ".txt");

                 for (int i = 0; i < m_IndexOfButtonListFinished.Count; i++)
                 {
                     m_Buttons[int.Parse(m_IndexOfButtonListFinished[i])].enabled = false;
                     m_Buttons[int.Parse(m_IndexOfButtonListFinished[i])].GetComponent<Image>().color = Color.grey;
                 }
             }
             catch (Exception e)
             {
                 Debug.Log(e);
             }
         }
     }

     public void Serialize()
     {
         XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
         using (TextWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\" + "listTestInt" + ".txt"))
         {
             serializer.Serialize(writer, m_IndexOfButtonListFinished);
         }
     }

     public static List<string> Deserialize(string fileName)
     {
         XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
         FileStream stream = new FileStream(fileName, FileMode.Open);
         return (List<string>)serializer.Deserialize(stream);
     }
}
