using System.ComponentModel;

namespace MedHair.ClassLibrary.ViewModel
{
    public class HairSettings_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _lengthOfTelogenHair = 300;
        public int LengthOfTelogenHair
        {
            get { return _lengthOfTelogenHair; }
            set
            {
                _lengthOfTelogenHair = value;
                OnPropertyChanged("LengthOfTelogenHair");
            }
        }

        private int _diameterOfVelusTerminal = 30;
        public int DiameterOfVelusTerminal
        {
            get { return _diameterOfVelusTerminal; }
            set
            {
                _diameterOfVelusTerminal = value;
                OnPropertyChanged("DiameterOfVelusTerminal");

                if(_diameterOfVelusTerminal > _diameterOfTerminalsThinMedium)
                {
                    DiameterOfTerminalsThinMedium = _diameterOfVelusTerminal;
                }
            }
        }

        private int _diameterOfTerminalsThinMedium = 60;
        public int DiameterOfTerminalsThinMedium
        {
            get { return _diameterOfTerminalsThinMedium; }
            set
            {
                _diameterOfTerminalsThinMedium = value;
                OnPropertyChanged("DiameterOfTerminalsThinMedium");

                if(DiameterOfVelusTerminal > _diameterOfTerminalsThinMedium)
                {
                    DiameterOfVelusTerminal = _diameterOfTerminalsThinMedium;
                }
                if(_diameterOfTerminalsThinMedium > DiameterOfTerminalsMediumThick)
                {
                    DiameterOfTerminalsMediumThick = _diameterOfTerminalsThinMedium;
                }
            }
        }

        private int _diameterOfTerminalsMediumThick = 80;
        public int DiameterOfTerminalsMediumThick
        {
            get { return _diameterOfTerminalsMediumThick; }
            set
            {
                _diameterOfTerminalsMediumThick = value;
                OnPropertyChanged("DiameterOfTerminalsMediumThick");

                if (DiameterOfTerminalsThinMedium > _diameterOfTerminalsMediumThick)
                {
                    DiameterOfTerminalsThinMedium = _diameterOfTerminalsMediumThick;
                }
            }
        }

        private int _radiusOfFollicularUnits = 0;
        public int RadiusOfFollicularUnits
        {
            get { return _radiusOfFollicularUnits; }
            set
            {
                _radiusOfFollicularUnits = value;
                OnPropertyChanged("RadiusOfFollicularUnits");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
