using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMedii
{
    class RequiredValidationBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = !string.IsNullOrWhiteSpace(e.NewTextValue);

           // ((Entry)sender).TextColor = isValid ? null : Color.Red;
            // You can also handle validation messages or perform other actions based on isValid
        }
    }
}
