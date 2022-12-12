using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Characters : MonoBehaviour
{
    private Touch touch;
    Rigidbody physics;
    public float speed;
    Animator animator;
    public GameObject cover;
    static int charactercounter = 0;
    string levelname;
    static int charactersnumber = 0;
    static int fallingcharacters = 0;



    void Start()
    {
        fallingcharacters = 0;
        charactersnumber = 0;
        charactercounter = 0;
        physics = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -75, 0);
        physics.velocity = transform.forward * speed;
        foreach (Transform child in cover.transform)
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + touch.deltaPosition.x * 0.01f, -7, 22),
                    transform.position.y,
                    transform.position.z
                );
            }
        }
        transform.position += new Vector3(0, 0, Time.deltaTime * speed);
        if (charactersnumber > 1 && fallingcharacters > 1)
        {
            if (charactersnumber <= fallingcharacters)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "forbiddencube")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (col.gameObject.tag == "gameover")
        {
            fallingcharacters++;
            Debug.Log("Düşen Karakter sayisi : " + fallingcharacters);
        }
        if (col.gameObject.tag == "reset")
        {
            foreach (Transform child in cover.transform)
            {
                child.GetComponent<MeshRenderer>().enabled = false;
                child.GetComponent<MeshCollider>().isTrigger = true;
            }
            charactercounter = 0;
        }
        if (col.CompareTag("Number15"))
        {
            charactercounter++;
            if (charactercounter == 15)
            {
                col.gameObject.SetActive(true);
                foreach (Transform child in cover.transform)
                {
                    child.GetComponent<MeshCollider>().isTrigger = false;
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        if (col.CompareTag("Number10"))
        {
            charactercounter++;
            if (charactercounter == 10)
            {
                col.gameObject.SetActive(true);
                foreach (Transform child in cover.transform)
                {
                    child.GetComponent<MeshCollider>().isTrigger = false;
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        if (col.CompareTag("Number5"))
        {
            charactercounter++;
            if (charactercounter == 5)
            {
                col.gameObject.SetActive(true);
                foreach (Transform child in cover.transform)
                {
                    child.GetComponent<MeshCollider>().isTrigger = false;
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        if (col.CompareTag("Number25"))
        {
            charactercounter++;


            if (charactercounter == 25)
            {
                col.gameObject.SetActive(true);
                foreach (Transform child in cover.transform)
                {
                    child.GetComponent<MeshCollider>().isTrigger = false;
                    child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        if (col.gameObject.tag == "control")
        {
            charactersnumber++;
            Debug.Log("Karakter sayisi : " + charactersnumber);
        }
    }
}
