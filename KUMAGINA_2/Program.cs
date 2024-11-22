namespace KUMAGINA_2
{
    internal class Program
    {
        private Dictionary<int, List<int>> tree;
        private Dictionary<int, int> A;
        private Dictionary<int, int> B;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.IsConsistent();
        }

        public Program()
        {
            tree = new Dictionary<int, List<int>>();
            A = new Dictionary<int, int>();
            B = new Dictionary<int, int>();
            tree[0] = new List<int> { 1, 2, 3 };
            tree[1] = new List<int> { 4, 5 };
            tree[2] = new List<int> { 6 };
            tree[3] = new List<int> { 7, 8, 9 };
            tree[4] = null;
            tree[5] = null;
            tree[6] = null;
            tree[7] = null;
            tree[8] = null;
            tree[9] = null;

            A[0] = 19;
            B[0] = 25;
            A[1] = 7;
            B[1] = 9;
            A[2] = 2;
            B[2] = 4;
            A[3] = 15;
            B[3] = 18;
            A[4] = 3;
            B[4] = 5;
            A[5] = 2;
            B[5] = 4;
            A[6] = 1;
            B[6] = 3;
            A[7] = 5;
            B[7] = 7;
            A[8] = 4;
            B[8] = 6;
            A[9] = 2;
            B[9] = 5;
        }

        private bool IsConsistent()
        {
            var Ap = new Dictionary<int, int>();
            var Bp = new Dictionary<int, int>();
            DFS__A(0, new HashSet<int>(), Ap);
            DFS__B(0, new HashSet<int>(), Bp);
            foreach (var kvp in Ap)
            {
                if (kvp.Value > Bp[kvp.Key])
                {
                    return false;
                }
            }

            return true;
        }

        private void DFS__A(
            int node,
            HashSet<int> visited,
            Dictionary<int, int> dict
        )
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);

            int value = 0;
            if (tree[node] != null)
            {
                int sum = 0;
                foreach (var child in tree[node])
                {
                    DFS__A(child, visited, dict);
                    sum += dict[child];
                }
                value = Math.Max(A[node], sum);
            }
            else
            {
                value = A[node];
            }
            dict[node] = value;
        }

        private void DFS__B(
            int node,
            HashSet<int> visited,
            Dictionary<int, int> dict
        )
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);

            int value = 0;
            if (tree[node] != null)
            {
                int sum = 0;
                foreach (var child in tree[node])
                {
                    DFS__B(child, visited, dict);
                    sum += dict[child];
                }
                value = Math.Min(B[node], sum);
            }
            else
            {
                value = B[node];
            }
            dict[node] = value;
        }
    }
}
