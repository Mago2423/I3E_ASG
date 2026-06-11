using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount = 10;
    public UIManagerScript UIManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<CollisionDetector>();
        if (player != null)
        {
            var audio = GetComponent<AudioSource>();
            audio.Play();
            print($"Player took {damageAmount} damage");
            player.Health -= damageAmount;
            UIManagerScript.UpdateHealth(player.Health);

            int health = player.Health;
            if (health <= 0)
            {
                print("Game Over");
                health = 0;
                UIManagerScript.UpdateHealth(health);
                UIManagerScript.Gameover();
            }
        }
    }
}
