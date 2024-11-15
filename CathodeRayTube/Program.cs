using CathodeRayTube;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = ReadEmbeddedResource("CathodeRayTube.input.txt");
        List<Instruction> instructions = GetInstructions(input);
        Dictionary<int, int> cycles = GetCycles(instructions);
        int sum = SumSignalStrengths(cycles, [20, 60, 100, 140, 180, 220]);
        Console.WriteLine("Sum: " + sum);
    }

    private static int SumSignalStrengths(Dictionary<int, int> cycles, int[] cycleIndexes)
    {
        int sum = 0;

        for (int i = 0; i < cycleIndexes.Length; i++)
        {
            sum += cycles[cycleIndexes[i] - 1] * (cycleIndexes[i]);
        }

        return sum;
    }

    private static Dictionary<int, int> GetCycles(List<Instruction> instructions)
    {
        Dictionary<int, int> cycles = new Dictionary<int, int>();
        int x = 1;

        for (int i = 0; i < instructions.Count; i++)
        {
            for (int c = 0; c < instructions[i].Cycles; c++)
            {
                cycles.Add(cycles.Count, x);
            }
            x += instructions[i].Value;
        }

        return cycles;
    }

    private static List<Instruction> GetInstructions(string input)
    {
        return input
            .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(instructionString => new Instruction(instructionString))
            .ToList();
    }

    private static string ReadEmbeddedResource(string resourceName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream? stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");
        }

        using StreamReader reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}