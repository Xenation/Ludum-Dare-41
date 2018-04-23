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

		[SerializeField]
		private Text scoreTxt;
		
		[SerializeField]
		private GameObject victoryPanel;
		[SerializeField]
		private GameObject defeatPanel;

		private void Awake() {
			this.RegisterListener();
			UpdateScore();
		}

		private void OnDestroy() {
			EventManager.I.UnregisterListener(this);
		}

		private void UpdateScore() {
			scoreTxt.text = GameManager.I.score.ToString();
		}

		private void UpdateShipHealth(Ship ship) {
			shipLifeBar.fillAmount = ship.health / 10;
		}

		private void UpdateCharacterHealth(Character character) {
			characterLifeBar.fillAmount = character.health / 10;
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
