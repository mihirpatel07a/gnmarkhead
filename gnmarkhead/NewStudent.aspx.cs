using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace gnmarkhead
{
    public partial class NewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GNmarkhead gNmarkhead = new GNmarkhead();

            DataTable dt1 = StudenttoDatatable.main();
            DataTable dt2 = HeadDataTable.main();

            Student_Gridview.DataSource = dt1;
            Student_Gridview.DataBind();

            Head_GridView1.DataSource = dt2;
            Head_GridView1.DataBind();

            DataTable dt = gNmarkhead.main();

            output_gridview.DataSource = dt;
            output_gridview.DataBind();
        }
    }
}