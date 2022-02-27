namespace NearX
{
    public class StateContainer
    {
        private string? _userName;
        private string _userId;

        private int _reviewCount;

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

        public int ReviewCount
        {
            get => _reviewCount;
            set
            {
                _reviewCount = value;
                NotifyStateChanged();
            }
        }
        

        public event Action OnChange;

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
