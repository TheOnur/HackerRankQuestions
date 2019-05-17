using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace allsquare
{
    class Program
    {
        static void Main()
        {
            int number = 100;
            int power = 3;

            List<string> solutions = new List<string>();
            FindAllSolutions(number, power, solutions);

            foreach (string solution in solutions)
            {
                Console.WriteLine(solution);
            }
            
            Console.ReadLine();
        }

        private static int OtherWay_Recur(int number, int power, int i)
        {
            if (Math.Pow(i, power) < number)
                return OtherWay_Recur(number, power, i + 1) + OtherWay_Recur(number - (int)Math.Pow(i, power), power, i + 1);
            else if (Math.Pow(i, power) == number)
                return 1;
            else
                return 0;
        }
        // best solution ever
        public static void FindAllSolutions(int number, int power, List<string> solutions)
        {
            int flooredRoot = FlooredRoot(number, power);
            List<CandidateSet> mainRoots = FindCandidateSet(flooredRoot);

            foreach (CandidateSet candidateSet in mainRoots)
            {
                SquareStack tmpSolution = new SquareStack { { candidateSet.Candidate, power, true } };

                FindAllSolutions_Recur(number, power, tmpSolution);

                if (tmpSolution.GetTopCandidateSum() == number)
                {
                    string sln = tmpSolution.ToPowerExpression(power);

                    if (!solutions.Any(x => x.Equals(sln)))
                    {
                        solutions.Add(sln);
                    }
                }
            }
        }
        private static void FindAllSolutions_Recur(int number, int power, SquareStack tmpSolution, List<CandidateSet> candidates = null)
        {
            if (tmpSolution.GetTopCandidateSum() == number)
            {
                return;
            }
            else if (tmpSolution.GetTopCandidateSum() > number)
            {
                tmpSolution.RemoveTop();
            }

            if (candidates != null && candidates.All(x => x.IsVisited) && tmpSolution.GetTopCandidateSum() != number)
            {
                tmpSolution.RemoveTop();
                return;
            }

            int flooredRoot = FlooredRoot(number - tmpSolution.GetTopCandidateSum(), power, tmpSolution.GetTopCandidate());

            if (tmpSolution.StackContains(flooredRoot))
            {
                tmpSolution.RemoveTop();
                return;
            }

            candidates = FindCandidateSet(flooredRoot, tmpSolution.GetTopCandidate());

            foreach (CandidateSet candidateSet in candidates.Where(x => x.IsVisited == false).ToList())
            {
                if (tmpSolution.GetTopCandidate() < candidateSet.Candidate)
                {
                    tmpSolution.RemoveTop();
                    return;
                }

                candidateSet.IsVisited = true;
                tmpSolution.Add(candidateSet.Candidate, power);
                FindAllSolutions_Recur(number, power, tmpSolution, candidates);

                if (tmpSolution.GetTopCandidateSum() != number)
                {
                    tmpSolution.RemoveTop();
                }
                else
                {
                    return;
                }
            }
        }
        private static int FlooredRoot(int number, double power, int? top = null)
        {
            if (top.HasValue)
            {
                int calculated = (int)Math.Floor(Math.Pow(number, 1 / power));

                return calculated < top.Value ? calculated : top.Value - 1;
            }
            else
            {
                return (int)Math.Ceiling(Math.Pow(number, 1 / power));
            }
        }
        private static List<CandidateSet> FindCandidateSet(int root, int? top = null)
        {
            List<CandidateSet> candidateSet = new List<CandidateSet>();

            if (top.HasValue && top.Value < root)
            {
                while (top > 0)
                {
                    candidateSet.Add(new CandidateSet
                    {
                        Candidate = top.Value,
                        IsVisited = false
                    });

                    top -= 1;
                }
            }
            else
            {
                while (root > 0)
                {
                    candidateSet.Add(new CandidateSet
                    {
                        Candidate = root--,
                        IsVisited = false
                    });
                }
            }

            return candidateSet;
        }
    }
    public class CandidateSet
    {
        public int Candidate { get; set; }
        public bool IsVisited { get; set; }

        public override string ToString()
        {
            return $"C:{Candidate}, V:{IsVisited}";
        }
    }
    public class SquareStack : Stack
    {
        private Stack<StackData> stack;
        private List<int> list;
        public SquareStack()
        {
            stack = new Stack<StackData>();
            list = new List<int>();
        }
        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
        public void Add(int candidate, int power, bool isMainRoot = false)
        {
            list.Add(candidate);

            if (IsEmpty())
            {
                stack.Push(new StackData
                {
                    Candidate = candidate,
                    CandidateSum = (int)Math.Pow(candidate, power),
                    IsMainRoot = isMainRoot
                });
            }
            else
            {
                stack.Push(new StackData
                {
                    Candidate = candidate,
                    CandidateSum = (int)Math.Pow(candidate, power) + GetTopCandidateSum(),
                    IsMainRoot = isMainRoot
                });
            }
        }
        public int GetTopCandidate()
        {
            if (!IsEmpty())
            {
                return stack.Peek().Candidate;
            }

            return 0;
        }
        public int GetTopCandidateSum()
        {
            if (!IsEmpty())
            {
                return stack.Peek().CandidateSum;
            }

            return 0;
        }
        public void RemoveTop()
        {
            if (!IsEmpty())
            {
                StackData stackData = stack.Peek();

                if (stackData != null && !stackData.IsMainRoot)
                {
                    stack.Pop();
                    list.Remove(stackData.Candidate);
                }
            }
        }
        public string ToPowerExpression(int power)
        {
            StringBuilder sbExp = new StringBuilder();
            List<int> roots = new List<int>();

            while (stack.Count > 0)
            {
                roots.Add(stack.Pop().Candidate);
            }

            roots.OrderBy(x => x).ToList().ForEach(x => { sbExp.AppendFormat("{0}^{1}+", x, power); });

            return sbExp.ToString().Trim('+');
        }
        public bool StackContains(int candidate)
        {
            return list.Any(x => x.Equals(candidate));
        }
        internal class StackData
        {
            public bool IsMainRoot { get; set; }
            public int Candidate { get; set; }
            public int CandidateSum { get; set; }
        }
    }
}
