using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth; 
    public int currentHealth; 
    void Start()
    {
        currentHealth = maxHealth;
        DontDestroyOnLoad(this.gameObject);
    }
}

