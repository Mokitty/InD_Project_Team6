using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    // g_fCharacterSpeed -> g�� �۷ι�(public) m�� ���(private) ���� f(float)/i(int)/s(string)
    public static Slot g_SInstance;
    public Image g_iitem_Image;
    public Sprite g_snull_item_Image;
    public Item g_Ihave_item;

    public int item_Number; // ȹ���� ������ ����
    Slot_Button s_B;

    [Header("UI�Ҵ�")]
    public Image item_View_Img;
    public TextMeshProUGUI item_Number_Text;
    public TextMeshProUGUI item_Description_Text;
    public TextMeshProUGUI item_Name_Text;

    private void Awake()
    {
        g_SInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        s_B = GetComponent<Slot_Button>();
    }

    // Update is called once per frame
    void Update()
    {
        Show_Item();
        Empty_Check();
    }

    public void Empty_Check()
    {
        if (g_Ihave_item != null)
        {
            if (item_Number <= 0) // �������� ���ٸ� �������� �� ����ߴٸ�
            {
                g_Ihave_item = null;               // ���� 
                g_iitem_Image.gameObject.SetActive(false);
            }
            else
            {
                g_iitem_Image.gameObject.SetActive(true);
                g_iitem_Image.sprite = g_Ihave_item.item_Image;
                
            }
        }
        else
        {
            if (item_Number <= 0) // �������� ���ٸ� �������� �� ����ߴٸ�
            {
                g_Ihave_item = null;               // ���� 
                g_iitem_Image.gameObject.SetActive(false);
            }
            item_Number = 0;
        }
    }

    public void OnPointerEnter()
    {
        print(gameObject.name);
      //  item_View_Img.sprite = g_Ihave_item.item_Image;
        //item_Number_Text.text = item_Number.ToString();
        //item_Description_Text = g_Ihave_item.
       // item_Name_Text.text = g_Ihave_item.item_Name + " : " + item_Number.ToString();
    }



    public void Input_Item(Item item, int num = 1) // ������ �ֱ�
    {
        if (item != null) // �޾ƿ� �������� �ִٸ�
        {
            g_Ihave_item = item;  // ���� ������ ������ ������ �������� �ְ�
            item_Number += num;
        }
    }

    void Show_Item()
    {
        if (g_Ihave_item != null)
        {
            g_iitem_Image.sprite = g_Ihave_item.item_Image ; // ������ �̹��� �Ҵ�
        }
        else
        {
            g_iitem_Image.sprite = g_snull_item_Image;
        }
    }
}
