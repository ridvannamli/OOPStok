using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLLMusteri
    {
        public static List<EntityMusteri> BLLMusteriListele()
        {
            return DALMusteri.MusteriListesi();
        }

        public static int BLLMusteriEkle(EntityMusteri p)
        {
            if (p.Musteriad != "" && p.Musterisoyad != "" && p.Musteriad.Length <= 15)
            {
                return DALMusteri.MusteriEkle(p);
            }
            else
            {
                return -1;
            }
        }

        public static bool MusteriSil(int p)
        {
            if (p <= 4)
            {
                return DALMusteri.MusteriSil(p);
            }
            return false;
        }

        public static List<EntityMusteri> BLLMusteriGetir(int p)
        {
            return DALMusteri.MusteriGetir(p);
        }

        public static bool BLLMusteriGuncelle(EntityMusteri p)
        {
            if (p.Musteriad != "" && p.Musterisoyad != "")
            {
                return DALMusteri.MusteriGuncelle(p);
            }
            return false;
        }

    }
}
