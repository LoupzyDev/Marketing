using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarController : MonoBehaviour {
    public float speed;
    public float carSpeed;
    public float inputMove;
    public Rigidbody2D tireFront;
    public Rigidbody2D tireBack;
    public Rigidbody2D carRb2d;

    private int direction;

    [SerializeField] private ParticleSystem particles;

    private void Update() {
        GetInput();
        HandleParticles();
    }

    private void FixedUpdate() {
        MoveLogic();
        MoveMobile();
    }

    void GetInput() {
        inputMove = Input.GetAxis("Horizontal");
    }

    void MoveLogic() {
        tireFront.AddTorque(-inputMove * speed * Time.fixedDeltaTime);
        tireBack.AddTorque(-inputMove * speed * Time.fixedDeltaTime);
        carRb2d.AddTorque(-inputMove * carSpeed * Time.fixedDeltaTime);
    }

    void MoveMobile() {
        tireFront.AddTorque(direction * speed * Time.deltaTime);
        tireBack.AddTorque(direction * speed * Time.deltaTime);
        carRb2d.AddTorque(direction * carSpeed * Time.deltaTime);
    }

    public void CarInputMobile(int dir) {
        direction = dir;
    }

    void HandleParticles() {
        if (inputMove != 0 || direction != 0) {
            particles.Play();
        } else {
            if (particles.isPlaying) {
                particles.Stop();
            }
        }
    }
}
