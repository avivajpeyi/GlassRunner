
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    // PUBLIC ATTRIBUTES
    public Camera cam;
    public GameObject target;
    public GameObject transparentTarget;
    public bool isDead = false;
    public bool renderCursor;

    // PRIVATE ATTRIBUTES
    NavMeshAgent agent;
    public string SegmentClickedOn;
    ThirdPersonCharacter third_person_character_controller;
    int numDeath = 0;
    bool playerMovement = true;
    GameObject placed_target;
    GameObject hover_target;
    AudioSource playerAudio;
   // PauseManager pauseManager;

    public AudioClip[] shatterSounds; 

    // Use this for initialization
    void Start()
    {
        //pauseManager = FindObjectOfType<PauseManager>();

        placed_target = Instantiate(target, new Vector3(transform.position.x, 0.64f, transform.position.z), new Quaternion(0, 0, 0, 0));
        hover_target = Instantiate(transparentTarget, new Vector3(transform.position.x, 0.64f, transform.position.z), new Quaternion(0, 0, 0, 0));
        placed_target.SetActive(false);
        hover_target.SetActive(false);

        agent = GetComponent<NavMeshAgent>();
        cam = FindObjectOfType<Camera>();
        playerAudio = GetComponent<AudioSource>();
        try
        {
            third_person_character_controller = GetComponent<ThirdPersonCharacter>();
            agent.updateRotation = false; // controlled by animation
        }
        catch (MissingComponentException)
        { //Debug.Log("No ThirdPersonCharacter hence default movements"); 
        }


    }

    // Update is called once per frame
    void Update()
    {

        renderCursor = isDead;//  pauseManager.is_paused ||

        if (renderCursor == true) {
            Cursor.visible = true;
        }
        else
        { 
            update3DCursor();
            if (playerMovement)
            { HandlePlayerMovement(); }
            else
            { agent.SetDestination(transform.position); }
        }

    }


    void update3DCursor()
    {

        // create a click from the SCREEN SPACE (2d)
        // into a ray in the WORLD SPACE
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // cast the ray and store information of the location the ray has hit
        if (Physics.Raycast(ray, out hit)) // returns true if actually does hit something
        {
            hover_target.SetActive(true);
            Cursor.visible = false;

            //////Debug.Log("Moving to pos " + hit.point);
            // if the ray its something it is stored in 'hit' (also code )
            // use 'hit' to move our dude
            //agent.SetDestination(hit.point); // hit the location the ray hit on naveMesh
            hover_target.transform.position = new Vector3(hit.point.x, 0.64f, hit.point.z);

        }
        else {
            hover_target.SetActive(false);
            Cursor.visible = true;
        }
    }



    void HandlePlayerMovement()
    {
        // click left mouse button
        if (Input.GetMouseButton(0))
        {
            // create a click from the SCREEN SPACE (2d)
            // into a ray in the WORLD SPACE
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // cast the ray and store information of the location the ray has hit
            if (Physics.Raycast(ray, out hit)) // returns true if actually does hit something
            {
                //////Debug.Log("Moving to pos " + hit.point);
                // if the ray its something it is stored in 'hit' (also code )
                // use 'hit' to move our dude
                agent.SetDestination(hit.point); // hit the location the ray hit on naveMesh
                hover_target.SetActive(false);
                placed_target.SetActive(true);
                placed_target.transform.position = new Vector3(hit.point.x, 0.64f, hit.point.z);
                SegmentClickedOn = hit.collider.gameObject.transform.root.name;
            }

        }


        if (third_person_character_controller != null)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                third_person_character_controller.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                third_person_character_controller.Move(Vector3.zero, false, false);
            }
        }

    }



    public void Death()
    {

        if (isDead == false)
        { 
            //// Set the death flag so this function won't be called again.
            isDead = true;

            //// Turn off any remaining effects.

            //// Tell the animator that the player is dead.
            //anim.SetTrigger("Die");
            if (third_person_character_controller != null)
            {
                third_person_character_controller.DeathAnim();
                GameObject fragments = transform.Find("Fragments").gameObject;
                GameObject playerModel = transform.Find("LowBody").gameObject;

                fragments.SetActive(true);
                playerModel.SetActive(false);

            }

            //// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = shatterSounds[Random.Range(0, shatterSounds.Length)];
            playerAudio.Play();

            //// Turn off the movement and shooting scripts.
            playerMovement = false;


            GetComponent<PlayerScore>().GameOver();

            ////RestartLevel();
            //if (numDeath == 0)
            //{
            //    Contine();
            //}
        }
    }

    public void Contine()
    {
        numDeath += 1;
        isDead = false;
        playerMovement = true;
        if (third_person_character_controller != null)
        {
            third_person_character_controller.DeathAnim();
        }

    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
