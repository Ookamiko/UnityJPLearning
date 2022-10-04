using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    private InterfaceScript interfaceScript;

    private bool isOnGround = true;
    private bool isGameOver = false;
    private bool canDoubleJump = true;
    private bool isRunning = false;
    private DateTime startRunning;

    private readonly float offsetRunningPoint = 0.5f;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSFX;
    public AudioClip crashSFX;

    public float jumpAmplifier = 10.0f;
    public float gravityModifier = 1.0f;

    public bool IsGameOver { get { return isGameOver; } }

    public bool IsRunning { get { return isRunning && (DateTime.Now - startRunning).TotalSeconds > offsetRunningPoint; } }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        interfaceScript = GameObject.Find("Interface").GetComponent<InterfaceScript>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || canDoubleJump) && !isGameOver)
        {
            playerAudioSource.PlayOneShot(jumpSFX);
            playerRb.AddForce(Vector3.up * jumpAmplifier, ForceMode.Impulse);
            dirtParticle.Stop();

            if (isOnGround)
            {
                playerAnim.SetTrigger("Jump_trig");
                isOnGround = false;
            } else if (canDoubleJump)
            {
                canDoubleJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            startRunning = DateTime.Now;
            playerAnim.SetFloat("RunMultiplier_f", 1.5f);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            playerAnim.SetFloat("RunMultiplier_f", 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            isOnGround = true;
            canDoubleJump = true;
            dirtParticle.Play();
        } else if (collision.gameObject.tag.Equals("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudioSource.PlayOneShot(crashSFX);
            dirtParticle.Stop();

            interfaceScript.DisplayGameOver();

            isGameOver = true;
        }
    }
}
