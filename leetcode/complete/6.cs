public static string Convert(string s, int numRows)
{
    if(numRows == 1)
    {
        return s;
    }

    var strings = new string[numRows];
    var curDirection = 1;
    var curStringIndex = 0;

    for (int i = 0; i < s.Length; i++)
    {
        strings[curStringIndex] = strings[curStringIndex] + s[i];

        curStringIndex += curDirection;
        if (curStringIndex < 0)
        {
            curDirection = 1;
            curStringIndex = 1;
        }
        else if (curStringIndex >= strings.Length)
        {
            curDirection = -1;
            curStringIndex = strings.Length - 2;
        }
    }

    var answer = "";
    for (int i = 0; i < strings.Length; i++)
    {
        answer += strings[i];
    }

    return answer;
}