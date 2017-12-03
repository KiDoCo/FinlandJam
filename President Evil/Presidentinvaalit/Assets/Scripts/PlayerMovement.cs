using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    RaycastHit hit;
    public float speed;

    SpriteRenderer Sprite;
    BoxCollider Coll;
    BoxCollider HitZone;
    //nyrkkien komponentit
    public Transform PunchRight;
    public Transform PunchLeft;
    public GameObject DamageZone;
    public Sprite Character;
    private bool Side;
    LevelManager Lvlmng;
    public bool Blocked;
    Animator anim;
    public bool CanPunch;
    public bool CanBlock;
    public bool PlayerPick;
    private IEnumerator coroutine;
    public float Health;
    Slider HPSlider;
    public AudioSource PlayerAudio;
    public AudioClip[] PlayerSounds;
    public AudioSource Walk;
    public bool win;
    public bool IsGrounded;

    void Awake()
    {
        Health = 100;

    }

    void Start()
    {
        Sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        Coll = GameObject.Find("PlayerHitZone").GetComponent<BoxCollider>();
        HitZone = GameObject.Find("PlayerHitZone").GetComponent<BoxCollider>();
        anim = gameObject.GetComponentInChildren<Animator>();
        PlayerAudio = gameObject.GetComponent<AudioSource>();
        //Walk = GameObject.FindWithTag("Sound").GetComponent<AudioSource>();
        win = false;
        CanPunch = true;
        CanBlock = true;
        

    }


    void FixedUpdate()
    {
        // }

        if (gameObject.name == "Player1")
        {
            //Liikkuuko pelaaja?
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                anim.SetBool("Move", false); // ei liiku --> Idle
            }
            else
            {

                //Vertical Movement
                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                    anim.SetBool("Move", true);
                    Sprite.flipX = false;
                    Side = false;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                    anim.SetBool("Move", true);
                    Sprite.flipX = true;
                    Side = true;
                }


                //Ylösalas liikkuminen
                if (Input.GetAxis("Vertical") > 0)
                {
                    anim.SetBool("Move", true);
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    anim.SetBool("Move", true);
                    transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                }
               
            }
        }
        else if (gameObject.name == "Player2")
        {

            if (Input.GetAxis("Horizontal2") == 0 && Input.GetAxis("Vertical2") == 0)
            {
                anim.SetBool("Move", false); // ei liiku --> Idle
            }
           
            else
            {
                //Vertical Movement
                if (Input.GetAxis("Horizontal2") > 0)
                {
                    transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                    anim.SetBool("Move", true);
                    Sprite.flipX = false;
                    Side = false;
                }
                else if (Input.GetAxis("Horizontal2") < 0)
                {
                    transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                    anim.SetBool("Move", true);
                    Sprite.flipX = true;
                    Side = true;
                }


                //Ylösalas liikkuminen
                if (Input.GetAxis("Vertical2") > 0)
                {
                    anim.SetBool("Move", true);
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
                else if (Input.GetAxis("Vertical2") < 0)
                {
                    anim.SetBool("Move", true);
                    transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                }
            }
        }
        else
        {
            return;

        }



    }
    void Update()
    {

        //lyönti
        if (Input.GetKey(KeyCode.C) && CanPunch && gameObject.name == "Player1")
        {
            PunchSound();
            if (Side && CanPunch)
            {


                CanPunch = false;
                anim.SetBool("HitKey", true);

                Instantiate(DamageZone, PunchLeft.position, Quaternion.identity, PunchLeft);
                coroutine = Timing(1);
                StartCoroutine(coroutine);
            }
            else if (CanPunch && !Side)
            {

                CanPunch = false;
                anim.SetBool("HitKey", true);

                Instantiate(DamageZone, PunchRight.position, Quaternion.identity, PunchRight);
                coroutine = Timing(1);
                StartCoroutine(coroutine);
            }
            else
            {
                return;
            }
        }
        else if (Input.GetKey(KeyCode.P) && CanPunch && gameObject.name == "Player2")
        {
            PunchSound();
            if (Side && CanPunch)
            {


                CanPunch = false;
                anim.SetBool("HitKey", true);

                Instantiate(DamageZone, PunchLeft.position, Quaternion.identity, PunchLeft);
                coroutine = Timing(1);
                StartCoroutine(coroutine);
            }
            else if (CanPunch && !Side)
            {

                CanPunch = false;
                anim.SetBool("HitKey", true);

                Instantiate(DamageZone, PunchRight.position, Quaternion.identity, PunchRight);
                coroutine = Timing(1);
                StartCoroutine(coroutine);
            }

        }
        //blokkaus
        else if (Input.GetKey(KeyCode.V) && CanBlock && gameObject.name == "Player1")
        {
            anim.SetBool("Block", true);
            Sprite.enabled = true;

            CanBlock = false;
            Blocked = true;
            coroutine = BlockTimer(1);
            StartCoroutine(coroutine);
        }
        else if (Input.GetKey(KeyCode.O) && CanBlock && gameObject.name == "Player2")
        {
            anim.SetBool("Block", true);
            Sprite.enabled = true;

            CanBlock = false;
            Blocked = true;
            coroutine = BlockTimer(1);
            StartCoroutine(coroutine);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Punch" && !Blocked)
        {

            anim.SetBool("Damage", true);
            HitSound();
            PlayerAudio.clip = PlayerSounds[0];
            PlayerAudio.Play();

            Invoke("DamageZero", 0.5f);


            //HPSlider.value -= damage;
        }
        else if (other.gameObject.tag == "Homo")
        {
            if (Health < 100)
            {
                Health += 20;
                Destroy(other.gameObject);

            }
            else
            {
                return;
            }

        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    //Ajanlaskijat
    IEnumerator Timing(float Timer)
    {

        yield return new WaitForSeconds(0.2f);
        //Instantiate(DamageZone, Pos.position, Quaternion.identity);
        anim.SetBool("HitKey", false);
        yield return new WaitForSeconds(Timer);
        CanPunch = true;
    }
    IEnumerator BlockTimer(float Timer)
    {
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("Block", false);
        Blocked = false;
        yield return new WaitForSeconds(Timer);
        CanBlock = true;
    }
    //reset levelmanagerille
    private void Reset()
    {
        Health = 100;


    }
    //damagecheck
    private void DamageZero()
    {
        anim.SetBool("Damage", false);
        Health = Health - 5;
    }
    //äänet
    public void PlaySound()
    {
        if (!win)
        {
            PlayerAudio.clip = PlayerSounds[2];
            PlayerAudio.Play();
            win = true;
        }




    }
    private void WalkingSound()
    {

        PlayerAudio.clip = PlayerSounds[4];
        PlayerAudio.Play();
    }
    private void HitSound()
    {
        if (CanPunch)




            PlayerAudio.clip = PlayerSounds[1];
        PlayerAudio.Play();

    }
    private void PunchSound()
    {
        PlayerAudio.clip = PlayerSounds[3];
        PlayerAudio.Play();
    }
}
