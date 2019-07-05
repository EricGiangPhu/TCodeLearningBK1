using System;
using System.Collections;
using System.Collections.Generic;

namespace BK1_04._07 {
    /*   
    1. Thiết kế class STUDENT với cấu trúc như sau:
    Trường string FirstName: tên riêng.
    Trường string LastName: họ.
    Trường int Age: tuổi.
    Trường Genders Gender: giới tính, dùng enum Genders { Unknown, Male, Female }.
    Phương thức void ReadInfo(): nhập thông tin học viên từ người dùng.
    Phương thức void WriteInfo(): in ra các thông tin về học viên.
    Nhập liệu và in thông tin cho 3 học viên.

    2. Làm lại bài quản lý sinh viên với class đã tạo ở bài 1.
    Viết thêm trường string Id lưu mã số sinh viên.
    Viết thêm các phương thức kiểm tra so sánh như:
    bool CheckName(string s)
    bool CheckId(string id)
    ===> để phục vụ chức năng tìm kiếm.
*/

    enum Genders {
        Unknown,
        Female,
        Male
    }

    enum SearchType {
        SearchName = 1,
        SearchID = 2,
        SearchBoth = 3
    }
    class Student {

        public string ID;
        public string FirstName;
        public string LastName;
        public int Age;
        public Genders Gender;

        public void ReadInfo () {
            ID = InputString ("Input ID:");
            FirstName = InputString ("Input first name :");
            LastName = InputString ("Input last name :");
            Age = InputInt ("Input age :");
            Gender = GetGender ();
        }

        public void WriteInfo () {
            string info = "Name: " + FirstName + " " + LastName + " Age: " + Age + " Gender:" + Gender;
            Console.WriteLine ("================");
            Console.WriteLine (info);
        }

        public bool CheckName (string s) {
            string fullName = FirstName + " " + LastName;
            return fullName.Contains (s);
        }

        public bool CheckId (string id) {
            return ID.Contains (id);
        }

        public string InputString (string message) {
            Console.Write (message);
            return Console.ReadLine ();
        }

        public int InputInt (string message) {
            Console.Write (message);
            return Int32.Parse (Console.ReadLine ());
        }

        public Genders GetGender () {
            Array genders = Enum.GetValues (typeof (Genders));
            string genderNames = "Please chose gender \n";
            for (int i = 0; i < genders.Length; i++) {
                genderNames += "\t" + (i + 1) + " " + genders.GetValue (i) + "\n";
            }

            Console.WriteLine (genderNames);
            string g = InputString ("Your gender ? :");
            object gender;
            bool isExist = Enum.TryParse (typeof (Genders), g, out gender);
            if (isExist && Enum.IsDefined (typeof (Genders), gender)) {
                return (Genders) gender;
            }

            return Genders.Unknown;
        }
    }

    class Program {
        static void Main (string[] args) {
            // baiTap_1 ();
            baiTap_2 ();
        }

        static void baiTap_1 () {
            Student studentA = new Student ();
            Student studentB = new Student ();
            Student studentC = new Student ();

            //input info student
            studentA.ReadInfo ();
            studentB.ReadInfo ();
            studentC.ReadInfo ();

            //write info student
            studentA.WriteInfo ();
            studentB.WriteInfo ();
            studentC.WriteInfo ();
        }

        static void baiTap_2 () {
            //default 3 student, change if you need
            Student[] students = new Student[3];
            InputStudents (students);
            searchStudents (students);
        }

        static void InputStudents (Student[] students) {
            for (int i = 0; i < students.Length; i++) {
                Console.WriteLine ("Create student {0}", (i + 1));
                students[i] = new Student ();
                students[i].ReadInfo ();
                Console.WriteLine ("=================");
            }
        }

        static void searchStudents (Student[] students) {
            Student[] results = new Student[3];
            do {
                int count = 0;
                string search;
                SearchType searchType = getChoseTypeSearch ();
                switch (searchType) {
                    case SearchType.SearchName:
                        Console.Write ("search by name :");
                        search = Console.ReadLine ();
                        count = searchByName (students, search, results);
                        break;
                    case SearchType.SearchID:
                        Console.Write ("search by id :");
                        search = Console.ReadLine ();
                        count = searchByID (students, search, results);
                        break;
                    case SearchType.SearchBoth:
                        search = Console.ReadLine ();
                        Console.Write ("search by name and id :");
                        count = searchByName (students, search, results);
                        count = count + searchByID (students, search, results);
                        break;
                }

                //Print result
                WriteResults (results, count);

                //check exit
                Console.WriteLine ("===================");
                if (isQuitApplication ()) {
                    break;
                }
            } while (true);
        }

        static bool isQuitApplication () {
            Console.Write ("Do you want quit or continue search ?  (Y/N): ");
            string quit = Console.ReadLine ().ToLower ();
            if (quit == "y" || quit == "yes") {
                return true;
            }
            return false;
        }

        static SearchType getChoseTypeSearch () {
            string infoSearch = "Please input your number" +
                "\n\t 1. Search by name" +
                "\n\t 2. Search by id" +
                "\n\t 3. Search by name and id";
            string messageInput = infoSearch;

            do {
                Console.WriteLine (messageInput);
                Console.Write ("Number ? :");
                object yourChose;
                bool isOK = Enum.TryParse (typeof (SearchType), Console.ReadLine (), out yourChose);
                if (isOK && Enum.IsDefined (typeof (SearchType), yourChose)) {
                    return (SearchType) yourChose;
                }

                messageInput = "Unknown your input. please try again!\n\n" + infoSearch;
                Console.Clear ();
            } while (true);
        }

        static int searchByName (Student[] students, string name, Student[] result) {
            int count = 0;
            for (int i = 0; i < students.Length; i++) {
                if (students[i].CheckName (name)) {
                    result[count] = students[i];
                    count++;

                    if (count >= result.Length) {
                        break;
                    }
                }
            }
            return count;
        }

        static int searchByID (Student[] students, string id, Student[] result) {
            int count = 0;
            for (int i = 0; i < students.Length; i++) {
                if (students[i].CheckId (id)) {
                    result[count] = students[i];
                    count++;

                    if (count >= result.Length) {
                        break;
                    }
                }
            }
            return count;
        }

        static void WriteResults (Student[] result, int count) {
            for (int i = 0; i < count; i++) {
                result[i].WriteInfo ();
            }

            if (count < 1) {
                Console.WriteLine ("Student not found !");
            }
        }
    }
}