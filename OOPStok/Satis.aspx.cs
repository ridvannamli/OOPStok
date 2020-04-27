using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataAccessLayer;
using BusinessLogicLayer;

namespace OOPStok
{
    public partial class Satis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EntitySatis> SatListe = BLLSatis.SatisListesi();
            Repeater1.DataSource = SatListe;
            Repeater1.DataBind();
        }
    }
}