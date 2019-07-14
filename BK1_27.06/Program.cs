using System;

namespace BK1_27._06 {

    class Program {

        enum TechCompany {
            Apple, //0
            Nokia, //1
            Honda //2

        }

        enum DayOfWeek {

            MonDay = 1,
            TueDay,
            WedDay,
            ThurDay,
            FriDay,
            SaturDay,
            SunDay,
        }

        enum Drink {
            Tea = 2,
            Enemy_1 = 1,
            Enemy_2 = 1,
            Coffee,
            MilkTea = 2,
        }
        
        static void Main (string[] args) {
            // string[] TechNames = Enum.GetNames (typeof (TechCompany));
            // for (int i = 0; i < TechNames.Length; i++) {
            //     System.Console.WriteLine (TechNames[i]);
            // }

            // string[] WeekNames = Enum.GetNames (typeof (DayOfWeek));
            // for (int i = 0; i < WeekNames.Length; i++) {
            //     System.Console.WriteLine (WeekNames[i]);
            // }

            // System.Console.WriteLine ("==============");
            // int inputValue = Int32.Parse (Console.ReadLine ());
            // System.Console.WriteLine ((DayOfWeek) inputValue);

            // string input = Console.ReadLine ();
            // DayOfWeek day = (DayOfWeek)Enum.Parse (typeof (DayOfWeek), input);            
            // System.Console.WriteLine((int)day);

            // Array dayOffWeeks = Enum.GetValues (typeof (DayOfWeek));
            // for (int i = 0; i < dayOffWeeks.Length; i++) {
            //     DayOfWeek day = (DayOfWeek)dayOffWeeks.GetValue (i);
            //     System.Console.WriteLine ("{0} = {1}",day, (int)day);
            // }

             Drink drink = (Drink) Enum.Parse (typeof (Drink), "MilkTea");
             System.Console.WriteLine(drink);
             
        }
    }
}