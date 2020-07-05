using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator player_anim;
    public float MoveSpeed;
    public Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        player_anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
        Debug.Log(rig.velocity);
    }
    void Move(){
          float getmove = Input.GetAxis("Horizontal"); //获取水平轴上的移动向量的量，用来下面改变人物运动
            Vector2 vector2 = new Vector2(MoveSpeed*getmove,rig.velocity.y); //有了一个给定的x,y的向量
            rig.velocity = vector2;  //改变角色的速度
            bool RUN = Mathf.Abs(rig.velocity.x) > 0;
            player_anim.SetBool("Run",RUN);
    }

    void Turn(){
        if(Mathf.Abs(rig.velocity.x) > 0){
            if(rig.velocity.x > 0.1f){
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            if(rig.velocity.x < 0.1f){
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }
}
