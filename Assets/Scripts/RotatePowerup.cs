
using UnityEngine;


public class RotatePowerup : MonoBehaviour
{
    private float rotationSpeed;



    private void Start()
    {
        rotationSpeed = 50f;
    }


    private void Update()
    {
        //transform.Rotate(0f, 2f, 0f);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }


} // end of class
