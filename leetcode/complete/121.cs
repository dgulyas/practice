//Move through the prices, testing to see if each price is better than the last.
//If it is, update the new best price.
//If a new lower price is found, reset highest price to that price as well.
//This works because if the highest price in the nums is behind, we'll already
//have found the best price, and if it's still to come, we have a new lower
//price to use with it.
//It's late, and I'm feeling stupid. I hope this makes sense.

public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Count() < 2){
            return 0; //Can't buy and sell
        }
        var lowestPrice = prices[0];
        var highestPrice = prices[1];
        var bestPrice = highestPrice <= lowestPrice ? 0 : highestPrice - lowestPrice;
        
        for(int i = 1; i < prices.Count(); i++){
            if(prices[i] > highestPrice){
                highestPrice = prices[i];
                var possibleBestPrice = highestPrice <= lowestPrice ? 0 : highestPrice - lowestPrice;
                if(possibleBestPrice > bestPrice){
                    bestPrice = possibleBestPrice;
                }
            }
            if(prices[i] < lowestPrice){
                lowestPrice = prices[i];
                highestPrice = prices[i];
            }
        }
        return bestPrice;
    }
}