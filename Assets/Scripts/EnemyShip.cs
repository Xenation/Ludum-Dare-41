using LD41.Processes;
using UnityEngine;
using Xenon;

namespace LD41 {
	public class EnemyShip : Ship {

		public enum State {
			Inactive,
			Entering,
			Active
		}

		public SpawnTriggerType spawnTriggerType;
		[System.NonSerialized]
		public Collider2D spawnTrigger;

		public bool isFixed;
		public EnemyEnterBehaviour enterType;
		public EnemyShootBehaviour shootType;

		protected EnemyMover mover;
		protected WeaponsAutoController weaponController;

		protected State state = State.Inactive;
		protected ProcessManager procManager = new ProcessManager();

		protected new void Awake() {
			base.Awake();
			spawnTrigger = manager.triggersManager.GetTrigger(spawnTriggerType, transform.localPosition.x);
			mover = GetComponent<EnemyMover>();
			if (mover != null) {
				mover.enabled = false;
			}
			weaponController = GetComponent<WeaponsAutoController>();
			if (weaponController != null) {
				weaponController.enabled = false;
			}
			enabled = false;
		}

		public void Activate() {
			enabled = true;
		}

		protected void Update() {
			switch (state) {
				case State.Active:
					switch (shootType) {
						case EnemyShootBehaviour.TargetPlayerSimple:
							SetAllWeaponsTarget(manager.playerShip.transform.position);
							break;
					}
					break;
			}
		}

		protected new void FixedUpdate() {
			procManager.UpdateProcesses(Time.fixedDeltaTime);
			switch (state) {
				case State.Inactive:
					SwitchState(State.Entering);
					break;
				case State.Entering:
					
					break;
				case State.Active:
					break;
			}

			base.FixedUpdate();

			if (bounds.BellowKillY(transform.position)) {
				Die();
			}
		}

		public void SwitchState(State st) {
			state = st;
			switch (st) {
				case State.Entering:
					if (enterType != EnemyEnterBehaviour.Fixed) {
						transform.SetParent(manager.enemiesRoot);
					}
					switch (enterType) {
						case EnemyEnterBehaviour.Fixed:
						case EnemyEnterBehaviour.Classic:
							SwitchState(State.Active);
							break;
						case EnemyEnterBehaviour.Translate:
							procManager.LaunchProcess(new EnemyEnterTranslationProcess(this, (transform.localPosition.x > 0) ? 1 : -1, manager.mapBounds.bounds.extents.x));
							break;
					}
					break;
				case State.Active:
					if (mover != null) {
						mover.enabled = true;
					}
					if (weaponController != null) {
						weaponController.enabled = true;
					}
					if (enterType != EnemyEnterBehaviour.Fixed && isFixed) {
						transform.SetParent(manager.mapTransform);
					}
					if (isFixed) {
						velocity = Vector2.zero;
					}
					break;
			}
		}

	}
}
