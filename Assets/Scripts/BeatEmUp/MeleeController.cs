using LD41.Events;
using UnityEngine;
using Xenon;

namespace LD41.BeatEmUp {
	[RequireComponent(typeof(BoxCollider2D))]
	public class MeleeController : MonoBehaviour, IEventSender {

		public float damage;
		public float cooldown = .5f;

		protected BoxCollider2D col;
		protected int layer;
		protected float lastHitTime;
		[System.NonSerialized]
		public Character character;

		protected void Awake() {
			col = GetComponent<BoxCollider2D>();
			character = GetComponentInParent<Character>();
			layer = gameObject.layer;
		}

		public void Hit() {
			if (Time.time < lastHitTime + cooldown) return;
			this.Send(new MeleeAttackEvent(this));
			lastHitTime = Time.time;
			ContactFilter2D filter = new ContactFilter2D();
			if (layer == LayerUtils.Enemy) {
				filter.SetLayerMask(1 << LayerUtils.Player | 1 << LayerUtils.Terminal);
			} else if (layer == LayerUtils.Player) {
				filter.SetLayerMask(1 << LayerUtils.Enemy | 1 << LayerUtils.Terminal);
			}
			Collider2D[] overlapping = new Collider2D[10];
			int touchedCount = col.OverlapCollider(filter, overlapping);
			for (int i = 0; i < touchedCount; i++) {
				if (overlapping[i].gameObject.layer == LayerUtils.Terminal) {
					if (layer == LayerUtils.Player) {
						Terminal terminal = overlapping[i].GetComponent<Terminal>();
						terminal.EnableTerminal();
					} else if (layer == LayerUtils.Enemy) {
						Terminal terminal = overlapping[i].GetComponent<Terminal>();
						terminal.DisableTerminal();
					}
				} else {
					Character ch = overlapping[i].GetComponent<Character>();
					if (ch != null) {
						ch.ReceiveDamage(character, damage);
					}
				}
			}
		}

	}
}
