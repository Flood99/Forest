using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    



    public void EndGame()
    {
        gameOver = true;
        StartCoroutine(EndTimer());
        Debug.Log("End");
    }
    IEnumerator EndTimer()
    {
        Scene scene = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene.name);
        
           
    }
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
