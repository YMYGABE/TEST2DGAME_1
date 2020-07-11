using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BagMenu : MonoBehaviour
{
    public GameObject Bag_Menu; //获取背包的类
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            Bag_Menu.SetActive(true);
        }
    }

    public void CloseBag(){
        Bag_Menu.SetActive(false);
    }
}
