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
    public class DALMusteri
    {
        public static List<EntityMusteri> MusteriListesi()
        {
            List<EntityMusteri> degerler = new List<EntityMusteri>();
            SqlCommand komut = new SqlCommand("SELECT *FROM TBLMUSTERI", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityMusteri ent = new EntityMusteri();
                ent.Musteriid = Convert.ToInt32(dr["MUSTERIID"].ToString());
                ent.Musteriad = dr["MUSTERIAD"].ToString();
                ent.Musterisoyad = dr["MUSTERISOYAD"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int MusteriEkle(EntityMusteri p)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLMUSTERI(MUSTERIAD,MUSTERISOYAD) values (@P1,@P2)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Musteriad);
            komut2.Parameters.AddWithValue("@P2", p.Musterisoyad);
            return komut2.ExecuteNonQuery();
        }

        public static bool MusteriSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("DELETE FROM TBLMUSTERI WHERE MUSTERIID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static List<EntityMusteri> MusteriGetir(int id)
        {
            List<EntityMusteri> degerler = new List<EntityMusteri>();
            SqlCommand komut4 = new SqlCommand("SELECT *FROM TBLMUSTERI WHERE MUSTERIID = @P1", Baglanti.bgl);
            komut4.Parameters.AddWithValue("@P1", id);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }

            SqlDataReader dr = komut4.ExecuteReader();
            while (dr.Read())
            {
                EntityMusteri ent = new EntityMusteri();
                //  ent.Musteriid = Convert.ToInt32(dr["MUSTERIID"].ToString());
                ent.Musteriad = dr["MUSTERIAD"].ToString();
                ent.Musterisoyad = dr["MUSTERISOYAD"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static bool MusteriGuncelle(EntityMusteri p)
        {
            SqlCommand komut5 = new SqlCommand("UPDATE TBLMUSTERI SET MUSTERIAD = @P1, MUSTERISOYAD = @P2 WHERE MUSTERIID = @P3", Baglanti.bgl);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@P1", p.Musteriad);
            komut5.Parameters.AddWithValue("@P2", p.Musterisoyad);
            komut5.Parameters.AddWithValue("@P3", p.Musteriid);
            return komut5.ExecuteNonQuery() > 0;
        }
    }
}
