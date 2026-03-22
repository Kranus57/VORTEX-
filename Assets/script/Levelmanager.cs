using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float levelDuration = 10f; 
    public GameObject mothershipPrefab;
    public Transform spawnPoint;

    private bool levelEnding = false;

    void Update()
    {
        if (!levelEnding)
        {
            levelDuration -= Time.deltaTime;

            if (levelDuration <= 0)
            {
                ExecuteLevelEnd();
                levelEnding = true;
            }
        }
    }

    void ExecuteLevelEnd()
    {
        Debug.Log("!!! LEVEL END TRIGGERED !!!");

        // 1. FORCE STOP BACKGROUND
        QuadScroll.canScroll = false; 

        // 2. FORCE STOP SPAWNER
        // We look for any object named "Spawner" or "spawner"
        GameObject spawner = GameObject.Find("Spawner");
        if (spawner == null) spawner = GameObject.Find("spawner");

        if (spawner != null)
        {
            spawner.SetActive(false);
            Debug.Log("Spawner found and deactivated.");
        }
        else
        {
            Debug.LogError("COULD NOT FIND SPAWNER. Check the name in Hierarchy!");
        }

        // 3. CLEAR ALL ROCKS
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obs in obstacles)
        {
            Destroy(obs);
        }

        // 4. SPAWN MOTHERSHIP
        if (mothershipPrefab != null && spawnPoint != null)
        {
            Instantiate(mothershipPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}