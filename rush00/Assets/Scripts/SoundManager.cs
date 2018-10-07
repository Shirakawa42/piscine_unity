using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource bruitages;

    [SerializeField]
    private AudioClip enemy_die;
    [SerializeField]
    private AudioClip player_die;
    [SerializeField]
    private AudioClip player_drop;
    [SerializeField]
    private AudioClip player_get;
    [SerializeField]
    private AudioClip player_win;
    [SerializeField]
    private AudioClip player_loose;

    public static SoundManager manager;

	// Use this for initialization
	void Start () {
        if (manager == null) {
			manager = this;
            bruitages = GetComponent<AudioSource>();         
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyDieSound() {
        PlaySound(enemy_die);
    }

    public void PlayerDieSound() {
        PlaySound(player_die);
    }

    public void PlayerDropWeaponSound() {
        PlaySound(player_drop);
    }

    public void PlayerGetWeaponSound() {
        PlaySound(player_get);
    }

    public void PlayerLooseSound() {
        PlaySound(player_loose);
    }

    public void PlayerWinSound() {
        PlaySound(player_win);
    }

    private void PlaySound(AudioClip sound) {
        if (bruitages.clip == player_loose || bruitages.clip == player_win)
            return;
        bruitages.clip = sound;
        bruitages.Play();
    }

}
