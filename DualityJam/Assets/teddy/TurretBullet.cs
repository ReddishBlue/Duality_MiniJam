using UnityEngine;
using UnityEngine.InputSystem;

public class TurretBullet : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public float speed = 5f;

    private Vector2 direction;

    InputAction attackAction;

    //public bool isCollided = false; //for testing

    private void Start() {
       // attackAction = InputSystem.actions.FindAction("Attack");
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("bullets collided");
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullets collided");
        Destroy(this.gameObject);
    }
    
    //When projectile goes offscreen destroy it
    void OnBecameInvisible() 
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);
    }

}
