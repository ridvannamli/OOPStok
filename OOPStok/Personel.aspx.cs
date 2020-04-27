using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;
using DataAccessLayer;

namespace OOPStok
{
    public partial class Personel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EntityPersonel> Perlis = BLLPersonel.PersonelListesi();
            Repeater1.DataSource = Perlis;
            Repeater1.DataBind();
        }
    }
}