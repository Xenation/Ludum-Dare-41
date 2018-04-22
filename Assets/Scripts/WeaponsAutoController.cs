using UnityEngine;

namespace LD41 {
	public enum FiringMode {
		NotFiring,
		Firing
	}

	[System.Serializable]
	public struct FiringPatternStep {
		public float duration;
		public FiringMode firingMode;

		public FiringPatternStep(float duration, FiringMode firingMode) {
			this.duration = duration;
			this.firingMode = firingMode;
		}
	}

	public class WeaponsAutoController : MonoBehaviour {

		public FiringPatternStep[] pattern;

		protected EnemyShip ship;
		protected ShootEmUpManager manager;
		protected ShipController playerShip;

		protected int currentStepIndex = 0;
		protected float currentStepStartTime;

		protected void Awake() {
			ship = GetComponent<EnemyShip>();
			manager = ShootEmUpManager.I;
			playerShip = manager.playerShip;
		}

		protected void OnEnable() {
			currentStepIndex = 0;
			currentStepStartTime = Time.time;
		}

		protected void Update() {
			if (pattern.Length == 0) return;
			if (Time.time > currentStepStartTime + pattern[currentStepIndex].duration) { // Move To Next Step
				currentStepIndex = (currentStepIndex + 1) % pattern.Length;
				currentStepStartTime = Time.time;
			}
			switch (pattern[currentStepIndex].firingMode) {
				case FiringMode.Firing:
					ship.FireAll();
					break;
			}
		}

	}
}
