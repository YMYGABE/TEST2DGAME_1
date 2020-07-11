using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public static Player_controller play;
    public float speed;
    public Animator PlayerAnim;
    public Rigidbody2D PlayerRig;
    public Vector2 PlayerMoveMent;
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
        PlayerRig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
    }
    public void Move(){
        PlayerMoveMent.x =  Input.GetAxisRaw("Horizontal"); //获取水平轴上的变量
        PlayerMoveMent.y =  Input.GetAxisRaw("Vertical");  //获取垂直轴上的变量
        PlayerRig.MovePosition(PlayerRig.position+PlayerMoveMent*speed*Time.deltaTime); //改变人物的位置
    }

    public void Turn(){
        if(PlayerMoveMent != Vector2.zero){   //Vector2(0, 0)的简写，就是没动的意思
            PlayerAnim.SetFloat("VX",PlayerMoveMent.x);   //获取玩家x轴上的变量
            PlayerAnim.SetFloat("VY",PlayerMoveMent.y);   //获取玩家y轴上的变量
        }
        PlayerAnim.SetFloat("Run",PlayerMoveMent.magnitude);   //这个计算的是（x^2+y^2）^2,反正肯定 >= 0，只要动了，就切换ANIMATOR
    }
    public static void Drop(int ID,Inventory MyBag)
    {
        Instantiate(MyBag.Items[ID].ItemImage,play.PlayerRig.position,Quaternion.identity);
    }
}
