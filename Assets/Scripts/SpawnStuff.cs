using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class DeployableObject
{
    public int   minWait;
    public int   maxWait;
    public float[] heights;
    public GameObject[] prefabs;

    private float timeForNext;
    private System.Random randomizer;

    public DeployableObject()
    {
        randomizer = new System.Random ();
    }

    public void Initialize()
    {
        this.timeForNext = this.generateRandom (minWait, maxWait);
        // Debug.Log ("Generated random with min:" + this.minWait + " and max:" + this.maxWait + " = " + this.timeForNext);
    }

    public bool shoudDeploy()
    {
        if (this.timeForNext < 0) {
            this.deploy ();
            return true;
        }

        this.timeForNext -= Time.deltaTime;		
        return false;
    }

    private void deploy()
    {
        GameObject obj = this.prefabs[this.generateRandom(0, this.prefabs.Length - 1)];
        
        // New position is really just set by hand.
        int heightIndex = this.generateRandom (0, this.heights.Length);
        Vector3 position = new Vector3(Camera.main.transform.position.x + 12,
                                       Camera.main.transform.position.y + this.heights[heightIndex],
                                       0);

        this.timeForNext = this.generateRandom (this.minWait, this.maxWait);
        GameObject.Instantiate (obj, position, Quaternion.identity);

    }

    private int generateRandom(int minWait, int maxWait)
    {
        int number = this.randomizer.Next (minWait, maxWait);
        // Debug.Log ("random " + number);
        return number;
    }
}

public class SpawnStuff : MonoBehaviour {
    public float noDeployDeltaTime = 1.0f;

    public DeployableObject coins;
    public DeployableObject obstacles;
    public DeployableObject groundEnemies;
    public DeployableObject flyingEnemies;

    // Use this for initialization
    void Start () {
        coins.Initialize ();
        obstacles.Initialize ();
    }
    
    // Update is called once per frame
    void Update () {
        if (this.coins.shoudDeploy ()) return;
        if (this.obstacles.shoudDeploy()) return;
        if (this.groundEnemies.shoudDeploy()) return;
        if (this.flyingEnemies.shoudDeploy()) return;
    }
}





