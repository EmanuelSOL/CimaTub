using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cimatub_.Pantallas
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar datos de prueba en los ListView
                ListViewDestacados.DataSource = GetPlaceholderData(4); // 4 videos destacados
                ListViewDestacados.DataBind();

                ListViewRecomendados.DataSource = GetPlaceholderData(10); // 10 videos recomendados
                ListViewRecomendados.DataBind();
            }
        }

        // Método para generar datos de prueba
        private DataTable GetPlaceholderData(int count)
        {
            DataTable table = new DataTable();
            table.Columns.Add("VideoId");
            table.Columns.Add("ThumbnailUrl");
            table.Columns.Add("Title");
            table.Columns.Add("Channel");

            for (int i = 1; i <= count; i++)
            {
                table.Rows.Add(
                    i, // VideoId
                    "https://via.placeholder.com/320x180.png?text=Video+" + i, // ThumbnailUrl
                    "Título del Video " + i,                                  // Title
                    "Canal " + i                                              // Channel
                );
            }

            return table;
        }



    }

}