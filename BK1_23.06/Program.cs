using System;

namespace BK1_23._06 {
    class Program {
        static void Main (string[] args) {
            // showAndCountLowerCharWhenInput()
            // upperCaseFirstCharacterAndAfterSpace ();
            // splitStringWithSeparator ();
        }

        /*==========================//
         * BÀI THỰC HÀNH 1
         * =>Cho người dùng nhập 1 chuổi
         * 1. In ra số lượng ký tự thường
         * 2. In ra những ký tự thường
         */
        static void showAndCountLowerCharWhenInput () {
            string str = Console.ReadLine ();
            int count = 0;
            string lowerChars = "";
            for (int i = 0; i < str.Length; i++) {
                char ch = str[i];
                if (ch >= 'a' && ch <= 'z') {
                    count++;
                    lowerChars += ch + " ";
                }
            }
            System.Console.WriteLine ("Number lower characters {0}", count);
            System.Console.WriteLine ("isLower: {0}", lowerChars);
        }

        /*=======================================
         * BÀI THỰC HÀNH 2
         * Nhập một chuỗi họ và tên.
         * In ra họ riêng, tên riêng.
         * Viêt hoa chữ cái đầu của họ và tên.
         */

        static void upperCaseFirstCharacterAndAfterSpace () {
            System.Console.Write ("Nhap họ và tên: ");
            string hoVaTen = Console.ReadLine ();
            string ho = "";
            string ten = "";

            for (int i = 0; i < hoVaTen.Length; i++) {
                char k = hoVaTen[i];
                if (k == ' ') {
                    ho = hoVaTen.Substring (0, i);
                    ten = hoVaTen.Substring (i + 1, hoVaTen.Length - i - 1);
                    break;
                }
            }

            ho = ho[0].ToString ().ToUpper () + ho.Substring (1);
            string tenVietHoa = "";
            for (int i = 0; i < ten.Length; i++) {
                char k = ten[i];
                if (i == 0) {
                    tenVietHoa += k.ToString ().ToUpper ();
                } else if (k == ' ') {
                    if ((i + 1) < ten.Length) {
                        tenVietHoa += k.ToString () + ten[i + 1].ToString ().ToUpper ();
                        i += 1;
                    }
                } else {
                    tenVietHoa += k;
                }
            }

            ten = ten[0].ToString ().ToUpper () + ten.Substring (1);
            System.Console.WriteLine ("Ho = {0} , Ten = {1}", ho, tenVietHoa);
        }

        /*=======================================
         * BÀI THỰC HÀNH 3
         * 
         * 
         * 
         */
        static void splitStringWithSeparator () {
            string str = "HellozzzWorldzzzThezzzCode";
            // Separator = zzz
            string[] words = str.Split ("zzz", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++) {
                System.Console.WriteLine (words[i]);
            }
        }
    }
}