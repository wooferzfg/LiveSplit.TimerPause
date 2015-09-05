using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using UpdateManager;

[assembly: ComponentFactory(typeof(TimerPauseFactory))]

namespace LiveSplit.UI.Components
{
	public class TimerPauseFactory : IComponentFactory, IUpdateable
	{
		public string ComponentName
		{
			get
			{
				return "Timer Pause";
			}
		}

		public string Description
		{
			get
			{
				return "Unpauses the timer after an exact number of seconds whenever the timer is paused.";
			}
		}

		public ComponentCategory Category
		{
			get
			{
				return ComponentCategory.Control;
			}
		}

		public string UpdateName
		{
			get
			{
				return ComponentName;
			}
		}

		public string XMLURL
		{
			get
			{
				return "http://livesplit.org/update/Components/noupdates.xml";
			}
		}

		public string UpdateURL
		{
			get
			{
				return "http://livesplit.org/update/";
			}
		}

		public Version Version
		{
			get
			{
				return Version.Parse("1.2.0");
			}
		}

		public IComponent Create(LiveSplitState state)
		{
			return new TimerPause(state);
		}
	}
}
