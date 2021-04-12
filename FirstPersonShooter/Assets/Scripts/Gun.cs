using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
	public enum FireMode {Auto, Single}
	public FireMode fireMode;

	public Transform bulletSpawn;
	public GameObject projectile;
	public int _damage;
	public float msBetweenShots = 100;
	UseAttacks useAttacks;

	public AudioClip shotSound;
	AudioSource audioSource;

	MuzzleFlash muzzleFlash;

	float nextShotTime;

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
		muzzleFlash = GetComponent<MuzzleFlash>();
		useAttacks = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UseAttacks>();

		projectile.GetComponent<BulletHit>().damage = _damage;
	}

    public void Shoot()
	{
		if (Time.time > nextShotTime)
		{
			nextShotTime = Time.time + msBetweenShots / 1000;
			var clone = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
			useAttacks.ammoAmount--;
			useAttacks.UpdateText();
			muzzleFlash.Activate();
			audioSource.PlayOneShot(shotSound);
			Destroy(clone, 5.0f);
		}
	}
}
