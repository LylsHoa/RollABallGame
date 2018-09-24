using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//To use library 
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //PUBLIC
    public float speed;

    public Text scoreText;
    public Text pickupCountText;

    public Text winText;
    public Text resultText;
    public Text loseText;
    //This lets you pick which scene to load onto next
    public string nextSceneName;

    //PRIVATE
    private Rigidbody rb;
          //Total Score +/-
    private int score;
         //Amount of PickUps = 12 Only refers to Yellow
    private int pickUpTotal;
        //Amount Picked up = __
    private int pickUpCount;
    //The timer until scene transition
    private float transitionTimer;
    //The set value aka. amount of time (the 2secs; the pause)
    private float transitionGoalTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        score = 0;
        pickUpCount = 0;
        SetScoreText();
        // STARTS Empty = no text below v
        winText.text = "";
        loseText.text = "";
        resultText.text = "";

        transitionTimer = 0;
        transitionGoalTime = 0;

        //@Level Start; Timer = 0
        SaveLoadData.Instance.timer = 0;

        // Array [] List of 12 Pickups = last[11] Written to keep track of items if added on to or deleted (not 12)

        GameObject[] Pickups = GameObject.FindGameObjectsWithTag("Pick Up");

        //Lengths = amount of objects in list 
        pickUpTotal = Pickups.Length;
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

        GetComponent<Renderer>().material.color = new Color(transform.position.x, transform.position.y, transform.position.z);

        //Keeps track of timer.
        if (transitionGoalTime > 0)
        {
            //Time.delaTime updates the time everyframe
            transitionTimer += Time.deltaTime;

            //Once the Timer is over the set time (Goal time) then the new scene loads
            if (transitionTimer > transitionGoalTime)
            {
                SceneManager.LoadSceneAsync(nextSceneName);
                //Since the timer is always going to be > the goal from here on --> set it to 0 so the scene doesn't continuously load.
                transitionGoalTime = 0;
            }
        }

        if (SaveLoadData.Instance.timer >= 90)
        {
            loseText.text = "You Lose.";
            resultText.text = "You Finished with a Score of : " + SaveLoadData.Instance.Score;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If the player touches a "Pick Up" object aka- the blocks, then it's active setting will turn off. 
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            
            SaveLoadData.Instance.Score = SaveLoadData.Instance.Score + 1; 
           //score = score + 1;
            pickUpCount = pickUpCount + 1;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Red Pick Up"))
        {
            other.gameObject.SetActive(false);

            SaveLoadData.Instance.Score = SaveLoadData.Instance.Score - 1;
            //score = score - 1;
            SetScoreText();
        }

        if(other.gameObject.CompareTag("Blue Pick Up"))
        {
            other.gameObject.SetActive(false);

            SaveLoadData.Instance.Score = SaveLoadData.Instance.Score + 3;
            //score = score + 3;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Pink Pick Up"))
        {
            other.gameObject.SetActive(false);

            SaveLoadData.Instance.Score = SaveLoadData.Instance.Score - 3;
            //score = score - 3;
            SetScoreText();
        }


        if (other.gameObject.CompareTag("Obstacle"))
        {
            SaveLoadData.Instance.Score = SaveLoadData.Instance.Score - 1;
            //score = score - 1;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Out of Bounds"))
        {
            transform.position = new Vector3(4.5f, .5f, 6.5f);
        }
    }

    void SetScoreText()
    {
        //ToString = make this # text
        scoreText.text = "Score: " + SaveLoadData.Instance.Score.ToString();
        pickupCountText.text = "Pick Ups: " + pickUpCount.ToString();

        //As long as 12 items picked up(Yellow) = win
        if (pickUpCount >= pickUpTotal)
        {
            winText.text = "You Win!";

           
            resultText.text = "You Finished with a Score of : " + SaveLoadData.Instance.Score;

            // don't load anything (new scene) if left blank
           
            if (nextSceneName.Length > 0)
            {
                transitionGoalTime = 2;
            }
        }

    }  
}




//Below templates
//Destroy(other.gameObject);
//if (other.gameObject.CompareTag("Player"))
    //gameObject.SetActive(false);

    //Normally when a new scene loads, the playerController script gets destroyed and recreated, that's why the score resets