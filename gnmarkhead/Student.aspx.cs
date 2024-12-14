using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using RoslynScriptOptions = Microsoft.CodeAnalysis.Scripting.ScriptOptions; 

namespace gnmarkhead
{
    public partial class Student1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = StudenttoDatatable.main();
                DataTable dt1 = HeadDataTable.main();
               

                BindGrids(dt, dt1);

                var studentGroups = dt.AsEnumerable()
                                      .GroupBy(r => r.Field<int>("Sid"))
                                      .ToList();

             
                DataTable dt6 = dt;
                dt6.Columns.Add("Result", typeof(string));
                dt6.Columns.Add("MarkGracingRequired", typeof(int));

                foreach (DataRow row in dt.Rows)
                {
                    int obtainedmarks = row.Field<int>("ObtainedMarks");
                    int headid = row.Field<int>("Headid");
                    int passingmarks = row.Field<int>("PassingMarks");
 

                    if (obtainedmarks > passingmarks)
                    {
                        row["Result"] = "Pass";
                        row["MarkGracingRequired"] = 0;
                    }
                    else
                    {
                        row["Result"] = "Fail";
                        row["MarkGracingRequired"] = passingmarks - obtainedmarks;
                    }
                }

               
                foreach (DataRow row in dt1.Rows)
                {
                    string headformula = row.Field<string>("MarkHeadFormula");
         

                    int maxhead = dt.AsEnumerable().Max(r => r.Field<int>("Headid"));

                  
                    if (!string.IsNullOrEmpty(headformula))
                    {
                        foreach (var group in studentGroups)
                        {
                            int stdid = group.Key;

                            var groupbysubject = group.AsEnumerable().GroupBy(r => r.Field<string>("Subject")).ToList();

                            foreach (var groupsubject in groupbysubject)
                            {
                                string subject = groupsubject.Key.ToString();
                                int maxmarks = Convert.ToInt32(groupsubject.AsEnumerable().Select(r => r.Field<int>("MaxMarks")).FirstOrDefault());

                                int passingmarks = Convert.ToInt32(groupsubject.AsEnumerable().Select(r => r.Field<int>("PassingMarks")).FirstOrDefault());




                                string formulaToEvaluate = headformula;

                                formulaToEvaluate = Replace(formulaToEvaluate, dt1, group);

                           
                                var headSystems = new[] { "it", "et", "ip", "ep" };
                                foreach (var system in headSystems)
                                {
                                    var systemHeadIds = dt1.AsEnumerable()
                                        .Where(r => r.Field<string>("HsystemName") == system)
                                        .Select(r => r.Field<int>("Headid")).FirstOrDefault();

                                    int systemValue = groupsubject.AsEnumerable()
                                        .Where(r => r.Field<int>("Headid") == systemHeadIds)
                                        .Select(r => r.Field<int>("ObtainedMarks"))
                                        .FirstOrDefault();

                                    formulaToEvaluate = formulaToEvaluate.Replace(system, systemValue.ToString());
                                }

                               
                                int totalMarks = EvaluateFormula(formulaToEvaluate);

                               
                                if (totalMarks > passingmarks)
                                {
                                    dt6.Rows.Add(stdid,  subject, maxhead + 1 ,maxmarks , passingmarks ,  totalMarks, "Pass", 0);
                                }
                                else
                                {
                                    int requiredmarks = passingmarks - totalMarks;
                                    dt6.Rows.Add(stdid,  subject, maxhead + 1, maxmarks , passingmarks , totalMarks, "Fail", requiredmarks);
                                }
                            }
                        }
                        maxhead++;
                    }
                }

                dt6.DefaultView.Sort = "Sid ASC ,Subject ASC";
                dt6 = dt6.DefaultView.ToTable();

                theory_gridview.DataSource = dt6;
                theory_gridview.DataBind();
            }
        }


        private string Replace(string formula, DataTable dt1, IEnumerable<DataRow> group)
        {

            int maxIterations = 100;
            int iterationCount = 0;

            while (!ContainsOnlyAllowedSubstrings(formula))
            {
             
                if (iterationCount >= maxIterations)
                {
                    Console.WriteLine("Exceeded maximum iterations. Exiting loop.");
                    break;
                }

                bool formulaUpdated = false;

                foreach (DataRow row in dt1.Rows)
                {
                    string headformula = row.Field<string>("MarkHeadFormula").ToString();
                    string htype = row.Field<string>("Htype").ToString();
                    string hsystemname = row.Field<string>("HsystemName").ToString();

                    
                    if (htype == "composite")
                    {
                        string iformula = GetFormulaForHeadid(hsystemname, dt1);
                        if (formula.Contains(hsystemname))
                        {
                            formula = formula.Replace(hsystemname, iformula);
                            formulaUpdated = true; 
                        }
                    }
                }

            
                if (!formulaUpdated)
                {
                    Console.WriteLine("Formula was not updated in this iteration. Exiting loop.");
                    break;
                }

                iterationCount++;
            }

            return formula;
        }



        private bool ContainsOnlyAllowedSubstrings(string formula)
        {
        
            string[] allowedSubstrings = { "ip", "it", "ep", "et" };

            // Split the formula by common operators (+, -, *, /)
            var operators = new char[] { '+', '-', '*', '/' };
            var parts = formula.Split(operators, StringSplitOptions.RemoveEmptyEntries);

            // Check each part of the formula
            foreach (var part in parts)
            {
                // Trim whitespace before checking
                string trimmedPart = part.Trim();

                // If the part is a number, we can skip checking it
                if (int.TryParse(trimmedPart, out _))
                {
                    continue; // Skip numeric parts
                }

                bool isValid = allowedSubstrings.Any(sub => trimmedPart.IndexOf(sub, StringComparison.OrdinalIgnoreCase) >= 0);
                if (!isValid)
                {
                    return false;
                }
            }

           
            return true;
        }




        private string GetFormulaForHeadid(string hsystemname, DataTable dt1)
        {
            var formula = dt1.AsEnumerable()
                             .Where(r => r.Field<string>("HsystemName") ==  hsystemname)
                             .Select(r => r.Field<string>("MarkHeadFormula"))
                             .FirstOrDefault();

            return formula;
        }

        private int EvaluateFormula(string formula)
        {
            try
            {
                var result = CSharpScript.EvaluateAsync<int>(formula, RoslynScriptOptions.Default).Result;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error evaluating formula: {ex.Message}");
                return 0;
            }
        }


        private void BindGrids(DataTable dt, DataTable dt1)
        {
            Student_Gridview.DataSource = dt;
            Student_Gridview.DataBind();

            Head_GridView1.DataSource = dt1;
            Head_GridView1.DataBind();
        }

    }
}
