using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Safe") 
        {
            rb.AddForce(Vector3.up * jumpForce);
           
        }
       else if(collision.gameObject.tag == "Danger") 
        {
            SceneManager.LoadScene(0);
        }
    }
}
