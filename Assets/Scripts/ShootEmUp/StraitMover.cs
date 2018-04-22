namespace LD41.ShootEmUp {
	public class StraitMover : EnemyMover {

		protected void OnEnable() {
			ship.velocity = new UnityEngine.Vector2(0, -ship.speed);
		}

	}
}
