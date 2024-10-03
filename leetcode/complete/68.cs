public class Solution {
    public IList<string> FullJustify(string[] wordsArray, int maxWidth) {
        var answer = new List<string>();
        var words = wordsArray.ToList();
        
        while(words.Count > 0){
            var nextWords = GetNextWords(words, maxWidth);
            var nextLine = CreateNextLine(nextWords, maxWidth, words.Count <= 0);
            answer.Add(nextLine);
        }

        return answer;
    }

    private List<string> GetNextWords(List<string> words, int maxWidth){
        var currLength = 0;
        var nextWords = new List<string>();
        while(true){
            if(words.Count == 0){
                return nextWords;
            }
            if(currLength + words[0].Length > maxWidth){
                return nextWords;
            }else{
                nextWords.Add(words[0]);
                currLength += words[0].Length + 1;
                words.RemoveAt(0);
            }
        }
    }

    private string CreateNextLine(List<string> nextWords, int maxWidth, bool lastLine){
        var nextLine = "";
        if(lastLine){
            for(int i = 0; i < nextWords.Count - 1; i++){
                nextLine += nextWords[i];
                nextLine += " ";
            }
            nextLine += nextWords[nextWords.Count - 1];
            nextLine += new string(' ', maxWidth - nextLine.Length);
            return nextLine;
        }
        
        if(nextWords.Count < 2){
            return nextWords[0] + new string(' ', maxWidth - nextWords[0].Count());
        }
        
        var numLetters = 0;
        nextWords.ForEach(w => numLetters += w.Length);
        var numSpaces = maxWidth - numLetters;
        var numSpBetweenWords = numSpaces / (nextWords.Count - 1);
        var numExtraSpaces = numSpaces % (nextWords.Count - 1);

        for(int i = 0; i < nextWords.Count - 1; i++){
            nextLine += nextWords[i];
            nextLine += new string(' ', numSpBetweenWords);
            if(i <= numExtraSpaces - 1){
                nextLine += " ";
            }
        }
        nextLine += nextWords[nextWords.Count - 1];

        return nextLine;
    }
}