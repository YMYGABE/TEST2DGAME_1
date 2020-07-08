using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

 [CreateAssetMenu(fileName = "New item",menuName = "Inventory/New item")]
public class item : ScriptableObject
{
  public string ItemName;
  public Sprite ItemImage;
  public int ItemNum;
}