using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreateTrash : MonoBehaviour
{
    
    public enum ChangePO { supLeft,Left,Right,supRight}
    public ChangePO newposition;

    [Header("生成物信息")]
    public GameObject Trash_1;   //这是俩垃圾
    public GameObject Trash_2;
    public float itemnum;    //限制生成数量

    [Header("位置信息")]
    public Transform itempo;     //用来生成物品的位置
    public float x;            //每次移动的量
    public LayerMask TrashLayer;  //用来判断是否重叠的层
    private int randomNum;       //随机数，用来随机生成任意垃圾
    // Start is called before the first frame update

    public List<GameObject> Trashs = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < itemnum; i++)
        {
            randomNum = Random.Range(0, 2);
            switch (randomNum)
            {
                case 0:
                    Trashs.Add(Instantiate(Trash_1, itempo.position, Quaternion.identity));break;
                case 1:
                    Trashs.Add(Instantiate(Trash_2, itempo.position, Quaternion.identity)); break;
            }
            ChangePoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    public void ChangePoint()
    {
        do
        {
            newposition = (ChangePO)Random.Range(0, 5);
            switch (newposition)
            {
                case ChangePO.supLeft:
                    itempo.position += new Vector3(-2 * x, 0, 0); break;
                case ChangePO.Left:
                    itempo.position += new Vector3(-x, 0, 0); break;
                case ChangePO.Right:
                    itempo.position += new Vector3(x, 0, 0); break;
                case ChangePO.supRight:
                    itempo.position += new Vector3(2 * x, 0, 0); break;

            }
        } while (Physics2D.OverlapCircle(itempo.position, 0.1f, TrashLayer));
    }
}
