using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gnmarkhead
{
    public class Student
    {
        public int Sid { get; set; }
       
     
        public string Subject { get; set; }

        public int HeadId { get; set; }
         
        public int MaxMarks { get; set; }

        public int PassingMarks { get; set; }


        public int ObtainedMarks { get; set; }


        public Student(int sid, string subject, int headId = 0, int maxMarks = 0, int passingMarks = 0, int obtainedMarks = 0)
        {
            Sid = sid;
            Subject = subject;
            HeadId = headId;
            MaxMarks = maxMarks;
            PassingMarks = passingMarks;
            ObtainedMarks = obtainedMarks;
        }



    }

    public class StudenttoDatatable
    {
        public static DataTable convert_datatable(List<Student> students)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Sid", typeof(int));
            dataTable.Columns.Add("Subject", typeof(String));
            dataTable.Columns.Add("Headid", typeof(int));
            dataTable.Columns.Add("MaxMarks", typeof(int));
            dataTable.Columns.Add("PassingMarks", typeof(int));

            dataTable.Columns.Add("ObtainedMarks", typeof(int));

            foreach(Student student in students)
            {
                DataRow row = dataTable.NewRow();
                row["Sid"] = student.Sid;
                row["Subject"] = student.Subject;
                row["Headid"] = student.HeadId;
                row["MaxMarks"] = student.MaxMarks;
                row["PassingMarks"] = student.PassingMarks;
                row["ObtainedMarks"] = student.ObtainedMarks;
                dataTable.Rows.Add(row);

            }

            return dataTable; 

        }

        public static DataTable main()
        {

            

            List<Student> students = new List<Student>
        {

          new Student(1, "Math", 1, 85, 35, 85),
new Student(1, "Science", 1, 90, 35, 90),
new Student(1, "History", 1, 70, 35, 70),
new Student(1, "English", 1, 90, 35, 90),
new Student(1, "Geography", 1, 70, 35, 70),

new Student(1, "Math", 2, 78, 35, 78),
new Student(1, "Science", 2, 88, 35, 88),
new Student(1, "History", 2, 82, 35, 82),
new Student(1, "English", 2, 95, 35, 95),
new Student(1, "Geography", 2, 65, 35, 65),

new Student(1, "Math", 3, 92, 35, 92),
new Student(1, "Science", 3, 87, 35, 87),
new Student(1, "History", 3, 74, 35, 74),
new Student(1, "English", 3, 88, 35, 88),
new Student(1, "Geography", 3, 93, 35, 93),

new Student(1, "Math", 4, 80, 35, 80),
new Student(1, "Science", 4, 85, 35, 85),
new Student(1, "History", 4, 75, 35, 75),
new Student(1, "English", 4, 92, 35, 92),
new Student(1, "Geography", 4, 80, 35, 80),

new Student(1, "Math", 5, 90, 35, 90),
new Student(1, "Science", 5, 92, 35, 92),
new Student(1, "History", 5, 78, 35, 78),
new Student(1, "English", 5, 89, 35, 89),
new Student(1, "Geography", 5, 85, 35, 85),

new Student(2, "Math", 1, 27, 35, 27),
new Student(2, "Science", 1, 13, 35, 13),
new Student(2, "History", 1, 30, 35, 30),
new Student(2, "English", 1, 25, 35, 25),
new Student(2, "Geography", 1, 16, 35, 16),

new Student(2, "Math", 2, 20, 35, 20),
new Student(2, "Science", 2, 18, 35, 18),
new Student(2, "History", 2, 22, 35, 22),
new Student(2, "English", 2, 15, 35, 15),
new Student(2, "Geography", 2, 19, 35, 19),

new Student(2, "Math", 3, 25, 35, 25),
new Student(2, "Science", 3, 20, 35, 20),
new Student(2, "History", 3, 30, 35, 30),
new Student(2, "English", 3, 17, 35, 17),
new Student(2, "Geography", 3, 28, 35, 28),

new Student(2, "Math", 4, 29, 35, 29),
new Student(2, "Science", 4, 27, 35, 27),
new Student(2, "History", 4, 18, 35, 18),
new Student(2, "English", 4, 22, 35, 22),
new Student(2, "Geography", 4, 19, 35, 19),

new Student(2, "Math", 5, 18, 35, 18),
new Student(2, "Science", 5, 26, 35, 26),
new Student(2, "History", 5, 21, 35, 21),
new Student(2, "English", 5, 19, 35, 19),
new Student(2, "Geography", 5, 23, 35, 23),

new Student(1001, "Math", 1, 85, 90, 82),
new Student(1002, "Science", 2, 92, 88, 95),
new Student(1003, "History", 3, 78, 75, 80),
new Student(1004, "English", 4, 95, 92, 90),
new Student(1005, "Art", 5, 88, 85, 82),
new Student(1006, "Music", 1, 90, 88, 92),
new Student(1007, "PE", 2, 75, 78, 80),
new Student(1008, "Tech", 3, 98, 95, 92),
new Student(1009, "Math", 4, 82, 85, 88),
new Student(1010, "Science", 5, 91, 90, 88),
new Student(1011, "History", 1, 80, 78, 82),
new Student(1012, "English", 2, 93, 95, 90),
new Student(1013, "Art", 3, 85, 82, 88),
new Student(1014, "Music", 4, 92, 90, 88),
new Student(1015, "PE", 5, 78, 80, 82),
new Student(1016, "Tech", 1, 96, 98, 95),
new Student(1017, "Math", 2, 83, 85, 88),
new Student(1018, "Science", 3, 90, 88, 92),
new Student(1019, "History", 4, 79, 82, 85),
new Student(1020, "English", 5, 94, 92, 90),
new Student(1021, "Art", 1, 82, 85, 88),
new Student(1022, "Music", 2, 90, 88, 92),
new Student(1023, "PE", 3, 78, 80, 82),
new Student(1024, "Tech", 4, 95, 92, 90),
new Student(1025, "Math", 5, 88, 85, 82),
new Student(1026, "Science", 1, 92, 88, 95),
new Student(1027, "History", 2, 78, 75, 80),
new Student(1028, "English", 3, 90, 88, 92),
new Student(1029, "Art", 4, 85, 82, 88),
new Student(1030, "Music", 5, 92, 90, 88),
new Student(1031, "PE", 1, 78, 80, 82),
new Student(1032, "Tech", 2, 96, 98, 95),
new Student(1033, "Math", 3, 83, 85, 88),
new Student(1034, "Science", 4, 90, 88, 92),
new Student(1035, "History", 5, 79, 82, 85),
new Student(1036, "English", 1, 94, 92, 90),
new Student(1037, "Art", 2, 82, 85, 88),
new Student(1038, "Music", 3, 90, 88, 92),
new Student(1039, "PE", 4, 78, 80, 82),
new Student(1040, "Tech", 5, 95, 92, 90),
new Student(1041, "Math", 1, 85, 90, 82),
new Student(1042, "Science", 2, 92, 88, 95),
new Student(1043, "History", 3, 78, 75, 80),
new Student(1044, "English", 4, 95, 92, 90),
new Student(1045, "Art", 5, 88, 85, 82),
new Student(1046, "Music", 1, 90, 88, 92),
new Student(1047, "PE", 2, 75, 78, 80),
new Student(1048, "Tech", 3, 98, 95, 92),
new Student(1049, "Math", 4, 82, 85, 88),
new Student(1050, "Science", 5, 91, 90, 88),
new Student(1051, "History", 1, 80, 78, 82),
new Student(1052, "English", 2, 93, 95, 90),
new Student(1053, "Art", 3, 85, 82, 88),
new Student(1054, "Music", 4, 92, 90, 88),
new Student(1055, "PE", 5, 78, 80, 82),
new Student(1056, "Tech", 1, 96, 98, 95),
new Student(1057, "Math", 2, 83, 85, 88),
new Student(1058, "Science", 3, 90, 88, 92),
new Student(1059, "History", 4, 79, 82, 85),
new Student(1060, "English", 5, 94, 92, 90),
new Student(1061, "Art", 1, 82, 85, 88),
new Student(1062, "Music", 2, 90, 88, 92),
new Student(1063, "PE", 3, 78, 80, 82),
new Student(1064, "Tech", 4, 95, 92, 90),
new Student(1065, "Math", 5, 88, 85, 82),
new Student(1066, "Science", 1, 92, 88, 95),
new Student(1067, "History", 2, 78, 75, 80),
new Student(1068, "English", 3, 90, 88, 92),
new Student(1069, "Art", 4, 85, 82, 88),
new Student(1070, "Music", 5, 92, 90, 88),
new Student(1071, "PE", 1, 78, 80, 82),
new Student(1072, "Tech", 2, 96, 98, 95),
new Student(1073, "Math", 3, 83, 85, 88),
new Student(1074, "Science", 4, 90, 88, 92),
new Student(1075, "History", 5, 79, 82, 85),
new Student(1076, "English", 1, 94, 92),

new Student(122116, "Physics", 1, 40, 40, 30),
new Student(131645, "English", 1, 40, 35, 28),
new Student(125678, "Mathematics", 2, 50, 45, 42),
new Student(132987, "Chemistry", 3, 40, 38, 33),
new Student(124563, "Physics", 4, 30, 25, 20),
new Student(137981, "Mathematics", 5, 45, 40, 40),
new Student(122776, "Chemistry", 1, 20, 15, 10),
new Student(129845, "Physics", 2, 45, 40, 35),
new Student(133489, "English", 3, 30, 28, 25),
new Student(141124, "Chemistry", 4, 60, 55, 50),
new Student(145676, "Physics", 5, 60, 50, 50),
new Student(152455, "Mathematics", 1, 50, 45, 38),
new Student(137858, "English", 2, 20, 15, 12),
new Student(146789, "Physics", 3, 30, 28, 24),
new Student(154236, "Mathematics", 4, 70, 60, 55),
new Student(128743, "Chemistry", 5, 40, 35, 30),
new Student(132764, "Physics", 1, 45, 40, 35),
new Student(135437, "English", 2, 35, 30, 28),
new Student(121876, "Mathematics", 3, 50, 48, 45),
new Student(146239, "Chemistry", 4, 30, 25, 22),
new Student(139876, "Physics", 5, 20, 18, 15),
new Student(120963, "English", 1, 40, 35, 32),
new Student(144512, "Mathematics", 2, 50, 48, 45),
new Student(124875, "Chemistry", 3, 60, 55, 50),
new Student(137198, "Physics", 4, 30, 25, 22),
new Student(149675, "English", 5, 45, 40, 38),
new Student(134289, "Mathematics", 1, 40, 35, 32),
new Student(136471, "Chemistry", 2, 30, 28, 24),
new Student(128347, "Physics", 3, 50, 48, 45),
new Student(155478, "English", 4, 40, 35, 32),
new Student(149762, "Mathematics", 5, 45, 40, 38),
new Student(124586, "Chemistry", 1, 60, 55, 50),
new Student(138561, "Physics", 2, 20, 15, 10),
new Student(144354, "English", 3, 40, 35, 32),
new Student(131567, "Mathematics", 4, 50, 45, 40),
new Student(125879, "Chemistry", 5, 30, 28, 25),
new Student(148763, "Physics", 1, 55, 50, 45),
new Student(138456, "English", 2, 40, 38, 35),
new Student(129867, "Mathematics", 3, 60, 55, 52),
new Student(124839, "Chemistry", 4, 30, 28, 25),
new Student(145376, "Physics", 5, 45, 42, 40),
new Student(141284, "English", 1, 50, 45, 40),
new Student(132548, "Mathematics", 2, 45, 40, 35),
new Student(120836, "Chemistry", 3, 60, 55, 50),
new Student(138542, "Physics", 4, 40, 35, 30),
new Student(126823, "English", 5, 30, 25, 22),
new Student(147564, "Mathematics", 1, 70, 60, 55),
new Student(129876, "Chemistry", 2, 45, 40, 38),
new Student(137652, "Physics", 3, 50, 45, 42),
new Student(154781, "English", 4, 40, 35, 30),
new Student(120475, "Mathematics", 5, 30, 25, 22),
new Student(143756, "Chemistry", 1, 55, 50, 48),
new Student(146372, "Physics", 2, 45, 40, 38),
new Student(138765, "English", 3, 50, 45, 42),
new Student(132459, "Mathematics", 4, 60, 55, 52),
new Student(145342, "Chemistry", 5, 45, 42, 40),
new Student(154132, "Physics", 1, 55, 50, 48),
new Student(124783, "English", 2, 30, 25, 22),
new Student(139485, "Mathematics", 3, 70, 60, 55),
new Student(141237, "Chemistry", 4, 40, 35, 32),
new Student(132904, "Physics", 5, 45, 42, 40),
new Student(137564, "English", 1, 50, 45, 42),
new Student(141853, "Mathematics", 2, 60, 55, 50),
new Student(121258, "Chemistry", 3, 30, 28, 25),
new Student(133289, "Physics", 4, 40, 35, 30),
new Student(145232, "English", 5, 60, 55, 50),
new Student(152435, "Mathematics", 1, 30, 28, 25),
new Student(145639, "Chemistry", 2, 40, 35, 30),
new Student(138249, "Physics", 3, 55, 50, 48),
new Student(123874, "English", 4, 60, 55, 50),
new Student(134867, "Mathematics", 5, 45, 40, 38),
new Student(149832, "Chemistry", 1, 70, 60, 55),
new Student(128579, "Physics", 2, 45, 40, 38),
new Student(137184, "English", 3, 50, 45, 42),
new Student(120435, "Mathematics", 4, 60, 55, 52),
new Student(141739, "Chemistry", 5, 30, 28, 25),
new Student(132974, "Physics", 1, 55, 50, 45),
new Student(125678, "English", 2, 40, 35, 32),
new Student(134790, "Mathematics", 3, 45, 42, 38),
new Student(148237, "Chemistry", 4, 60, 55, 50),
new Student(123567, "Physics", 5, 30, 28, 25),
new Student(145762, "English", 1, 50, 45, 42),
new Student(132609, "Mathematics", 2, 40, 35, 30),
new Student(139560, "Chemistry", 3, 50, 45, 40),
new Student(140765, "Physics", 4, 60, 55, 50),
new Student(120946, "English", 5, 45, 40, 38),
new Student(134520, "Mathematics", 1, 45, 42, 40),
new Student(128530, "Chemistry", 2, 55, 50, 48),
new Student(136759, "Physics", 3, 70, 60, 55),
new Student(145374, "English", 4, 50, 45, 42),
new Student(120586, "Mathematics", 5, 40, 35, 30),
new Student(137924, "Chemistry", 1, 60, 55, 50),
new Student(132475, "Physics", 2, 30, 25, 20),
new Student(140736, "English", 3, 45, 40, 38),
new Student(125438, "Mathematics", 4, 60, 55, 50),
new Student(123609, "Chemistry", 5, 50, 45, 42),
new Student(149827, "Physics", 1, 55, 50, 48),
new Student(136982, "English", 2, 60, 55, 52),
new Student(134512, "Mathematics", 3, 30, 28, 25),
new Student(140975, "Chemistry", 4, 40, 35, 30),
new Student(121657, "Physics", 5, 45, 40, 38),
new Student(145289, "English", 1, 50, 45, 42),
new Student(132689, "Mathematics", 2, 60, 55, 52),
new Student(138720, "Chemistry", 3, 45, 42, 40),
new Student(137640, "Physics", 4, 50, 45, 42),
new Student(123894, "English", 5, 60, 55, 50),
new Student(125738, "Mathematics", 1, 45, 40, 38),
new Student(136481, "Chemistry", 2, 40, 35, 32),
new Student(139654, "Physics", 3, 55, 50, 48),
new Student(124572, "English", 4, 50, 45, 42),
new Student(128925, "Mathematics", 5, 60, 55, 52),
new Student(140732, "Chemistry", 1, 30, 28, 25),
new Student(132549, "Physics", 2, 70, 60, 55),
new Student(121479, "English", 3, 40, 35, 30),
new Student(137286, "Mathematics", 4, 60, 55, 52),
new Student(145973, "Chemistry", 5, 45, 40, 38),
new Student(133680, "Physics", 1, 50, 45, 42),
new Student(124981, "English", 2, 60, 55, 50),
new Student(139102, "Mathematics", 3, 70, 60, 55),
new Student(136520, "Chemistry", 4, 40, 35, 30),
new Student(120765, "Physics", 5, 45, 42, 40),
new Student(134580, "English", 1, 50, 45, 42),
new Student(145638, "Mathematics", 2, 60, 55, 52),
new Student(138781, "Chemistry", 3, 45, 40, 38),
new Student(121698, "Physics", 4, 70, 60, 55),
new Student(129467, "English", 5, 30, 28, 25),
new Student(134823, "Mathematics", 1, 55, 50, 48),
new Student(142689, "Chemistry", 2, 50, 45, 42),
new Student(132784, "Physics", 3, 40, 35, 32),
new Student(121348, "English", 4, 60, 55, 52),
new Student(138763, "Mathematics", 5, 45, 42, 40),
new Student(139837, "Chemistry", 1, 30, 28, 25),
new Student(137249, "Physics", 2, 60, 55, 50),
new Student(123598, "English", 3, 50, 45, 42),
new Student(128596, "Mathematics", 4, 60, 55, 52),
new Student(145673, "Chemistry", 5, 40, 35, 30),
new Student(134509, "Physics", 1, 55, 50, 48),
new Student(137764, "English", 2, 45, 40, 38),
new Student(129875, "Mathematics", 3, 60, 55, 52),
new Student(145391, "Chemistry", 4, 45, 40, 38),
new Student(138986, "Physics", 5, 30, 25, 20),
new Student(121265, "English", 1, 60, 55, 52),
new Student(137689, "Mathematics", 2, 40, 35, 32),
new Student(132478, "Chemistry", 3, 50, 45, 42),
new Student(145371, "Physics", 4, 60, 55, 50),
new Student(138924, "English", 5, 45, 42, 40),
new Student(132634, "Mathematics", 1, 45, 40, 38),
new Student(120934, "Chemistry", 2, 55, 50, 48),
new Student(124587, "Physics", 3, 60, 55, 52),
new Student(137945, "English", 4, 50, 45, 42),
new Student(128352, "Mathematics", 5, 40, 35, 32),
new Student(145276, "Chemistry", 1, 60, 55, 52),
new Student(141963, "Physics", 2, 70, 60, 55),
new Student(134652, "English", 3, 50, 45, 42),
new Student(132894, "Mathematics", 4, 45, 42, 40),
new Student(137520, "Chemistry", 5, 30, 25, 22),
new Student(120765, "Physics", 1, 55, 50, 48),
new Student(134809, "English", 2, 60, 55, 50),
new Student(138654, "Mathematics", 3, 40, 35, 32),
new Student(137409, "Chemistry", 4, 50, 45, 42),
new Student(120835, "Physics", 5, 70, 60, 55),
new Student(132417, "English", 1, 30, 28, 25),
new Student(145749, "Mathematics", 2, 60, 55, 52),
new Student(138679, "Chemistry", 3, 55, 50, 48),
new Student(137528, "Physics", 4, 60, 55, 50),
new Student(124763, "English", 5, 45, 42, 40),
new Student(129645, "Mathematics", 1, 40, 35, 32),
new Student(132917, "Chemistry", 2, 50, 45, 42),
new Student(139861, "Physics", 3, 70, 60, 55),
new Student(120746, "English", 4, 55, 50, 48),
new Student(138563, "Mathematics", 5, 45, 42, 40),








        };

            DataTable Std_dt = new DataTable();

            Std_dt = convert_datatable(students);

            return Std_dt;
                 
        }


        
    }



}