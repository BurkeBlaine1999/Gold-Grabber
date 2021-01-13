using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraPlayer2 : MonoBehaviour
{
    public Transform player;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;   
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0,10,10);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player 2").transform;
        startOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        moveVector = player.position + startOffset;

        moveVector.x = 7;

        // moveVector.y = Mathf.Clamp(moveVector.y,30,10);

        if(transition > 1.0f){
            transform.position = moveVector;
        }
        else{
            //Animation at start of game.
            transform.position = Vector3.Lerp(moveVector + animationOffset,moveVector,transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(player.position + Vector3.up);
        }

        
    }

}
