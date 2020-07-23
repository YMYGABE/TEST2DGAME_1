using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
 [CreateAssetMenu(fileName = "New item",menuName = "Inventory/New item")]
public class item : ScriptableObject
{
  public string ItemName;
  public Sprite ItemImage;
  public int ItemNum;
  [TextArea]
  public string Iteminfo;
}