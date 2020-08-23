using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;
    public ParticleSystem playerExplosion;
    public bool isDead;

    private void Awake()
    {
        instance = this;

        isDead = false;
    }

    public void Die()
    {
        if (isDead != true)
        {
            Instantiate(playerExplosion);
            playerExplosion.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            isDead = true;
        }
    }
}
