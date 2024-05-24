using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DicCTR : MonoBehaviour,IPointerClickHandler
{
    private List<GameObject> m_DicElementsList;
    public GameObject m_DicElementPrefab;
    public GameObject g_ElementUI;
    public GameObject g_PortalEventButton;
    private GameObject g_PortalChangeButton;
    public ExplainAreaCTR g_ExplainArea;

    private void OnEnable()
    {
        g_PortalEventButton = Instantiate(Resources.Load<GameObject>("Prefabs/PortalEventButton"));
        g_PortalChangeButton = Instantiate(Resources.Load<GameObject>("Prefabs/PortalChange"));
        g_PortalEventButton.SetActive(false);
        g_PortalChangeButton.SetActive(false);
        InitList();
        InitUI();
        g_ExplainArea.Init("����");
    }

    private void InitList()
    {
        m_DicElementsList = new List<GameObject>();

        foreach (var element in GameManager.Instance.m_DataManager.m_UnitDic)
        {
            if(element.Value.m_sUnitName.Equals("����"))
                return;
            string unitName = element.Key;
            GameObject DicElementPrefab_temp = Instantiate(m_DicElementPrefab);
            DicElementPrefab_temp.GetComponent<DIcElementCTR>().Init(unitName);
            m_DicElementsList.Add(DicElementPrefab_temp);
        }
    }
   private void InitUI()
   {
        for (int i = 0; i < g_ElementUI.transform.childCount; i++)
            Destroy(g_ElementUI.transform.GetChild(i).gameObject);
        for (int i = 0; i < m_DicElementsList.Count; i++)
            m_DicElementsList[i].transform.SetParent(g_ElementUI.transform);
        
   }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject.transform.GetComponent<DIcElementCTR>() != null)
        {
            if (GameManager.Instance.g_GameState == GameManager.GameState.PORTAL)
            {
                g_PortalEventButton.transform.position = clickedObject.transform.position;
                g_PortalEventButton.name = clickedObject.transform.GetComponent<DIcElementCTR>().m_UnitName;
                g_PortalEventButton.SetActive(true);
            }
            else
            {
                g_ExplainArea.Init(clickedObject.transform.GetComponent<DIcElementCTR>().m_UnitName);
            }
        }
    }

    public void PortalEvent_Info()
    {
        g_ExplainArea.Init(g_PortalEventButton.name);
    }
    public void PortalEvent_Change()
    {
        g_PortalChangeButton.transform.position = g_PortalEventButton.transform.position;
        for (int i = 0; i < g_PortalChangeButton.transform.childCount; i++)
        {
            g_PortalChangeButton.transform.GetChild(i).GetComponent<DIcElementCTR>().Init(GameManager.Instance.m_UnitManager.g_PlayerUnits[i].GetComponent<UnitEntity>().m_sUnitName);
        }
        
    }

}
