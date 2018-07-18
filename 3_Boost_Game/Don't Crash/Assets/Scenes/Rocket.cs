using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainEngineThrust = 100f;
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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag){
            case "Friendly":
                //do nothing
                print("Friendly");
                break;
            case "Fuel":
                //add fuel
                print("Collected fuel!");
                break;
            case "Finish":
                //win level
                print("Level complete!");
                break;
            default:
                print("Game over");
                break;
        }
    }

    private void Rotate(){
        rigidBody.freezeRotation = true; // take manual control of rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false; // resume physics control of rotation
    }

    private void Thrust()
    {
        float thrustThisFrame = mainEngineThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) //can thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }

        }
        else rocketSound.Stop();
    }
}
