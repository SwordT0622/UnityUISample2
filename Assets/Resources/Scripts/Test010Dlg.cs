using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test010Dlg : MonoBehaviour
{
    [SerializeField] ScrollRect m_AnimalScroll = null;
    [SerializeField] Text m_ResultTxt = null;
    [SerializeField] Button m_StartBtn = null;
    [SerializeField] Button m_ClearBtn = null;
    [SerializeField] GameObject m_AnimalItem = null;

    [SerializeField] string[] m_Animals = null;
    List<AnimalItem> m_AnimalItems = new List<AnimalItem>();

    AnimalItem selectedItem = null;

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

        m_StartBtn.onClick.AddListener(OnClicked_Start);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Start()
    {
        if (selectedItem == null)
            m_ResultTxt.text = "동물을 선택해주세요";
        else
            m_ResultTxt.text = string.Format("당신이 선택한 동물은 <color=#8a2be2>{0}</color> 입니다.", selectedItem.animalName);
    }

    void OnClicked_Clear()
    {
        selectedItem.UnSelect();
        selectedItem = null;

        m_ResultTxt.text = "초기화되었습니다.";
    }

    void OnClicked_AnimalItem(AnimalItem kItem)
    {
        if(selectedItem != null)
            selectedItem.UnSelect();
        selectedItem = kItem;
        selectedItem.Select();

        m_ResultTxt.text = string.Format("<color=#8a2be2>{0}</color>", selectedItem.animalName);
    }

    //void ClearAllItems()
    //{
    //    for (int i = 0; i < m_AnimalItems.Count; i++)
    //    {
    //        m_AnimalItems[i].UnSelect();
    //    }
    //}

    void CreateItem(int i)
    {
        GameObject go = Instantiate(m_AnimalItem, m_AnimalScroll.content);
        AnimalItem kItem = go.GetComponent<AnimalItem>();
        kItem.Initialize(m_Animals[i]);

        Button btn = kItem.m_AnimalBtn;
        btn.onClick.AddListener(() =>
        {
            OnClicked_AnimalItem(kItem);
        });

        //m_AnimalItems.Add(kItem);
    }

    void DestroyItem()
    {
        for (int i = 0; i < m_AnimalItems.Count; i++)
        {
            if (m_AnimalItems[i] != null)
                Destroy(m_AnimalItems[i].gameObject);
        }
    }

    private void OnDestroy()
    {
        DestroyItem();
    }
}