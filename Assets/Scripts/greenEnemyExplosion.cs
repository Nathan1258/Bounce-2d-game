using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenEnemyExplosion : MonoBehaviour
{
    public static greenEnemyExplosion instance;
    public ParticleSystem explosionParticle;

    private void Awake()
    {
        instance = this;
    }
}
