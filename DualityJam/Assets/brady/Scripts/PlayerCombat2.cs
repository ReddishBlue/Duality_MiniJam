// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class PlayerCombat2 : MonoBehaviour
// {
//     public GameObject sword;
//
//     public bool isSlashing = false;
//     private CapsuleCollider2D swordCollider;
//     private bool isImmune = false;
//     
//     public int damageToTake = 20; 
//     private PlayerHealth playerHealth; 
//     public TrailRenderer trailRenderer;
//     public GameObject swordTrail;
//     public float swingSpeed = .2f;
//     public float angleoffset;
//     public GameObject respawner;
//     private Respawner scripty;
//
//     void Awake() {
//         playerHealth = gameObject.GetComponent<PlayerHealth>(); 
//         
//         swordCollider = sword.GetComponentInChildren<CapsuleCollider2D>();
//         trailRenderer = swordTrail.GetComponent<TrailRenderer>();
//         scripty = respawner.GetComponent<Respawner>();
//     }
//
//     void FixedUpdate()
//     {
//         if(!isSlashing)
//         {
//             SwordTrackMouse();
//         }
//     }
//
//     private void SwordTrackMouse()
//     {
//         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         // Calculate direction vector from prefab to mouse
//         Vector3 direction = mousePosition - sword.transform.position;
//         // Set rotation to face the mouse (only rotate on the Z-axis in 2D)
//         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ; //offset by 90 to align with y
//         // +53.34f
//         sword.transform.rotation = Quaternion.Euler(0, 0, angle);
//         Debug.DrawLine(sword.transform.position,mousePosition,Color.white,Time.deltaTime);
//
//     }
//
//     //TODO: Implement OnSlash() event using Swing() coroutine
//     public void OnAttack() {
//         if(!isSlashing) {
//             isSlashing = true;
//             StartCoroutine(Swing(swingSpeed));
//         }
//     }
//
//     private IEnumerator Swing(float time)
//     {
//         
//         float elapsedTime = 0.0f;
//         swordCollider.enabled = true;
//         trailRenderer.emitting = true;
//         Quaternion startingRotation = sword.transform.rotation;
//         Quaternion targetRotation =  Quaternion.Euler ( new Vector3 ( 0.0f, 0.0f, sword.transform.eulerAngles.z + 100f ) );
//         
//         while (elapsedTime < time) {
//             elapsedTime += Time.deltaTime;
//             // Rotations
//             sword.transform.rotation = Quaternion.Lerp(startingRotation, targetRotation,  elapsedTime / time  );
//             // swordTrail.transform.localRotation = Quaternion.Lerp(startingTrailRotation, targetRotation,  elapsedTime / time  );
//             yield return new WaitForEndOfFrame();
//         }
//         //reset everything back for next time
//
//         elapsedTime = 0;
//
//         yield return new WaitForSeconds(0.2f);
//         
//         trailRenderer.emitting = false;
//         sword.transform.rotation = startingRotation;
//         // swordTrail.transform.localRotation = startingTrailRotation;
//         isSlashing = false;
//         swordCollider.enabled = false;
//         
//     }
//
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         Debug.Log(playerHealth.currentHealth);
//         if (other.gameObject.tag == "Enemy")
//         {
//             playerHealth.TakeDamage(damageToTake);
//             
//             // playerHealth.currentHealth -= damageToTake;
//             if(playerHealth.CheckDeath())
//             {
//                 scripty.RespawnPlayer();
//                 
//                 Destroy(this.gameObject);
//                 
//             }
//         }
//     }
// }
