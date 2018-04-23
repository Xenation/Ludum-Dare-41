using System.Collections.Generic;
using Xenon;

namespace LD41.Processes {
	public class CompositeProcess : Process {

		private ProcessManager manager;
		private LinkedList<Process> processes;

		public CompositeProcess() : base() {
			manager = new ProcessManager();
			processes = new LinkedList<Process>();
		}

		public override void OnBegin() {
			if (processes.Count != 0) {
				manager.LaunchProcess(processes.First.Value);
			} else {
				Terminate();
			}
		}

		public override void Update(float dt) {
			manager.UpdateProcesses(dt);
		}

		public override void OnTerminate() {
			
		}

		public void AddProcess(Process process) {
			if (processes.Count != 0) {
				processes.Last.Value.Attach(process);
				processes.Last.Value.TerminateCallback -= OnLastProcessEnded;
			}
			processes.AddLast(process);
			process.TerminateCallback += OnLastProcessEnded;
		}

		protected virtual void OnLastProcessEnded() {
			Terminate();
		}

	}
}
