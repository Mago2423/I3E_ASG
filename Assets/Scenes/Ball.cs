using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject currentBall;
    public void MoveBall()
    {
        if(currentBall != null)
        {
            float magnitude = 500f;
            currentBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * magnitude);
        }
    }
}
