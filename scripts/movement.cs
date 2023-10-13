using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class forkliftMovement : MonoBehaviour
{
        // Start is called before the first frame update
    public GameObject forkLiftMovement;
    Rigidbody forkliftRigid;
    public GameObject plane;
    Vector3 planeVectorStart;
    Vector3 playerStart;

    // Update is called once per frame
    float xLimit = 10f;
    float yLimit = 10f;
    float currentPointX = 0;
    float currentPointY = 0;
    bool changePoint = false;
    public static float moveX = 0;
    public static float moveY = 0;
    public static Vector3 forkliftVelocity;
    float speedDevider = 1;
    public BoxCollider playerCollider;
    Vector3 playerColliderVector;
    float originalCollderX;

    
    
void Start(){
    forkliftRigid = forkLiftMovement.GetComponent<Rigidbody>();
    forkliftVelocity.z = 1.0f;
    planeVectorStart = plane.transform.position;
    playerStart = forkliftRigid.transform.position;
    if (Screen.width > Screen.height) speedDevider = Screen.width; else speedDevider = Screen.height;
    playerColliderVector = playerCollider.size;
}
float count;
void OnTriggerEnter(Collider collision){
    if (collision.gameObject.tag == "ghost" ){
        timer.boxOut = true;
    }

}
    public static float level = 1;
    float oldLevel = 0;
    float changeLevelTime = 0;
    void FixedUpdate(){

if (Input.touchCount > 0) {
	Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
	if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) 
	{
        if (changePoint == false) {
            currentPointX = touch.position.x;
            currentPointY = touch.position.y;
            }
        moveX = Mathf.Clamp(15f*(touch.position.x - currentPointX)/speedDevider, -xLimit,xLimit); 
        moveY = Mathf.Clamp(50f*(touch.position.y - currentPointY)/speedDevider, -yLimit,yLimit); 
        if (Mathf.Abs(moveY) > 1f && level == oldLevel && Mathf.Abs(moveY) > 3.0f && changeLevelTime < 1.0f){
            level += Mathf.Sign(moveY);
            if (level < 1) level = 1;
            if (level > 12) level = 12;
            forkliftVelocity.z = level;
            playerCollider.size = new Vector3(
                1/(30 + 20*level) ,
                playerColliderVector.y,
                playerColliderVector.z
                );
        }
        changeLevelTime += Time.deltaTime;
        changePoint = true;
	}
} else {
    changePoint = false;
    moveX = Mathf.MoveTowards(moveX,0, 0.1f);
    oldLevel = level;
    changeLevelTime = 0;
}   
        forkliftRigid.velocity = new Vector3(
            -moveX,
            0,
            -forkliftVelocity.z
            );
        plane.transform.position = new Vector3(
            forkliftRigid.transform.position.x,
            0,
            forkliftRigid.transform.position.z - 4f
            ); 
    
    if (forkliftRigid.transform.position.z < -10000.0f || Mathf.Abs(forkliftRigid.transform.position.z) > 10000.0f){
        forkliftRigid.transform.position = playerStart;
        plane.transform.position = planeVectorStart;
    }

    }

}
