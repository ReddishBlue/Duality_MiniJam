using UnityEngine;
using TMPro;

public class HealthUIText : MonoBehaviour
{
    public TMP_Text healthText;
    public PlayerHealth playerHealth;
    void Awake()
    {
        ReferencePlayerHealth();
    }

    void Start()
    {
        healthText.text = "Health: " + "?" + "/" + "?"; 
    }

    void Update()
    {
        healthText.text = "Health: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
    }

    public void ReferencePlayerHealth() {
        playerHealth = GameObject.FindGameObjectWithTag("Saved Info").GetComponent<PlayerHealth>();   
    }

}

