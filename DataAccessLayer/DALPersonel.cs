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
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut = new SqlCommand("DEPARTMANLISTESI", Baglanti.bgl);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Personelid = Convert.ToInt32(dr["PERSONELID"].ToString());
                ent.Personelad = dr["PERSONELAD"].ToString();
                ent.Personelsoyad = dr["PERSONELSOYAD"].ToString();
                ent.Personelmaas = Convert.ToDecimal(dr["PERSONELMAAS"].ToString());
                // ent.Personeldepartman = Convert.ToByte(dr["PERSONELDEPARTMAN"].ToString());
                ent.Personeldep = dr["DEPARTMANAD"].ToString();
                ent.Personelfotograf = dr["PERSONELFOTOGRAF"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut4 = new SqlCommand("insert into TBLPERSONEL(PERSONELAD,PERSONELSOYAD,PERSONELDEPARTMAN,PERSONELMAAS) values (@P1,@P2,@P3,@P4)", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", p.Personelad);
            komut4.Parameters.AddWithValue("@P2", p.Personelsoyad);
            komut4.Parameters.AddWithValue("@P3", p.Personeldepartman);
            komut4.Parameters.AddWithValue("@P4", p.Personelmaas);
            return komut4.ExecuteNonQuery();
        }
    }
}
