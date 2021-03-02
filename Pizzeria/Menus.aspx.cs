using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Bussiness;

namespace Pizzeria
{
    public partial class Menus1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillMenuGrid();
            this.txtSearch.Attributes.Add("OnFocus", "LimpiarTexto(this);");
            this.txtSearch.Attributes.Add("blur", "LimpiarTexto(this);");
            this.TxtSearchTipo.Attributes.Add("OnFocus", "LimpiarTexto(this);");
        }

        private void FillMenuGrid()
        {
            List<Entidades.Menu> MenuList = new List<Entidades.Menu>();
            MenuBussiness MenuBuss = new MenuBussiness();
            MenuList = MenuBuss.GetMenus();

            gridMenusList.DataSource = MenuList;
            gridMenusList.DataBind();

        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in gridMenusList.Rows)
            {
                row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gridMenusList, "Select$" + row.RowIndex.ToString(), true));
            }
            base.Render(writer);
        }
        protected void gridMenusList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onMouseOver", "this.style.cursor='pointer';");
                e.Row.ToolTip = "Click en la fila para seleccionarla";
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoMenu.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string idMenu = null;
            if (gridMenusList.SelectedIndex != -1)
            {
                idMenu = gridMenusList.SelectedRow.Cells[0].Text;
                Response.Redirect("EditarMenu.aspx?idmenu=" + idMenu);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMenu;
            if (gridMenusList.SelectedIndex != -1)
            {
                idMenu = Convert.ToInt32(gridMenusList.SelectedRow.Cells[0].Text);
                MenuBussiness menuBuss = new MenuBussiness();
                menuBuss.EliminarMenu(idMenu);
                FillMenuGrid();
            }
            


        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            MenuBussiness mbuss = new MenuBussiness();
            if (this.txtSearch.Text == "*Menu")
            {
                this.txtSearch.Text ="";
            }
            if (this.TxtSearchTipo.Text == "*Tipo")
            {
                this.TxtSearchTipo.Text = "";
            }
            if (this.txtSearch.Text != "*Menu" && this.TxtSearchTipo.Text!= "*Tipo")
            {
                gridMenusList.DataSource = mbuss.FiltrarMenu(this.txtSearch.Text, this.TxtSearchTipo.Text);
                gridMenusList.DataBind();
            }
            

        }

        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {
            FillMenuGrid();
            this.txtSearch.Text = "*Menu";
            this.TxtSearchTipo.Text = "*Tipo";
        }

        protected void btnNombreMenu_Click(object sender, EventArgs e)
        {
            if (gridMenusList.SelectedIndex != -1)
            {
                this.txtParaCopiar.Text = gridMenusList.SelectedRow.Cells[1].Text;
            }
        }

        protected void btnTipo_Click(object sender, EventArgs e)
        {
            if (gridMenusList.SelectedIndex != -1)
            {
                this.txtParaCopiar.Text = gridMenusList.SelectedRow.Cells[2].Text;
            }

        }

        protected void btnDescripcion_Click(object sender, EventArgs e)
        {
            if (gridMenusList.SelectedIndex != -1)
            {
                this.txtParaCopiar.Text = gridMenusList.SelectedRow.Cells[3].Text;
            }
        }
    }
}