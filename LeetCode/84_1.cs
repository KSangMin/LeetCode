public class _84_1
{
    public int LargestRectangleArea(int[] heights)
    {
        return Find(ref heights, 0, heights.Length - 1);
    }

    public int Find(ref int[] hist, int left, int right)
    {
        if (left == right) return hist[left];
        int mid = (left + right) / 2;
        int i = mid, j = mid + 1;

        int minH = Math.Min(hist[i], hist[j]);
        int ans = minH * 2;

        while (left < i || j < right)
        {
            if (i == left && j < right) j++;
            else if (j == right && left < i) i--;
            else if (hist[i - 1] < hist[j + 1]) j++;
            else i--;

            minH = Math.Min(minH, Math.Min(hist[i], hist[j]));
            ans = Math.Max(ans, minH * (j - i + 1));
        }

        return Math.Max(ans, Math.Max(Find(ref hist, left, mid), Find(ref hist, mid + 1, right)));
    }
}