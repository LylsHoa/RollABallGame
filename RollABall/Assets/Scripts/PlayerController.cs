using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //PUBLIC
    public float speed;
    public Text countText;
    public Text winText;
    //PRIVATE
    private Rigidbody rb;
    private int count; 
    

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    //

    void OnTriggerEnter(Collider other)
    {
        //If the player touches a "Pick Up" object aka- the blocks, then it's active setting will turn off. 
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {

        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winText.text = "You Win!";
        }

    }
   

}
//Below templates
//Destroy(other.gameObject);
//if (other.gameObject.CompareTag("Player"))
    //gameObject.SetActive(false);