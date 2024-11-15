namespace CathodeRayTube
{
    internal class Instruction
    {
        private readonly int _cycles;
        private readonly int _value;

        public int Cycles => _cycles;
        public int Value => _value;

        public Instruction(string instruction)
        {
            string[] keyValue = instruction.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            _cycles = keyValue.Length;
            _value = keyValue.Length > 1 ? int.Parse(keyValue[1]) : 0;
        }
    }
}
