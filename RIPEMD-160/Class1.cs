using System.Text;

namespace RIPEMD_160;

public static class HashDirectory
{
    internal static Int32[] Raznitsa = new Int32[80];

    internal static class HashConst
    {

        internal static UInt64 RotateLeft(UInt64 value, int bits)
        {
            return (value << bits) | (value >> (32 - bits));
        }

        internal static UInt64 Func(UInt64 j, UInt64 x, UInt64 y, UInt64 z)
        {


            if (j >= 0 && j <= 15)
                return x ^ y ^ z;


            if (j >= 16 && j <= 31)
                return (x & y) | (~x & z);


            if (j >= 32 && j <= 47)
                return (x | ~y) ^ z;


            if (j >= 48 && j <= 63)
                return (x & z) | (y & ~z);


            if (j >= 64 && j <= 79)
                return x ^ (y | ~z);


            return 0;

        }

        internal static UInt64 cnst1(UInt64 j)
        {


            if (j >= 0 && j <= 15)
                return 0x00000000;


            if (j >= 16 && j <= 31)
                return 0x5A827999;


            if (j >= 32 && j <= 47)
                return 0x6ED9EBA1;


            if (j >= 48 && j <= 63)
                return 0x8F1BBCDC;


            if (j >= 64 && j <= 79)
                return 0xA953FD4E;


            return 0;

        }

        internal static UInt64 cnst2(UInt64 j)
        {


            if (j >= 0 && j <= 15)
                return 0x50A28BE6;


            if (j >= 16 && j <= 31)
                return 0x5C4DD124;


            if (j >= 32 && j <= 47)
                return 0x6D703EF3;


            if (j >= 48 && j <= 63)
                return 0x7A6D76E9;


            if (j >= 64 && j <= 79)
                return 0x00000000;


            return 0;
        }

        internal static UInt64[] Selection1 =
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            7, 4, 13, 1, 10, 6, 15, 3, 12, 0, 9, 5, 2, 14, 11, 8,
            3, 10, 14, 4, 9, 15, 8, 1, 2, 7, 0, 6, 13, 11, 5, 12,
            1, 9, 11, 10, 0, 8, 12, 4, 13, 3, 7, 15, 14, 5, 6, 2,
            4, 0, 5, 9, 7, 12, 2, 10, 14, 1, 3, 8, 11, 6, 15, 13


        };

        internal static UInt64[] Selection2 =
        {
            5, 14, 7, 0, 9, 2, 11, 4, 13, 6, 15, 8, 1, 10, 3, 12,
            6, 11, 3, 7, 0, 13, 5, 10, 14, 15, 8, 12, 4, 9, 1, 2,
            15, 5, 1, 3, 7, 14, 6, 9, 11, 8, 12, 2, 10, 0, 4, 13,
            8, 6, 4, 1, 3, 11, 15, 0, 5, 12, 2, 13, 9, 7, 10, 14,
            12, 15, 10, 4, 1, 5, 8, 7, 6, 2, 13, 14, 0, 3, 9, 11

        };

        internal static Int32[] CyclRoll1 =
        {
            11, 14, 15, 12, 5, 8, 7, 9, 11, 13, 14, 15, 6, 7, 9, 8,
            7, 6, 8, 13, 11, 9, 7, 15, 7, 12, 15, 9, 11, 7, 13, 12,
            11, 13, 6, 7, 14, 9, 13, 15, 14, 8, 13, 6, 5, 12, 7, 5,
            11, 12, 14, 15, 14, 15, 9, 8, 9, 14, 5, 6, 8, 6, 5, 12,
            9, 15, 5, 11, 6, 8, 13, 12, 5, 12, 13, 14, 11, 8, 5, 6

        };

        internal static Int32[] CyclRoll2 =
        {
            8, 9, 9, 11, 13, 15, 15, 5, 7, 7, 8, 11, 14, 14, 12, 6,
            9, 13, 15, 7, 12, 8, 9, 11, 7, 7, 12, 7, 6, 15, 13, 11,
            9, 7, 15, 11, 8, 6, 6, 14, 12, 13, 5, 14, 13, 13, 7, 5,
            15, 5, 8, 11, 14, 14, 6, 14, 6, 9, 12, 9, 12, 5, 15, 8,
            8, 5, 12, 9, 12, 5, 14, 6, 8, 13, 6, 5, 15, 13, 11, 11

        };

        internal static String HexConverter(String C)
        {
            if (C == "0000")
                return ("0");
            if (C == "0001")
                return ("1");
            if (C == "0010")
                return ("2");
            if (C == "0011")
                return ("3");
            if (C == "0100")
                return ("4");
            if (C == "0101")
                return ("5");
            if (C == "0110")
                return ("6");
            if (C == "0111")
                return ("7");
            if (C == "1000")
                return ("8");
            if (C == "1001")
                return ("9");
            if (C == "1010")
                return ("A");
            if (C == "1011")
                return ("B");
            if (C == "1100")
                return ("C");
            if (C == "1101")
                return ("D");
            if (C == "1110")
                return ("E");
            if (C == "1111")
                return ("F");
            return "0";
        }


    }
    internal static string StringToHex(string hexstring)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char t in hexstring)
        {

            sb.Append(Convert.ToInt32(t).ToString("x"));
        }
        return sb.ToString();
    }
    internal static String[,] ByteStringForCycle(StringBuilder TextBits)
    {
        StringBuilder TextBytsLength = new StringBuilder();
        //Переводим длинну в биты и добавляем битов до 64
        TextBytsLength.Append(Convert.ToString(TextBits.Length, 2));
        if (TextBytsLength.Length < 64)
        {
            while (TextBytsLength.Length % 64 != 0)
            {
                TextBytsLength.Insert(0, "0");
            }
        }
        else
        {
            TextBytsLength.Remove(0, TextBytsLength.Length - 64); // не проверено!
        }
        //свапаем 32 бита 
        String S_0_32 = TextBytsLength.ToString(0, 32);
        TextBytsLength.Remove(0, 32);
        TextBytsLength.Append(S_0_32);



        //Добавляем биты до 448 mod 512
        TextBits.Append("1");

        while (TextBits.Length % 512 != 448 % 512)
        {
            TextBits.Append("0");
        }

        //Добавляем биты длинны сообщения к сообщению
        TextBits.Append(TextBytsLength);


        //Создаем массив байтов
        String[] Bytes = new String[128];
        for (Int32 i = 0; i < Bytes.Length; i++)
        {
            Bytes[i] = "";
        }

        for (Int32 i = 0, j = 0; i < TextBits.Length; i++)
        {

            if (Bytes[j].Length < 4)
            {
                Bytes[j] += Convert.ToString(TextBits[i]);
            }
            else
            {
                j++;
                Bytes[j] += Convert.ToString(TextBits[i]);
            }
        }

        //Массив байтов в массив по 4
        String[,] Words_4_Bytes = new String[16, 4];
        for (Int32 i = 0; i < 16; i++)
        {
            for (Int32 j = 0; j < 4; j++)
            {
                Words_4_Bytes[i, j] = "";
            }
        }

        for (Int32 i = 0, j = 0, z = 0; i < Bytes.Length; i++)
        {

            if (Words_4_Bytes[j, z].Length < 2)
            {
                Words_4_Bytes[j, z] += HashConst.HexConverter(Bytes[i]);
            }
            else
            {

                z++;
                if (z == 4)
                {
                    j++;
                    z = 0;
                }
                Words_4_Bytes[j, z] += HashConst.HexConverter(Bytes[i]);

            }
        }
        //перестройка слов
        for (Int32 i = 0; i < 16; i++)
        {
            (Words_4_Bytes[i, 0], Words_4_Bytes[i, 1]) = (Words_4_Bytes[i, 1], Words_4_Bytes[i, 0]);

            (Words_4_Bytes[i, 2], Words_4_Bytes[i, 3]) = (Words_4_Bytes[i, 3], Words_4_Bytes[i, 2]);

            Words_4_Bytes[i, 0] = Reverse(Words_4_Bytes[i, 0]);
            Words_4_Bytes[i, 1] = Reverse(Words_4_Bytes[i, 1]);
            Words_4_Bytes[i, 2] = Reverse(Words_4_Bytes[i, 2]);
            Words_4_Bytes[i, 3] = Reverse(Words_4_Bytes[i, 3]);

        }
        //Массив входных значений 
        String[,] Vxodim = new String[1, 16];
        for (Int32 i = 0; i < 16; i++)
        {
            Vxodim[0, i] = "";
            for (Int32 j = 0; j < 4; j++)
            {
                Vxodim[0, i] += Words_4_Bytes[i, j];
            }
        }

        return Vxodim;
    }

    internal static UInt32 Converter(String s)
    {
        String[] hexValuesSplit = s.Split();
        UInt32 value = 0;
        foreach (String hex in hexValuesSplit)
        {
            // Convert the number expressed in base-16 to an integer.
            value = Convert.ToUInt32(hex, 16);

        }
        return value;
    }

    internal static string Reverse(this string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public static string GetHash(String vxodim, String cicle = "")
    {
        String[,] dataToHash = ByteStringForCycle(new StringBuilder(vxodim));


        UInt64 h0 = 0x67452301;
        UInt64 h1 = 0xEFCDAB89;
        UInt64 h2 = 0x98BADCFE;
        UInt64 h3 = 0x10325476;
        UInt64 h4 = 0xC3D2E1F0;

        UInt64 a1 = h0;
        UInt64 b1 = h1;
        UInt64 c1 = h2;
        UInt64 d1 = h3;
        UInt64 e1 = h4;
        UInt64 a2 = h0;
        UInt64 b2 = h1;
        UInt64 c2 = h2;
        UInt64 d2 = h3;
        UInt64 e2 = h4;
        UInt64 tt;
        String equal2;
        Int32 flag = 0;

        for (UInt64 j = 0; j <= 79; j++)
        {

            tt = (UInt64)((HashConst.RotateLeft((UInt64)((a1 + HashConst.Func(j, b1, c1, d1) + Converter(dataToHash[0, (UInt64)(HashConst.Selection1[j])]) + HashConst.cnst1(j)) % 4294967296), HashConst.CyclRoll1[j]) + e1) % 4294967296);

            a1 = e1;
            e1 = d1;
            d1 = (UInt64)(HashConst.RotateLeft(c1, 10) % 4294967296);
            c1 = b1;
            b1 = tt;
            tt = (UInt64)((HashConst.RotateLeft((UInt64)((a2 + HashConst.Func(79 - j, b2, c2, d2) + Converter(dataToHash[0, (UInt64)(HashConst.Selection2[j])]) + HashConst.cnst2(j)) % 4294967296), HashConst.CyclRoll2[j]) + e2) % 4294967296);
            a2 = e2;
            e2 = d2;
            d2 = (UInt64)(HashConst.RotateLeft(c2, 10) % 4294967296);
            c2 = b2;
            b2 = tt;

            if (cicle != "")
            {
                equal2 = StringToHex($"{h0:x}" + $"{h1:x}" + $"{h2:x}" + $"{h3:x}" + $"{h4:x}");

                for (Int32 i = 0; i < equal2.Length; i++)
                {
                    if (cicle[i] != equal2[i])
                    {
                        flag++;

                    }
                }
                Raznitsa[j] = flag;
            }
            flag = 0;
        }
        tt = (UInt64)((h1 + c1 + d2) % 4294967296);
        h1 = (UInt64)((h2 + d1 + e2) % 4294967296);
        h2 = (UInt64)((h3 + e1 + a2) % 4294967296);
        h3 = (UInt64)((h4 + a1 + b2) % 4294967296);
        h4 = (UInt64)((h0 + b1 + c2) % 4294967296);
        h0 = tt;

        return ($"{h0:x}" + $"{h1:x}" + $"{h2:x}" + $"{h3:x}" + $"{h4:x}");
    }

}