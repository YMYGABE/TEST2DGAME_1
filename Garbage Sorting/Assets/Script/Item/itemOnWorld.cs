using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public item this_Item;  //素材所属的item
    public Inventory this_Inventory; //素材所属的Inventory
    void OnTriggerEnter2D(Collider2D other)  //检测碰撞
    {
        if(other.gameObject.CompareTag("Player")){
            AddItem();
            Destroy(gameObject);
        }
    }
    public void AddItem(){   // 添加物品
        if(!this_Inventory.Items.Contains(this_Item)){      //数量不为0时添加
            this_Inventory.Items.Add(this_Item);
            // InventoryManager.CreatNewItem(this_Item);
            Debug.Log("挂载了吗？？");
        }else{   //否则数量增加
            this_Item.ItemNum++;
        }
        InventoryManager.RefreshItem();
    }
}
