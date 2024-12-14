using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gnmarkhead
{
    public class Head
    {
        public int Hid;
        public string Hname;
        public string HsystemName;
        public string AssesmentType;
        public string ExamLevel;
        public string Htype;
        //public int MaxMarks;
        //public int PassingMarks;
        public string MarkHeadFormula;
        

        public Head(int headid, string hname, string hsystemname ,  string assesmentType, string examLevel, string htype, int maxMarks , string markheadformula , int passingmarks)
        {
            Hid = headid;
            Hname = hname;
            HsystemName = hsystemname;
            AssesmentType = assesmentType;
            ExamLevel = examLevel;
            Htype = htype;
            //MaxMarks = maxMarks;
            MarkHeadFormula = markheadformula;
            //PassingMarks = passingmarks;

        }


    }

    public class HeadDataTable
    {
        public static DataTable ConvrtTotable(List<Head> heads)
        {

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Headid", typeof(int));
            dataTable.Columns.Add("Hname", typeof(string));
            dataTable.Columns.Add("HsystemName", typeof(string));
            dataTable.Columns.Add("AssesmentType", typeof(string));
            dataTable.Columns.Add("ExamLevel", typeof(string));
            dataTable.Columns.Add("Htype", typeof(string));
            //dataTable.Columns.Add("MaxMarks", typeof(int));
            dataTable.Columns.Add("MarkHeadFormula", typeof(string));
            //dataTable.Columns.Add("PassingMarks", typeof(int));


            foreach (Head head in heads)
            {
                DataRow row = dataTable.NewRow();
                row["Headid"] = head.Hid;
                row["Hname"] = head.Hname;
                row["HsystemName"] = head.HsystemName;
                row["AssesmentType"] = head.AssesmentType;
                row["ExamLevel"] = head.ExamLevel;
                row["Htype"] = head.Htype;
                //row["MaxMarks"] = head.MaxMarks;
                row["MarkHeadFormula"] = head.MarkHeadFormula;
                //row["PassingMarks"] = head.PassingMarks;

                dataTable.Rows.Add(row);
            }


            return dataTable; 

        }


        public static DataTable main()
        {


            List<Head> heads = new List<Head>
        {
            new Head(1, "internal theory","it", "theory", "internal", "individual", 50 , "" , 18),
            new Head(2, "internal practical", "ip" , "practical", "internal", "individual", 50 , "" , 18),
            new Head(3, "tutorial", "TT", "tutorial", "internal", "individual" ,50 , "", 18),
            new Head(4, "external theory", "et", "theory", "external", "individual" ,100 , "",34),
            new Head(5, "external practical", "ep", "practical", "external", "individual" ,50 , "",18),
            new Head(6, "theory", "th", "theory", " ", "composite" ,100 , "2*it" , 52),
            new Head(7 , "practical" , "pt" , "practical" , " " , "composite" , 200 , "ip+ep" , 36),
            new Head(8 , "internal" , "ii" , "" , " " , "composite" , 200 , "(ip+it)*3" , 36),
            new Head(9 , "external" , "ee" , "" , " " , "composite" , 200 , "ep+et" , 52),
            new Head(10 , "Grand Total" , "gt" , "" , " " , "composite" , 200 , "(ii+ee)/2" , 52),
            new Head(11 , "PCT" , "PT" , "" , " " , "composite" , 200 , "2*gt" , 52),
            new Head(12 , "PCTe" , "km" , "" , " " , "composite" , 200 , "PT+gt" , 52),
            new Head(13 , "PCTee" , "Ppp" , "" , " " , "composite" , 200 , "it*ip" , 52),
                  
          

        };

            DataTable dataTable = ConvrtTotable(heads);


            return dataTable; 
        }
    }
}