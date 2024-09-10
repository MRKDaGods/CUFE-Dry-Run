using MRK.Models;
using MRK.Views;
using System.Drawing;
using System.Windows.Forms;

namespace MRK
{
    public class CourseButton
    {
        private static readonly Color SameGroupColor = Color.FromArgb(184, 134, 11);
        private static readonly Color DiffGroupColor = Color.FromArgb(85, 107, 47);
        private static readonly Color SelectedColor = Color.FromArgb(211, 84, 0);

        private readonly Button _button;
        private bool _clashing;
        private readonly Color _backColor;
        private bool _selected;

        private TimeTableView Owner { get; init; }
        public CourseRecord Record { get; init; }
        public bool IsClashing => _clashing && Record.Selected;
        public Button Button => _button;
        public Color BackColor => _selected ? SelectedColor : _backColor;

        public CourseButton(TimeTableView owner, Button button, CourseRecord record)
        {
            _button = button;
            Owner = owner;
            Record = record;

            _button.MouseEnter += (_, _) => Owner.SetHoveredRecord(this, true);
            _button.MouseLeave += (_, _) => Owner.SetHoveredRecord(this, false);

            _backColor = _button.BackColor;

            _button.Click += (_, _) => OnClick();
        }

        /// <summary>
        /// UI ONLY
        /// </summary>
        private void SetSelected(bool selected)
        {
            _selected = selected;

            _button.FlatAppearance.BorderColor = selected ? Color.FromArgb(255, 215, 0) : Color.White;
            _button.Font = new Font(_button.Font, selected ? FontStyle.Bold : FontStyle.Regular);

            _button.BackColor = BackColor;
            _button.ForeColor = Color.White;
        }

        private void OnClick()
        {
            CourseManager.Instance.SelectCourseRecord(Record, out var deselected);

            if (deselected != null)
            {
                var other = Owner.CourseButtons.Find(x => x.Record == deselected);
                other?.SetSelected(false);
            }

            if (deselected != Record)
            {
                SetSelected(true);
            }

            Owner.CheckClashes();
            Owner.UpdateCourseList();
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
            _button.BackColor = hovered ? (sameGroup ? SameGroupColor : DiffGroupColor) : BackColor;
        }
    }
}
