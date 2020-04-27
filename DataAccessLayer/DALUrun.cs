using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DALUrun
    {
        public static List<EntityUrun> UrunListesi()
        {
            List<EntityUrun> degerler = new List<EntityUrun>();
            SqlCommand komut = new SqlCommand("SELECT *FROM TBLURUN", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityUrun ent = new EntityUrun();
                ent.Urunid = Convert.ToByte(dr["URUNID"].ToString());
                ent.Urunad = dr["URUNAD"].ToString();
                ent.Urunfiyat = Convert.ToDecimal(dr["URUNFIYAT"].ToString());
                ent.Urunadet = Convert.ToInt32(dr["URUNADET"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int UrunEkle(EntityUrun p)
        {
            SqlCommand komut3 = new SqlCommand("insert into TBLURUN(URUNAD,URUNFIYAT,URUNADET) values (@P1,@P2,@P3)", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p.Urunad);
            komut3.Parameters.AddWithValue("@P2", p.Urunfiyat);
            komut3.Parameters.AddWithValue("@P3", p.Urunadet);
            return komut3.ExecuteNonQuery();
        }

    }
}
