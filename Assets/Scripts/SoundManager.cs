using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

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
	}

	public void PlaySingle(AudioClip clip) {
		sfxSource.clip = clip;
		sfxSource.Play();
	}

	public void RandomizeClips(AudioClip clip, AudioSource aSource, bool isPlayedOneTime = false, bool isPitched = false) {

		if (isPitched) {
			float randomPitch = Random.Range(lowPitchRange, highPitchRange);
			aSource.pitch = randomPitch;
		}

		aSource.clip = clip;

		if (isPlayedOneTime) {
			aSource.PlayOneShot(clip);
		} else {
			aSource.Play();
		}

	}
	
	public void PlayExplosionSoundEffect() {
		RandomizeClips(explosionEffect, sfxSource, true);
	}

	public void PlaylaserShootSoundEffect() {
		RandomizeClips(laserShootEffect, sfxSource, true);
	}

	public void PlayHitSoundEffect() {
		RandomizeClips(hitEffect, sfxSource, true);
	}

}
