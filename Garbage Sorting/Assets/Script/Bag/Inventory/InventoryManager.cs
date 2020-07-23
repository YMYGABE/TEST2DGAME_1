using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;
    // Start is called before the first frame update

    public Inventory Bag;  //获取背包列表
    public GameObject slotGrid;  //获取预制体将要挂载的父级
    // public Slot slotPrefab;
    public GameObject EmptySlots; //获取空的预制体
    public Text itemInfromation;  //物品信息

    public List<GameObject> slots = new List<GameObject>();  //用一个列表来存放预制体
    private  void Awake()
    { //因为挂载在Bag下，一开一关都会调用
        if(instance != null){
            Destroy(this);
        }
        instance = this;
    }

    private  void OnEnable()
    {
        RefreshItem();
        instance.itemInfromation.text = "";
    }
    public static void UpdateItemInfo(string iteminfo){
        instance.itemInfromation.text = iteminfo;  //更新物品信息
    }
    /*public static void CreatNewItem(item it){
        Slot NewItem = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        //复制带代码的预制体

        NewItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        //挂载到背包格子的下面

        //  给物品赋值
        NewItem.slotitem = it;
        NewItem.slotimage.sprite = it.ItemImage;
        NewItem.slotNum.text = it.ItemNum.ToString();
        // Debug.Log("yes");
    }*/

    public static void RefreshItem(){     //更新物品数量
        for(int i = 0;i < instance.slotGrid.transform.childCount;i++){   //先把之前的都删除了
            if(instance.transform.childCount == 0){
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for(int i = 0;i < instance.Bag.Items.Count;i++){   //再从新添加
            // CreatNewItem(instance.Bag.Items[i]);
            instance.slots.Add(Instantiate(instance.EmptySlots));   //生成空栏位，并存储到列表里，方便后面调用
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);    //挂载到Grid下面
            instance.slots[i].GetComponent<Slot>().ID = i;
            instance.slots[i].GetComponent<Slot>().setupSlot(instance.Bag.Items[i]);   //调用Slot里的方法
        }
    }
}
