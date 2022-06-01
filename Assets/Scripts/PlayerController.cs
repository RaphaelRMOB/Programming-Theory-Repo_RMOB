using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 10.0f;
    private float forwardInput;
    public float turnSpeed = 50.0f;
    private float horizontalInput;
    public bool gameOver;

    private AudioSource playerAudio;
    public AudioClip bounceSound;
    public AudioClip jumpSound;

    
    // Power Ups das Gemas.
    public bool haspowerUp = false;
    public bool hasSpeed = false;    
    public int boostDuration = 3;
    public bool isOnGround = true;
    public ParticleSystem dirtParticle;
    public GameObject powerupIndicator;
    private float jumpForce = 100.0f;
    public int powerUpStrenght = 30;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();

        

    }

    // Update is called once per frame
    void Update()
    {
        //Aqui � coletado os comandos do jogador.
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (gameOver == false)
        {
            // Aqui o CUBO anda pra frente ou para tras.
            transform.Translate(forwardInput * speed * Time.deltaTime * Vector3.forward);

            //Aqui o CUBO faz curvas.
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.51f, 0);


            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && haspowerUp && !gameOver)
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                //playerAnim.SetTrigger("Jump_trig");
                //dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                dirtParticle.Play();
                StartCoroutine(ParticleJump());

            }

            if (hasSpeed)
            { 
                speed = 50.0f;               
            }
            else
            {
                speed = 10.0f;
            }
        }

        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            haspowerUp = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());

            //Nota: Para a mensagem do debug aparecer, o Power Up precisa estar ativo.
            Debug.Log("Got Jump Power Up");


        }

        if (other.CompareTag("GSpeed"))
        {
            hasSpeed = true;

            Destroy(other.gameObject);
            StartCoroutine(GSpeedCountdownRoutine());

            //Nota: Para a mensagem do debug aparecer, o Power Up precisa estar ativo.
            Debug.Log("Got Speed Power Up");


        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        //Cria um contador(contando 7 segundos). depois seta o powerUp off. 
        yield return new WaitForSeconds(7);
        haspowerUp = false;
        powerupIndicator.SetActive(false);

    }

    IEnumerator GSpeedCountdownRoutine()
    {
        //Cria um contador(contando 7 segundos). depois seta o powerUp off. 
        yield return new WaitForSeconds(7);
        hasSpeed = false;
        
    }

    IEnumerator ParticleJump()
    {
        //Cria um contador(contando 7 segundos). depois seta o powerUp off. 
        yield return new WaitForSeconds(2);
        dirtParticle.Stop();

    }

    private void OnCollisionEnter(Collision collision)
    {

        


        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (haspowerUp)
            {
                //Criando uma variavel para coletar o RigidBody do inimigo.
                Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

                //Variavel contendo a dire��o para onde o inimigo ira ser lan�ado. No aso, para longe do Player.
                Vector3 alwayFromPlayer = collision.gameObject.transform.position - transform.position;

                //Vamos aplicar a for�a contra o inimigo.
                enemyRigidBody.AddForce(alwayFromPlayer * powerUpStrenght, ForceMode.Impulse);

                //Nota: Para a mensagem do debug aparecer, o Power Up precisa estar ativo.
                Debug.Log("Collided with " + collision.gameObject.name + " with power up set to " + haspowerUp);
            }else { 
            Debug.Log("Game Over");
            gameOver = true;
            }

        }
       
            //playerAnim.SetBool("Death_b", true);
            //playerAnim.SetInteger("DeathType_int", 1);
            //dirtParticle.Stop();
            //explosionParticle.Play();
            //playerAudio.PlayOneShot(crashSound, 1.0f);
       

        if (collision.gameObject.CompareTag("Ground"))
        {
            // qdo o CUBO pinger tocar o ch�o.
            playerAudio.PlayOneShot(bounceSound, 1.0f);
            isOnGround = true;

        }
    }

}
