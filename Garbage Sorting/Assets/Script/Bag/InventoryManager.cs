using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;
    // Start is called before the first frame update

    public Inventory Bag;
    public GameObject slotGrid;
    public Slot slotPrefab;



    private  void Awake()
    {
        if(instance != null){
            Destroy(this);
        }
        instance = this;
    }

    private  void OnEnable()
    {
        RefreshItem();
    }
    public static void CreatNewItem(item it){
        Slot NewItem = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        //复制带代码的预制体

        NewItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        //挂载到背包格子的下面

        //  给物品赋值
        NewItem.slotitem = it;
        NewItem.slotimage.sprite = it.ItemImage;
        NewItem.slotNum.text = it.ItemNum.ToString();
        // Debug.Log("yes");
    }

    public static void RefreshItem(){     //更新物品数量
        for(int i = 0;i < instance.slotGrid.transform.childCount;i++){   //先把之前的都删除了
            if(instance.transform.childCount == 0){
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for(int i = 0;i < instance.Bag.Items.Count;i++){   //再从新添加
            CreatNewItem(instance.Bag.Items[i]);
        }
    }
}
