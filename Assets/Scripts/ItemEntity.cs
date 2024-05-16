using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ItemEntity : MonoBehaviour
{
    public int m_iItemNumber;
    public Sprite m_ItemSprite;
    public string m_sItemName;
    public string m_sItemDescription;
    public string m_sItemUseDialog;
    public IItemBehavior ExecuteEffect;
    public UnitEntity allyUnit;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SetItemInfo();
    }

    public void SetItemInfo()
    {
        spriteRenderer = gameObject.transform.GetComponent<SpriteRenderer>();
        if (m_sItemName == null)
            Debug.Log("Item Name Missed");
        var ItemData = GameManager.Instance.GetItemData(m_sItemName);
        m_iItemNumber = ItemData.m_iItemNo;
        m_ItemSprite = ItemData.m_ItemSprite;
        m_sItemDescription = ItemData.m_sItemDescription;
        m_sItemUseDialog = ItemData.m_sItemUseDialog;
        ExecuteEffect = Instantiate(ItemData.m_ItemEffect);
        spriteRenderer.sprite = m_ItemSprite;
    }

    public void ExecuteItem(int index)
    {
        ExecuteEffect.ExecuteItemEffect(GameManager.Instance.m_UnitManager.g_PlayerUnits[index].GetComponent<UnitEntity>());
    }

    public string GetUseDialog()
    {
        return m_sItemUseDialog;
    }



// ������ ������ �����ϱ� ���� ���� Ŭ���� ����
[System.Serializable]
    public class ItemStats_Save
    {
        public string m_sItemName;
        public int m_iItemCount; // �������� ������ �����ϴ� ���� �߰�
    }
}
