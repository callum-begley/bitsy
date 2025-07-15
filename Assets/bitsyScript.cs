using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitsyScript : MonoBehaviour
{
    public float moveSpeed = 30f;
    public Camera followCamera;
    public float cameraFollowSpeed = 2f;
    public Vector3 cameraOffset = new Vector3(0, 0, -10);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Move left
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            // Flip character to face left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Move right
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            // Flip character to face right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        // Camera follow
        if (followCamera != null)
        {
            Vector3 targetPosition = transform.position + cameraOffset;
            followCamera.transform.position = Vector3.Lerp(followCamera.transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        }
    }
}
