using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleButtonCTR : MonoBehaviour
{
    public GameObject BattleButtons;
    public GameObject SkillButtonPrefab;
    public GameObject g_Canvas;
    public BattleManager g_BattleManager;
    public GameManager.Action g_eAction;
    public int g_iIndex;
    delegate void OnButton(GameManager.Action action, int index);

    private void Start()
    {
        BattleButtons = gameObject.transform.parent.gameObject;
        g_Canvas = GameObject.Find("Canvas");
        g_BattleManager = GameObject.Find("BattleManager").transform.GetComponent<BattleManager>();
        if(g_eAction == GameManager.Action.RUN)
        {
            Debug.Log("Afds");
            OnButton buttonDelegate = new OnButton(g_BattleManager.OnButton);

            // Button ������Ʈ�� onClick �̺�Ʈ�� ��������Ʈ ���
            gameObject.GetComponent<Button>().onClick.AddListener(() => buttonDelegate(g_eAction, g_iIndex));
        }
    }
    public void OnClick_Skill()
    {
        if (g_BattleManager.state == BattleManager.BattleState.ACTION)
        {
            Debug.Log("��ų��ư ����");
            SkillButtonPrefab = Resources.Load<GameObject>("Prefabs/SkillButtons");
            GameObject SkillButton_Temp = Instantiate(SkillButtonPrefab, g_Canvas.transform);
            for (int i = 0; i < SkillButton_Temp.transform.childCount - 1; i++)
            {
                SkillButton_Temp.transform.GetChild(i).GetChild(0).transform.GetComponent<Text>().text = g_BattleManager.playerUnit.m_AttackBehaviors[i].GetSkillName();
                SkillButton_Temp.transform.GetChild(i).GetChild(1).transform.GetComponent<Text>().text = g_BattleManager.playerUnit.m_iSkillAmounts[i] + "/" + g_BattleManager.playerUnit.m_AttackBehaviors[i].m_iUseAmount;
                if (g_BattleManager.playerUnit.m_iSkillAmounts[i] == 0)
                {
                    SkillButton_Temp.transform.GetChild(i).transform.GetComponent<Button>().enabled = false;
                    SkillButton_Temp.transform.GetChild(i).GetChild(0).transform.GetComponent<Text>().color = new Color(255,0,0);
                }
                    
            }

            BattleButtons.SetActive(false);
        }
    }
    public void Onclick_Change()
    {
        if (g_BattleManager.state == BattleManager.BattleState.ACTION)
        {
            Debug.Log("���� ��ư ����");
            //�������� Load
            GameObject ChangeButtonPrefab = Resources.Load<GameObject>("Prefabs/ChangeButtons");
            //instantiate �ϰ� �ؽ�Ʈ�� �ٲٱ� ���� Temp�� ����
            GameObject ChangeButton_Temp = Instantiate(ChangeButtonPrefab, g_Canvas.transform);
            //��ư�� �ؽ�Ʈ�� �÷��̾��� ���� �̸����� �ٲ�
            for (int i = 0; i < GameManager.Instance.m_UnitManager.g_PlayerUnits.Length; i++)
                ChangeButton_Temp.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<Text>().text = GameManager.Instance.m_UnitManager.g_PlayerUnits[i].GetComponent<UnitEntity>().m_sUnitName;
            BattleButtons.SetActive(false);
        }
    }
    public void OnClick_Inventory()
    {
        Debug.Log("�κ��丮 ��ư ����");
    }
}
