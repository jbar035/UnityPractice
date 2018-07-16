using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource rocketSound;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {
        Rotate();
        Thrust();
    }

    private void Rotate(){
        rigidBody.freezeRotation = true; // take manual control of rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }

        }
        else rocketSound.Stop();
    }
}
