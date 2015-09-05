using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
	public class TimerPause : IComponent, IDisposable
	{
		private TimeStamp PauseTime;

		public float PaddingTop
		{
			get
			{
				return 0f;
			}
		}

		public float PaddingLeft
		{
			get
			{
				return 0f;
			}
		}

		public float PaddingBottom
		{
			get
			{
				return 0f;
			}
		}

		public float PaddingRight
		{
			get
			{
				return 0f;
			}
		}

		public TimerPauseSettings Settings
		{
			get;
			set;
		}

		protected ITimerModel Model
		{
			get;
			set;
		}

		protected LiveSplitState CurrentState
		{
			get;
			set;
		}

		public float VerticalHeight
		{
			get
			{
				return 0f;
			}
		}

		public float MinimumWidth
		{
			get
			{
				return 0f;
			}
		}

		public float HorizontalWidth
		{
			get
			{
				return 0f;
			}
		}

		public float MinimumHeight
		{
			get
			{
				return 0f;
			}
		}

		public string ComponentName
		{
			get
			{
				return "Timer Pause";
			}
		}

		public IDictionary<string, Action> ContextMenuControls
		{
			get
			{
				return null;
			}
		}

		public TimerPause(LiveSplitState state)
		{
            Settings = new TimerPauseSettings();
            PauseTime = TimeStamp.Now;
			var timerModel = new TimerModel();
            timerModel.CurrentState = state;
            Model = timerModel;
            state.OnPause += state_OnPause;
            CurrentState = state;
		}

        private void state_OnPause(object sender, EventArgs e)
		{
            PauseTime = TimeStamp.Now;
		}

		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
		{
		}

		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
		{
		}

		public Control GetSettingsControl(LayoutMode mode)
		{
			return Settings;
		}

		public void SetSettings(XmlNode settings)
		{
            Settings.SetSettings(settings);
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			return Settings.GetSettings(document);
		}

		public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
		{
			if (state.CurrentPhase == TimerPhase.Paused && TimeStamp.Now - PauseTime > TimeSpan.FromSeconds(Settings.PauseLength))
			{
                Model.Pause();
			}
		}

		public void Dispose()
		{
            CurrentState.OnPause -= state_OnPause;
		}
	}
}
