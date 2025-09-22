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
        CalculateSubarray();
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
    
    public void CalculateSubarray()
    {
        int sequenceLength = 1;
        int index = _maxElementIndex;
        int sum = 0;
        int maxSubarrayIndex = _maxElementIndex;
        int maxSubarrayValue = _maxElementValue;
        int maxSequenceLength = 1;
        
        for (int i = 0; i < _arr.Length; i++)
        {
            if (_arr[i] > 0)
            {
                sum += _arr[i];
                
                if (index < 0) index = i;

                else sequenceLength++;
            }
            else
            {
                if (sum > maxSubarrayValue)
                {
                    maxSubarrayIndex = index;
                    maxSubarrayValue = sum;
                    maxSequenceLength = sequenceLength;
                }
                
                sum = 0;
                index = -1;
                sequenceLength = 1;
            }
        }

        _subarray = new int[maxSequenceLength];

        for (int i = 0; i < maxSequenceLength; i++)
        {
            _subarray[i] = _arr[i + maxSubarrayIndex];
        }
    }
}