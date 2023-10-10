using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTestDlg : MonoBehaviour
{
    [SerializeField] InputField m_NumberInput = null;
    [SerializeField] InputField m_NameInput = null;
    [SerializeField] InputField m_KoreanInput = null;
    [SerializeField] InputField m_EnglishInput = null;
    [SerializeField] InputField m_MathInput = null;
    [SerializeField] ScrollRect m_ScoreScroll = null;
    [SerializeField] Button m_AddBtn = null;
    [SerializeField] Button m_EditBtn = null;
    [SerializeField] Button m_DeleteBtn = null;
    [SerializeField] Button m_ClearBtn = null;
    [SerializeField] Button m_SaveBtn = null;
    [SerializeField] Button m_LoadBtn = null;
    [SerializeField] GameObject m_ScoreItem = null;

    [SerializeField] Button[] m_SortBtns = null;

    List<Score> m_Scores = new List<Score>();
    List<ScoreItem> m_ScoreItems = new List<ScoreItem>();
    ScoreItem curItem = null;
    int curIdx = -1;

    class Score
    {
        public int number;
        public string name;
        public int kor;
        public int eng;
        public int math;
        public int total
        {
            get
            {
                return kor + eng + math;
            }
        }
        public float average
        {
            get
            {
                return total / 3f;
            }
        }

        public Score(int number, string name, int kor, int eng, int math)
        {
            this.number = number;
            this.name = name;
            this.kor = kor;
            this.eng = eng;
            this.math = math;
        }
    }

    private void Start()
    {
        Initialize();   
    }

    void Initialize()
    {
        m_AddBtn.onClick.AddListener(OnClicked_Add);
        m_EditBtn.onClick.AddListener(OnClicked_Edit);
        m_DeleteBtn.onClick.AddListener(OnClicked_Delete);
        m_ClearBtn.onClick.AddListener(OnClicked_Clear);
        m_SaveBtn.onClick.AddListener(OnClicked_Save);
        m_LoadBtn.onClick.AddListener(OnClicked_Load);

        for(int i = 0; i < m_SortBtns.Length; i++)
        {
            int idx = i;
            m_SortBtns[i].onClick.AddListener(() =>
            {
                OnClicked_Sort(idx);
            });
        }
    }

    void OnClicked_Sort(int idx)
    {
        ClearAllItems();

        switch (idx)
        {
            case 0:
                {
                    m_Scores.Sort((a, b) => a.number.CompareTo(b.number));
                    break;
                }
            case 1:
                {
                    m_Scores.Sort((a, b) => a.name.CompareTo(b.name));
                    break;
                }
            case 2:
                {
                    m_Scores.Sort((a, b) => b.kor.CompareTo(a.kor));
                    break;
                }
            case 3:
                {
                    m_Scores.Sort((a, b) => b.eng.CompareTo(a.eng));
                    break;
                }
            case 4:
                {
                    m_Scores.Sort((a, b) => b.math.CompareTo(a.math));
                    break;
                }
            case 5:
                {
                    m_Scores.Sort((a, b) => b.total.CompareTo(a.total));
                    break;
                }
            case 6:
                {
                    m_Scores.Sort((a, b) => b.average.CompareTo(a.average));
                    break;
                }
        }

        CreateAllItems();
    }

    void OnClicked_Add()
    {
        if (m_NumberInput.text == string.Empty || m_NameInput.text == string.Empty || m_KoreanInput.text == string.Empty || m_EnglishInput.text == string.Empty || m_MathInput.text == string.Empty)
            return;

        ClearAllItems();

        int number = int.Parse(m_NumberInput.text);
        string name = m_NameInput.text;
        int kor = int.Parse(m_KoreanInput.text);
        int eng = int.Parse(m_EnglishInput.text);
        int math = int.Parse(m_MathInput.text);

        if (kor < 0 || kor > 100)
            return;
        if (eng < 0 || eng > 100)
            return;
        if (math < 0 || math > 100)
            return;

        Score score = new Score(number, name, kor, eng, math);
        m_Scores.Add(score);
        m_Scores.Sort((a, b) => b.total.CompareTo(a.total));

        CreateAllItems();
        ClearInputField();
    }

    void OnClicked_Edit()
    {
        if (curItem == null)
            return;

        int number = int.Parse(m_NumberInput.text);
        string name = m_NameInput.text;
        int kor = int.Parse(m_KoreanInput.text);
        int eng = int.Parse(m_EnglishInput.text);
        int math = int.Parse(m_MathInput.text);

        m_Scores[curIdx] = new Score(number, name, kor, eng, math);
        m_Scores.Sort((a, b) => b.total.CompareTo(a.total));

        for(int i = 0; i < m_Scores.Count; i++)
        {
            int nu = m_Scores[i].number;
            string na = m_Scores[i].name;
            int k = m_Scores[i].kor;
            int e = m_Scores[i].eng;
            int m = m_Scores[i].math;

            m_ScoreItems[i].Initialize(nu, na, k, e, m);
        }

        curItem.UnSelected();
        curItem = null;
        curIdx = -1;

        ClearInputField();
    }

    void OnClicked_Delete()
    {
        if (curItem == null)
            return;

        Destroy(curItem.gameObject);
        m_ScoreItems.Remove(curItem);
        curItem = null;

        m_Scores.RemoveAt(curIdx);
        curIdx = -1;

        ClearInputField();
    }

    void OnClicked_Clear()
    {
        ClearAllItems();
        curIdx = -1;
        curItem = null;
        m_Scores.Clear();
        m_ScoreItems.Clear();
        ClearInputField();
    }

    void OnClicked_Save()
    {
        FileStream fs = new FileStream("Save.data", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine(m_Scores.Count);

        for(int i = 0; i < m_Scores.Count; i++)
        {
            int number = m_Scores[i].number;
            string name = m_Scores[i].name;
            int kor = m_Scores[i].kor;
            int eng = m_Scores[i].eng;
            int math = m_Scores[i].math;
            
            sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", number, name, kor, eng, math));
        }

        sw.Close();
        fs.Close();
    }

    void OnClicked_Load()
    {
        FileStream fs = new FileStream("Save.data", FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        int count = int.Parse(sr.ReadLine());

        for(int i = 0; i < count; i++)
        {
            string line = sr.ReadLine();
            string[] data = line.Split('\t');

            int number = int.Parse(data[0]);
            string name = data[1];
            int kor = int.Parse(data[2]);
            int eng = int.Parse(data[3]);
            int math = int.Parse(data[4]);

            Score score = new Score(number, name, kor, eng, math);
            m_Scores.Add(score);
        }

        sr.Close();
        fs.Close();

        m_Scores.Sort((a, b) => b.total.CompareTo(a.total));
        CreateAllItems();
    }

    void OnClicked_Item(ScoreItem kItem, int idx)
    {
        if(curItem == kItem)
        {
            curItem.UnSelected();
            curItem = null;
            curIdx = -1;

            ClearInputField();
        }
        else
        {
            curIdx = idx;
            if (curItem != null)
                curItem.UnSelected();
            curItem = kItem;
            curItem.Selected();

            m_NumberInput.text = curItem.number.ToString();
            m_NameInput.text = curItem.name;
            m_KoreanInput.text = curItem.kor.ToString();
            m_EnglishInput.text = curItem.eng.ToString();
            m_MathInput.text = curItem.math.ToString();
        }
    }

    void ClearAllItems()
    {
        for(int i = 0; i < m_ScoreItems.Count; i++)
        {
            Destroy(m_ScoreItems[i].gameObject);
        }

        m_ScoreItems.Clear();
    }

    void CreateAllItems()
    {
        for(int i = 0; i < m_Scores.Count; i++)
        {
            int number = m_Scores[i].number;
            string name = m_Scores[i].name;
            int kor = m_Scores[i].kor;
            int eng = m_Scores[i].eng;
            int math = m_Scores[i].math;

            ScoreItem kItem = CreateItem(i);
            kItem.Initialize(number, name, kor, eng, math);
            m_ScoreItems.Add(kItem);
        }
    }

    void ClearInputField()
    {
        m_NumberInput.text = "";
        m_NameInput.text = "";
        m_KoreanInput.text = "";
        m_EnglishInput.text = "";
        m_MathInput.text = "";
    }

    ScoreItem CreateItem(int idx)
    {
        GameObject go = Instantiate(m_ScoreItem, m_ScoreScroll.content);
        ScoreItem kItem = go.GetComponent<ScoreItem>();

        int i = idx;
        Button btn = go.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            OnClicked_Item(kItem, i);
        });
        return kItem;
    }

    private void OnDestroy()
    {
        for(int i = 0; i < m_ScoreItems.Count; i++)
        {
            Destroy(m_ScoreItems[i].gameObject);
        }
    }
}
