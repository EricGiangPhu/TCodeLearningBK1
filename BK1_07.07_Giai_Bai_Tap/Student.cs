using System;
namespace BK1_07._07 {
    public class Student {

        readonly string id;
        string firstName;
        string lastName;
        int age;
        Genders gender;
        AgesStages agesStage;

        public Student () {
            this.id = Program.InputString ("Input ID:");
        }
        public void ReadInfo () {
            this.FirstName = Program.InputString ("Input first name :");;
            this.LastName = Program.InputString ("Input last name :");
            this.Age = Program.InputInt ("Input age :");
            this.Gender = GetGender ();            
        }

        public void WriteInfo () {
            string info = "Name: " + firstName + " " + lastName + " Age: " + age + " Gender:" + gender + " AgesStage:" + agesStage;
            Console.WriteLine ("================");
            Console.WriteLine (info);
        }

        public bool CheckName (string s) {
            string fullName = firstName + " " + lastName;
            return fullName.Contains (s);
        }

        public bool CheckId (string id) {
            return this.id.Contains (id);
        }

        public Genders GetGender () {
            Array genders = Enum.GetValues (typeof (Genders));
            string genderNames = "Please chose gender \n";
            for (int i = 0; i < genders.Length; i++) {
                genderNames += "\t" + (i + 1) + " " + genders.GetValue (i) + "\n";
            }

            Console.WriteLine (genderNames);
            string g = Program.InputString ("Your gender ? :");
            object gender;
            bool isExist = Enum.TryParse (typeof (Genders), g, out gender);
            if (isExist && Enum.IsDefined (typeof (Genders), gender)) {
                return (Genders) gender;
            }

            return Genders.Unknown;
        }

        void handleAgesStage () {
            if (this.age >= (int) AgesStages.OlderAdults) {
                this.agesStage = AgesStages.OlderAdults;
            } else if (this.age >= (int) AgesStages.MiddleAgedAdults) {
                this.agesStage = AgesStages.MiddleAgedAdults;
            } else if (this.age >= (int) AgesStages.YoungAdult) {
                this.agesStage = AgesStages.YoungAdult;
            } else if (this.age >= (int) AgesStages.Child) {
                this.agesStage = AgesStages.Child;
            } else {
                this.agesStage = AgesStages.Unknown;
            }
        }

        public string FirstName {
            get {
                return this.firstName;
            }
            set {
                this.firstName = value;
            }
        }
        public string LastName {
            get {
                return this.lastName;
            }
            set {
                this.lastName = value;
            }
        }
        public int Age {
            get {
                return this.age;
            }
            set {
                this.age = value;
                this.handleAgesStage ();
            }
        }
        public Genders Gender {
            get {
                return this.gender;
            }
            set {
                this.gender = value;
            }
        }

        public AgesStages AgesStage {
            get {
                return this.agesStage;
            }
            set {
                this.agesStage = value;
            }
        }
    }
}