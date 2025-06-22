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

    private void OnTriggerEnter2D(Collider2D other){
        int sceneID = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetSceneByBuildIndex(sceneID + 1).IsValid()){
            SceneManager.LoadScene(sceneID + 1);
        }
    
    }
}
