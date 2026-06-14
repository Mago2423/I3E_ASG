using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 1; //custimisable in unity to set how much score each collectable gives
    public void Collect()
    {
        var audio = GetComponent<AudioSource>(); //play audio
        audio.Play();

        var collider = GetComponent<CapsuleCollider>(); //disable collider
        collider.enabled = false;

        Destroy(gameObject, 2);
        var animator = GetComponent<Animator>(); //destroy game object after 2 seconds
       
        animator.SetTrigger("Fly"); //play animation
    }
}
