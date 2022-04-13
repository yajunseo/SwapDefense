using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using common;

public class InGame : MonoBehaviour
{
    [SerializeField] SpriteRenderer ingameBg;
    //[SerializeField] Color 

    private void Start()
    {
        CreateMap(10, 4, EMap.Forest);
    }

    /// <summary>
    /// 배경 생성
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="eMap"></param>
    public void CreateMap(int x, int y, EMap eMap)
    {
        // 1. 커다란 밑 판 만들기
        //ingameBg.color 
        // 2. 위에 사각 체스판 만들기 (배경에  따른 색상 고려)
        // 3. 사각 

    }
}
