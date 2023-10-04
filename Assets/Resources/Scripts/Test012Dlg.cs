using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test012Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_AnimalScroll = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_ResultBtn = null;
    [SerializeField] Button m_ClearBtn = null;
    [SerializeField] GameObject m_AnimalItem = null;

    [SerializeField] string[] m_Animals = null;
    List<AnimalItem> m_AnimalItems = new List<AnimalItem>();
    AnimalItem curItem = null;

    private void Start()
    {
        Initialize();   
    }

    void Initialize()
    {
        for(int i = 0; i < m_Animals.Length; i++)
        {
            CreateItem(i);
        }

        m_ResultBtn.onClick.AddListener(OnClicked_Result);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Result()
    {
        if(curItem == null)
        {
            m_ResultTxt.text = "동물을 선택해주세요.";
            return;
        }
        else
        {
            m_ResultTxt.text = string.Format("당신이 선택한 동물은 <color=#8a2be2>{0}</color> 입니다.", curItem.animalName);
        }
    }

    void OnClicked_Clear()
    {
        curItem = null;
        m_ResultTxt.text = "초기화되었습니다.";
    }

    void OnClicked_Item(AnimalItem kItem)
    {
        if (curItem != null)
            curItem.UnSelect();
        curItem = kItem;
        curItem.Select();

        m_ResultTxt.text = curItem.animalName;
    }

    void CreateItem(int idx)
    {
        GameObject go = Instantiate(m_AnimalItem, m_AnimalScroll.content);

        AnimalItem kItem = go.GetComponent<AnimalItem>();
        kItem.Initialize(m_Animals[idx]);

        Button btn = kItem.m_AnimalBtn;
        btn.onClick.AddListener(() =>
        {
            OnClicked_Item(kItem);
        });

        m_AnimalItems.Add(kItem);
    }

    private void OnDestroy()
    {
        for(int i = 0; i < m_AnimalItems.Count; i++)
        {
            Destroy(m_AnimalItems[i].gameObject);
        }
    }
}
