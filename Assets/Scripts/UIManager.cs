using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LD41.Events;

public class UIManager : MonoBehaviour {


	public LD41.ShootEmUp.ShipController ship;

	public Image heartLifeBar;

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
		SetEndPanel();
	}

	private void SetShipHealth() {

		heartLifeBar.fillAmount = ship.health / 10;

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
