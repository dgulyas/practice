public class Solution {
    public bool IsValidSudoku(char[][] board) {
        for(int i = 0; i < 9; i++){
            if(!RowIsGood(board, i) || !ColIsGood(board, i)){
                return false;
            }
        }

        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                if(!BoxIsGood(board, i, j)){
                    return false;
                }
            }
        }

        return true;
    }

    public bool RowIsGood(char[][] board, int rowNum){
        var seenValues = new bool[10];
        for(int i = 0; i < 9; i++){
            
            if(!char.IsDigit(board[rowNum][i])){
                continue;
            }
            int cellInt = board[rowNum][i] - 48;
            if(seenValues[cellInt]){
                return false;
            }
            seenValues[cellInt] = true;
        }
        return true;
    }

    public bool ColIsGood(char[][] board, int colNum){
        var seenValues = new bool[10];
        for(int i = 0; i < 9; i++){
            if(!char.IsDigit(board[i][colNum])){
                continue;
            }
            int cellInt = board[i][colNum] - 48;
            
            if(seenValues[cellInt]){
                return false;
            }
            seenValues[cellInt] = true;
        }
        return true;
    }

    public bool BoxIsGood(char[][] board, int rowNum, int colNum){
        var seenValues = new bool[10];
        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                if(!char.IsDigit(board[rowNum*3 + i][colNum*3 + j])){
                    continue;
                }
                int cellInt = board[rowNum*3 + i][colNum*3 + j] - 48;
                
                if(seenValues[cellInt]){
                    return false;
                }
                seenValues[cellInt] = true;
            }    
        }
        return true;
    }
}