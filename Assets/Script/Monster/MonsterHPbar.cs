using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHPbar : MonoBehaviour
{
    [SerializeField]private GameObject m_goPrefab = null;
    private List<Transform> m_objectList = new List<Transform>();
    private List<GameObject> m_hpBarList = new List<GameObject>();
    private Camera m_cam = null;
    private void Start()
    {
        m_cam = Camera.main;
        GameObject[] t_object = GameObject.FindGameObjectsWithTag("Enemy");
        // 배열의 개수만큼 오브젝트에게 체력바를 부여한다.
        for (int i = 0; i < t_object.Length; i++)
        {
            m_objectList.Add(t_object[i].transform);
            GameObject t_hpbar = Instantiate(m_goPrefab, t_object[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);

            MonsterStat monsterStat = t_object[i].GetComponent<MonsterStat>();
            if (monsterStat != null)
            {
                monsterStat.SetHpBar(t_hpbar.GetComponent<Slider>());
            }
        }
    }
    private void Update()
    {
        for(int i = 0; i< m_objectList.Count; i++)
        {
            if (m_objectList[i] != null)
            {
                m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.5f, 0));
            }
            else
            {
                Destroy(m_hpBarList[i]);
                m_hpBarList.RemoveAt(i);
                m_objectList.RemoveAt(i);
                i--; // 리스트에서 항목을 제거했기 때문에 인덱스를 감소시켜야 합니다.
            }
        }
    }
}
