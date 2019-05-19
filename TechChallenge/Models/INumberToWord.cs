namespace TechChallenge.Models
{
    public interface INumberToWord
    {
        /// <summary>
        /// Convert decimal to word
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        InputNumber ConvertNumberToWord(string name, decimal number);
    }
}
