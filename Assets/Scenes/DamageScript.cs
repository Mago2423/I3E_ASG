using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 10;
    int time = 100;
    CollisionDetector player;
    bool isTriggered = false;
    public UIManagerScript UIManagerScript;


    void OnTriggerStay(Collider collision)
    {
        if (!isTriggered) return;
        
        player = collision.gameObject.GetComponent<CollisionDetector>();
        if (player == null) return;
        
        time -= 1;
        if (time <= 0)
        {
            var audio = GetComponent<AudioSource>();
            audio.Play();
            print($"Player took {damageAmount} damage");
            player.health -= damageAmount;
            UIManagerScript.UpdateHealth(player.health);
            time = 100;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter(Collider collision)
    {
        isTriggered = true;
        player = collision.gameObject.GetComponent<CollisionDetector>();
        var audio = GetComponent<AudioSource>();
        audio.Play();
        print($"Player took {damageAmount} damage");
        player.health -= damageAmount;
        UIManagerScript.UpdateHealth(player.health);
    }
    void OnTriggerExit(Collider collision)
    {
        isTriggered = false;
    }
}

