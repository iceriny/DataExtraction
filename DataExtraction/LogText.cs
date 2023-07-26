
namespace DataExtraction
{
    /// <summary>
    /// 主处理类
    /// </summary>
    internal class LogText
    {
        /// <summary>
        /// 默认路径，空字符串为程序根目录
        /// </summary>
        readonly string path = "";
        /// <summary>
        /// 声明一个 键为行数 值为三个数字的字符串数组 的字典类型；
        /// </summary>
        readonly Dictionary<int, string[]> logData = new();

        /// <summary>
        /// 使用默认路径加载文件的构造函数
        /// </summary>
        public LogText() { }
        /// <summary>
        /// 使用自定义路径加载文件的构造函数
        /// </summary>
        /// <param name="FilePath"></param>
        public LogText(string FilePath)
        {
            path = FilePath;
        }

        /// <summary>
        /// 读取源数据文件方法
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回布尔值为是否成功</returns>
        public bool ReadData(string fileName)
        {
            //文件读取类声明
            StreamReader sr = new(path + fileName + ".log");
            string? line;
            int lineNumber = 0;//行计数
            try
            {
                while ((line = sr.ReadLine()) != null)//循环逐行读取文本
                {
                    lineNumber++;//行计数
                    if (line.StartsWith(" IR Inten"))//查找开头是" IR Inten"的行
                    {
                        //空格分割行
                        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 6)//如果分割后为6个元素
                        {
                            DisplayContent.PrintContent(line, true);//打印到控制台
                            string[] data = new string[3];//单个数据组；3个数据
                            data[0] = parts[3];
                            data[1] = parts[4];
                            data[2] = parts[5];
                            //将行数作为键，数据组作为值，添加到logData字典
                            logData.Add(lineNumber, data);
                        }
                    }

                }
                //如果结果大于0，则返回true;
                if (logData.Count > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)//异常处理
            {
                DisplayContent.PrintContent($"在读取数据环节发生错误：{ex.Message} \n请按任意键继续。");
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// 将处理后数据输出到文件的方法
        /// </summary>
        /// <param name="outPutFileName">输出文件名</param>
        /// <returns>表示是否成功</returns>
        public bool WriteData(string outPutFileName)
        {

            try
            {
                string _path = @"Output\" + outPutFileName + ".txt";
                string? directoryPath = string.Empty;
                // 检查目录是否存在，如果不存在，则创建目录
                if (!string.IsNullOrEmpty(_path))
                {
                    directoryPath = Path.GetDirectoryName(_path);
                }
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                StreamWriter sw = new(@"Output\" + outPutFileName + ".txt");//文件写入类声明
                foreach (var data in logData)//遍历字典，data为键值对
                {
                    string key = $"第 {data.Key} 行:";//格式化行开头；
                    sw.WriteLine($"{key, -14}   IR Inten    --    {data.Value[0], -10}        {data.Value[1], -10}        {data.Value[2], -10}");//格式化文本，行开头为14个占位的左对齐，其他数据为10个占位的左对齐
                }
                return true;
            }
            catch (Exception ex)//异常处理
            {
                DisplayContent.PrintContent($"在写入数据环节发生错误：{ex.Message} \n请按任意键继续。");
                Console.ReadKey();
                return false;
            }
        }


    }
}
