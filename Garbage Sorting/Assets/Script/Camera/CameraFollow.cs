using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smooth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public  void LateUpdate()
    {
        if(transform.position != player.position){
            Vector3 playerpo = player.position;
            transform.position = Vector3.Lerp(transform.position,playerpo,smooth);
        }
    }
}
