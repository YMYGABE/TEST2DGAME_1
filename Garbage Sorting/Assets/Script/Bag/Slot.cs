using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public int ID;
    public item slotitem;
    public Image slotimage;
    public Text slotNum;
    public GameObject iteminslot;
    public string slotinfor;
    public void onclick(){
        InventoryManager.UpdateItemInfo(slotinfor);
        if (Trash_Can.HaveCatch)
        {
            Destroy(slotitem);
        }
    }
    public void setupSlot(item item)
    {
        if(item == null)
        {
            iteminslot.SetActive(false);
            return;
        }

        slotimage.sprite = item.ItemImage;
        slotNum.text = item.ItemNum.ToString();
        slotinfor = item.Iteminfo;
    }
}
