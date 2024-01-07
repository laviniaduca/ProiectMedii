using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMedii
{
    public class ValidationBehavior : Behavior<View>
    {
        protected override void OnAttachedTo(View view)
        {
            if (view is Entry entry)
            {
                entry.TextChanged += OnTextChanged;
            }
            else if (view is Editor editor)
            {
                editor.TextChanged += OnTextChanged;
            }
            else if (view is DatePicker datePicker)
            {
                datePicker.DateSelected += OnDateSelected;
            }
            /*else if (view is TimePicker timePicker)
            {
                timePicker.Time += OnTimeSelected; // sa o las ?
            }*/

            base.OnAttachedTo(view);
        }

        protected override void OnDetachingFrom(View view)
        {
            if (view is Entry entry)
            {
                entry.TextChanged -= OnTextChanged;
            }
            else if (view is DatePicker datePicker)
            {
                datePicker.DateSelected -= OnDateSelected;
            }
            else if (view is Editor editor)
            {
                editor.TextChanged -= OnTextChanged;
            }
            // Detach from other view events as needed

            base.OnDetachingFrom(view);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Your validation logic for Entry fields
                entry.BackgroundColor = string.IsNullOrEmpty(e.NewTextValue) ? Color.FromRgb(170, 74, 68) : Color.FromRgba(255, 255, 255, 255); ;
            }
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                // Your validation logic for DatePicker fields
                datePicker.TextColor = e.NewDate == DateTime.MinValue ? Color.FromArgb("170,74,68") : null;
            }
        }

        // Add similar methods for other types of views (e.g., TimePicker, Picker) as needed
    }

}
