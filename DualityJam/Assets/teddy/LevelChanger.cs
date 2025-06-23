using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public string nextScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void  OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene(nextScene);
        //Debug.Log("collided with door!");
        if (other.gameObject.tag == "Player"){
            int sceneID = SceneManager.GetActiveScene().buildIndex;

            if (sceneID + 1 < SceneManager.sceneCountInBuildSettings){
                SceneManager.LoadScene(sceneID + 1);
                Debug.Log("scene loaded!");
            }

        }
    
    }
}
