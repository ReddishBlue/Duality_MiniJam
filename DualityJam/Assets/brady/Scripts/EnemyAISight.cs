using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAISight : MonoBehaviour
{
    public float radius;
    public float angle;
    //layers with objects we want to see
    public LayerMask objectsLayers;
    //layers that have objects that will block our view
    public LayerMask obstaclesLayers;
    public Collider2D detectedObject;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius, objectsLayers);

        detectedObject = null;
        for(int i=0;i<colliders.Length;i++)
        {
            Collider2D collider = colliders[i];
            Vector3 directionToController = Vector3.Normalize(collider.bounds.center - transform.position);
            float angleToCollider = Vector3.Angle(transform.up,directionToController);

            if(angleToCollider < angle)
            {
                RaycastHit2D result = Physics2D.Linecast(transform.position, collider.bounds.center, obstaclesLayers);

                if(!result)
                {
                    Debug.DrawLine(transform.position,collider.bounds.center,Color.green);
                    detectedObject = collider;
                    break;
                }
                else
                {
                    Debug.DrawLine(transform.position,result.point,Color.red);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.red;
        Vector3 rightDirection = Quaternion.Euler(0,0,angle)*transform.up;
        Gizmos.DrawRay(transform.position,rightDirection*radius);
        Vector3 leftDirection = Quaternion.Euler(0,0,-angle)*transform.up;
        Gizmos.DrawRay(transform.position,leftDirection*radius);
    }
}
