using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    private int bulletHP = 5;
    public Rigidbody2D bulletRB;
    public float speed = 5f;

    private Vector2 direction;

    InputAction attackAction;

    //public bool isCollided = false; //for testing

    private void Start() {
        attackAction = InputSystem.actions.FindAction("Attack");
        bulletRB = gameObject.GetComponent<Rigidbody2D>();
      
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bulletHP--; 

        if (other.gameObject.tag == "Player") //TODO: fix tag as needed
        {
            Destroy(this.gameObject);
        }
        else if (bulletHP < 0) {
            Destroy(this.gameObject);
            return;
        } 

        Vector2 newVelocity = Vector2.Reflect(direction.normalized, other.contacts[0].normal);
      
        speed = -speed;

        //isCollided = true; //for testing
    
    }
    
    //When projectile goes offscreen destroy it
    void OnBecameInvisible() 
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
        
    }
}
