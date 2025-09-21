namespace AlgorithmicLab.SubarrayMaxSum;

public class SubarrayResolver
{
    private int[] _arr;
    private int _maxElementValue;
    private int _maxElementIndex;
    private int[] _subarray;
    public int MaxElementValue => _maxElementValue;
    public int MaxElementIndex => _maxElementIndex;
    public int[] Subarray => _subarray;

    //[1, -2, 3, 5, -1]
    public SubarrayResolver(int[] arr)
    {
        _arr = arr;
        _maxElementValue = _arr[0];
        _maxElementIndex = 0;

        CalculateMaxElementValueAndIndex();
    }

    public void CalculateMaxElementValueAndIndex()
    {
        for (int i = 1; i < _arr.Length; i++)
        {
            if (_arr[i] > _maxElementValue)
            {
                _maxElementValue = _arr[i];
                _maxElementIndex = i;
            }
        }
    }
    
    public int GetSubarrayMaxSum()
    {
        int sequenceLength = 0;
        int index = 0;
        int sum = 0;
        
        for (int i = 0; i < _arr.Length; i++)
        {
            if (_arr[i] > 0)
            {
                sum += _arr[i];
                index = index == _maxElementIndex ? index : i;
                sequenceLength++;
            }
            else
            {
                _maxElementValue = _maxElementValue > sum ? _maxElementValue : sum;
                sum = 0;
                index = _maxElementIndex;
                sequenceLength = 0;
            }
        }
        _subarray = new int[sequenceLength];

        for (int i = index; i < sequenceLength + index; i++)
        {
            _subarray[i] = _arr[i];
        }
        return _maxElementValue;
    }
}