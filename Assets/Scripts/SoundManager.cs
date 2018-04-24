using System.Collections;
using System.Collections.Generic;
using LD41.Events;
using UnityEngine;
using Xenon;

public class SoundManager : MonoBehaviour, IEventListener {

	public AudioSource sfxSource;
	public AudioSource musicSource;

	public static SoundManager instance = null;

	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	public AudioClip explosionEffect;

	public AudioClip laserShootEffect;

	public AudioClip hitEffect;


	private void Awake() {
		if(instance == null) {
			instance = this;
		}
		else if(instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		this.RegisterListener();
	}

	private void OnDestroy() {
		this.UnregisterListener();
	}

	public void PlaySingle(AudioClip clip) {
		sfxSource.clip = clip;
		sfxSource.Play();
	}

	public void RandomizeClips(AudioClip clip, AudioSource aSource, float volume, bool isPlayedOneTime = false, bool isPitched = false) {

		if (isPitched) {
			float randomPitch = Random.Range(lowPitchRange, highPitchRange);
			aSource.pitch = randomPitch;
		}

		aSource.clip = clip;

		if (isPlayedOneTime) {
			aSource.PlayOneShot(clip, volume);
		} else {
			aSource.Play();
		}

	}
	
	public void PlayExplosionSoundEffect() {
		Debug.Log("exp");
		RandomizeClips(explosionEffect, sfxSource, 2f, true);
	}

	public void PlayLaserShootSoundEffect() {
		RandomizeClips(laserShootEffect, sfxSource, .1f, true);
	}

	public void PlayHitSoundEffect() {
		RandomizeClips(hitEffect, sfxSource, 1f, true);
	}

	public void OnLauncherFiring(IEventSender sender, LauncherFiringEvent ev) {
		PlayLaserShootSoundEffect();
	}

	public void OnPlayerShipDamaged(IEventSender sender, PlayerShipDamagedEvent ev) {
		PlayHitSoundEffect();
	}

	public void OnEnemyShipDamaged(IEventSender sender, EnemyShipDamagedEvent ev) {
		PlayHitSoundEffect();
	}

	public void OnEnemyShipDeath(IEventSender sender, EnemyShipDeathEvent ev) {
		PlayExplosionSoundEffect();
	}

}
