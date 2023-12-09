using System.CommandLine;

namespace svan_sort
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var inputOption = new Option<DirectoryInfo>(
                aliases: new[] {"--input", "-i"},
                description: "Путь к входной папке")
            {
                IsRequired = true 
            };

            var outputOption = new Option<DirectoryInfo>(
                aliases: new[] {"--out", "-o"},
                description: "Путь к выходной папке")
            {
                IsRequired = true 
            };

            var rootCommand = new RootCommand("Показывает полные пути к папкам");
            rootCommand.AddOption(inputOption);
            rootCommand.AddOption(outputOption);

            rootCommand.SetHandler((input, output) =>
                {
                    string fullInputPath = Path.GetFullPath(input.FullName);
                    string fullOutputPath = Path.GetFullPath(output.FullName);
                
                    Console.WriteLine($"Полный путь к входной папке: {fullInputPath}");
                    Console.WriteLine($"Полный путь к выходной папке: {fullOutputPath}");
                },
                inputOption, outputOption);

            return await rootCommand.InvokeAsync(args);
        }
    }
}