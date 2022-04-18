using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;
using System;

[Serializable]
public class MapInfo
{
    public string name;
    public int x = 4, y = 10;
    public EMap mapType;
}

[Serializable]
public class GameInfo : MonoBehaviour
{
    [SerializeField] public MapInfo[] mapInfo = new MapInfo[5];
}
