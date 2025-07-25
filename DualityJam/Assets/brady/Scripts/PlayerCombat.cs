using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject spawnPoint;
    
    public int damageToTake = 1; 
    private PlayerHealth playerHealth;
    public GameObject gun;
    
    private void FixedUpdate()
    {
        GunTrackMouse();

    }

    void Awake() {
        // playerHealth = gameObject.GetComponent<PlayerHealth>(); 
        playerHealth = GameObject.FindGameObjectWithTag("Saved Info").GetComponent<PlayerHealth>();   
    }
    public void OnFire()
    {
        if (projectilePrefab == null) {
            Debug.LogError("No projectile prefab!");
        }
        
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (this.gameObject.tag == "Player" && (other.gameObject.tag == "Enemy Attack" || other.gameObject.tag == "Player Attack"))
        {
            playerHealth.currentHealth -= damageToTake;
            Destroy(other.gameObject);
            if (playerHealth.currentHealth <= 0)
            {
                playerHealth.currentHealth = playerHealth.maxHealth;
                SceneManager.LoadScene("restart");
                Destroy(this.gameObject);
            }
        }
    
    }
    
    
    private void GunTrackMouse()
     {
         float angle = AngleToCursor();
         // Debug.Log(angle);
         gun.transform.rotation = Quaternion.Euler(0, 0, angle);
         

     }
    
    private float AngleToCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Calculate direction vector from prefab to mouse
        Vector3 direction = mousePosition - gun.transform.position;
        // Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        Debug.DrawLine(gun.transform.position,mousePosition,Color.white,Time.deltaTime);
        return angle;
    }

}
