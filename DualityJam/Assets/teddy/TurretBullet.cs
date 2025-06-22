using UnityEngine;
using UnityEngine.InputSystem;

public class TurretBullet : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    public float speed = 20f;

    private Vector2 direction;

    InputAction attackAction;

    //public bool isCollided = false; //for testing

    private void Start() {
        attackAction = InputSystem.actions.FindAction("Attack");
        bulletRB = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 dir){
        this.direction = dir;
        bulletRB.linearVelocity = this.direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
    
    //When projectile goes offscreen destroy it
    void OnBecameInvisible() 
    {
        Destroy(this.gameObject);
    }

    // private void Update()
    // {

    //     Vector2 dir = new Vector2(1f, 0.0f);

    //     if (attackAction.IsPressed())
    //     {
    //         Shoot(dir);
    //     }
    // }

}
