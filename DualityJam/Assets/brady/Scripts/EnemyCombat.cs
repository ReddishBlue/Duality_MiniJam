using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject spawnPoint;
    public float enemyFireRate = 2f;
    public bool isOnCooldown = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Attack") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
    }

    public IEnumerator Fire() {
        isOnCooldown = true;
        Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        yield return new WaitForSeconds(enemyFireRate);
        isOnCooldown = false;
    }

}
