using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public TextMeshProUGUI skorText;
    public int skor;
    public float jumpForce;
    public GameObject splashPrefab;
    // Start is called before the first frame update
    void Start()
    {
       skorReset();
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject x = Instantiate(splashPrefab, transform.position + new Vector3(0f,-.2f,0f), transform.rotation);
        x.transform.SetParent(collision.gameObject.transform);
        rb.AddForce(Vector3.up * jumpForce);
        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;

        if (collision.gameObject.tag == "Safe") 
        {
            skor += 10;
            skorText.text = skor.ToString();
        }
       else if(collision.gameObject.tag == "Danger") 
        {
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            //Sonraki Level
        }
    }

    public void skorReset() 
    {
        skor = 0;
        skorText.text = skor.ToString();
    }
}
