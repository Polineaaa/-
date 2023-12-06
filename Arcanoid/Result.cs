using System.ComponentModel;

public class Result : INotifyPropertyChanged
{
    private string _name;
    public string NAME
    {
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(NAME));
            }
        }
    }

    private int _result;
    public int RESULT
    {
        get { return _result; }
        set
        {
            if (_result != value)
            {
                _result = value;
                OnPropertyChanged(nameof(RESULT));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}