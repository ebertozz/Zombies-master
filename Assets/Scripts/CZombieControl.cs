using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZombieControl : ZombieParent

{

    private void Awake()
    {
        base.SetParams("CZombie", 0.9f);
    }


}
