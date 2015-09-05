using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;

namespace LiveSplit.UI.Components
{
    public partial class TimerPauseSettings : UserControl
    {
        private float pauseLength;
        public float PauseLength
        {
            get
            {
                return pauseLength;
            }
            set
            {
                pauseLength = Math.Max(value, 0f);
            }
        }

		public TimerPauseSettings()
		{
            InitializeComponent();
            PauseLength = 5f;
            txtPauseLength.DataBindings.Add("Text", this, "PauseLength");
		}

		public void SetSettings(XmlNode node)
		{
			var xmlElement = (XmlElement)node;
            PauseLength = SettingsHelper.ParseFloat(xmlElement["PauseLength"], 0f);
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			var xmlElement = document.CreateElement("Settings");
			xmlElement.AppendChild(SettingsHelper.ToElement(document, "PauseLength", PauseLength));
			return xmlElement;
		}
    }
}
