using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 10;
    int time = 100;
    CollisionDetector player;
    bool isColliding = false;
    public UIManagerScript UIManagerScript;


    void OnCollisionStay(Collision collision)
    {
        if (!isColliding) return;
        
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

            if (player.health <= 0)
            {
                print("Game Over");
                UIManagerScript.Gameover();
            }
            time = 100;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        player = collision.gameObject.GetComponent<CollisionDetector>();
        var audio = GetComponent<AudioSource>();
        audio.Play();
        print($"Player took {damageAmount} damage");
        player.health -= damageAmount;
        UIManagerScript.UpdateHealth(player.health);
    }
    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
