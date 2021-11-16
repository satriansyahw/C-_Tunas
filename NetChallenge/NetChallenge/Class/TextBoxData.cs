using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Class
{

    public class TextBoxData : INotifyPropertyChanged
    {
        private string textBoxA;
        private string textBoxB;
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        public string TextBoxA
        {
            get { return textBoxA; }
            set
            {
                textBoxA = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public string TextBoxB
        {
            get { return textBoxB; }
            set
            {
                textBoxB = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            if(name== "TextBoxA")
            {
                textBoxB = textBoxA;
            }
            else if (name == "TextBoxB")
            {
                textBoxA = textBoxB;
            }
        }
    }
   
}
