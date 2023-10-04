using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityItem : MonoBehaviour
{
    [SerializeField] Text m_CityTxt = null;
    [SerializeField] Image m_Img = null;
    public Button m_CityBtn = null;
    public string cityName;

    public void Initialize(string cityName)
    {
        this.cityName = cityName;
        m_CityTxt.text = cityName;
    }

    public void Selected()
    {
        m_Img.color = Color.green;
    }

    public void UnSelected()
    {
        m_Img.color = Color.white;
    }
}
