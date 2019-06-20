/*
BÀI TẬP ĐẠI CA 01 - QUẢN LÝ SINH VIÊN
- MSSV, TÊN, TUỔI, THÔNG TIN
- Tạo danh sách sv theo yêu cầu như sau:
1.  Tạo mảng sinh viên với n phần tử với n được nhập từ người dùng.
    ==>Mảng sinh viên gồm có : mssv[], hoten[], tuoi[], thongtin[] do chúng ta chưa học tới class và struct nên tạm thời dùng nhiều mảng để quản lý 
2.  Nhâp thông tin cho từng sv từ người dùng
3.  Cho phép người dùng tìm sv theo mssv.
4.  Cho phép người dùng tìm sv theo tên
5.  Cho phep người dùng tìm sv theo tên và mssv.
6.  In ra những sv tìm thấy , nếu số lượng tìm thấy lớn hơn 3 thì chỉ hiện 3 sv tìm thấy đầu tiên.
7.  Cuối cùng là hỏi người dùng có muốn tìm tiêp ko ? nếu tiếp tương ứng 'y' hoặc 'yes' thì trở về câu 3 để tiếp tục tìm và ngược lại là 'n' hoặc 'no' thì kết thúc chương trinh và không phân biệt chữ hoa hay thường.
    Chú ý: 
    Phần 3,4,5 phải hiện ra cho người dùng chọn phương pháp nào để tìm
    Phải xử lý các trường hợp người dùng nhập vào mà không đúng hoặc lỏi. ví dụ ham nhập tuổi nếu nhập ko phải số hoặc không nhập gì thì phải yêu cầu nhập lại.
    Tất cả phải tách hàm để có thể tận dụng lại code còn tách như thế nào thì mõi người phải tự nghĩ để xem kết quả của mình vào phút cuối
    Gợi ý : dùng hàm Contains() để check có chuổi mình cần tìm hay ko.
*/

using System;
using Utilities;

namespace bigbrother01_190614
{
    class Program
    {
        static CommonLibrary commonLib = new CommonLibrary();
        static bool isCreated = false, isEmpty = true;
        static int dbSize = 0;
        static string[] mssv, hoten, thongtin;
        static byte[] tuoi;

        static void Main(string[] args)
        {
            Menu();
        }


        /// <summary>
        /// Menu chính
        /// </summary>
        static void Menu()
        {
            string[] items = new string[4] 
            {
                "Tao co so du lieu sinh vien",
                "Nhap du lieu sinh vien",
                "Tim kiem",
                "Thoat"
            };
            commonLib.ItemsList(items);
            
            int selection = commonLib.InputSelection(items.Length);
            Works(selection);
        }


        /// <summary>
        /// Hàm lựa chọn các yêu cầu
        /// </summary>
        /// <param name="selection">int</param>
        static void Works(int selection)
        {
            switch(selection)
            {
                /* Yêu cầu 1 */
                case 1:
                    Console.Clear();
                    W01();
                    Menu();
                    break;
                
                /* Yêu cầu 2 */
                case 2:
                    Console.Clear();
                    W02();
                    Menu();
                    break;

                /* Yêu cầu 3 */
                case 3:
                    Console.Clear();
                    W03();
                    Menu();
                    break;

                /* Thoát chương trinh */
                case 4:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + "BYE BYE!!!!!!!!!!");
                    Environment.Exit(0); // Thông báo system thoát chương trình thành công
                    break;
            }

        }


 


        /***********************************************************************************/
        /*                                      Yêu cầu 1                                  */
        /***********************************************************************************/
        // Tạo mảng sinh viên với n phần tử với n được nhập từ người dùng.
        // Mảng sinh viên gồm có : mssv[], hoten[], tuoi[], thongtin[] 
        // do chúng ta chưa học tới class và struct nên tạm thời dùng nhiều mảng để quản lý 
        static void W01()
        {   
            commonLib.homeworkTitle("Khoi tao co so du lieu sinh vien");

            // Kiểm tra cơ sở dữ liệu đã được tạo chưa.
            // Nếu chưa tạo mới.
            // Nếu rồi hỏi người dùng có tạo lại không.
            if (isCreated)
            {
                string message = "!!! Co so du lieu da ton tai. Ban co muon xoa va tao lai moi? (y/n): ";
                string input = commonLib.YesNoInput(message);

                switch (input)
                {
                    case "y":
                    case "yes":
                        createDB();
                        break;
                    case "n":
                    case "no":
                        break;
                }
            } else 
            {
                createDB();
            }
        }


        /// <summary>
        /// Tạo cơ sở dữ liệu
        /// </summary>
        static void createDB()
        {
            string message = "Nhap kich thuoc co so du lieu: ";
            string int_warning = "- Kich thuoc co so du lieu phai la so nguyen. Vui long nhap lai: ";
            string null_warning = "- Khong de trong. Vui long nhap lai: ";
            dbSize = commonLib.intInput(message, int_warning, null_warning);
            
            mssv = new string[dbSize];
            hoten = new string[dbSize];
            tuoi = new byte[dbSize];
            thongtin = new string[dbSize];

            isCreated = true;
            Console.WriteLine(Environment.NewLine + "!!! Ban da thanh cong tao mot co so du lieu sinh vien vơi kich thuoc {0} sinh vien.", dbSize);
        }


        /***********************************************************************************/
        /*                                      Yêu cầu 2                                  */
        /***********************************************************************************/
        // Nhâp thông tin cho từng sv từ người dùng
        static void W02()
        {   
            commonLib.homeworkTitle("Nhap du lieu sinh vien");
            bool loop = true;

            // Kiểm tra cơ sở dữ liệu có rỗng hay không.
            // Nếu có tiến hành nhập liệu
            if (!isEmpty)
            {
                Console.WriteLine("!!! Du lieu da ton tai." + Environment.NewLine);
            } else
            {
                insertData();
            }
                
            // Hiển thị menu con yêu cầu 2
            while (loop) 
            {
                string input = ViewInsertBackMenu();

                switch (input)
                {
                    case "v":
                    case "view":
                        Console.WriteLine(Environment.NewLine);
                        viewData();
                        break;
                    case "i":
                    case "insert":
                        Console.WriteLine(Environment.NewLine);
                        insertData();
                        break;
                    case "b":
                    case "back":
                        loop = false;
                        break;
                }
            }
        }


        /// <summary>
        /// Tạo menu cho yêu cầu 2
        /// </summary>
        /// <param name="message">Menu</param>
        /// <returns>string</returns>
        static string ViewInsertBackMenu(
            string message = "Chon (v)iew de xem, (i)nsert de nhap lai hoac (b)ack de tro ve: ", 
            string warning = "- Vui long chon (v)iew, (i)nsert hoac (b)ack: ")
        {
            string input = commonLib.stringInput(message, warning).ToLower();
            while (input != "v" && input != "view" && input != "i" && input != "insert" && input != "b" && input != "back" )
            {
                input = commonLib.stringInput(message, warning).ToLower();
            }
            return input;
        }


        /// <summary>
        /// Hàm nhập dữ liệu
        /// </summary>
        static void insertData()
        {
            // Kiểm tra cơ sở dữ liệu được tạo hay chưa
            // Nếu chưa tạo mới
            if (!isCreated)
            {
                Console.WriteLine("!!! Co so du lieu chua duoc khoi tao.");
                createDB();
                Console.WriteLine(Environment.NewLine);
            }

            // Nhập liệu
            for (int i = 0; i < dbSize; ++i)
            {
                Console.WriteLine("Sinh vien {0}:", i + 1);
                
                mssv[i] = commonLib.stringInput("- MSSV: ");
                hoten[i] = commonLib.stringInput("- Ho va ten: ");
                tuoi[i] = commonLib.byteInput("- Tuoi: ");
                thongtin[i] = commonLib.stringInput("- Thong tin: ");

                Console.WriteLine();
            }

            isEmpty = false;
            Console.WriteLine(Environment.NewLine + "!!! Du lieu da hoan thanh" + Environment.NewLine);
        }


        /// <summary>
        /// Hàm xem dữ liệu
        /// </summary>
        static void viewData()
        {
            Console.WriteLine("=============================================================");
            for (int i = 0; i < dbSize; ++i)
            {
                Console.WriteLine("{" + Environment.NewLine
                    + "\tmssv: " + mssv[i] + Environment.NewLine
                    + "\thoten: " + hoten[i] + Environment.NewLine
                    + "\ttuoi: " + tuoi[i] + Environment.NewLine
                    + "\tthongtin: " + thongtin[i] + Environment.NewLine
                    + "}" + Environment.NewLine);
            }
            Console.WriteLine("=============================================================");
        }


        /***********************************************************************************/
        /*                                      Yêu cầu 3                                  */
        /***********************************************************************************/
        // Cho phép người dùng tìm sv theo mssv.
        // Cho phép người dùng tìm sv theo tên
        // Cho phep người dùng tìm sv theo tên và mssv.
        static void W03()
        {
            searchMenu();
        }

        /// <summary>
        /// Danh sách tìm kiếm
        /// </summary>
        static void searchMenu()
        {
            // Nếu cơ sở dữ liệu chưa được tạo, trở vê menu chính
            if (!isCreated)
            {
                Console.WriteLine("!!! Co so du lieu chua duoc tao. Vui long dao co so du lieu truoc");
                Menu();
            }

            // Nếu cơ sở dữ liệu rỗng, trở vê menu chính
            if (isEmpty)
            {
                Console.WriteLine("!!! Co so du lieu rong. Vui long nhap lieu truoc.");
                Menu();
            }


            string[] items = new string[4] 
            {
                "Tim theo mssv",
                "Tim theo ten",
                "Tim theo ten va mssv",
                "Thoat"
            };
            commonLib.ItemsList(items, "=== Tim kiem du lieu ===", false);
            
            int selection = commonLib.InputSelection(items.Length);
            searchSelection(selection);
        }


        static void searchSelection(int selection)
        {
            switch(selection)
            {
                /* Tìm theo mssv */
                case 1:
                    Console.Clear();
                    commonLib.homeworkTitle("Tim theo ma so sinh vien");

                    searchByMSSV();

                    bool mssvLoop = true;
                    while (mssvLoop)
                    {
                        string message = "Ban co muon tiep tuc tim kiem? (y/n): ";
                        string input = commonLib.YesNoInput(message);

                        switch (input)
                        {
                            case "y":
                            case "yes":
                                searchByMSSV();
                                break;
                            case "n":
                            case "no":
                                mssvLoop = false;
                                break;
                        }
                    }
                    searchMenu();
                    break;
                
                /* Tìm theo tên */
                case 2:
                    Console.Clear();
                    commonLib.homeworkTitle("Tim theo ten sinh vien");

                    searchByTen();

                    bool tenLoop = true;
                    while (tenLoop)
                    {
                        string message = "Ban co muon tiep tuc tim kiem? (y/n): ";
                        string input = commonLib.YesNoInput(message);

                        switch (input)
                        {
                            case "y":
                            case "yes":
                                searchByTen();
                                break;
                            case "n":
                            case "no":
                                tenLoop = false;
                                break;
                        }
                    }
                    searchMenu();
                    break;

                /* Tìm theo tên và mssv */
                case 3:
                    Console.Clear();
                    commonLib.homeworkTitle("Tim theo ten va ma so sinh vien");

                    searchByTenAndMSSV();

                    bool tenMSSVLoop = true;
                    while (tenMSSVLoop)
                    {
                        string message = "Ban co muon tiep tuc tim kiem? (y/n): ";
                        string input = commonLib.YesNoInput(message);

                        switch (input)
                        {
                            case "y":
                            case "yes":
                                searchByTenAndMSSV();
                                break;
                            case "n":
                            case "no":
                                tenMSSVLoop = false;
                                break;
                        }
                    }
                    searchMenu();
                    break;

                /* Trở về danh sách tìm kiếm */
                case 4:
                    Menu();
                    break;
            }
        }


        /// <summary>
        /// Tìm kiếm sinh viên theo mssv
        /// </summary>
        static void searchByMSSV()
        {
            int[] result = new int[3];
            int count = 0;
            string mssvString;
            string searchString = commonLib.stringInput("Nhap mssv: ");
            
            for (int i = 0; i < mssv.Length && count < 3; ++i)
            {
                mssvString = mssv[i];
                if (mssvString.Contains(searchString)){
                    result[count] = i;
                    count += 1;
                }
            }

            if (count == 0)
            {
                Console.WriteLine(Environment.NewLine + "!!! Khong co ket qua phu hop.");
            } else
            {
                displayResult(result, count);
            }
        }


        /// <summary>
        /// Hiển thị kết quả tìm kiếm
        /// </summary>
        /// <param name="result">Kết quả</param>
        /// <param name="count">Độ dài kết quả</param>
        static void displayResult(int[] result, int count)
        {
            Console.WriteLine(Environment.NewLine 
                + "=============================================================");
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("{" + Environment.NewLine
                    + "\tmssv: " + mssv[result[i]] + Environment.NewLine
                    + "\thoten: " + hoten[result[i]] + Environment.NewLine
                    + "\ttuoi: " + tuoi[result[i]] + Environment.NewLine
                    + "\tthongtin: " + thongtin[result[i]] + Environment.NewLine
                    + "}" + Environment.NewLine);
            }
            Console.WriteLine("=============================================================");
        }


        /// <summary>
        /// Tìm kiếm sinh viên theo tên
        /// </summary>
        static void searchByTen()
        {
            int[] result = new int[3];
            int count = 0;
            string hotenString;
            string searchString = commonLib.stringInput("Nhap ten: ");
            
            for (int i = 0; i < hoten.Length && count < 3; ++i)
            {
                hotenString = hoten[i];
                if (hotenString.Contains(searchString)){
                    result[count] = i;
                    count += 1;
                }
            }

            if (count == 0)
            {
                Console.WriteLine(Environment.NewLine + "!!! Khong co ket qua phu hop.");
            } else
            {
                displayResult(result, count);
            }
        }


        /// <summary>
        /// Tìm kiếm sinh viên theo tên và mssv
        /// </summary>
        static void searchByTenAndMSSV()
        {
            int[] result = new int[3];
            int count = 0;
            string hotenString, mssvString;
            string searchHotenString = commonLib.stringInput("Nhap ten: ");
            string searchMSSVString = commonLib.stringInput("Nhap mssv: ");
            
            for (int i = 0; i < hoten.Length && count < 3; ++i)
            {
                hotenString = hoten[i];
                mssvString = mssv[i];

                if (hotenString.Contains(searchHotenString) && mssvString.Contains(searchMSSVString))
                {
                    result[count] = i;
                    count += 1;
                }
            }

            if (count == 0)
            {
                Console.WriteLine(Environment.NewLine + "!!! Khong co ket qua phu hop.");
            } else
            {
                displayResult(result, count);
            }

        }
  
    }
}