using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] Image m_Img = null;
    [SerializeField] Text m_NumberTxt = null;
    [SerializeField] Text m_NameTxt = null;
    [SerializeField] Text m_KorTxt = null;
    [SerializeField] Text m_EngTxt = null;
    [SerializeField] Text m_MathTxt = null;
    [SerializeField] Text m_TotalTxt = null;
    [SerializeField] Text m_AverageTxt = null;

    public int number;
    public string name;
    public int kor;
    public int eng;
    public int math;

    public void Initialize(int num, string name, int kor, int eng, int math)
    {
        m_NumberTxt.text = num.ToString();
        m_NameTxt.text = name;
        m_KorTxt.text = kor.ToString();
        m_EngTxt.text = eng.ToString();
        m_MathTxt.text = math.ToString();
        m_TotalTxt.text = (kor + eng + math).ToString();
        m_AverageTxt.text = string.Format("{0:0.00}", (kor + math + eng) / 3f);

        number = num;
        this.name = name;
        this.kor = kor;
        this.eng = eng;
        this.math = math;
    }

    public void Selected()
    {
        m_Img.color = new Color32(138, 43, 226, 255);
    }

    public void UnSelected()
    {
        m_Img.color = Color.white;
    }
}
