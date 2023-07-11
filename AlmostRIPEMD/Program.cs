using RIPEMD_160;
namespace AlmostRIPEMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(HashDirectory.GetHash("0100010010100101110001010111010"));
        }
    }
}