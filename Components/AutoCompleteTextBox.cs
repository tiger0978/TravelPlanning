using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點規劃.Components
{
    using GoogleMapAPI.Places;
    using GoogleMapAPI.Places.PlaceAutoComplete;
    using GoogleMapAPI.Places.PlaceDetail;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using 旅遊景點規劃.Events;

    namespace TubeUploader
    {
        public class AutoCompleteTextBox : TextBox
        {
            private ListBox _listBox;
            private bool _isAdded;
            private List<AutoCompleteTextBoxData> _values;
            private String _formerValue = String.Empty;
            public EventHandler<PlaceDetailResponse> SelectedItem;

            public AutoCompleteTextBox()
            {
                InitializeComponent();
                ResetListBox();
            }

            private void InitializeComponent()
            {
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _listBox
            // 
            this._listBox.ItemHeight = 20;
            this._listBox.Location = new System.Drawing.Point(0, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(120, 96);
            this._listBox.TabIndex = 0;
            this._listBox.SelectedIndexChanged += new System.EventHandler(this._listBox_SelectedIndexChanged);
            this._listBox.DoubleClick += new System.EventHandler(this._listBox_DoubleClick);
            KeyDown += this_KeyDown;
            this.ResumeLayout(false);
            }

            private void ShowListBox()
            {
                if (!_isAdded)
                {
                    Parent.Controls.Add(_listBox);
                    // 原版寫法，長在下面
                    //_listBox.Left = Left;
                    //_listBox.Top = Top + Height;
                    _listBox.Left = Right;
                    _listBox.Top = 0;
                    _isAdded = true;
                }
                _listBox.Visible = true;
                _listBox.BringToFront();
            }

            private void ResetListBox()
            {
                _listBox.Visible = false;
            }

            private void this_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                    case Keys.Tab:
                        {
                            if (_listBox.Visible)
                            {
                                AutoCompleteTextBoxData item = (AutoCompleteTextBoxData)_listBox.SelectedItem;
                                this.Text = item.Key;
                                SendPlaceDetail(item.Value);
                                //InsertWord((String)_listBox.SelectedItem);
                                ResetListBox();
                                _formerValue = Text;
                            }
                            break;
                        }
                    case Keys.Down:
                        {
                            if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                                _listBox.SelectedIndex++;

                            break;
                        }
                    case Keys.Up:
                        {
                            if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                                _listBox.SelectedIndex--;

                            break;
                        }
                }
            }

            protected override bool IsInputKey(Keys keyData)
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        return true;
                    default:
                        return base.IsInputKey(keyData);
                }
            }

            private void UpdateListBox()
            {
                if (Text == _formerValue) return;

                _formerValue = Text;
                _listBox.DataSource = _values;
                _listBox.DisplayMember = "Key";
                _listBox.ValueMember = "Value";
                ShowListBox();
                _listBox.Width = this.Size.Width;
            }

            private String GetWord()
            {
                String text = Text;
                int pos = SelectionStart;

                int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
                posStart = (posStart == -1) ? 0 : posStart + 1;
                int posEnd = text.IndexOf(' ', pos);
                posEnd = (posEnd == -1) ? text.Length : posEnd;

                int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

                return text.Substring(posStart, length);
            }

            private void InsertWord(String newTag)
            {
                String text = Text;
                int pos = SelectionStart;

                int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
                posStart = (posStart == -1) ? 0 : posStart + 1;
                int posEnd = text.IndexOf(' ', pos);

                String firstPart = text.Substring(0, posStart) + newTag;
                String updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


                Text = updatedText;
                SelectionStart = firstPart.Length;
            }

            public List<AutoCompleteTextBoxData> Values
            {
                get
                {
                    return _values;
                }
                set
                
                {
                    _values = value;
                    UpdateListBox();
                }
            }

            public List<String> SelectedValues
            {
                get
                {
                    String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    return new List<String>(result);
                }
            }

            private void _listBox_DoubleClick(object sender, EventArgs e)
            {
                if (_listBox.Visible)
                {
                    AutoCompleteTextBoxData item = (AutoCompleteTextBoxData)_listBox.SelectedItem;
                    this.Text = item.Key;
                    SendPlaceDetail(item.Value);

                    ResetListBox();
                    _formerValue = Text;
                }
            }

            private void _listBox_SelectedIndexChanged(object sender, EventArgs e)
            {

            }
            private async void SendPlaceDetail(object itemValue)
            {
                PlaceAutoCompleteRespnse.Prediction prediction = (PlaceAutoCompleteRespnse.Prediction)itemValue;
                PlaceDetailResponse placeDetail = await PlaceService.PlaceDetail(prediction.place_id);
                //PlaceEvent.SelectPlaceItem(placeDetail);
                SelectedItem.Invoke(this, placeDetail);
            }
        }
    }
}
