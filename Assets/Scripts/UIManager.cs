using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LD41.Events;

public class UIManager : MonoBehaviour {


	public LD41.ShootEmUp.ShipController ship;
	public LD41.BeatEmUp.PlayerCharacter player;

	public Image shipLifeBar;
	public Image characterLifeBar;

	[SerializeField]
	private Text scoreTxt;


	[SerializeField]
	private GameObject victoryPanel;
	[SerializeField]
	private GameObject defeatPanel;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	private void Update() {
		scoreTxt.text = LD41.GameManager.I.score.ToString();
		SetShipHealth();
		SetCharacterHealth();
		SetEndPanel();
	}

	private void SetShipHealth() {

		shipLifeBar.fillAmount = ship.health / 10;

	}

	private void SetCharacterHealth() {

		characterLifeBar.fillAmount = player.health / 10;

	}

	private void SetEndPanel() {
		if(ship.health <= 0) {
			defeatPanel.SetActive(true);
			victoryPanel.SetActive(false);
			Time.timeScale = 0;
		}
		if (LD41.GameManager.I.endGame) {
			victoryPanel.SetActive(true);
			defeatPanel.SetActive(false);
			Time.timeScale = 0;
		}
	}


}
