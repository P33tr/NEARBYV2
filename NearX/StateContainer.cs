namespace NearX
{
    public class StateContainer
    {
        private string? _userName;
        private string _userId;

        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set
            {
                _userId = value;
                NotifyStateChanged();
            }    
        }

        public string UserName
        {
            get { return _userName ?? string.Empty; }
            set
            {
                _userName = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
