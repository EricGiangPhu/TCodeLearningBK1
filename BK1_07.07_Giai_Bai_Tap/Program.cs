using System;

namespace BK1_07._07 {

    //=====================//
    // Start QLSV 
    //====================//
    public enum Genders {
        Unknown,
        Female,
        Male
    }

    public enum AgesStages {
        Child = 0,
        YoungAdult = 18, //18->35 
        MiddleAgedAdults = 36, // 36->55
        OlderAdults = 55, // > 55
        Unknown,
    }

    enum SearchType {
        SearchName = 1,
        SearchID = 2,
        SearchBoth = 3
    }

    class Program {
        public static string InputString (string message) {
            Console.Write (message);
            return Console.ReadLine ();
        }

        public static int InputInt (string message) {
            Console.Write (message);
            return Int32.Parse (Console.ReadLine ());
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
                        Console.Write ("search by name and id :");
                        search = Console.ReadLine ();
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
            Console.Write ("Do you want quit application ?  (Y/N): ");
            string quit = Console.ReadLine ().ToLower ();
            if (quit == "y" || quit == "yes") {
                return true;
            }
            return false;
        }

        static SearchType getChoseTypeSearch () {
            WriteMessageHeader ("Please input your number");
            string infoSearch =
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

        static void baiTap_1_qlsv () {
            WriteMessageHeader ("Bai Tập Quản Lý Sinh Viên");
            //default 3 student, change if you need
            Student[] students = new Student[3];
            InputStudents (students);
            searchStudents (students);
        }

        static void baiTap_2_vector () {
            WriteMessageHeader ("Bai Tập Vector2D");

            Vector2D a = new Vector2D (2, 5);
            Vector2D b = new Vector2D (100, 5);
            System.Console.WriteLine ("A = {0}  B = {1}", a.ToString (), b.ToString ());

            Vector2D cloneVector = a.Clone ();
            System.Console.WriteLine ("CloneA = {0}{1}", cloneVector.ToString (), Environment.NewLine);

            cloneVector.Add (b);
            System.Console.WriteLine ("CloneA.Add(VectorB) => CloneA = {0}{1}", cloneVector.ToString (), Environment.NewLine);

            cloneVector.Div (b);
            System.Console.WriteLine ("CloneA.Div(VectorB) => CloneA = {0}{1}", cloneVector.ToString (), Environment.NewLine);

            cloneVector.Swap (b);
            System.Console.WriteLine ("CloneA.Swap(VectorB) => CloneA = {0}, B = {1}{2}", cloneVector.ToString (), b.ToString (), Environment.NewLine);

            float distance = a.Distance (b);
            System.Console.WriteLine ("CloneA.Distance(VectorB) => distance = {0}{1}", distance, Environment.NewLine);
        }

        static void bonusVector2D () {
            WriteMessageHeader ("Bonus Vector2D");
            Vector2D a = new Vector2D (10, 6);
            Vector2D b = new Vector2D (5, 1);
            System.Console.WriteLine ("A = {0}  B = {1}", a.ToString (), b.ToString ());

            Vector2D c1 = a + b;
            System.Console.WriteLine ("A + B => C = {0}", c1.ToString ());

            Vector2D c2 = a - b;
            System.Console.WriteLine ("A - B => C = {0}", c2.ToString ());

        }

        static void WriteMessageHeader (string message) {
            System.Console.WriteLine ("//=============================//");
            System.Console.WriteLine ("// " + message);
            System.Console.WriteLine ("//=============================//");
        }
        static void Main (string[] args) {
            // baiTap_1_qlsv ();

            // baiTap_2_vector ();

            bonusVector2D ();
        }

    }
}