using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test001Dlg : MonoBehaviour
{
    [SerializeField] InputField m_NameInput = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;
    [SerializeField] Text m_ResultTxt = null;

    private void Start()
    {
        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
        m_NameInput.onSubmit.AddListener(OnSubmit_Name);
        //m_NameInput.onEndEdit.AddListener(OnEndEdit_Name);
    }

     void OnClicked_Start()
    {
        SetResult(m_NameInput.text);
    }

    void OnClicked_Clear()
    {
        m_ResultTxt.text = "";
        m_NameInput.text = "";
    }

    void OnSubmit_Name(string txt)
    {
        SetResult(txt);
    }

    void OnEndEdit_Name(string txt)
    {
        m_ResultTxt.text = string.Format("�Է��� �������ϴ�. <color=#FF0000>{0}</color>", txt);
    }

    void SetResult(string txt)
    {
        m_ResultTxt.text = string.Format("����� �Է��� �̸��� <color=#FF0000>{0}</color>�Դϴ�.", txt);
    }
}
