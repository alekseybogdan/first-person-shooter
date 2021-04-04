using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseAttacks : MonoBehaviour
{
    public int ammoAmount = 10;
    public float meleeRepeatDelay = 0.25f;
    public GameObject projectile;
    public GameObject punchMesh;
    public Text ammoPanel;
    private bool punchActive;

    MuzzleFlash muzzleFlash;

    public GameObject projectileSpawn;

    public PauseMenu pause;

    float fireElapsedTime = 0f;
    public float fireDelay = 1f;

    AudioSource audioSource;

    public AudioClip pistolShot;

    private void Start()
    {
        //Update text to display the player ammo.
        UpdateText();
        //Hide the hand when we start the game and have ammo.
        punchMesh.SetActive(false);
        muzzleFlash = GetComponent<MuzzleFlash>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fireElapsedTime += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && !pause.isGamePaused)
        {
            if (ammoAmount > 0)
            {
                if (fireElapsedTime >= fireDelay)
                {
                    fireElapsedTime = 0f;
                    ammoAmount--;
                    UpdateText();
                    var clone = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                    muzzleFlash.Activate();
                    audioSource.PlayOneShot(pistolShot);
                    //Destroy after 2 seconds to stop clutter.
                    Destroy(clone, 5.0f);
                }
            }
            else
            {
                if (!punchActive)
                {
                    punchActive = true;
                    StartCoroutine(MeleeAttack());
                }
            }
        }
    }

    void ApplyAmmo(int ammo)
    {
        ammoAmount += ammo;
        UpdateText();
    }

    void UpdateText()
    {
        //Check the ammo panel exists.
        if (ammoPanel != null)
        {
            //Sets the text on our panel.
            ammoPanel.text = ammoAmount.ToString();
        }
    }

    IEnumerator MeleeAttack()
    {
        punchMesh.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        punchMesh.SetActive(false);
        yield return new WaitForSeconds(meleeRepeatDelay);
        punchActive = false;
        yield return null;
    }
}
