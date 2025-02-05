public class Solution
{
    public void BFS(ref int[][] image, int sX, int sY, int color)
    {
        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };
        bool[,] visited = new bool[image.Length, image[0].Length];
        Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();

        q.Enqueue(new Tuple<int, int>(sX, sY));
        visited[sX, sY] = true;
        int sColor = image[sX][sY];
        image[sX][sY] = color;
        while(q.Count > 0)
        {
            int cX = q.Peek().Item1;
            int cY = q.Peek().Item2;
            q.Dequeue();

            for(int i = 0; i < 4; i++)
            {
                int nX = cX + dx[i];
                int nY = cY + dy[i];

                if (0 <= nX && nX < image.Length
                    && 0 <= nY && nY < image[0].Length
                    && visited[nX, nY] == false
                    && image[nX][nY] == sColor)
                {
                    image[nX][nY] = color;
                    visited[nX, nY] = true;
                    q.Enqueue(new Tuple<int,int>(nX, nY));
                }
            }
        }
    }
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        BFS(ref image, sr, sc, color);

        return image;
    }
}