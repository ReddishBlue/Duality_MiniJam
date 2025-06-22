using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){

        Debug.Log("collided with door!");
        if (other.gameObject.tag == "Player"){
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            

            if (SceneManager.GetSceneByBuildIndex(sceneID + 1).IsValid()){
                SceneManager.LoadScene(sceneID + 1);
                Debug.Log("scene loaded!");
            }

        }
    
    }
}
