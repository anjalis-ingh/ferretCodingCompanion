using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    AudioSource audioSource;
    Rigidbody2D rb2D;
    float x, y; 
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        rb2D.velocity = new Vector2(x, rb2D.velocity.y);

        y = Input.GetAxis("Vertical") * speed;
        rb2D.velocity = new Vector2(rb2D.velocity.x, y);

        if (rb2D.velocity.x != 0 || rb2D.velocity.y != 0) {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
        else {
            audioSource.Stop();
        }
    }
}
