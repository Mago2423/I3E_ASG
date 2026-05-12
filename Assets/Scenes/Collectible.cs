using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 1;
    public void Collect()
    {

        Destroy(gameObject);
    }
}
