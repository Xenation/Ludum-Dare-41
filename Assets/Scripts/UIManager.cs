using LD41.BeatEmUp;
using LD41.Events;
using LD41.ShootEmUp;
using UnityEngine;
using UnityEngine.UI;
using Xenon;

namespace LD41 {
	public class UIManager : MonoBehaviour, IEventListener {

		public Image shipLifeBar;
		public Image characterLifeBar;
		public Image progressBar;

		[SerializeField]
		private Text scoreTxt;
		
		[SerializeField]
		private GameObject victoryPanel;
		[SerializeField]
		private GameObject defeatPanel;

		private void Awake() {
			this.RegisterListener();
			UpdateScore();
			UpdateShipHealth(ShootEmUpManager.I.playerShip);
			UpdateCharacterHealth(BeatEmUpManager.I.playerChar);
		}

		private void Update() {
			UpdateProgressBar();
		}

		private void OnDestroy() {
			this.UnregisterListener();
		}

		private void UpdateScore() {
			scoreTxt.text = GameManager.I.score.ToString();
		}

		private void UpdateShipHealth(Ship ship) {
			shipLifeBar.material.SetFloat("_FillAmount", ship.health / 10f);
		}

		private void UpdateCharacterHealth(Character character) {
			characterLifeBar.material.SetFloat("_FillAmount", character.health / 10f);
		}

		private void UpdateProgressBar() {
			progressBar.fillAmount = ShootEmUpManager.I.portionReached;
		}

		private void DisplayGameOverPanel() {
			defeatPanel.SetActive(true);
			Time.timeScale = 0;
		}

		private void DisplayWinPanel() {
			victoryPanel.SetActive(true);
			Time.timeScale = 0;
		}

		//// EVENTS \\\\
		public void OnPlayerShipDamaged(IEventSender sender, PlayerShipDamagedEvent ev) {
			UpdateShipHealth(ev.ship);
		}

		public void OnPlayerShipDeath(IEventSender sender, PlayerShipDeathEvent ev) {
			DisplayGameOverPanel();
		}

		public void OnPlayerCharacterDamaged(IEventSender sender, PlayerCharacterDamagedEvent ev) {
			UpdateCharacterHealth(ev.character);
		}

		public void OnGameWon(IEventSender sender, GameWonEvent ev) {
			DisplayWinPanel();
		}

		public void OnScoreChanged(IEventSender sender, ScoreChangedEvent ev) {
			UpdateScore();
		}

	}
}
