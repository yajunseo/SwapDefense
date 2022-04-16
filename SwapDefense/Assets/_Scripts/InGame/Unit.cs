using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public enum TEAM
    {
        FRIENDLY = 0,
        ENEMY = 1
    }
    public class Unit : Entity
    {
        //Default Friendly
        [SerializeField]
        TEAM myTeam = TEAM.FRIENDLY;

    }
}
