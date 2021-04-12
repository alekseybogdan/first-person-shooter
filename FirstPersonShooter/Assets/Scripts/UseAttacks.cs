using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseAttacks : MonoBehaviour
{
    public int ammoAmount = 10;
    public Text ammoPanel;
    public Transform weaponHold;
    Gun equippedGun;
    public Gun startingGun;

    public float meleeRepeatDelay = 0.25f;
    public GameObject punchMesh;
    private bool punchActive;

    public PauseMenu pause;

    bool shooting;

    private void Start()
    {
        //Update text to display the player ammo.
        UpdateText();
        //Hide the hand when we start the game and have ammo.
        punchMesh.SetActive(false);       

        if (startingGun != null)
            EquipGun(startingGun);
    }

    // Update is called once per frame
    void Update()
    {
        if (equippedGun.fireMode == Gun.FireMode.Single)
            shooting = Input.GetButtonDown("Fire1");
        else
            shooting = Input.GetButton("Fire1");

        if (shooting && !pause.isGamePaused)
        {
            if (ammoAmount > 0)
            {
                equippedGun.Shoot();
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

    public void UpdateText()
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

    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if (equippedGun != null)
            equippedGun.Shoot();
    }
}
