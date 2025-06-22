using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBullet : MonoBehaviour
{
    private int bulletHP = 5;
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
        Shoot(newVelocity.normalized);

        //isCollided = true; //for testing
    
    }

    private void Update() {

        Vector2 dir = new Vector2(1f, 0.0f);

        if (attackAction.IsPressed()){
            Shoot(dir);
        }
    }

    // private void Update()
    // {
        
    //     //just to test it out
    //     // if(!isCollided){
    //     //     Vector2 dir = new Vector2(1f, 0.0f);
    //     //     Shoot(dir.normalized);
    //     // }
        
       
    // }
}
