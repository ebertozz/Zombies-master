using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZombieControl : ZombieParent
{
    // Start is called before the first frame update
    void Awake()
    {
        base.SetParams("TreeZombie", 0.3f);
    }


}
