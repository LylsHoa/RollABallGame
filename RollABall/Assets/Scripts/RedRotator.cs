using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRotator : MonoBehaviour
{
    void Update()
    {
        //Make Y negative to rotate the other way 
        transform.Rotate(new Vector3(15, -30, 45 ) * Time.deltaTime);
    }

}
