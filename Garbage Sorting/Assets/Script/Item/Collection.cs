using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public static AudioSource touchSource;   //声音播放器
    public static AudioClip pickup;  //声音片段
    // Start is called before the first frame update
    void Start()
    {
        touchSource = GetComponent<AudioSource>();    
        pickup = Resources.Load<AudioClip>("pickUp");  //选取声音片段，文件夹必须是Resources，不然会检测不到
    }
    public static void pickupcollection()
    {
        touchSource.PlayOneShot(pickup);     //播放一次声音片段，这个是2D专属的，3D是另一个方法
    }
}
