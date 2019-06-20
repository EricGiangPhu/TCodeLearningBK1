using System;

namespace TCODELearning {
    class Program {

        public static uint InputUInt (string message) {
            string mg = message;
            do {
                System.Console.Write (mg);
                uint n;
                bool isOk = uint.TryParse (Console.ReadLine (), out n);
                if (isOk) {
                    return n;
                } else {
                    mg = "Vui long nhap lai ! " + message;
                }

            } while (true);
        }

        public static string InputString (string message) {
            string mg = message;
            do {
                System.Console.Write (mg);
                string input = Console.ReadLine ();
                if (input.Trim ().Length > 0) {
                    return input;
                } else {
                    mg = "Vui long nhap lai !, " + message;
                }
            } while (true);
        }

        public static void ResetArrayInt (ref int[] array, int defaultInt = -1) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = defaultInt;
            }
        }

        public static void CreateSV (out string[] mssv, out string[] hoten,
            out int[] tuoi, out string[] thongtin) {

            uint n = InputUInt ("Nhap so sinh vien: ");
            mssv = new string[n];
            hoten = new string[n];
            tuoi = new int[n];
            thongtin = new string[n];
        }

        public static void InsertDataForSV (ref string[] mssv, ref string[] hoten, ref int[] tuoi, ref string[] thongtin) {
            System.Console.WriteLine ("================");
            for (int i = 0; i < mssv.Length; i++) {                
                System.Console.WriteLine ("Nhap thong tin sinh vien {0}", i + 1);
                mssv[i] = InputString ("MSSV: ");
                hoten[i] = InputString ("Ho Ten: ");
                tuoi[i] = (int) InputUInt ("Tuoi: ");
                thongtin[i] = InputString ("Ghi chu : ");
                System.Console.WriteLine ("=================");
            }
        }

        public static int TimTheoMSSV (string[] mssv, string mssvCanTim, ref int[] result) {
            int count = 0;
            for (int i = 0; i < mssv.Length; i++) {
                // //phan biet viet hoa va viet thuong
                // if (mssv[i].Contains (mssvCanTim)) {
                //     result[count] = i;
                //     count++;
                // }

                //phan khong phan biet viet hoa va viet thuong
                if (mssv[i].ToLower ().Contains (mssvCanTim.ToLower ())) {
                    if (count < 3) {
                        result[count] = i;
                        count++;
                    } else {
                        // ket thuc ham neu da tim du 3 hoc sinh theo yeu cau va khong ko can tim nua
                        break;
                    }
                }
            }

            return count;
        }

        static int TimTheoHoTen (string[] hoten, string hotenCanTim, ref int[] result) {
            int count = 0;
            for (int i = 0; i < hoten.Length; i++) {
                // //phan biet viet hoa va viet thuong
                // if (hoten[i].Contains (hotenCanTim)) {
                //     if (count < 3) {
                //         result[count] = i;
                //         count++;
                //     } else {
                //         break;
                //     }
                // }

                //phan khong phan biet viet hoa va viet thuong
                if (hoten[i].ToLower ().Contains (hotenCanTim.ToLower ())) {
                    if (count < 3) {
                        result[count] = i;
                        count++;
                    } else {
                        // ket thuc ham neu da tim du 3 hoc sinh theo yeu cau va khong ko can tim nua
                        break;
                    }
                }
            }

            return count;
        }

        static int TimTheoHoTenVaMssv (string[] mssv, string[] hoten, string chuoiCanTim, ref int[] result) {
            int count = 0;
            for (int i = 0; i < hoten.Length; i++) {
                if (mssv[i].ToLower ().Contains (chuoiCanTim.ToLower ())) {
                    if (count < 3) {
                        result[count] = i;
                        count++;
                        continue; // Chu y: khong xuong ham tim theo ho ten vi sinh vien nay da duoc tim thay
                    } else {
                        // ket thuc ham neu da tim du 3 hoc sinh theo yeu cau va khong ko can tim nua
                        break;
                    }
                }

                //phan khong phan biet viet hoa va viet thuong
                if (hoten[i].ToLower ().Contains (chuoiCanTim.ToLower ())) {
                    if (count < 3) {
                        result[count] = i;
                        count++;
                    } else {
                        // ket thuc ham neu da tim du 3 hoc sinh theo yeu cau va khong ko can tim nua
                        break;
                    }
                }
            }

            return count;
        }

        public static void TimKiem (string[] mssv, string[] hoten, int[] tuoi, string[] thongtin, ref int[] result) {
            int iSoLuongTimDuoc = -1;
            string strCanTim = "";

            do {
                Console.Clear ();
                iSoLuongTimDuoc = -1;
                System.Console.WriteLine ("Vui lòng chọn cách thức tìm kiếm");
                System.Console.WriteLine ("1. Tìm theo MSSV" + Environment.NewLine +
                    "2. Tìm theo Họ Tên" + Environment.NewLine +
                    "3. Tìm theo MSSV và Họ Tên");

                //nhap so minh muon tim
                uint timTheo = InputUInt ("=> ");

                //chon hinh thuc tim sao khi nao so
                switch (timTheo) {
                    case 1:
                        strCanTim = InputString ("Nhap MSSV can tim: ");
                        iSoLuongTimDuoc = TimTheoMSSV (mssv, strCanTim, ref result);
                        break;

                    case 2:
                        strCanTim = InputString ("Nhap ho ten can tim: ");
                        iSoLuongTimDuoc = TimTheoHoTen (hoten, strCanTim, ref result);
                        break;

                    case 3:
                        strCanTim = InputString ("Nhap mssv hoac ho ten can tim: ");
                        iSoLuongTimDuoc = TimTheoHoTenVaMssv (mssv, hoten, strCanTim, ref result);
                        break;

                    default:
                        break;
                }

                if (iSoLuongTimDuoc >= 0) {
                    //show in all result after search
                    hienThiKetQuaTimDuoc (mssv, hoten, tuoi, thongtin, result, iSoLuongTimDuoc);

                    //thoat chuong trinh neu
                    bool isExit = isThoatChuongHayKhong ();
                    if (isExit) {
                        break;
                    }
                }

            } while (true);
        }

        static void hienThiKetQuaTimDuoc (string[] mssv, string[] hoten, int[] tuoi, string[] thongtin, int[] result, int soLuongTimDuoc) {
            if (soLuongTimDuoc > 0) {
                for (int i = 0; i < soLuongTimDuoc; i++) {
                    int vitriSV = result[i];
                    string sinhVien = "Mssv: " + mssv[vitriSV] + "\n" +
                        "HoTen: " + hoten[vitriSV] + "\n" +
                        "Tuoi: " + tuoi[vitriSV] + "\n" +
                        "Ghi chu: " +thongtin[vitriSV];
                    System.Console.WriteLine ("Sinh Vien : {0} \n" + sinhVien, i + 1);
                    System.Console.WriteLine("============");
                }
            } else {
                System.Console.WriteLine("Khong tim thay sinh vien nao");
            }
        }

        static bool isThoatChuongHayKhong () {
            string traLoi = InputString ("Ban co muon tim lai khong Yes/No:").ToLower ();
            if (traLoi == "yes" || traLoi == "y") {
                return false;
            }
            return true;
        }

        //========================================//
        //Ham chinh de chay bai sua bai tap QL SV
        //========================================//
        public static void MainQLSV () {
            string[] mssv;
            string[] hoten;
            string[] thongtin;
            int[] tuoi;
            int[] result = new int[3];

            CreateSV (out mssv, out hoten, out tuoi, out thongtin);
            InsertDataForSV (ref mssv, ref hoten, ref tuoi, ref thongtin);
            TimKiem (mssv, hoten, tuoi, thongtin, ref result);

        }

        //========================================//
        //Bai tap thuc hanh tren lop
        //========================================//
        static void BaiTapThucHanhVeDimensionArray () {
            uint[, ] array = new uint[3, 4];
            for (int i = 0; i < array.GetLength (0); i++) {
                for (int j = 0; j < array.GetLength (1); j++) {
                    array[i, j] = InputUInt ("Vui long nhap gia tri[" + i + "," + j + "] :");
                }
            }

            for (int i = 0; i < array.GetLength (0); i++) {
                for (int j = 0; j < array.GetLength (1); j++) {

                    System.Console.Write ("{0} ", array[i, j]);
                }
                System.Console.WriteLine ();
            }
        }
        
        
        //========================================//
        //Ham main cua chuong trinh
        //========================================//
        static void Main (string[] args) {

            MainQLSV ();

            // BaiTapThucHanhVeDimensionArray ();
        }

    }
}