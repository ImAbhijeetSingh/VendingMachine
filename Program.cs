using System;

namespace CompressorDecompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            // ================== File Compressor and Decompressor ======================
            string nullTest = null;
            Console.WriteLine(FileCompressor(nullTest));            // Your string is null.
            Console.WriteLine(FileCompressor(""));                  // Your string is empty.
            Console.WriteLine(FileCompressor("RTFFFFYYUPPPEEEUU")); // RTF4YYUP3E3UU
            Console.WriteLine(FileCompressor("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBCCCCCCCCCCC"));    // A100BBC11
            Console.WriteLine(FileCompressor("AMAAAAN"));           // AMA4N
            Console.WriteLine("");

            Console.WriteLine(FileDecompressor(nullTest));     // Your string is null.
            Console.WriteLine(FileDecompressor(""));           // Your string is empty.
            Console.WriteLine(FileDecompressor("A11BBC3D4"));  // AAAAAAAAAAABBCCCDDDD
            Console.WriteLine(FileDecompressor("AMA4N"));      // AMAAAAN
            Console.WriteLine(FileDecompressor("AAB5CCD4"));   // AABBBBBCCDDDD
            Console.WriteLine(FileDecompressor("A100BBC11"));  // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABBCCCCCCCCCCC
        
        }
        static string FileCompressor(string str)
        {
            Console.WriteLine($"\n====================== Compressing file: {str} ======================");
            if (str == null)
            {
                return ("Your string is null.");
            }
            if (str.Length == 0)
            {
                return ("Your string is empty.");
            }
            str += " ";
            string fileName = "";
            int charCount = 1;
            int temp;
            for (int i = 1; i < str.Length; i++)
            {
                if (charCount < 3)
                {
                    fileName += str[i - 1];
                }
                else
                {
                    temp = charCount - 1;
                    while (temp != 0)
                    {
                        fileName = fileName.Remove(fileName.Length - 1);
                        temp /= 10;
                    }
                    fileName += charCount;
                }

                if (str[i - 1] == str[i])
                {
                    charCount++;
                }
                else
                {
                    charCount = 1;
                }
            }
            return fileName;
        }

        static bool isNum(char c)
        {
            int charToASCII = Convert.ToInt32(c);
            if (charToASCII > 47 && charToASCII < 58)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string FileDecompressor(string str)
        {
            Console.WriteLine($"\n====================== Decompressing file: {str} ======================");
            if (str == null)
            {
                return ("Your string is null.");
            }
            if (str.Length == 0)
            {
                return ("Your string is empty.");
            }
            str += " ";
            int count = 0;
            string fileName = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (!isNum(str[i]))
                {
                    fileName += str[i];
                }

                while (isNum(str[i]))
                {
                    count *= 10;
                    count += (str[i] - 48);
                    i++;
                }

                for (int j = 1; j < count; j++)
                {
                    fileName += fileName[fileName.Length - 1];
                }

                if (count > 0)
                {
                    count = 0;
                    i--;
                }
            }
            return fileName;
        }
    }
}
