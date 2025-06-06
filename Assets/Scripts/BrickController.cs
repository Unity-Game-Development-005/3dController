
using UnityEngine;


public class BrickController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        if (collidingObject.gameObject.CompareTag("Puck"))
        {
            Destroy(gameObject);
        }
    }


} // end of class
