using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facePlayer : MonoBehaviour
{
    public Rigidbody ghost;
    public Rigidbody player;

void LateUpdate(){
     ghost.MoveRotation(
        Quaternion.Slerp(
            ghost.transform.rotation, 
            Quaternion.LookRotation(ghost.transform.position -  player.transform.position), 
            0.5f
        )
    ); 
}
void Update(){
    if (transform.position.y < 0) Destroy(gameObject);
}
}
// bool time = true;
// float xRandom = 0;
// float zRandom = 0;
// void FixedUpdate(){
//     if (time){
//         xRandom = forkliftMovement.level;
//         if (xRandom < 0) zRandom = Random.Range(Random(),0);
//         time = false;
//     } 
//     ghost.velocity = new Vector3(0,0,zRandom);
// }