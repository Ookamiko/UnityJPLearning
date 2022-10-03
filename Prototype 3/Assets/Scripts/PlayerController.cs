using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;

    private bool isOnGround = true;
    private bool isGameOver = false;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSFX;
    public AudioClip crashSFX;

    public float jumpAmplifier = 10.0f;
    public float gravityModifier = 1.0f;

    public bool IsGameOver { get { return isGameOver; } }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerAudioSource.PlayOneShot(jumpSFX);
            playerRb.AddForce(Vector3.up * jumpAmplifier, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.tag.Equals("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudioSource.PlayOneShot(crashSFX);
            dirtParticle.Stop();
            Debug.Log("Game Over !");
            isGameOver = true;
        }
    }
}
