using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score = 1;
    public void Collect()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();

        var collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;

        Destroy(gameObject, 2);
        var animator = GetComponent<Animator>();
       
        animator.SetTrigger("Fly");
    }
}
