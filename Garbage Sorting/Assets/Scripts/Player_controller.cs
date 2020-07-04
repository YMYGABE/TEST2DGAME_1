using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_controller : MonoBehaviour
{
    public float Movespeed;  //设置人物移动速度

    private Rigidbody rdb;  //获取人物刚体
    private Animator anim;  //人物的精灵图表
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      Move();
      Turn();
    }

    void Move()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        if (H != 0 || V != 0)
        {
           transform.Translate(new Vector3(H, 0, V) * Time.deltaTime * Movespeed, Space.World);
           bool RUN = Mathf.Abs(rdb.velocity.x) > 0;
           anim.SetBool("Run", RUN);  //动作切换，这里来改变引擎里设置的bool变量。
        }
        else
        {
           //没有移动
        }
    }
    
    void Turn() //用来让人物翻面
    {
        bool player = Mathf.Abs(rdb.velocity.x) > 0;
        if (player)
        {
            if(rdb.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);  //改变这个物体的角度，Quaternion都用来弄角度相关的东西
            }
            if(rdb.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 180);  //翻转180 （x,y,z）
                
            }
        }
    }
}
