using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton Instance;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

}
