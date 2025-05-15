using System;
using System.Drawing;
using System.Windows.Forms;

namespace HL7Analyser
{
	public enum Hl7Action
	{
		Process,
		Extend,
		Compress,
	}

	public partial class MainForm : Form
	{
		string hl7 = "";
		int height0 = 0;
		float split = 0.6f;

		public MainForm()
		{
			InitializeComponent();

			resize();
		}

		public void process(Hl7Action action)
		{
			string[] lines = hl7Text.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			string[] parts;
			string[] codeparts;
			string line, part, codetext;
			int code, type;
			bool error;
			int headersFound = 0;
			int requestsFound = 0;
			int obsFound = 0;

			if (hl7Text.Text == "")
			{
				return;
			}

			clearAll();

			foreach (string line0 in lines)
			{
				line = line0.Trim();
				if (hl7 != "" && line != "")
				{
					hl7 += Constants.lineDelim;
					hl7Text.AppendText(Constants.lineDelim);
				}
				type = 0;
				parts = line.Split('|');	// don't remove empty strings!
				if (parts.Length > 1)
				{
					if (parts[0] == Constants.headerHeader)
					{
						headersFound++;
					}

					if (parts[0] == Constants.requestHeader)
					{
						requestsFound++;
					}

					if (parts[0] == Constants.obsHeader)
					{
						obsFound++;
					}

					hl7Text.SelectionColor = Color.Black;
					for (int p = 0; p < parts.Length; p++)
					{
						error = false;
						if (p > 0)
						{
							hl7Text.AppendText("|");
							hl7 += "|";
						}
						part = parts[p].Trim();
						if (part != "")
						{
							// content
							if (part.EndsWith("MDC"))
							{
								// fill in empty constant text
								codeparts = part.Split('^');
								code = 0;
								if (codeparts.Length >= 3)
								{
									code = int.Parse(codeparts[0]);
									codetext = getCodeText(code);
									if (codetext == "")
									{
										error = true;
									}
									if (action == Hl7Action.Extend && codeparts[1] == "")
									{
										if (codetext != "")
										{
											// overwrite part
											part = string.Format("{0}^{1}^{2}", codeparts[0], codetext, codeparts[2]);
										}
									}
									else if (action == Hl7Action.Compress && codeparts[1] != "")
									{
										// overwrite part
										part = string.Format("{0}^^{1}", codeparts[0], codeparts[2]);
									}
								}
								if (p == 3)
								{
									// OBX-3: Type
									type = code;
								}
							}
							else if (part.Contains("(") && part.Contains(")") && part.Contains("^"))
							{
								codeparts = part.Split("^()".ToCharArray());
								if (codeparts.Length >= 3)
								{
									code = int.Parse(codeparts[2].Trim("()".ToCharArray()));
									codetext = getFlagText(code, type);
									if (codetext == "")
									{
										error = true;
									}
									if (action == Hl7Action.Extend && codeparts[1] == "")
									{
										if (codetext != "")
										{
											// overwrite part
											part = string.Format("{0}^{1}({2})", codeparts[0], codetext, codeparts[2]);
										}
									}
									else if (action == Hl7Action.Compress && codeparts[1] != "")
									{
										// overwrite part
										part = string.Format("{0}^({1})", codeparts[0], codeparts[2]);
									}
								}
							}
							hl7 += part;
							if (error)
							{
								hl7Text.SelectionColor = Color.Red;
							}
							hl7Text.AppendText(part);
							hl7Text.SelectionColor = Color.Black;
						}
					}
				}
				else
				{
					hl7 += line;
					hl7Text.SelectionColor = Color.Red;
					hl7Text.AppendText(line);
					hl7Text.SelectionColor = Color.Black;
				}
			}

			if (action == Hl7Action.Process)
			{
				if (headersFound == 0)
				{
					MessageBox.Show("Header element (" + Constants.headerHeader + ") not found", "HL7 unexpected format");
				}
				if (requestsFound == 0)
				{
					MessageBox.Show("Request element (" + Constants.requestHeader + ") not found", "HL7 unexpected format");
				}
				if (obsFound == 0)
				{
					MessageBox.Show("No observation elements (" + Constants.obsHeader + ") found", "HL7 unexpected format");
				}
				else
				{
					obsFound = extractObs();

					if (obsFound == 0)
					{
						MessageBox.Show("No actual observations found", "HL7 unexpected format");
					}
				}
			}
		}

		public int extractObs()
		{
			string[] lines = hl7.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
			string line;
			string[] parts;
			string timeStamp = "";
			string type, value, units;
			int obsFound = 0;

			obsListView.Items.Clear();

			foreach (string line0 in lines)
			{
				line = line0.Trim();
				parts = line.Split('|');	// don't remove empty strings!
				if (parts.Length >= 6)
				{
					if (parts[0] == Constants.obsHeader)
					{
						// type
						type = parts[3];

						//value
						value = getText(parts[5], type);

						// units
						if (parts.Length >= 7)
						{
							units = getText(parts[6]);
						}
						else
						{
							units = "";
						}
						if (parts.Length >= 15)
						{
							timeStamp = convertDateTime(parts[14]);
						}
						if (parts[2] != "")
						{
							obsListView.Items.Add(new ListViewItem(new string[] { timeStamp, getText(type), value, units }));
							obsFound++;
						}
					}
				}
			}
			return obsFound;
		}

		string convertDateTime(string dateTime0)
		{
			string dateTime = dateTime0;

			if (dateTime.Length >= 14)
			{
				dateTime = dateTime0.Substring(0, 4) + "-" + dateTime0.Substring(4, 2) + "-" + dateTime0.Substring(6, 2) + " " +
							dateTime0.Substring(8, 2) + ":" + dateTime0.Substring(10, 2) + ":" + dateTime0.Substring(12, 2);
				if (dateTime.Length >= 19)
				{
					dateTime += " " + dateTime0.Substring(14, 3) + ":" + dateTime0.Substring(17, 2);
				}
			}
			return dateTime;
		}

		string timestampString(DateTime timestamp)
		{
			return string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}] ", timestamp);
		}

		public string getText(string mdc, string type = "")
		{
			string s = mdc;
			string[] codeparts = mdc.Split("^()".ToCharArray());
			int typeCode, code;

			if (codeparts.Length >= 4)
			{
				if (int.TryParse(type.Split("^".ToCharArray())[0], out typeCode))
				{
					if (int.TryParse(codeparts[2], out code))
					{
						s = getFlagText(code, typeCode);
					}
				}
			}
			else if (codeparts.Length >= 3)
			{
				if (codeparts[1] != "")
				{
					// text present; simply copy
					s = codeparts[1];
				}
				else
				{
					// lookup text using code
					if (int.TryParse(codeparts[0], out code))
					{
						s = getCodeText(code);
					}
				}
			}
			// reduce text
			if (s.StartsWith("MDC_"))
			{
				s = s.Substring(4);
				if (s.StartsWith("DIM_"))
				{
					s = s.Substring(4);
				}
			}
			return s;
		}

		public string getCodeText(int code)
		{
			int scode = code & 0xFFFF;

			String codetext = ((Nomenclature)scode).ToString();
			if (codetext != scode.ToString())
			{
				return codetext;
			}
			return "";
		}

		public string getFlagText(int code, int type)
		{
			string codetext;

			switch ((Nomenclature)(type & 0xFFFF))
			{
				case Nomenclature.MDC_AI_TYPE_SENSOR_FALL:
					codetext = ((MDC_AI_TYPE_SENSOR_FALL_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_PERS:
					codetext = ((MDC_AI_TYPE_SENSOR_PERS_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_SMOKE:
				case Nomenclature.MDC_AI_TYPE_SENSOR_CO:
				case Nomenclature.MDC_AI_TYPE_SENSOR_WATER:
				case Nomenclature.MDC_AI_TYPE_SENSOR_GAS:
					codetext = ((MDC_AI_TYPE_SENSOR_substance_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_MOTION:
					codetext = ((MDC_AI_TYPE_SENSOR_MOTION_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_PROPEXIT:
					codetext = ((MDC_AI_TYPE_SENSOR_PROPEXIT_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_ENURESIS:
					codetext = ((MDC_AI_TYPE_SENSOR_ENURESIS_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_CONTACTCLOSURE:
					codetext = ((MDC_AI_TYPE_SENSOR_CONTACTCLOSURE_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_USAGE:
					codetext = ((MDC_AI_TYPE_SENSOR_USAGE_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_SWITCH:
					codetext = ((MDC_AI_TYPE_SENSOR_SWITCH_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_DOSAGE:
					codetext = ((MDC_AI_TYPE_SENSOR_DOSAGE_flags)code).ToString();
					break;

				case Nomenclature.MDC_AI_TYPE_SENSOR_TEMP:
					codetext = ((MDC_AI_TYPE_SENSOR_TEMP_flags)code).ToString();
					break;

				default:
					codetext = "";
					break;
			}
			return codetext;
		}

		void clearAll()
		{
			hl7Text.Clear();
			obsListView.Items.Clear();
			hl7 = "";
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			clearAll();
		}

		private void processButton_Click(object sender, EventArgs e)
		{
			process(Hl7Action.Process);
		}

		private void extendButton_Click(object sender, EventArgs e)
		{
			process(Hl7Action.Extend);
		}

		private void compressButton_Click(object sender, EventArgs e)
		{
			process(Hl7Action.Compress);
		}

		private void wrapButton_Click(object sender, EventArgs e)
		{
			hl7Text.WordWrap = wrapButton.Checked;
		}

		private void aboutButton_Click(object sender, EventArgs e)
		{
			AboutBox about = new AboutBox();
			about.ShowDialog();
		}

		private void hl7Text_TextChanged(object sender, EventArgs e)
		{
			lengthText.Text = hl7Text.Text.Length.ToString();
		}

		void resize()
		{
			int height = mainPanel.ClientSize.Height - splitter.Height;

			if (height != height0)
			{
				hl7Group.Height = (int)(split * height);
				obsGroup.Height = (int)((1 - split) * height);
				height0 = height;
			}
		}

		private void mainPanel_Resize(object sender, EventArgs e)
		{
			resize();
		}

		private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
		{
			split = (float)hl7Group.Height / height0;
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Control control = getControl(sender);
			if (control != null)
			{
				if (control == hl7Text)
				{
					hl7Text.Focus();
					hl7Text.SelectAll();
				}
				if (control == obsListView)
				{
					obsListView.Focus();
					foreach (ListViewItem item in obsListView.Items)
					{
						item.Selected = true;
					}
				}
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Control control = getControl(sender);
			if (control != null)
			{
				if (control == hl7Text)
				{
					hl7Text.Copy();
				}
				if (control == obsListView)
				{
					Clipboard.SetText(listViewToString(obsListView));
				}
			}
		}

		private Control getControl(object sender)
		{
			// get menu source control
			ToolStripDropDownItem item = (ToolStripDropDownItem)sender;
			ContextMenuStrip menu = (ContextMenuStrip)item.Owner;
			Control control = menu.SourceControl;
			if (control == null)
			{
				// if null; get currently active control
				control = ActiveControl;
			}
			return control;
		}

		private string listViewToString(ListView listview)
		{
			string s = "";

			foreach (ColumnHeader column in listview.Columns)
			{
				s += column.Text + "\t";
			}
			foreach (ListViewItem item in listview.SelectedItems)
			{
				s += "\r\n";
				for (int i = 0; i < listview.Columns.Count; i++)
				{
					s += item.SubItems[i].Text + "\t";
				}
			}
			return s;
		}

	}
}
