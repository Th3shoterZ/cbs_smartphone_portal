using SmartphonePortal_WV_KW.Client.Models;

namespace SmartphonePortal_WV_KW.Client
{
    // TODO: does it notify when deep state gets modified?
    public class StateContainer
    {
        private State state = new();

        public State Property
        {
            get => state;
            set
            {
                state = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
