using System;
using System.Collections.Generic;

namespace tes2
{
    class Program
    {
        static void Main()
        {
            string input1 = "{[()]}";
            string input2 = "{[(])}";
            string input3 = "{(([])[])[]}";

            Console.WriteLine("Output 1: " + (IsBalanced(input1) ? "YES" : "NO"));
            Console.WriteLine("Output 2: " + (IsBalanced(input2) ? "YES" : "NO"));
            Console.WriteLine("Output 3: " + (IsBalanced(input3) ? "YES" : "NO"));
            Console.ReadLine();
        }

        static bool IsBalanced(string s)
        {
            // Jika panjang string tidak genap, langsung kembalikan false
            if (s.Length % 2 != 0)
            {
                return false;
            }

            // Inisialisasi tumpukan untuk menyimpan karakter buka
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                // Jika karakter adalah karakter buka, masukkan ke dalam stack
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    // Jika stack kosong atau karakter tutup tidak sesuai dengan karakter buka di atas tumpukan, kembalikan false
                    if (stack.Count == 0 ||
                       (c == ')' && stack.Peek() != '(') ||
                       (c == '}' && stack.Peek() != '{') ||
                       (c == ']' && stack.Peek() != '['))
                    {
                        return false;
                    }
                    stack.Pop(); // Hapus karakter buka yang sesuai karena sudah ditemukan pasangannya
                }
            }

            // Jika tumpukan kosong, berarti semua pasangan ditemukan dan seimbang
            return stack.Count == 0;
        }

    }
}
