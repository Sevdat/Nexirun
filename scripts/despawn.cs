using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    public GameObject mainGhost;
    public GameObject mainGhostLocation;
void OnTriggerEnter(Collider collision){
    if (collision.gameObject.tag == "ghost" && collision.gameObject.name != "ghost" ){
        Destroy(collision.gameObject);
    }

}
void Update(){
     mainGhost.transform.position = mainGhostLocation.transform.position;
}
}
