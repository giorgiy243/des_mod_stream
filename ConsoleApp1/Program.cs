using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static string path;
        static readonly int len = 64;
        static byte B;
        static Int16[] BL = new Int16[len];
        static int pointer = 0;
        static System.Int16[] _gamma = { 0, 0, 0, 0, 0, 0,     // 6
                                      1, 1, 1, 1, 1, 1,     // 12
                                      0, 0, 0, 0, 0, 0,     // 18
                                      1, 1, 1, 1, 1, 1,     // 24
                                      0, 0, 0, 0, 0, 0,     // 30
                                      1, 1, 1, 1, 1, 1,     // 36
                                      0, 0, 0, 0, 0, 0,     // 42
                                      1, 1, 1, 1, 1, 1,     // 48
                                      0, 0, 0, 0, 0, 0,     // 54
                                      1, 1, 1, 1, 1, 1,     // 60
                                      0, 0, 0, 0 };         // 64 
        static System.Int16[] L = new Int16[len / 2];
        static System.Int16[] R = new Int16[len / 2];


        private static Int16 XOR(Int16 a, Int16 b) // Реализация ксора
        {
            if (a + b == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static void WriteBinaryFile(byte []arr, int pointer)
        {
            BinaryWriter bw = new BinaryWriter(File.Open(path + "more.txt", FileMode.Append), UTF8Encoding.UTF8);

            for (int i = 0; i < pointer / 8; i++)
                bw.Write(arr[i]);
            bw.Close();
        }

        private static void Dig(int pointer = 64)
        {
            for (int i = 0; i < len; i++)
            {
                BL[i] = XOR(_gamma[i], BL[i]);  // Сложение ксором (получение шифротекста)
            }

            byte[] answer = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                answer[0] += Convert.ToByte(BL[i] * Math.Pow(2, i));
            }
            for (int i = 8; i < 16; i++)
            {
                answer[1] += Convert.ToByte(BL[i] * Math.Pow(2, i - 8));
            }
            for (int i = 16; i < 24; i++)
            {
                answer[2] += Convert.ToByte(BL[i] * Math.Pow(2, i - 16));
            }
            for (int i = 24; i < 32; i++)
            {
                answer[3] += Convert.ToByte(BL[i] * Math.Pow(2, i - 24));
            }
            for (int i = 32; i < 40; i++)
            {
                answer[4] += Convert.ToByte(BL[i] * Math.Pow(2, i - 32));
            }
            for (int i = 40; i < 48; i++)
            {
                answer[5] += Convert.ToByte(BL[i] * Math.Pow(2, i - 40));
            }
            for (int i = 48; i < 56; i++)
            {
                answer[6] += Convert.ToByte(BL[i] * Math.Pow(2, i - 48));
            }
            for (int i = 56; i < 64; i++)
            {
                answer[7] += Convert.ToByte(BL[i] * Math.Pow(2, i - 56));
            }

            WriteBinaryFile(answer , pointer);
        }

        private static void Initial_Permutation(Int16[] key)
        {
            System.Int16[] IP = new System.Int16[key.Length];

            IP[0] = key[58 - 1];
            IP[1] = key[50 - 1];
            IP[2] = key[42 - 1];
            IP[3] = key[34 - 1];
            IP[4] = key[26 - 1];
            IP[5] = key[18 - 1];
            IP[6] = key[10 - 1];
            IP[7] = key[2 - 1];
            IP[8] = key[60 - 1];
            IP[9] = key[52 - 1];
            IP[10] = key[44 - 1];
            IP[11] = key[36 - 1];
            IP[12] = key[28 - 1];
            IP[13] = key[20 - 1];
            IP[14] = key[12 - 1];
            IP[15] = key[4 - 1];
            IP[16] = key[62 - 1];
            IP[17] = key[54 - 1];
            IP[18] = key[46 - 1];
            IP[19] = key[38 - 1];
            IP[20] = key[30 - 1];
            IP[21] = key[22 - 1];
            IP[22] = key[14 - 1];
            IP[23] = key[6 - 1];
            IP[24] = key[64 - 1];
            IP[25] = key[56 - 1];
            IP[26] = key[48 - 1];
            IP[27] = key[40 - 1];
            IP[28] = key[32 - 1];
            IP[29] = key[24 - 1];
            IP[30] = key[16 - 1];
            IP[31] = key[8 - 1];
            IP[32] = key[57 - 1];
            IP[33] = key[49 - 1];
            IP[34] = key[41 - 1];
            IP[35] = key[33 - 1];
            IP[36] = key[25 - 1];
            IP[37] = key[17 - 1];
            IP[38] = key[9 - 1];
            IP[39] = key[1 - 1];
            IP[40] = key[59 - 1];
            IP[41] = key[51 - 1];
            IP[42] = key[43 - 1];
            IP[43] = key[35 - 1];
            IP[44] = key[27 - 1];
            IP[45] = key[19 - 1];
            IP[46] = key[11 - 1];
            IP[47] = key[3 - 1];
            IP[48] = key[61 - 1];
            IP[49] = key[53 - 1];
            IP[50] = key[45 - 1];
            IP[51] = key[37 - 1];
            IP[52] = key[29 - 1];
            IP[53] = key[21 - 1];
            IP[54] = key[13 - 1];
            IP[55] = key[5 - 1];
            IP[56] = key[63 - 1];
            IP[57] = key[55 - 1];
            IP[58] = key[47 - 1];
            IP[59] = key[39 - 1];
            IP[60] = key[31 - 1];
            IP[61] = key[23 - 1];
            IP[62] = key[15 - 1];
            IP[63] = key[7 - 1];

            for (int i = 0; i < L.Length; i++)  // Вычленияем левую часть
            {
                L[i] = IP[i];
            }
            for (int i = 0; i < R.Length; i++)  // Вычленяем правую часть
            {
                R[i] = IP[L.Length + i];
            }
        }

        private static void Initial_Permutation_Revert() // Обратная перестановка после 16 раундов
        {
            System.Int16[] outdata = new Int16[len];

            outdata[0] = R[40 - 32 - 1];
            outdata[1] = L[8 - 1];
            outdata[2] = R[48 - 32 - 1];
            outdata[3] = L[16 - 1];
            outdata[4] = R[56 - 32 - 1];
            outdata[5] = L[24 - 1];
            outdata[6] = R[64 - 32 - 1];
            outdata[7] = L[32 - 1];
            outdata[8] = R[39 - 32 - 1];
            outdata[9] = L[7 - 1];
            outdata[10] = R[47 - 32 - 1];
            outdata[11] = L[15 - 1];
            outdata[12] = R[55 - 32 - 1];
            outdata[13] = L[23 - 1];
            outdata[14] = R[63 - 32 - 1];
            outdata[15] = L[31 - 1];
            outdata[16] = R[38 - 32 - 1];
            outdata[17] = L[6 - 1];
            outdata[18] = R[46 - 32 - 1];
            outdata[19] = L[14 - 1];
            outdata[20] = R[54 - 32 - 1];
            outdata[21] = L[22 - 1];
            outdata[22] = R[62 - 32 - 1];
            outdata[23] = L[30 - 1];
            outdata[24] = R[37 - 32 - 1];
            outdata[25] = L[5 - 1];
            outdata[26] = R[45 - 32 - 1];
            outdata[27] = L[13 - 1];
            outdata[28] = R[53 - 32 - 1];
            outdata[29] = L[21 - 1];
            outdata[30] = R[61 - 32 - 1];
            outdata[31] = L[29 - 1];
            outdata[32] = R[36 - 32 - 1];
            outdata[33] = L[4 - 1];
            outdata[34] = R[44 - 32 - 1];
            outdata[35] = L[12 - 1];
            outdata[36] = R[52 - 32 - 1];
            outdata[37] = L[20 - 1];
            outdata[38] = R[60 - 32 - 1];
            outdata[39] = L[28 - 1];
            outdata[40] = R[35 - 32 - 1];
            outdata[41] = L[3 - 1];
            outdata[42] = R[43 - 32 - 1];
            outdata[43] = L[11 - 1];
            outdata[44] = R[51 - 32 - 1];
            outdata[45] = L[19 - 1];
            outdata[46] = R[59 - 32 - 1];
            outdata[47] = L[27 - 1];
            outdata[48] = R[34 - 32 - 1];
            outdata[49] = L[2 - 1];
            outdata[50] = R[42 - 32 - 1];
            outdata[51] = L[10 - 1];
            outdata[52] = R[50 - 32 - 1];
            outdata[53] = L[18 - 1];
            outdata[54] = R[58 - 32 - 1];
            outdata[55] = L[26 - 1];
            outdata[56] = R[33 - 32 - 1];
            outdata[57] = L[1 - 1];
            outdata[58] = R[41 - 32 - 1];
            outdata[59] = L[9 - 1];
            outdata[60] = R[49 - 32 - 1];
            outdata[61] = L[17 - 1];
            outdata[62] = R[57 - 32 - 1];
            outdata[63] = L[25 - 1];

            _gamma = outdata;  //   Сменна гаммы 
        }

        private static void GetNewLR(Int16[] nR)    // Конец раунда перестановка L и R частей
        {
            for (int i = 0; i < L.Length; i++)
            {
                L[i] = R[i];
            }
            for (int i = 0; i < R.Length; i++)
            {
                R[i] = XOR(nR[i], L[i]);
            }
        }

        private static void Expansion_R(Int16[] R, Int16[] _R) // Расширение правой части
        {
            _R[0] = R[32 - 1];
            _R[1] = R[1 - 1];
            _R[2] = R[2 - 1];
            _R[3] = R[3 - 1];
            _R[4] = R[4 - 1];
            _R[5] = R[5 - 1];
            _R[6] = R[4 - 1];
            _R[7] = R[5 - 1];
            _R[8] = R[6 - 1];
            _R[9] = R[7 - 1];
            _R[10] = R[8 - 1];
            _R[11] = R[9 - 1];
            _R[12] = R[8 - 1];
            _R[13] = R[9 - 1];
            _R[14] = R[10 - 1];
            _R[15] = R[11 - 1];
            _R[16] = R[12 - 1];
            _R[17] = R[13 - 1];
            _R[18] = R[12 - 1];
            _R[19] = R[13 - 1];
            _R[20] = R[14 - 1];
            _R[21] = R[15 - 1];
            _R[22] = R[16 - 1];
            _R[23] = R[17 - 1];
            _R[24] = R[16 - 1];
            _R[25] = R[17 - 1];
            _R[26] = R[18 - 1];
            _R[27] = R[19 - 1];
            _R[28] = R[20 - 1];
            _R[29] = R[21 - 1];
            _R[30] = R[20 - 1];
            _R[31] = R[21 - 1];
            _R[32] = R[22 - 1];
            _R[33] = R[23 - 1];
            _R[34] = R[24 - 1];
            _R[35] = R[25 - 1];
            _R[36] = R[24 - 1];
            _R[37] = R[25 - 1];
            _R[38] = R[26 - 1];
            _R[39] = R[27 - 1];
            _R[40] = R[28 - 1];
            _R[41] = R[29 - 1];
            _R[42] = R[28 - 1];
            _R[43] = R[29 - 1];
            _R[44] = R[30 - 1];
            _R[45] = R[31 - 1];
            _R[46] = R[32 - 1];
            _R[47] = R[1 - 1];
        }

        private static void Rounds()
        {
            System.Int16[] gamma = new Int16[len / 2];

            System.Int16[] S1 = { 14,   4,  13,  1,   2,  15,  11,   8,   3,  10,   6,  12,   5,   9,  0,   7,
                                   0,  15,   7,  4,  14,   2,  13,   1,  10,   6,  12,  11,   9,   5,  3,   8,
                                   4,   1,  14,  8,  13,   6,   2,  11,  15,  12,   9,   7,   3,  10,  5,   0,
                                  15,  12,   8,  2,   4,   9,   1,   7,   5,  11,   3,  14,  10,   0,  6,  13     };

            System.Int16[] S2 = { 15,   1,   8,  14,   6,  11,   3,   4,   9,  7,   2,  13,  12,  0,   5,  10,
                                   3,  13,   4,   7,  15,   2,   8,  14,  12,  0,   1,  10,   6,  9,  11,  5,
                                   0,  14,   7,  11,  10,   4,  13,   1,   5,  8,  12,   6,   9,  3,   2,  15,
                                  13,   8,  10,   1,   3,  15,   4,   2,  11,  6,   7,  12,   0,  5,  14,  9     };

            System.Int16[] S3 = { 10,   0,   9,  14,  6,   3,  15,   5,   1,  13,  12,   7,  11,   4,   2,   8,
                                  13,   7,   0,   9,  3,   4,   6,  10,   2,   8,   5,  14,  12,  11,  15,   1,
                                  13,   6,   4,   9,  8,  15,   3,   0,  11,   1,   2,  12,   5,  10,  14,   7,
                                   1,  10,  13,   0,  6,   9,   8,   7,   4,  15,  14,   3,  11,   5,   2,  12    };

            System.Int16[] S4 = {  7,   13,  14,  3,   0,   6,   9,  10,   1,  2,  8,   5,  11,  12,   4,  15,
                                  13,    8,  11,  5,   6,  15,   0,   3,   4,  7,  2,  12,   1,  10,  14,   9,
                                  10,    6,   9,  0,  12,  11,   7,  13,  15,  1,  3,  14,   5,   2,   8,   4,
                                   3,   15,   0,  6,  10,   1,  13,   8,   9,  4,  5,  11,  12,   7,   2,  14    };

            System.Int16[] S5 = {  2,  12,   4,   1,   7,  10,  11,   6,   8,   5,   3,  15,  13,  0,  14,   9,
                                  14,  11,   2,  12,   4,   7,  13,   1,   5,   0,  15,  10,   3,  9,   8,   6,
                                   4,   2,   1,  11,  10,  13,   7,   8,  15,   9,  12,   5,   6,  3,   0,  14,
                                  11,   8,  12,   7,   1,  14,   2,  13,   6,  15,   0,   9,  10,  4,   5,   3   };

            System.Int16[] S6 = { 12,   1,  10,  15,  9,   2,   6,   8,   0,  13,   3,   4,  14,   7,   5,  11,
                                  10,  15,   4,   2,  7,  12,   9,   5,   6,   1,  13,  14,   0,  11,   3,   8,
                                   9,  14,  15,   5,  2,   8,  12,   3,   7,   0,   4,  10,   1,  13,  11,   6,
                                   4,   3,   2,  12,  9,   5,  15,  10,  11,  14,   1,   7,   6,   0,   8,  13   };

            System.Int16[] S7 = {  4,  11,   2,  14,  15,   0,   8,  13,   3,  12,   9,   7,   5,  10,  6,   1,
                                  13 ,  0,  11,   7,   4,   9,   1,  10,  14,   3,   5,  12,   2,  15,  8,   6,
                                   1,   4,  11,  13,  12,   3,   7,  14,  10,  15,   6,   8,   0,   5,  9,   2,
                                   6,  11,  13,   8,   1,   4,  10,   7,   9,   5,   0,  15,  14,   2,  3,  12   };

            System.Int16[] S8 = { 13,   2,   8,   4,   6,  15,  11,   1,  10,   9,   3,  14,   5,   0,  12,   7,
                                   1,  15,  13,   8,  10,   3,   7,   4,  12,   5,   6,  11,   0,  14,   9,   2,
                                   7,  11,   4,   1,   9,  12,  14,   2,   0,   6,  10,  13,  15,   3,   5,   8,
                                   2,   1,  14,   7,   4,  10,   8,  13,  15,  12,   9,   0,   3,   5,   6,  11   };

            const int expansion = 48;

            System.Int16[] _R = new Int16[expansion]; // Расширенная правая часть


            Expansion_R(R, _R);

            System.Int16[] _round = new Int16[expansion];

            for (int i = 0; i < expansion; i++) // Складывакм расширенную правую часть и ключ ксором
            {
                _round[i] = XOR(_R[i], _gamma[i]);
            }

            // ------------- 1 й блок преобразования ---------------

            int x = _round[0] + _round[5] * 2; // X [0;3]
            int y = _round[1] + _round[2] * 2 + _round[3] * 4 + _round[4] * 8; // Y [0;15]

            System.Int16 S = S1[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[0] = 0;
                    gamma[1] = 0;
                    gamma[2] = 0;
                    gamma[3] = 0;
                    break;
                case 1:
                    gamma[0] = 0;
                    gamma[1] = 0;
                    gamma[2] = 0;
                    gamma[3] = 1;
                    break;
                case 2:
                    gamma[0] = 0;
                    gamma[1] = 0;
                    gamma[2] = 1;
                    gamma[3] = 0;
                    break;
                case 3:
                    gamma[0] = 0;
                    gamma[1] = 0;
                    gamma[2] = 1;
                    gamma[3] = 1;
                    break;
                case 4:
                    gamma[0] = 0;
                    gamma[1] = 1;
                    gamma[2] = 0;
                    gamma[3] = 0;
                    break;
                case 5:
                    gamma[0] = 0;
                    gamma[1] = 1;
                    gamma[2] = 0;
                    gamma[3] = 1;
                    break;
                case 6:
                    gamma[0] = 0;
                    gamma[1] = 1;
                    gamma[2] = 1;
                    gamma[3] = 0;
                    break;
                case 7:
                    gamma[0] = 0;
                    gamma[1] = 1;
                    gamma[2] = 1;
                    gamma[3] = 1;
                    break;
                case 8:
                    gamma[0] = 1;
                    gamma[1] = 0;
                    gamma[2] = 0;
                    gamma[3] = 0;
                    break;
                case 9:
                    gamma[0] = 1;
                    gamma[1] = 0;
                    gamma[2] = 0;
                    gamma[3] = 1;
                    break;
                case 10:
                    gamma[0] = 1;
                    gamma[1] = 0;
                    gamma[2] = 1;
                    gamma[3] = 0;
                    break;
                case 11:
                    gamma[0] = 1;
                    gamma[1] = 0;
                    gamma[2] = 1;
                    gamma[3] = 1;
                    break;
                case 12:
                    gamma[0] = 1;
                    gamma[1] = 1;
                    gamma[2] = 0;
                    gamma[3] = 0;
                    break;
                case 13:
                    gamma[0] = 1;
                    gamma[1] = 1;
                    gamma[2] = 0;
                    gamma[3] = 1;
                    break;
                case 14:
                    gamma[0] = 1;
                    gamma[1] = 1;
                    gamma[2] = 1;
                    gamma[3] = 0;
                    break;
                case 15:
                    gamma[0] = 1;
                    gamma[1] = 1;
                    gamma[2] = 1;
                    gamma[3] = 1;
                    break;
            }

            // ----------- 2 й блок преоброзования -------------------

            x = _round[6] + _round[11] * 2; // X [0;3]
            y = _round[7] + _round[8] * 2 + _round[9] * 4 + _round[10] * 8; // Y [0;15]

            S = S2[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[4] = 0;
                    gamma[5] = 0;
                    gamma[6] = 0;
                    gamma[7] = 0;
                    break;
                case 1:
                    gamma[4] = 0;
                    gamma[5] = 0;
                    gamma[6] = 0;
                    gamma[7] = 1;
                    break;
                case 2:
                    gamma[4] = 0;
                    gamma[5] = 0;
                    gamma[6] = 1;
                    gamma[7] = 0;
                    break;
                case 3:
                    gamma[4] = 0;
                    gamma[5] = 0;
                    gamma[6] = 1;
                    gamma[7] = 1;
                    break;
                case 4:
                    gamma[4] = 0;
                    gamma[5] = 1;
                    gamma[6] = 0;
                    gamma[7] = 0;
                    break;
                case 5:
                    gamma[4] = 0;
                    gamma[5] = 1;
                    gamma[6] = 0;
                    gamma[7] = 1;
                    break;
                case 6:
                    gamma[4] = 0;
                    gamma[5] = 1;
                    gamma[6] = 1;
                    gamma[7] = 0;
                    break;
                case 7:
                    gamma[4] = 0;
                    gamma[5] = 1;
                    gamma[6] = 1;
                    gamma[7] = 1;
                    break;
                case 8:
                    gamma[4] = 1;
                    gamma[5] = 0;
                    gamma[6] = 0;
                    gamma[7] = 0;
                    break;
                case 9:
                    gamma[4] = 1;
                    gamma[5] = 0;
                    gamma[6] = 0;
                    gamma[7] = 1;
                    break;
                case 10:
                    gamma[4] = 1;
                    gamma[5] = 0;
                    gamma[6] = 1;
                    gamma[7] = 0;
                    break;
                case 11:
                    gamma[4] = 1;
                    gamma[5] = 0;
                    gamma[6] = 1;
                    gamma[7] = 1;
                    break;
                case 12:
                    gamma[4] = 1;
                    gamma[5] = 1;
                    gamma[6] = 0;
                    gamma[7] = 0;
                    break;
                case 13:
                    gamma[4] = 1;
                    gamma[5] = 1;
                    gamma[6] = 0;
                    gamma[7] = 1;
                    break;
                case 14:
                    gamma[4] = 1;
                    gamma[5] = 1;
                    gamma[6] = 1;
                    gamma[7] = 0;
                    break;
                case 15:
                    gamma[4] = 1;
                    gamma[5] = 1;
                    gamma[6] = 1;
                    gamma[7] = 1;
                    break;
            }

            // ----------- 3 й блок преоброзования -------------------

            x = _round[12] + _round[17] * 2; // X [0;3]
            y = _round[13] + _round[14] * 2 + _round[15] * 4 + _round[16] * 8; // Y [0;15]

            S = S3[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[8] = 0;
                    gamma[9] = 0;
                    gamma[10] = 0;
                    gamma[11] = 0;
                    break;
                case 1:
                    gamma[8] = 0;
                    gamma[9] = 0;
                    gamma[10] = 0;
                    gamma[11] = 1;
                    break;
                case 2:
                    gamma[8] = 0;
                    gamma[9] = 0;
                    gamma[10] = 1;
                    gamma[11] = 0;
                    break;
                case 3:
                    gamma[8] = 0;
                    gamma[9] = 0;
                    gamma[10] = 1;
                    gamma[11] = 1;
                    break;
                case 4:
                    gamma[8] = 0;
                    gamma[9] = 1;
                    gamma[10] = 0;
                    gamma[11] = 0;
                    break;
                case 5:
                    gamma[8] = 0;
                    gamma[9] = 1;
                    gamma[10] = 0;
                    gamma[11] = 1;
                    break;
                case 6:
                    gamma[8] = 0;
                    gamma[9] = 1;
                    gamma[10] = 1;
                    gamma[11] = 0;
                    break;
                case 7:
                    gamma[8] = 0;
                    gamma[9] = 1;
                    gamma[10] = 1;
                    gamma[11] = 1;
                    break;
                case 8:
                    gamma[8] = 1;
                    gamma[9] = 0;
                    gamma[10] = 0;
                    gamma[11] = 0;
                    break;
                case 9:
                    gamma[8] = 1;
                    gamma[9] = 0;
                    gamma[10] = 0;
                    gamma[11] = 1;
                    break;
                case 10:
                    gamma[8] = 1;
                    gamma[9] = 0;
                    gamma[10] = 1;
                    gamma[11] = 0;
                    break;
                case 11:
                    gamma[8] = 1;
                    gamma[9] = 0;
                    gamma[10] = 1;
                    gamma[11] = 1;
                    break;
                case 12:
                    gamma[8] = 1;
                    gamma[9] = 1;
                    gamma[10] = 0;
                    gamma[11] = 0;
                    break;
                case 13:
                    gamma[8] = 1;
                    gamma[9] = 1;
                    gamma[10] = 0;
                    gamma[11] = 1;
                    break;
                case 14:
                    gamma[8] = 1;
                    gamma[9] = 1;
                    gamma[10] = 1;
                    gamma[11] = 0;
                    break;
                case 15:
                    gamma[8] = 1;
                    gamma[9] = 1;
                    gamma[10] = 1;
                    gamma[11] = 1;
                    break;
            }


            // ----------- 4 й блок преоброзования -------------------

            x = _round[18] + _round[23] * 2; // X [0;3]
            y = _round[19] + _round[20] * 2 + _round[21] * 4 + _round[22] * 8; // Y [0;15]

            S = S4[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[12] = 0;
                    gamma[13] = 0;
                    gamma[14] = 0;
                    gamma[15] = 0;
                    break;
                case 1:
                    gamma[12] = 0;
                    gamma[13] = 0;
                    gamma[14] = 0;
                    gamma[15] = 1;
                    break;
                case 2:
                    gamma[12] = 0;
                    gamma[13] = 0;
                    gamma[14] = 1;
                    gamma[15] = 0;
                    break;
                case 3:
                    gamma[12] = 0;
                    gamma[13] = 0;
                    gamma[14] = 1;
                    gamma[15] = 1;
                    break;
                case 4:
                    gamma[12] = 0;
                    gamma[13] = 1;
                    gamma[14] = 0;
                    gamma[15] = 0;
                    break;
                case 5:
                    gamma[12] = 0;
                    gamma[13] = 1;
                    gamma[14] = 0;
                    gamma[15] = 1;
                    break;
                case 6:
                    gamma[12] = 0;
                    gamma[13] = 1;
                    gamma[14] = 1;
                    gamma[15] = 0;
                    break;
                case 7:
                    gamma[12] = 0;
                    gamma[13] = 1;
                    gamma[14] = 1;
                    gamma[15] = 1;
                    break;
                case 8:
                    gamma[12] = 1;
                    gamma[13] = 0;
                    gamma[14] = 0;
                    gamma[15] = 0;
                    break;
                case 9:
                    gamma[12] = 1;
                    gamma[13] = 0;
                    gamma[14] = 0;
                    gamma[15] = 1;
                    break;
                case 10:
                    gamma[12] = 1;
                    gamma[13] = 0;
                    gamma[14] = 1;
                    gamma[15] = 0;
                    break;
                case 11:
                    gamma[12] = 1;
                    gamma[13] = 0;
                    gamma[14] = 1;
                    gamma[15] = 1;
                    break;
                case 12:
                    gamma[12] = 1;
                    gamma[13] = 1;
                    gamma[14] = 0;
                    gamma[15] = 0;
                    break;
                case 13:
                    gamma[12] = 1;
                    gamma[13] = 1;
                    gamma[14] = 0;
                    gamma[15] = 1;
                    break;
                case 14:
                    gamma[12] = 1;
                    gamma[13] = 1;
                    gamma[14] = 1;
                    gamma[15] = 0;
                    break;
                case 15:
                    gamma[12] = 1;
                    gamma[13] = 1;
                    gamma[14] = 1;
                    gamma[15] = 1;
                    break;
            }


            // ----------- 5 й блок преоброзования -------------------

            x = _round[24] + _round[29] * 2; // X [0;3]
            y = _round[25] + _round[26] * 2 + _round[27] * 4 + _round[28] * 8; // Y [0;15]

            S = S5[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[16] = 0;
                    gamma[17] = 0;
                    gamma[18] = 0;
                    gamma[19] = 0;
                    break;
                case 1:
                    gamma[16] = 0;
                    gamma[17] = 0;
                    gamma[18] = 0;
                    gamma[19] = 1;
                    break;
                case 2:
                    gamma[16] = 0;
                    gamma[17] = 0;
                    gamma[18] = 1;
                    gamma[19] = 0;
                    break;
                case 3:
                    gamma[16] = 0;
                    gamma[17] = 0;
                    gamma[18] = 1;
                    gamma[19] = 1;
                    break;
                case 4:
                    gamma[16] = 0;
                    gamma[17] = 1;
                    gamma[18] = 0;
                    gamma[19] = 0;
                    break;
                case 5:
                    gamma[16] = 0;
                    gamma[17] = 1;
                    gamma[18] = 0;
                    gamma[19] = 1;
                    break;
                case 6:
                    gamma[16] = 0;
                    gamma[17] = 1;
                    gamma[18] = 1;
                    gamma[19] = 0;
                    break;
                case 7:
                    gamma[16] = 0;
                    gamma[17] = 1;
                    gamma[18] = 1;
                    gamma[19] = 1;
                    break;
                case 8:
                    gamma[16] = 1;
                    gamma[17] = 0;
                    gamma[18] = 0;
                    gamma[19] = 0;
                    break;
                case 9:
                    gamma[16] = 1;
                    gamma[17] = 0;
                    gamma[18] = 0;
                    gamma[19] = 1;
                    break;
                case 10:
                    gamma[16] = 1;
                    gamma[17] = 0;
                    gamma[18] = 1;
                    gamma[19] = 0;
                    break;
                case 11:
                    gamma[16] = 1;
                    gamma[17] = 0;
                    gamma[18] = 1;
                    gamma[19] = 1;
                    break;
                case 12:
                    gamma[16] = 1;
                    gamma[17] = 1;
                    gamma[18] = 0;
                    gamma[19] = 0;
                    break;
                case 13:
                    gamma[16] = 1;
                    gamma[17] = 1;
                    gamma[18] = 0;
                    gamma[19] = 1;
                    break;
                case 14:
                    gamma[16] = 1;
                    gamma[17] = 1;
                    gamma[18] = 1;
                    gamma[19] = 0;
                    break;
                case 15:
                    gamma[16] = 1;
                    gamma[17] = 1;
                    gamma[18] = 1;
                    gamma[19] = 1;
                    break;
            }

            // ----------- 6 й блок преоброзования -------------------

            x = _round[30] + _round[35] * 2; // X [0;3]
            y = _round[31] + _round[32] * 2 + _round[33] * 4 + _round[34] * 8; // Y [0;15]

            S = S6[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[20] = 0;
                    gamma[21] = 0;
                    gamma[22] = 0;
                    gamma[23] = 0;
                    break;
                case 1:
                    gamma[20] = 0;
                    gamma[21] = 0;
                    gamma[22] = 0;
                    gamma[23] = 1;
                    break;
                case 2:
                    gamma[20] = 0;
                    gamma[21] = 0;
                    gamma[22] = 1;
                    gamma[23] = 0;
                    break;
                case 3:
                    gamma[20] = 0;
                    gamma[21] = 0;
                    gamma[22] = 1;
                    gamma[23] = 1;
                    break;
                case 4:
                    gamma[20] = 0;
                    gamma[21] = 1;
                    gamma[22] = 0;
                    gamma[23] = 0;
                    break;
                case 5:
                    gamma[20] = 0;
                    gamma[21] = 1;
                    gamma[22] = 0;
                    gamma[23] = 1;
                    break;
                case 6:
                    gamma[20] = 0;
                    gamma[21] = 1;
                    gamma[22] = 1;
                    gamma[23] = 0;
                    break;
                case 7:
                    gamma[20] = 0;
                    gamma[21] = 1;
                    gamma[22] = 1;
                    gamma[23] = 1;
                    break;
                case 8:
                    gamma[20] = 1;
                    gamma[21] = 0;
                    gamma[22] = 0;
                    gamma[23] = 0;
                    break;
                case 9:
                    gamma[20] = 1;
                    gamma[21] = 0;
                    gamma[22] = 0;
                    gamma[23] = 1;
                    break;
                case 10:
                    gamma[20] = 1;
                    gamma[21] = 0;
                    gamma[22] = 1;
                    gamma[23] = 0;
                    break;
                case 11:
                    gamma[20] = 1;
                    gamma[21] = 0;
                    gamma[22] = 1;
                    gamma[23] = 1;
                    break;
                case 12:
                    gamma[20] = 1;
                    gamma[21] = 1;
                    gamma[22] = 0;
                    gamma[23] = 0;
                    break;
                case 13:
                    gamma[20] = 1;
                    gamma[21] = 1;
                    gamma[22] = 0;
                    gamma[23] = 1;
                    break;
                case 14:
                    gamma[20] = 1;
                    gamma[21] = 1;
                    gamma[22] = 1;
                    gamma[23] = 0;
                    break;
                case 15:
                    gamma[20] = 1;
                    gamma[21] = 1;
                    gamma[22] = 1;
                    gamma[23] = 1;
                    break;
            }


            // ----------- 7 й блок преоброзования -------------------

            x = _round[36] + _round[41] * 2; // X [0;3]
            y = _round[37] + _round[38] * 2 + _round[39] * 4 + _round[40] * 8; // Y [0;15]

            S = S7[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[24] = 0;
                    gamma[25] = 0;
                    gamma[26] = 0;
                    gamma[27] = 0;
                    break;
                case 1:
                    gamma[24] = 0;
                    gamma[25] = 0;
                    gamma[26] = 0;
                    gamma[27] = 1;
                    break;
                case 2:
                    gamma[24] = 0;
                    gamma[25] = 0;
                    gamma[26] = 1;
                    gamma[27] = 0;
                    break;
                case 3:
                    gamma[24] = 0;
                    gamma[25] = 0;
                    gamma[26] = 1;
                    gamma[27] = 1;
                    break;
                case 4:
                    gamma[24] = 0;
                    gamma[25] = 1;
                    gamma[26] = 0;
                    gamma[27] = 0;
                    break;
                case 5:
                    gamma[24] = 0;
                    gamma[25] = 1;
                    gamma[26] = 0;
                    gamma[27] = 1;
                    break;
                case 6:
                    gamma[24] = 0;
                    gamma[25] = 1;
                    gamma[26] = 1;
                    gamma[27] = 0;
                    break;
                case 7:
                    gamma[24] = 0;
                    gamma[25] = 1;
                    gamma[26] = 1;
                    gamma[27] = 1;
                    break;
                case 8:
                    gamma[24] = 1;
                    gamma[25] = 0;
                    gamma[26] = 0;
                    gamma[27] = 0;
                    break;
                case 9:
                    gamma[24] = 1;
                    gamma[25] = 0;
                    gamma[26] = 0;
                    gamma[27] = 1;
                    break;
                case 10:
                    gamma[24] = 1;
                    gamma[25] = 0;
                    gamma[26] = 1;
                    gamma[27] = 0;
                    break;
                case 11:
                    gamma[24] = 1;
                    gamma[25] = 0;
                    gamma[26] = 1;
                    gamma[27] = 1;
                    break;
                case 12:
                    gamma[24] = 1;
                    gamma[25] = 1;
                    gamma[26] = 0;
                    gamma[27] = 0;
                    break;
                case 13:
                    gamma[24] = 1;
                    gamma[25] = 1;
                    gamma[26] = 0;
                    gamma[27] = 1;
                    break;
                case 14:
                    gamma[24] = 1;
                    gamma[25] = 1;
                    gamma[26] = 1;
                    gamma[27] = 0;
                    break;
                case 15:
                    gamma[24] = 1;
                    gamma[25] = 1;
                    gamma[26] = 1;
                    gamma[27] = 1;
                    break;
            }


            // ----------- 8 й блок преоброзования -------------------

            x = _round[42] + _round[47] * 2; // X [0;3]
            y = _round[43] + _round[44] * 2 + _round[45] * 4 + _round[46] * 8; // Y [0;15]

            S = S8[x * 16 + y];

            switch (S)
            {
                case 0:
                    gamma[28] = 0;
                    gamma[29] = 0;
                    gamma[30] = 0;
                    gamma[31] = 0;
                    break;
                case 1:
                    gamma[28] = 0;
                    gamma[29] = 0;
                    gamma[30] = 0;
                    gamma[31] = 1;
                    break;
                case 2:
                    gamma[28] = 0;
                    gamma[29] = 0;
                    gamma[30] = 1;
                    gamma[31] = 0;
                    break;
                case 3:
                    gamma[28] = 0;
                    gamma[29] = 0;
                    gamma[30] = 1;
                    gamma[31] = 1;
                    break;
                case 4:
                    gamma[28] = 0;
                    gamma[29] = 1;
                    gamma[30] = 0;
                    gamma[31] = 0;
                    break;
                case 5:
                    gamma[28] = 0;
                    gamma[29] = 1;
                    gamma[30] = 0;
                    gamma[31] = 1;
                    break;
                case 6:
                    gamma[28] = 0;
                    gamma[29] = 1;
                    gamma[30] = 1;
                    gamma[31] = 0;
                    break;
                case 7:
                    gamma[28] = 0;
                    gamma[29] = 1;
                    gamma[30] = 1;
                    gamma[31] = 1;
                    break;
                case 8:
                    gamma[28] = 1;
                    gamma[29] = 0;
                    gamma[30] = 0;
                    gamma[31] = 0;
                    break;
                case 9:
                    gamma[28] = 1;
                    gamma[29] = 0;
                    gamma[30] = 0;
                    gamma[31] = 1;
                    break;
                case 10:
                    gamma[28] = 1;
                    gamma[29] = 0;
                    gamma[30] = 1;
                    gamma[31] = 0;
                    break;
                case 11:
                    gamma[28] = 1;
                    gamma[29] = 0;
                    gamma[30] = 1;
                    gamma[31] = 1;
                    break;
                case 12:
                    gamma[28] = 1;
                    gamma[29] = 1;
                    gamma[30] = 0;
                    gamma[31] = 0;
                    break;
                case 13:
                    gamma[28] = 1;
                    gamma[29] = 1;
                    gamma[30] = 0;
                    gamma[31] = 1;
                    break;
                case 14:
                    gamma[28] = 1;
                    gamma[29] = 1;
                    gamma[30] = 1;
                    gamma[31] = 0;
                    break;
                case 15:
                    gamma[28] = 1;
                    gamma[29] = 1;
                    gamma[30] = 1;
                    gamma[31] = 1;
                    break;
            }

            //  -------------- Перемешивание ----------------------

            System.Int16[] answer = new Int16[len / 2];

            answer[0] = gamma[16 - 1];
            answer[1] = gamma[7 - 1];
            answer[2] = gamma[20 - 1];
            answer[3] = gamma[21 - 1];
            answer[4] = gamma[29 - 1];
            answer[5] = gamma[12 - 1];
            answer[6] = gamma[28 - 1];
            answer[7] = gamma[17 - 1];
            answer[8] = gamma[1 - 1];
            answer[9] = gamma[15 - 1];
            answer[10] = gamma[23 - 1];
            answer[11] = gamma[26 - 1];
            answer[12] = gamma[5 - 1];
            answer[13] = gamma[18 - 1];
            answer[14] = gamma[31 - 1];
            answer[15] = gamma[10 - 1];
            answer[16] = gamma[2 - 1];
            answer[17] = gamma[8 - 1];
            answer[18] = gamma[24 - 1];
            answer[19] = gamma[14 - 1];
            answer[20] = gamma[32 - 1];
            answer[21] = gamma[27 - 1];
            answer[22] = gamma[3 - 1];
            answer[23] = gamma[9 - 1];
            answer[24] = gamma[19 - 1];
            answer[25] = gamma[13 - 1];
            answer[26] = gamma[30 - 1];
            answer[27] = gamma[6 - 1];
            answer[28] = gamma[22 - 1];
            answer[29] = gamma[11 - 1];
            answer[30] = gamma[4 - 1];
            answer[31] = gamma[25 - 1];

            GetNewLR(answer);
        }

        private static void Round16()
        {
            Int16[] buf = new Int16[len / 2];

            buf = L;
            L = R;
            R = buf;
        }

        private static void GetNevKey()
        {
            Initial_Permutation(_gamma);

            for (int i = 0; i < 15; i++)    // Проводим 15 раундов
            {
                Rounds();
            }

            Round16();

            Initial_Permutation_Revert();
        }

        private static void ConwertByteToBitLine(byte sumbol)
        {
            byte _sumbol = sumbol;
            int size = 8;
            int needSize = 0;

            while(_sumbol > 0)
            {
                _sumbol /= 2;
                needSize ++;
            }

            for (int i = 0; i < needSize; i++)
            {
                BL[i + pointer] = Convert.ToInt16(sumbol % 2);
                sumbol /= 2;
            }

            pointer += size;

            if (pointer == len)
            {
                pointer = 0;

                GetNevKey();    // Получили новый ключ
                Dig();    // Складываем ксором и записываем в фаил



                for (int i = 0; i < len; i++)
                {
                    BL[i] = 0;
                }
            }

        }

        private static void ReadBinaryFile()
        {
            Console.Write("Введите путь к файлу: ............. ");
            path = Console.ReadLine();
            path += "/";

            Console.Write("Введите имя файла и расширение: ... ");
            string file = Console.ReadLine();

            int i = 0;

            BinaryReader br = new BinaryReader(File.Open(path + file, FileMode.Open));

            while(br.BaseStream.Position != br.BaseStream.Length)   // Пока не достигнут конец файла
            {
                B = br.ReadByte();
                ConwertByteToBitLine(B);
                i++;
            }
            br.Close();

            if (pointer != 0)
            {
                Dig(pointer);
            }
        }

        public static void Main()
        {
            ReadBinaryFile();
            Console.Read();
        }
    }
}
