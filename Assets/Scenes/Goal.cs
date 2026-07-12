using UnityEngine;

public class Goal : MonoBehaviour

{
    public UIManagerScript UIManagerScript;
    int Score = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            Debug.Log("Goal!");
            Score++;
            UIManagerScript.UpdateScore(Score);
        }
    }
}
