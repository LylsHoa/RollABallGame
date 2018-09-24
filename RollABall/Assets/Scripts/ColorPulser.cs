using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPulser : MonoBehaviour {


    private Color startingColor;

	// Use this for initialization
	void Start ()
    {
        //Grabbing starting color from object
        startingColor = GetComponent<Renderer>().material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (SaveLoadData.Instance.timer >= 80)
        {
            //Makes t go back and forth 0 - 1
            float alpha = Mathf.PingPong(Time.time, 1);

            //Gets the component from the game object
            //Lerp/Tween (start,end,t) t=0-1 0=start 1=end
            GetComponent<Renderer>().material.color = Color.Lerp(startingColor, Color.white, alpha);
        }
    }
            
}
