using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceSystem : MonoBehaviour
{
    public static BounceSystem instance;
    public Slider bounceStaminaBar;
    public bool isUsingSlowmo;
    public GameObject bar;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bounceStaminaBar.value = 1000;
        isUsingSlowmo = false;
    }


    private void Update()
    {
        float val = bounceStaminaBar.value;
        if(isUsingSlowmo)
        {
            bounceStaminaBar.value = val - 3;
        }
        else
        {
            bounceStaminaBar.value = val - 0.25f;
        }

        if(bounceStaminaBar.value < 1)
        {
            bar.SetActive(false);
            PlayerManager.instance.Die();
        }
    }

    public void addStamina(int stamina)
    {
        print("Adding");
        float val = bounceStaminaBar.value;
        bounceStaminaBar.value = val + stamina;
    }
}
