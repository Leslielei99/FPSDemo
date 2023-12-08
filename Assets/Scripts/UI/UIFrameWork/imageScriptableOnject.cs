using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sprites", menuName = "ScripeableObject/图片数据", order = 0)]
public class imageScriptableOnject : ScriptableObject
{
    public List<Sprite> sprites = new List<Sprite>();
}