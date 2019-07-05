using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind.DataAccess;

namespace MantenerEstado
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void LoadGridOrders(string customerid)
        {
            gvOrders.DataSource = NorthwindData.GetAllOrdersByCustomer(customerid);
            gvOrders.DataBind();
        }


        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Order order = (Order)e.Row.DataItem;

            GridView gvDetails = (GridView)e.Row.FindControl("gvDetails");

            gvDetails.DataSource = order.Details;
            gvDetails.DataBind();
        }

        protected void serach_Click(object sender, EventArgs e)
        {
            LoadGridOrders(txtCustomrId.Text);
        }

        protected void gvOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrders.PageIndex = e.NewPageIndex;

            LoadGridOrders(txtCustomrId.Text);

        }




    }
}
