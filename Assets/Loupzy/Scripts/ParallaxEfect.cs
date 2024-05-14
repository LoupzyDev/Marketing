using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour
{
    Transform cameraTransform;
    Vector3 previousCameraPosition;
    [SerializeField] private float speedMultiplier = 0.5f;
    private float spriteWidth,startPosition;

    private void Start() {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    private void LateUpdate() {
        float deltaX = (cameraTransform.position.x-previousCameraPosition.x) * speedMultiplier;
        float moveAmout = cameraTransform.position.x * (1 - speedMultiplier);
        transform.Translate(new Vector3(deltaX,0,0));
        previousCameraPosition=cameraTransform.position;

        if (moveAmout > startPosition + spriteWidth) {
            transform.Translate(new Vector3(spriteWidth,0,0));
            startPosition += spriteWidth;
        } 
        else if(moveAmout < startPosition - spriteWidth) {
            transform.Translate(new Vector3(-spriteWidth,0,0));
            startPosition -= spriteWidth;
        }
    }
}
