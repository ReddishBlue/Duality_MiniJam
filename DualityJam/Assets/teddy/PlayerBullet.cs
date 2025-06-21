using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private int collision count = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionCount >= 5) {
            Destroy(gameObject);
        }
        else {
            collision++;
        }
    }
}
