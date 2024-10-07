public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        var answers = new List<IList<string>>();
        var filledCols = new bool[n];
        var queenCords = new List<(int, int)>();

        PlaceAndCheckInRow(queenCords, filledCols, answers);

        return answers;
    }

    private void PlaceAndCheckInRow(
        List<(int, int)> queenCords,
        bool[] filledCols,
        List<IList<string>> answers)
    {
        var rowNum = queenCords.Count();
        var lastQueenBeingPlaced = filledCols.Count() == queenCords.Count + 1;
        
        for(int currCol = 0; currCol < filledCols.Length; currCol++){ 
            if(filledCols[currCol]){
                continue;
            }

            filledCols[currCol] = true;
            var newQueen = (rowNum, currCol);
            if(DiagonalsGood(queenCords, newQueen))
            {
                queenCords.Add(newQueen);
                if(lastQueenBeingPlaced)
                {
                    answers.Add(PrintAnswer(queenCords));
                }
                else
                {
                    PlaceAndCheckInRow(queenCords, filledCols, answers);
                }
                queenCords.Remove(newQueen);
            }

            filledCols[currCol] = false;
        }
    }

    private bool DiagonalsGood(List<(int, int)> queenCords, (int Item1, int Item2) newQueen){
        for(int i = 0; i < queenCords.Count; i++)
        {
            var currQueen = queenCords[i];
            if(Math.Abs(currQueen.Item1 - newQueen.Item1) == Math.Abs(currQueen.Item2 - newQueen.Item2))
            {
                return false;
            }
        }
        return true;
    }

    private List<string> PrintAnswer(List<(int, int)> queenCords){
        var answer = new List<string>();
        queenCords.ForEach(qc =>
        {
            var line = new char[queenCords.Count];
            Array.Fill(line, '.');
            line[qc.Item2] = 'Q';
            answer.Add(new string(line));
        });

        return answer;
    }
}