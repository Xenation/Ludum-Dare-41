namespace LD41.ShootEmUp {
	public class ShooterEntity : MovingEntity {

		protected ShootEmUpManager manager;

		protected void Awake() {
			manager = ShootEmUpManager.I;
			bounds = manager.mapBounds;
		}

	}
}
