using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.AssetImporters;

public class Playermovement : MonoBehaviour
{
    Rigidbody2D body; //referens till spelarens rigidbody - Robin

    float movementSpeed; //float till spelarens speed - Robin
    [SerializeField, Range(150, 1000)]
    float crouchspeed = 500; //variabel för crouchspeed i inspektorn - EN
    [SerializeField, Range(150, 2000)] //gör en slider som man kan ändra i konsolen till spelaren speed - Robin
    float walkspeed = 1600; //variabel för walkspeed i inspektorn - EN
    float privatewalkspeed; //variabel för walkspeed i koden - EN
    float privatecrouchspeed; //variabel för crouchspeed i koden - EN
    public float jumpheight = 7;// hur högt man kan hoppa variabel - EN

    bool hasJumped = true; //en bool som frågar om spelaren har hoppat - Robin
    bool sliding; //om spelaren slidar eller inte - Robin
    bool canstand; //om spelaren kan stå upp eller inte - Robin
    public static bool cuttherope = false; //har spelaren skurit repet? - Robin

    public Animator crouch; //referens till animatorn där crouch finns. - Robin
    public Animator mushroom; //referens till animatorn där mushroom finns - Robin

    public float maxFuel = 100; //variabel till maxFuel - Robin
    public float currentFuel; //sätter nuvarande fuel - Robin
    [SerializeField, Range(0.1f, 2)]
    public float loseFuel = 1f; //hur mycket fuel man förlorar - Robin
    public float loseFuelInWater = 10; //variable för att förlora mer fuel i vatten - EN
    public TheFuelBar fuelBar; //Referens till fuelbaren - Robin

    public GameObject dialog; //referens till dialog texten - Robin
    public GameObject textruta; //referens till textrutan för dialogen - Robin
    public GameObject restartbutton; //referens till restartknappen - Robin

    public Text dialogtext; //referens till dialog texten - Robin

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); //hämtar rigidbodyn från spelaren - Robin
        sliding = false; //sätter sliding till false - Robin
        canstand = true; //spelaren kan stå blir true - Robin
        currentFuel = maxFuel; //sätter nuvarande fuel till maxfuel i början.
        fuelBar.SetMaxFuel(maxFuel); //sätter värdet på fuelbaren
        movementSpeed = walkspeed; //sätt movement speed till walkspeed - EN
        privatewalkspeed = walkspeed; //sätt privatewalkspeed speed till walkspeed - EN
        privatecrouchspeed = crouchspeed; //sätt privatecrouchspeed speed till crouchspeed - EN
    }
    void Update()
    {
        if (sliding) //om du sneakar - Robin
        {
            movementSpeed = privatecrouchspeed; //sätt movement speed till crouchspeed - Robin
        }
        if (!sliding) //om du inte sneakar - Robin
        {
            movementSpeed = privatewalkspeed; //sätt movement speed till walkspeed - Robin
        }
        if (cuttherope == true) //om repet är skuret - Robin
        {
            dialogtext.text = "I cant walk that far. Il just stand here and\n wait for the rain..."; //sätt texten till det här - Robin
        }

        if (cuttherope == false) //om repet inte är skuret - Robin
        {
            dialogtext.text = "                     Use your flame to cut the rope.\n I would try myself but my flame has been gone for to long."; //sätt texten till det här - Robin
        }
        

        currentFuel -= loseFuel * Time.deltaTime; //tar bort fuel varje sekund - Robin
        fuelBar.SetHealth(currentFuel); //Uppdaterar så att man kan se den nuvarande fuelen - Robin

        if (currentFuel <= 0) //Om currentFuel är lika med eller mindre än 0 startar funktionen Die() - EN
        {
            Die();
        }

        float hor = Input.GetAxis("Horizontal"); //hämtar inputen "horizontal" och bevarar den i floaten hor (horizontal) - Robin

        body.velocity = new Vector2(hor * movementSpeed * Time.deltaTime, body.velocity.y); //ändrar body.velocityns x värde beroende på vilken knapp man klickar på för att röra sig åt höger eller vänster (ändra inte y värdet det är body.velocity.y för att man ska kunna hoppa) - Robin
       
        /* Första if satsen gör så att man inte kan gå någonstans om man försöker gå både höger och vänster samtidigt.
         * Andra if satsen eller else if satsen sätter tillbaka speed variablarna så att man kan röra sig igen och använder sig av
         * Robbins kod för att gå. 
         * Den fixar också så att animationen börjar igen.
         * - EN 
         */
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) 
            || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) 
            || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.D) 
            || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.RightArrow))
        {
            privatecrouchspeed = 0;
            privatewalkspeed = 0;

            crouch.SetBool("walking", false);
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.A)
              || !Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.RightArrow))
             {
                privatecrouchspeed = crouchspeed;
                privatewalkspeed = walkspeed;
            
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) //när spelaren håller ned D eller höger pilen- Robin
                   || Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.A)
                   || Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.LeftArrow)) 
                {
                    crouch.SetBool("walking", true); //sätt walking till true - Robin
                    transform.eulerAngles = new Vector2(0, 0); //vänder på spelaren - Robin
                }
            
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) //när spelaren håller ned D eller höger pilen- Robin
                   || Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D)
                   || Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.RightArrow)) 
                {
                    crouch.SetBool("walking", true); //sätt walking till true - Robin
                    transform.eulerAngles = new Vector2(0, 180); //vänder på spelaren - Robin
                }
             }

        //när spelaren håller ned A eller D - Robin
        //eller pilarna - EN
        if (Input.GetKeyUp(KeyCode.A) ||(Input.GetKeyUp(KeyCode.D)) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) 
        {
            crouch.SetBool("walking", false); //sätt walking till false - Robin
        }
        if (sliding == false) //om sliding är false - Robin
        {
            if (Input.GetButtonDown("Jump") && !hasJumped) //Om spelaren klickar på jump och spelaren inte har hoppat så hoppar den - Robin
            {
                body.velocity = new Vector2(body.velocity.x, jumpheight);
                hasJumped = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !hasJumped) //om spelaren är på marken och håller ned shift - Robin
        {
            sliding = true; //sliding är true - Robin
            crouch.SetBool("crouch", true); //spelar crouch animationen - Robin
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //annars om spelaren släpper på shift - Robin
        {
            if (canstand) //och om spelaren kan stå upp - Robin
            {
                sliding = false; //sliding på false - Robin
                crouch.SetBool("crouch", false); //spelaren crouchar inte längre - Robin
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //om spelaren collidar - Robin
    {
        hasJumped = false; //kan hoppa igen - Robin
    }
    private void OnTriggerEnter2D(Collider2D collision) //om spelaren entrar triggern - Robin
    {
        if (collision.transform.tag == "MushroomHead") //när spelaren går in i triggern med tagen MushroomHead - Robin
        {
            body.velocity += new Vector2(0, 10); //går du på svampen studsar du uppåt - Robin
        }
        if (collision.transform.tag == "CantStand") //om tagen är Cantstand - Robin
        {
            canstand = false; //blir canstand false - Robin
        }
        if (collision.transform.tag == "StartingJump") //om spelaren triggar tag startingjump - Robin
        {
            Time.timeScale = 0.6f; //tiden slowar ned - Robin
        }
        if (collision.transform.tag == "OldManNPC") //Går spelaren in i NPC triggern - Robin
        {
            textruta.SetActive(true); //sätts textrutan på - Robin
            dialog.SetActive(true); //sätts texten på- Robin
        }

        if (collision.tag == "WATER") //dör vid kontakt med vattenblock - EN
        {
            Die();
        }

        //vid contakt med en liten olja/hjärta så fylls slidern på med 10 och objektet försvinner - EN
        if (collision.tag == "heal")
        {
            TakeHealing(10); //Lägg till hur mycket den ska heala - EN
            Destroy(collision.transform.gameObject); //förstör objektet som healingen kom från - EN
        }
        //Plus 30 HP - EN
        if (collision.tag == "Heal")
        {
            TakeHealing(30);
            Destroy(collision.transform.gameObject);
        }
        //Plus 50 HP - EN
        if (collision.tag == "HEAL")
        {
            TakeHealing(50);
            Destroy(collision.transform.gameObject);
        }
        if(collision.transform.tag == "NextLevel") //När man går in i triggern som har tagen "NextLevel" - Robin
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //byter till nästa scen - Robin
        }
        if(collision.transform.tag == "TheEnd") //om du triggar triggern som heter TheEnd - Robin
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3); //byter till första scenen - Robin
        }

    }
    private void OnTriggerExit2D(Collider2D collision) //om spelaren exitar triggern - Robin
    {
        if (collision.transform.tag == "CantStand") //om den lämnar triggern cantstand - Robin
        {
            canstand = true; //canstand blir nu true - Robin
            sliding = false; //sliding blir nu false spelaren ställer sig alltså upp - Robin
            crouch.SetBool("crouch", false); //spelaren slutar croucha - Robin
        }
        if (collision.transform.tag == "Endingjump") //om spelaren triggar endingjump triggern - Robin
        {
            Time.timeScale = 1f; //blir tiden normal - Robin
        }
        if (collision.transform.tag == "OldManNPC") //När spelaren går ut från NPC triggern - Robin
        {
            textruta.SetActive(false); //stängs textrutan av - Robin
            dialog.SetActive(false); //stängs texten av - Robin
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //om spelaren stannar i triggern - EN
    {
        //förlorar mer fuel i vatten - EN
        if (collision.tag == "Water")
        {
            currentFuel -= loseFuel * Time.deltaTime * loseFuelInWater;
        }
    }

    //Kod för att ta up fuel av något - EN
    public void TakeHealing(int heal)
    {
        currentFuel += heal; //refererar till int i TakeHealing och säger vad den ska göra med den - EN
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);//säger vad den ska höja och vad som är max/min värdet - EN
    }

    public void Die()
    {
        body.velocity = new Vector2(0, 0); //så att gubben stannar när man dör - Robin
        restartbutton.SetActive(true); //sätter på restartknappen - Robin
        Cursor.lockState = CursorLockMode.Confined; //Sätter på musen igen - EN
        crouch.SetBool("walking", false); //Stänger av walking animatinon när man dör - EN

        /*anim.SetBool("IsDead", true); // sätt en animation här sen - EN*/
        this.enabled = false; //stänger av coden - EN
    }
}

