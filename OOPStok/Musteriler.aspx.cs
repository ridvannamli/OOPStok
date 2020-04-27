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
    public partial class Musteriler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EntityMusteri> MusList = BLLMusteri.BLLMusteriListele();
            Repeater1.DataSource = MusList;
            Repeater1.DataBind();
        }
    }
}