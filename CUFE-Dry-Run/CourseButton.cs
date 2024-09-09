using MRK.Models;
using System.Drawing;
using System.Windows.Forms;

namespace MRK
{
    public class CourseButton
    {
        private readonly Button _button;
        private bool _clashing;
        private readonly Color _backColor;
        private bool _selected;

        public CourseRecord Record { get; init; }
        public bool IsClashing => _clashing && Record.Selected;
        public Button Button => _button;
        public Color BackColor => _selected ? Color.OrangeRed : _backColor;
        private Main ParentInstance => Main.Instance;

        public CourseButton(Button button, CourseRecord record)
        {
            _button = button;
            Record = record;

            _button.MouseEnter += (_, _) => ParentInstance.SetHoveredRecord(this, true);
            _button.MouseLeave += (_, _) => ParentInstance.SetHoveredRecord(this, false);

            _backColor = _button.BackColor;

            _button.Click += (_, _) => OnClick();
        }

        /// <summary>
        /// UI ONLY
        /// </summary>
        private void SetSelected(bool selected)
        {
            _selected = selected;

            _button.FlatAppearance.BorderColor = selected ? Color.GreenYellow : Color.White;
            _button.Font = new Font(_button.Font, selected ? FontStyle.Bold : FontStyle.Regular);

            _button.BackColor = BackColor;
            _button.ForeColor = Color.White;
        }

        private void OnClick()
        {
            ParentInstance.CourseManager.SelectCourseRecord(Record, out var deselected);

            if (deselected != null)
            {
                var other = ParentInstance.CourseButtons.Find(x => x.Record == deselected);
                other?.SetSelected(false);
            }

            if (deselected != Record)
            {
                SetSelected(true);
            }

            ParentInstance.CheckClashes();
            ParentInstance.UpdateCourseList();
        }

        public void SetClashing(bool clashing)
        {
            _clashing = clashing;

            if (_clashing)
            {
                _button.FlatAppearance.BorderColor = Color.Red;
                _button.Font = new Font(_button.Font, FontStyle.Bold | FontStyle.Strikeout);
                _button.ForeColor = Color.Red;
            }
            else
            {
                SetSelected(Record.Selected);
            }
        }

        public void SetHoveredStatus(bool hovered, bool sameGroup)
        {
            _button.BackColor = hovered ? Color.FromArgb(sameGroup ? 255 : 128, 123, 220, 93) : BackColor;
        }
    }
}
