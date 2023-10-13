using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawnLocation;
    Vector3 randomSpawn;
    GameObject clonedEnemy;
    float level;
    public GameObject character;
    float boundryX = 0.3f;
    float boundryZ = 0.3f;

    void Start(){
        clonedEnemy = enemy;
    }
public void SpawnPlayer(GameObject ghost)
{
            level = forkliftMovement.level;
            float distanceSpawn = level;
            if (distanceSpawn > 4) distanceSpawn = 4;
            float movementSpawn = (Mathf.Lerp(1,5,level/12))*forkliftMovement.moveX/(level);
            
            Vector3 characterLoc = character.transform.position;
            float randomZ = Random.Range(-4.0f, -1.0f);
            float triangle = randomZ/2;
            float randomX = Random.Range(characterLoc.x - triangle, characterLoc.x + triangle);


            Vector3 randomized = new Vector3(
                randomX - movementSpawn,
                0.05f,
                characterLoc.z + randomZ + 0.5f - level/2.5f
            );

            Instantiate(ghost, randomized, clonedEnemy.transform.rotation);
}
float time;

void Update()
{
    time += Time.deltaTime;
    if (time > 0.03){
      SpawnPlayer(clonedEnemy);
      time = 0;
    }
}

}
