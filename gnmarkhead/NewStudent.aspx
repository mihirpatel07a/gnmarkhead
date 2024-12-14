<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewStudent.aspx.cs" Inherits="gnmarkhead.NewStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    body {
        font-family: Arial, sans-serif;
        background-color: aliceblue; /* Light blue background */
        color: red; /* White text for body */
        margin: 0;
        padding: 0;
    }

    #form1 {
        margin: 20px;
    }

    h1 {
        color: white; /* White text for the heading */
        font-size: 1.8em;
        margin-bottom: 10px;
        border-bottom: 2px solid white;
        padding-bottom: 5px;
    }

    .grid-container {
        margin-bottom: 30px;
        border-radius: 8px;
        box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        overflow: hidden;
        background-color: #222; /* Dark background for grid container */
        display: inline-block;
        width: 48%; /* 2 grids in a row by default */
        margin-right: 4%;
    }

    .grid-container .header {
        background-color: #444; /* Dark grey for header */
        color: white; /* White text for header */
        padding: 10px;
        font-size: 1.2em;
        text-align: center;
    }

    .grid-container .content {
        padding: 10px;
    }

    .grid-container .content .gridview {
        width: 100%;
        border-collapse: collapse;
        color: white; /* Ensures white text inside GridView */
    }

    .grid-container .content .gridview th, .grid-container .content .gridview td {
        padding: 10px;
        text-align: left;
        border: 1px solid #555; /* Light grey borders */
    }

    .grid-container .content .gridview th {
        background-color: #333; /* Darker grey for header cells */
        color: white; /* White text for column headers */
    }

    .grid-container .content .gridview tr:nth-child(even) {
        background-color: #333; /* Dark grey rows for even rows */
    }

    .grid-container .content .gridview tr:nth-child(odd) {
        background-color: #444; /* Lighter grey rows for odd rows */
    }

    .grid-container .content .gridview tr:hover {
        background-color: #555; /* Hover effect for rows */
    }

    /* For larger screen devices, display two grids per row */
    @media screen and (max-width: 1024px) {
        .grid-container {
            width: 100%; /* Stack grids on smaller screens */
            margin-right: 0;
            margin-bottom: 20px; /* Add space between stacked grids */
        }
    }

    /* For the Head GridView to take up full width */
    .full-width-grid {
        width: 100% !important; /* Make this grid take the full width */
        margin-right: 0; /* Remove margin */
    }
</style>
</head>
<body>
    <form id="form1" runat="server">

     <h1>Student Results</h1>

     <!-- First Row: Student GridView -->
     <div style="display: flex; flex-wrap: wrap; justify-content: space-between;">

         <!-- Student GridView -->
         <div class="grid-container">
             <div class="header">Student Information</div>
             <div class="content">
                 <asp:GridView ID="Student_Gridview" runat="server" CssClass="gridview"></asp:GridView>
             </div>
         </div>

     </div>

     <!-- Second Row: Head GridView (Full Width) -->
     <div style="display: flex; flex-wrap: wrap; justify-content: space-between;">

         <!-- Head GridView (Full Width) -->
         <div class="grid-container full-width-grid">
             <div class="header">Head Information</div>
             <div class="content">
                 <asp:GridView ID="Head_GridView1" runat="server" CssClass="gridview"></asp:GridView>
             </div>
         </div>

     </div>

     <!-- Third Row: Output GridView -->
     <div style="display: flex; flex-wrap: wrap; justify-content: space-between;">

         <!-- Student by Theory Exam GridView -->
         <div class="grid-container">
             <div class="header">Output</div>
             <div class="content">
                 <asp:GridView ID="output_gridview" runat="server" CssClass="gridview"></asp:GridView>
             </div>
         </div>

     </div>

 </form>
</body>
</html>
