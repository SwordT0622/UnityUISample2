using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalItem : MonoBehaviour
{
    [SerializeField] Text m_AnimalTxt = null;
    public Button m_AnimalBtn = null;
    public string animalName = null;

    public void Initialize(string name)
    {
        animalName = name;
        m_AnimalTxt.text = animalName;
    }

    public void Select()
    {
        m_AnimalTxt.color = new Color32(138, 43, 226, 255);
    }

    public void UnSelect()
    {
        m_AnimalTxt.color = Color.white;
    }

    //private void OnDestroy()
    //{
    //    Destroy(gameObject);
    //}
}
