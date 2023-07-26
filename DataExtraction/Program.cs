// See https://aka.ms/new-console-template for more information
using DataExtraction;

Console.WriteLine("数据提取程序");
Console.WriteLine("-------------------------");
Console.WriteLine();

//声明主功能类
LogText logText;

//状态表示，表示是否读取或写入成功。
bool state = false;

do
{
    Console.WriteLine("请输入Log文件所在路径，直接回车则为程序根目录下“SourceFile”中");
    string? soutceFilePath = Console.ReadLine();//获取用户输入


    if (!string.IsNullOrWhiteSpace(soutceFilePath))//判断用户输入是否为null或空字符串。
    {
        logText = new();
    }
    else
    {
        string readPath = @"SourceFile\";
        logText = new(readPath);
    }


    Console.WriteLine("请输入Log文件名称，不包括‘.log’");
    string? fileName = Console.ReadLine();//获取用户输入

    if (!string.IsNullOrWhiteSpace(fileName))//判断用户输入是否为null或空字符串。
    {
        state = logText.ReadData(fileName);//读取数据，并得到读取状态。
    }
    else
    {
        Console.WriteLine("文件名不可为空，请重新输入");
    }
    if (!state)
    {
        Console.WriteLine("异常，请重新开始。");
    }
} while (!state);



string? outputFileName;

do
{
    Console.WriteLine("请输入输出文件名称，不包括拓展名");
    outputFileName = Console.ReadLine();//获取用户输入

    if (string.IsNullOrEmpty(outputFileName))//判断用户输入是否为null或空字符串。
    {
        Console.WriteLine("文件名不可为空，请重新输入");
    }
    else
    {
        logText.WriteData(outputFileName);//写入处理后数据文件。
    }
} while (string.IsNullOrEmpty(outputFileName));
