using Maze; // Namespace Maze
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Singleton pattern
	private static GameController instance;
    // Maze generation
    private MazeGenerator generator;

    // Maze size
    public int columns = 5;
    public int rows = 5;

    // Room size, afects walls and floor
    
    public float roomSize = 5.0f;

    // Number of monsters
    public int numberOfMonsters;

    // Game objects
    public GameObject wallPrefab = null;
    public GameObject floorPrefab = null;
    public GameObject monsterPrefab = null;

    // Monster container for clear hierarchy 
    private GameObject monstersContainer;

    private readonly string MONSTERS = "monsters";
    private readonly string MONSTER = "monster";

    /** This section will disapear, it's just for the assignment II **/
    // Event for shake B objects
    public delegate void ShakeManager();
    public static ShakeManager shakeEvent;
    /** This section will disapear, it's just for the assignment II **/

    // Use this for initialization
    void Awake () {
        if (instance == null) 
			instance = this;
		else if (instance != this) // If it's not this, destroy it
			Destroy(gameObject);
    }

    private void Start() {
        if (roomSize < 2.5f)
            throw new UnityException("room size is too small");

        generator = new MazeGenerator(columns, rows);
        generator.BuildInUnity(floorPrefab, wallPrefab, roomSize);
        monstersContainer = new GameObject();
        InitContainer();
        // After 10 seconds, the game will spawn a monster every min
        StartCoroutine(Spawn(10.0f, 60.0f));
    }

    private void InitContainer() {
        monstersContainer.transform.position = new Vector3();
        monstersContainer.name = MONSTERS;
    }

    private IEnumerator Spawn(float waitBeforeSpawn, float repeatInterval) {
        yield return new WaitForSeconds(waitBeforeSpawn);
        int i = 0;
        while (i <= numberOfMonsters) {
            // Position of the last cell + the middle of the cell, so it spawn in center
            float x = (columns - 1) * roomSize + roomSize / 2;
            float z = (rows - 1) * roomSize + roomSize / 2;
            Vector3 position = new Vector3(x, floorPrefab.transform.localScale.y + monsterPrefab.transform.localScale.y / 2, -z);
            GameObject monster = GameObject.Instantiate(monsterPrefab, position, Quaternion.identity, monstersContainer.transform);
            monster.name = MONSTER + "_" + i;
            i++;
            yield return new WaitForSeconds(repeatInterval);
        }
    }

    /** This section will disapear, it's just for the assignment II **/
    public static void Shake() {
        shakeEvent();
    }
    /** This section will disapear, it's just for the assignment II **/
}
