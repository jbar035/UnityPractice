using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainEngineThrust = 100f;
    Rigidbody rigidBody;
    AudioSource rocketSound;

    enum State { Alive, Dying, Transcending };
    State state = State.Alive;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {
        if (state == State.Alive) {
            Rotate();
            Thrust();            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }

        switch (collision.gameObject.tag){
            case "Friendly":
                //do nothing
                break;
            case "Finish":
                //win level
                state = State.Transcending;
                Invoke("LoadNextScene", 1f);
                break;
            default:
                state = State.Dying;
                Invoke("LoadFirstScene", 1f);
                break;
        }
    }

    private static void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    private static void LoadNextScene()
    {
        SceneManager.LoadScene(1);
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
