public class _84_2
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> s = new Stack<int>();
        int m = 0;

        for(int i = 0; i <= heights.Length; i++)
        {
            int h = i < heights.Length ? heights[i] : 0;

            while(s.Any() && heights[s.Peek()] > h)
            {
                int minH = heights[s.Pop()];
                int prevId  = s.Any() ? s.Peek() : -1;
                m = Math.Max(m, minH * (i - 1 - prevId));
            }
            s.Push(i);
        }

        return m;
    }
}