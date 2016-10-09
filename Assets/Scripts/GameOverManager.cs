using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    Animator anim;
    public bool isGameOver = false;
    
    private LevelLoader levelLoader;
    private int restartDelay = 2;
    float restartTimer = 0;


    void Awake()
    {
        anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
        levelLoader = GameObject.Find("_GM").GetComponent<LevelLoader>();
    }

    void Update ()
    {   
        // If the player has run out of health...
        if(isGameOver)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger ("GameOver");            
            
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;
            
            // .. if it reaches the restart delay...
            if(restartTimer >= restartDelay)
            {
                levelLoader.LoadScene(0);
            }
            
            Debug.Log(restartTimer);
        }
    }


    public static void GameOverScreen ()
    {
        // ... tell the animator the game is over.
        GameObject.Find("_GM").GetComponent <GameOverManager> ().isGameOver = true;
    }
}