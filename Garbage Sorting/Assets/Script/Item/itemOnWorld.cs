using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    public item this_Item;  //素材所属的item
    public Inventory this_Inventory; //素材所属的Inventory
    public AudioSource GetAudio;
    public bool playmusic;
     void Start()
    {
        playmusic = false;
        GetAudio = GetComponent<AudioSource>();
    }
    //private void Update()
    //{
    //    if(playmusic)
    //    {
    //        PlayAudio();
    //    }
    //}
    void OnTriggerEnter2D(Collider2D other)  //检测碰撞
    {
        if(other.gameObject.CompareTag("Player")){
            //Debug.Log("play");
            //playmusic = true;
            //GetAudio.Play();
            Collection.pickupcollection();
            AddItem();
            Destroy(gameObject);
            
        }
    }
    //public void PlayAudio() {
    //    GetAudio.Play();
    //    playmusic = false;
    //}
    public void AddItem(){   // 添加物品
        if (!this_Inventory.Items.Contains(this_Item)){      //数量不为0时添加
            // this_Inventory.Items.Add(this_Item);
            // InventoryManager.CreatNewItem(this_Item);
            // Debug.Log("挂载了吗？？");
            for(int i = 0;i < this_Inventory.Items.Count;i++){
                if(this_Inventory.Items[i] == null){
                    this_Inventory.Items[i] = this_Item;
                    break;
                }
            }
        }else{   //否则数量增加
            this_Item.ItemNum++;
        }
        InventoryManager.RefreshItem();
    }
}
