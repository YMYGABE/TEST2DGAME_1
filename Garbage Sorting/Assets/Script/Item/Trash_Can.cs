using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_Can : MonoBehaviour
{
    [Header("判断是否有垃圾和有垃圾桶")]
    public static bool TrashHave;
    public static bool HaveCatch;

    [Header("等待时间")]
    public float Waittime;  //等待时间
    [Header("切换的状态")]
    public Animator TrashAnim;
    // Start is called before the first frame update
    void Start()
    {
        TrashHave = false; //手中默认无垃圾
        HaveCatch = false; //没有碰到垃圾桶
        TrashAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HaveCatch){   //若摁下E的时候同时检测到碰撞才会调用
            //TrashHave = true;
           StartCoroutine(FinishTrash());   //调用协程
        //    Debug.Log(TrashHave);
        }
        TrashAnim.SetBool("HaveTrash",TrashHave);  //实时改变垃圾桶的状态
    }

      void OnTriggerStay2D(Collider2D other)  //每帧调用检测碰撞，如果用 OnTiggerEnter 就只能走出去再进来触发
     {
        
        if(other.gameObject.CompareTag("Player") 
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            // Debug.Log("Catch You!!!!");
            HaveCatch = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") 
        && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
                HaveCatch = false;
            }
    }
    IEnumerator FinishTrash(){   //用协程倒计时，
        yield return new WaitForSeconds(Waittime);
        TrashHave = false;
    }
}
