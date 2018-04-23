using LD41.ShootEmUp;
using Xenon;

namespace LD41.Events {
	public class LauncherFiringEvent : XEvent {

		public ProjectileLauncher launcher;

		public LauncherFiringEvent(ProjectileLauncher launcher) {
			this.launcher = launcher;
		}
	}
}
