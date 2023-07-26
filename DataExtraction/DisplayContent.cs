
namespace DataExtraction
{
    /// <summary>
    /// 控制台输出信息类
    /// </summary>
    internal static class DisplayContent
    {
        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="content"></param>
        /// <param name="isTure">true输出绿色，false输出灰色</param>
        public static void PrintContent(string content, bool isTure)
        {
            switch (isTure)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine(content);
            Console.ResetColor();
        }
        /// <summary>
        /// 输出红色错误信息
        /// </summary>
        /// <param name="errorText"></param>
        public static void PrintContent(string errorText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorText);
            Console.ResetColor();
        }
    }
}
