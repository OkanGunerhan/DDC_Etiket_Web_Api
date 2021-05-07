using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _2001_Etiket_Web_Api.Models;
using FastReport;

namespace _2001_Etiket_Web_Api.Controllers
{
    [RoutePrefix("api/Etiket")]
    public class EtiketController : ApiController
    {
        [HttpPost]
        [Route("Yazdir")]
        public HttpResponseMessage Yazdir(Etiket etiket)
        {
            try
            {
                //Üretim Yeri Validasyonu
                var uretimYeri = etiket.URETIM_YERI == null
                       ? etiket.URETIM_YERI = "-"
                       : etiket.URETIM_YERI = etiket.URETIM_YERI;
                etiket.URETIM_YERI = uretimYeri;
                //Lokasyon Validasyonu
                var lokasyon = etiket.LOKASYON == null
                       ? etiket.LOKASYON = "-"
                       : etiket.LOKASYON = etiket.LOKASYON;
                etiket.LOKASYON = lokasyon;
                //Layout Adres Validasyonu
                var layoutAdres = etiket.LAYOUTADRES == null
                       ? etiket.LAYOUTADRES = "-"
                       : etiket.LAYOUTADRES = etiket.LAYOUTADRES;
                etiket.LAYOUTADRES = layoutAdres;
                //Urun Grubu Validasyonu
                var urunGrubu = etiket.URUN_GRUBU == null
                       ? etiket.URUN_GRUBU = "-"
                       : etiket.URUN_GRUBU = etiket.URUN_GRUBU;
                etiket.URUN_GRUBU = urunGrubu;
                var printerSecme = etiket.PRINTER_SELECT_PARAMETRESI == null
                      ? etiket.PRINTER_SELECT_PARAMETRESI = "PRT_HHYOL1"
                      : etiket.PRINTER_SELECT_PARAMETRESI = etiket.PRINTER_SELECT_PARAMETRESI;
                etiket.PRINTER_SELECT_PARAMETRESI = printerSecme;
                //Basım Adedi Validasyonu
                var basimAdet = etiket.BASIM_ADT == null
                       ? etiket.BASIM_ADT = 1
                       : etiket.BASIM_ADT = etiket.BASIM_ADT;
                etiket.BASIM_ADT = basimAdet;
                //Onem Durumu Validasyonu
                var onemDurumu = etiket.ONEM == null
                       ? etiket.ONEM = 1
                       : etiket.ONEM = etiket.ONEM;
                etiket.ONEM = onemDurumu;
                //Parti No Validasyonu
                var partiNo = etiket.PARTI_NO == null
                       ? etiket.PARTI_NO = "-"
                       : etiket.PARTI_NO = etiket.PARTI_NO;
                etiket.PARTI_NO = partiNo;
                //Müşteri Sipariş  Validasyonu
                var musSip = etiket.MUS_SIP == null
                       ? etiket.MUS_SIP = "-"
                       : etiket.MUS_SIP = etiket.MUS_SIP;
                etiket.MUS_SIP = musSip;
                //Müşteri Sipariş Kalemi Validasyonu
                var musSipKlm = etiket.MUS_SIP_KLM == null
                       ? etiket.MUS_SIP_KLM = 0
                       : etiket.MUS_SIP_KLM = etiket.MUS_SIP_KLM;
                etiket.MUS_SIP_KLM = musSipKlm;
                //Lot Validasyonu
                var lot = etiket.LOT == null
                       ? etiket.LOT = "-"
                       : etiket.LOT = etiket.LOT;
                etiket.LOT = lot;
                //Revizyon Numarası Validasyonu
                var revNo = etiket.REVIZYON_NO == null
                       ? etiket.REVIZYON_NO = 0
                       : etiket.REVIZYON_NO = etiket.REVIZYON_NO;
                etiket.REVIZYON_NO = revNo;
                //Döküm No Validasyonu
                var dokumNo = etiket.DOKUM_NO == null
                       ? etiket.DOKUM_NO = "-"
                       : etiket.DOKUM_NO = etiket.DOKUM_NO.ToUpper();
                etiket.DOKUM_NO = dokumNo;
                //Döküm Sıra No Validasyonu
                var dokumSiraNo = etiket.DOKUM_SIRA_NO == null
                       ? etiket.DOKUM_SIRA_NO = 0
                       : etiket.DOKUM_SIRA_NO = etiket.DOKUM_SIRA_NO;
                etiket.DOKUM_SIRA_NO = dokumSiraNo;

                //Döküm Tipi Validasyonu
                var dokumTipi = etiket.DOKUM_TIPI == null
                       ? etiket.DOKUM_TIPI = "-"
                       : etiket.DOKUM_TIPI = etiket.DOKUM_TIPI;
                etiket.DOKUM_TIPI = dokumTipi;

                //Ktk ID Validasyonu
                var ktkID = etiket.KTK_ID == null
                       ? etiket.KTK_ID = 0
                       : etiket.KTK_ID = etiket.KTK_ID;
                etiket.KTK_ID = ktkID;
                //Standart Validasyonu
                var standart = etiket.STANDART == null
                       ? etiket.STANDART = "-"
                       : etiket.STANDART = etiket.STANDART;
                etiket.STANDART = standart;
                //Kalite Validasyonu
                var kalite = etiket.KALITE == null
                       ? etiket.KALITE = "-"
                       : etiket.KALITE = etiket.KALITE;
                etiket.KALITE = kalite;
                //Ebat Validasyonu
                var ebat = etiket.EBAT == null
                       ? etiket.EBAT = 0
                       : etiket.EBAT = etiket.EBAT;
                etiket.EBAT = ebat;
                //Boy Validasyonu
                var boy = etiket.BOY == null
                       ? etiket.BOY = 0
                       : etiket.BOY = etiket.BOY;
                etiket.BOY = boy;
                //Cap Validasyonu
                var cap = etiket.CAP == null
                       ? etiket.CAP = 0
                       : etiket.CAP = etiket.CAP;
                etiket.CAP = cap;

                //Nervür - Düz  Validasyonu
                var nervur_duz = etiket.NERVUR_DUZ == null
                       ? etiket.NERVUR_DUZ = "-"
                       : etiket.NERVUR_DUZ = etiket.NERVUR_DUZ.ToUpper();
                etiket.NERVUR_DUZ = nervur_duz;
                //Vardiya Validasyonu
                var vardiya = etiket.VARDIYA == null
                       ? etiket.VARDIYA = "-"
                       : etiket.VARDIYA = etiket.VARDIYA.ToUpper();
                etiket.VARDIYA = vardiya;
                //Yol Validasyonu
                var yol = etiket.YOL == null
                       ? etiket.YOL = 0
                       : etiket.YOL = etiket.YOL;
                etiket.YOL = yol;
                //Yol Ktk Sıra Validasyonu
                var yolKtkSira = etiket.YOL_KTK_SIRA == null
                       ? etiket.YOL_KTK_SIRA = 0
                       : etiket.YOL_KTK_SIRA = etiket.YOL_KTK_SIRA;
                etiket.YOL_KTK_SIRA = yolKtkSira;
                //Standart Validasyonu
                var std_stdDisi = etiket.STD_STDDISI == null
                       ? etiket.STD_STDDISI = "-"
                       : etiket.STD_STDDISI = etiket.STD_STDDISI;
                etiket.STD_STDDISI = std_stdDisi;
                //Ikınci Kalite Validasyonu
                var ikinciKalite = etiket.IKINCI_KALITE == null
                       ? etiket.IKINCI_KALITE = "-"
                       : etiket.IKINCI_KALITE = etiket.IKINCI_KALITE.ToUpper();
                etiket.IKINCI_KALITE = ikinciKalite;


                //Bobin Sıra No Validasyonu
                var bobin_Sira_No = etiket.BOBIN_SIRA_NO == null
                       ? etiket.BOBIN_SIRA_NO = 0
                       : etiket.BOBIN_SIRA_NO = etiket.BOBIN_SIRA_NO;
                etiket.BOBIN_SIRA_NO = bobin_Sira_No;
                //Brut Ağırlık Validasyonu
                var brutAgirlik = etiket.BRUT_AGIRLIK == null
                       ? etiket.BRUT_AGIRLIK = 0
                       : etiket.BRUT_AGIRLIK = etiket.BRUT_AGIRLIK;
                etiket.BRUT_AGIRLIK = brutAgirlik;
                //Net Ağırlık Validasyonu
                var netAgirlik = etiket.NET_AGIRLIK == null
                       ? etiket.NET_AGIRLIK = 0
                       : etiket.NET_AGIRLIK = etiket.NET_AGIRLIK;
                etiket.NET_AGIRLIK = netAgirlik;
                //Cares Kod Validasyonu
                var caresKod = etiket.CARES_KOD == null
                       ? etiket.CARES_KOD = "-"
                       : etiket.CARES_KOD = etiket.CARES_KOD;
                etiket.CARES_KOD = caresKod;
                //C Sert Guid No Validasyonu
                var csertGuidNo = etiket.GUID_ID == null
                       ? etiket.GUID_ID = "-"
                       : etiket.GUID_ID = etiket.GUID_ID;
                etiket.GUID_ID = csertGuidNo;
                //Paketteki Çubuk Adedi Validasyonu
                var pakettekiCubukAdedi = etiket.CUBUK_SAYISI == null
                       ? etiket.CUBUK_SAYISI = 0
                       : etiket.CUBUK_SAYISI = etiket.CUBUK_SAYISI;
                etiket.CUBUK_SAYISI = pakettekiCubukAdedi;
                //Çentik Tipi Validasyonu
                var centikTipi = etiket.CENTIK_TIP == null
                       ? etiket.CENTIK_TIP = "-"
                       : etiket.CENTIK_TIP = etiket.CENTIK_TIP;
                etiket.CENTIK_TIP = centikTipi;

                //MALZEME_HURDA Validasyonu
                var malzemeHurda = etiket.HURDA == null
                       ? etiket.HURDA = "-"
                       : etiket.HURDA = etiket.HURDA;
                etiket.HURDA = malzemeHurda;
                //MALZEME_KISA_KUTUK Validasyonu
                var malzemeKisaKutuk = etiket.KISA_KTK == null
                       ? etiket.KISA_KTK = "-"
                       : etiket.KISA_KTK = etiket.KISA_KTK;
                etiket.KISA_KTK = malzemeKisaKutuk;
                //MARKALAMA Validasyonu
                var markalama = etiket.MARKALAMA == null
                       ? etiket.MARKALAMA = "-"
                       : etiket.MARKALAMA = etiket.MARKALAMA;
                etiket.MARKALAMA = markalama;
                //MASTER_COIL_NO Validasyonu
                var masterCoilNo = etiket.MASTERCOIL_NO == null
                       ? etiket.MASTERCOIL_NO = "-"
                       : etiket.MASTERCOIL_NO = etiket.MASTERCOIL_NO;
                etiket.MASTERCOIL_NO = masterCoilNo;
                //MIN_BOY_TOLERANSI Validasyonu
                var minBoyToleransı = etiket.MIN_BOY_TOL == null
                       ? etiket.MIN_BOY_TOL = 0
                       : etiket.MIN_BOY_TOL = etiket.MIN_BOY_TOL;
                etiket.MIN_BOY_TOL = minBoyToleransı;
                //MAX_BOY_TOLERANSI Validasyonu
                var maxBoyToleransı = etiket.MAX_BOY_TOL == null
                       ? etiket.MAX_BOY_TOL = 0
                       : etiket.MAX_BOY_TOL = etiket.MAX_BOY_TOL;
                etiket.MAX_BOY_TOL = maxBoyToleransı;
                //ULKE Validasyonu
                var ulke = etiket.ULKE == null
                       ? etiket.ULKE = "-"
                       : etiket.ULKE = etiket.ULKE.ToUpper();
                etiket.ULKE = ulke;
                //MENSEI Validasyonu
                var mensei = etiket.MENSEI == null
                       ? etiket.MENSEI = "-"
                       : etiket.MENSEI = etiket.MENSEI.ToUpper();
                etiket.MENSEI = mensei;
                //MUSTERI_KALITE_KODU Validasyonu
                var musKaliteKodu = etiket.MUSTERI_KAL_KOD == null
                       ? etiket.MUSTERI_KAL_KOD = "-"
                       : etiket.MUSTERI_KAL_KOD = etiket.MUSTERI_KAL_KOD;
                etiket.MUSTERI_KAL_KOD = musKaliteKodu;

                //SARIM YONU Validasyonu
                var sarimYonu = etiket.SARIM_YONU == null
                       ? etiket.SARIM_YONU = "-"
                       : etiket.SARIM_YONU = etiket.SARIM_YONU;
                etiket.SARIM_YONU = sarimYonu;
                //SAPMA Validasyonu
                var sapma = etiket.SAPMA == null
                       ? etiket.SAPMA = "-"
                       : etiket.SAPMA = etiket.SAPMA;
                etiket.SAPMA = sapma;
                //Üretim Yöntemi Validasyonu
                var tempcoreSicakHadde = etiket.URETIM_YONTEMI == null
                       ? etiket.URETIM_YONTEMI = "-"
                       : etiket.URETIM_YONTEMI = etiket.URETIM_YONTEMI;
                etiket.URETIM_YONTEMI = tempcoreSicakHadde;

                //URETIM_SEKLI Validasyonu
                var uretimSekli = etiket.URETIM_SEKLI == null
                       ? etiket.URETIM_SEKLI = "-"
                       : etiket.URETIM_SEKLI = etiket.URETIM_SEKLI.ToUpper();
                etiket.URETIM_SEKLI = uretimSekli;
                //URUN_METRAJI Validasyonu
                var urunMetraji = etiket.UZUNLUK == null
                       ? etiket.UZUNLUK = 0
                       : etiket.UZUNLUK = etiket.UZUNLUK;
                etiket.UZUNLUK = urunMetraji;
                //URUN_STATUSU Validasyonu
                var urunStatusu = etiket.URUN_STATU == null
                       ? etiket.URUN_STATU = "-"
                       : etiket.URUN_STATU = etiket.URUN_STATU.ToUpper();
                etiket.URUN_STATU = urunStatusu;
                //VAKUMLU Validasyonu
                var vakumlu = etiket.VAKUM == null
                       ? etiket.VAKUM = "-"
                       : etiket.VAKUM = etiket.VAKUM.ToUpper();
                etiket.VAKUM = vakumlu;
                //URETIM_TARIHI Validasyonu
                var uretimTarihi = etiket.URET_TAR_SAAT == null
                       ? etiket.URET_TAR_SAAT = "-"
                       : etiket.URET_TAR_SAAT = etiket.URET_TAR_SAAT;
                etiket.URET_TAR_SAAT = uretimTarihi;
                //PALET_NO Validasyonu
                var paletNo = etiket.PALET_NO == null
                       ? etiket.PALET_NO = "-"
                       : etiket.PALET_NO = etiket.PALET_NO;
                etiket.PALET_NO = paletNo;
                //MASTERCOIL_SIP_SIRA_NO Validasyonu
                var masterCoilSipSiraNo = etiket.MASTERCOIL_SIP_SIRA_NO == null
                       ? etiket.MASTERCOIL_SIP_SIRA_NO = 0
                       : etiket.MASTERCOIL_SIP_SIRA_NO = etiket.MASTERCOIL_SIP_SIRA_NO;
                etiket.MASTERCOIL_SIP_SIRA_NO = masterCoilSipSiraNo;
                //BABY_COIL_SIRA_NO Validasyonu
                var babyCoilSiraNo = etiket.BABY_COIL_SIRA_NO == null
                       ? etiket.BABY_COIL_SIRA_NO = 0
                       : etiket.BABY_COIL_SIRA_NO = etiket.BABY_COIL_SIRA_NO;
                etiket.BABY_COIL_SIRA_NO = babyCoilSiraNo;
                //HATAKODU Validasyonu
                var hataKodu = etiket.HATA_KODU == null
                       ? etiket.HATA_KODU = "-"
                       : etiket.HATA_KODU = etiket.HATA_KODU;
                etiket.HATA_KODU = hataKodu;
                //MUSTERI Validasyonu
                var musteri = etiket.MUSTERI == null
                       ? etiket.MUSTERI = "-"
                       : etiket.MUSTERI = etiket.MUSTERI;
                etiket.MUSTERI = musteri;
                //Bağ ID Validasyonu
                var bagID = etiket.BAG_ID == null
                       ? etiket.BAG_ID = 0
                       : etiket.BAG_ID = etiket.BAG_ID;
                etiket.BAG_ID = bagID;
                //Depo Kodu Validasyonu
                var depoKodu = etiket.DEPOKODU == null
                       ? etiket.DEPOKODU = "-"
                       : etiket.DEPOKODU = etiket.DEPOKODU;
                etiket.DEPOKODU = depoKodu;
                //İstif Kodu Validasyonu
                var istifKodu = etiket.ISTIFKODU == null
                       ? etiket.ISTIFKODU = "-"
                       : etiket.ISTIFKODU = etiket.ISTIFKODU;
                etiket.ISTIFKODU = istifKodu;
                //İstif Kodu Validasyonu
                var istifSiraNo = etiket.ISTIFSIRANO == null
                       ? etiket.ISTIFSIRANO = "-"
                       : etiket.ISTIFSIRANO = etiket.ISTIFSIRANO;
                etiket.ISTIFSIRANO = istifSiraNo;
                //Çıkış Tarihi Validasyonu
                var cikisTarihi = etiket.CTARIH == null
                       ? etiket.CTARIH = "-"
                       : etiket.CTARIH = etiket.CTARIH;
                etiket.CTARIH = cikisTarihi;
                //Çıkış Tarihi Validasyonu
                var STDNEDEN = etiket.STDNEDEN == null
                       ? etiket.STDNEDEN = "-"
                       : etiket.STDNEDEN = etiket.STDNEDEN;
                etiket.STDNEDEN = STDNEDEN;
                //Çıkış Tarihi Validasyonu
                var hedefBag = etiket.HEDEFBAG == null
                       ? etiket.HEDEFBAG = 0
                       : etiket.HEDEFBAG = etiket.HEDEFBAG;
                etiket.HEDEFBAG = hedefBag;
                //Çıkış Tarihi Validasyonu
                var HEDEFTON = etiket.HEDEFTON == null
                       ? etiket.HEDEFTON = 0
                       : etiket.HEDEFTON = etiket.HEDEFTON;
                etiket.HEDEFTON = HEDEFTON;
                //Çıkış Tarihi Validasyonu
                var HEDEFBAGKG = etiket.HEDEFBAGKG == null
                       ? etiket.HEDEFBAGKG = 0
                       : etiket.HEDEFBAGKG = etiket.HEDEFBAGKG;
                etiket.HEDEFBAGKG = HEDEFBAGKG;
                //Çıkış Tarihi Validasyonu
                var GIRNUM = etiket.GIRNUM == null
                       ? etiket.GIRNUM = "-"
                       : etiket.GIRNUM = etiket.GIRNUM;
                etiket.GIRNUM = GIRNUM;
                //Çıkış Tarihi Validasyonu
                var ARACPLAKA = etiket.ARACPLAKA == null
                       ? etiket.ARACPLAKA = "-"
                       : etiket.ARACPLAKA = etiket.ARACPLAKA;
                etiket.ARACPLAKA = ARACPLAKA;
                //ETIKET_BASIM_TARIHI Validasyonu
                var etiketBasimTarihi = etiket.ETIKET_BASIM_TARIHI == null
                       ? etiket.ETIKET_BASIM_TARIHI = DateTime.Now
                       : etiket.ETIKET_BASIM_TARIHI = etiket.ETIKET_BASIM_TARIHI;
                etiket.ETIKET_BASIM_TARIHI = etiketBasimTarihi;
                //KARISIM_KALITE Validasyonu
                var karisimKalite = etiket.Y_KARISIM_KALITESI == null
                       ? etiket.Y_KARISIM_KALITESI = "-"
                       : etiket.Y_KARISIM_KALITESI = etiket.Y_KARISIM_KALITESI.ToUpper();
                etiket.Y_KARISIM_KALITESI = karisimKalite;
                //Elastisite Mod Validasyonu
                var elastisiteMod = etiket.Y_ELASTISITE_MODUL_NOM == null
                       ? etiket.Y_ELASTISITE_MODUL_NOM = "-"
                       : etiket.Y_ELASTISITE_MODUL_NOM = etiket.Y_ELASTISITE_MODUL_NOM;
                etiket.Y_ELASTISITE_MODUL_NOM = elastisiteMod;
                //Elastisite Mod Validasyonu
                var DIJITALRECORDID = etiket.DIJITALRECORDID == null
                       ? etiket.DIJITALRECORDID = "-"
                       : etiket.DIJITALRECORDID = etiket.DIJITALRECORDID;
                etiket.DIJITALRECORDID = DIJITALRECORDID;
                //Elastisite Mod Validasyonu
                var METRIKTON = etiket.METRIKTON == null
                       ? etiket.METRIKTON = "-"
                       : etiket.METRIKTON = etiket.METRIKTON;
                etiket.METRIKTON = METRIKTON;
                //İslem Durumu Validasyonu
                var islemDurumu = etiket.ISLEM_DRM == null
                       ? etiket.ISLEM_DRM = 0
                       : etiket.ISLEM_DRM = etiket.ISLEM_DRM;
                etiket.ISLEM_DRM = islemDurumu;

                //Oracle Id No Validasyonu
                var FILMASIN_TONAJI = etiket.FILMASIN_TONAJI == null
                       ? etiket.FILMASIN_TONAJI = "-"
                       : etiket.FILMASIN_TONAJI = etiket.FILMASIN_TONAJI;
                etiket.FILMASIN_TONAJI = FILMASIN_TONAJI;

                //Çekme Mukavemeti Validasyonu
                var cekmeMuavemeti = etiket.QM_CEKME_MUKAVVEMETI == null
                       ? etiket.QM_CEKME_MUKAVVEMETI = "-"
                       : etiket.QM_CEKME_MUKAVVEMETI = etiket.QM_CEKME_MUKAVVEMETI;
                etiket.QM_CEKME_MUKAVVEMETI = cekmeMuavemeti;

                //DOKUMYOLSIRANOSU Validasyonu
                var SIPNO_LOT_SIRA = etiket.SIPNO_LOT_SIRA == null
                       ? etiket.SIPNO_LOT_SIRA = 0
                       : etiket.SIPNO_LOT_SIRA = etiket.SIPNO_LOT_SIRA;
                etiket.SIPNO_LOT_SIRA = SIPNO_LOT_SIRA;


                //MALZEME_KOD Validasyonu
                var malzemeKod = etiket.MALZEME_KOD == null
                       ? etiket.MALZEME_KOD = "-"
                       : etiket.MALZEME_KOD = etiket.MALZEME_KOD;
                etiket.MALZEME_KOD = malzemeKod;
                //LAYOUT_KOD Validasyonu
                var layoutKod = etiket.LAYOUT_KOD == null
                       ? etiket.LAYOUT_KOD = "-"
                       : etiket.LAYOUT_KOD = etiket.LAYOUT_KOD;
                etiket.LAYOUT_KOD = layoutKod;

                //SIPARIS_SIRA_NO Validasyonu
                var siparisSiraNo = etiket.SIPARIS_SIRA_NO == null
                       ? etiket.SIPARIS_SIRA_NO = "-"
                       : etiket.SIPARIS_SIRA_NO = etiket.SIPARIS_SIRA_NO;
                etiket.SIPARIS_SIRA_NO = siparisSiraNo;
                //MAMUL_STANDART Validasyonu
                var mamulStandart = etiket.MAMUL_STANDART == null
                       ? etiket.MAMUL_STANDART = "-"
                       : etiket.MAMUL_STANDART = etiket.MAMUL_STANDART;
                etiket.MAMUL_STANDART = mamulStandart;
                //MAMUL_KALITE Validasyonu
                var mamulKalite = etiket.MAMUL_KALITE == null
                       ? etiket.MAMUL_KALITE = "-"
                       : etiket.MAMUL_KALITE = etiket.MAMUL_KALITE;
                etiket.MAMUL_KALITE = mamulKalite;
                //KALITE_KODU Validasyonu
                var kaliteKodu = etiket.KALITE_KODU == null
                       ? etiket.KALITE_KODU = "-"
                       : etiket.KALITE_KODU = etiket.KALITE_KODU;
                etiket.KALITE_KODU = kaliteKodu;
                //FILMASIN_TONAJ Validasyonu
                var filmasinTonaji = etiket.FILMASIN_TONAJI == null
                       ? etiket.FILMASIN_TONAJI = "-"
                       : etiket.FILMASIN_TONAJI = etiket.FILMASIN_TONAJI;
                etiket.FILMASIN_TONAJI = filmasinTonaji;
                //MALZEME Validasyonu
                var malzeme = etiket.MALZEME == null
                       ? etiket.MALZEME = "-"
                       : etiket.MALZEME = etiket.MALZEME;
                etiket.MALZEME = malzeme;
                //MALZEME_NO Validasyonu
                var malzemeNo = etiket.MALZEME_NO == null
                       ? etiket.MALZEME_NO = "-"
                       : etiket.MALZEME_NO = etiket.MALZEME_NO;
                etiket.MALZEME_NO = malzemeNo;
                //UNIQ_ID Validasyonu
                var unidID = etiket.UNIQ_ID == null
                       ? etiket.UNIQ_ID = "-"
                       : etiket.UNIQ_ID = etiket.UNIQ_ID;
                etiket.UNIQ_ID = unidID;
                //Urun Tipi Validasyonu
                var urunTipi = etiket.URUN_TIPI == null
                       ? etiket.URUN_TIPI = "-"
                       : etiket.URUN_TIPI = etiket.URUN_TIPI;
                etiket.URUN_TIPI = urunTipi;
                //Firma Validasyonu
                var firma = etiket.FIRMA == null
                    ? etiket.FIRMA = "-"
                    : etiket.FIRMA = etiket.FIRMA;
                etiket.FIRMA = urunTipi;
                //Depo Yeri Validasyonu
                var depoYeri = etiket.DEPO_YERI == null
                    ? etiket.DEPO_YERI = "-"
                    : etiket.DEPO_YERI = etiket.DEPO_YERI;
                etiket.DEPO_YERI = depoYeri;
                //Istif Validasyonu
                var istif = etiket.ISTIF_ADI == null
                    ? etiket.ISTIF_ADI = "-"
                    : etiket.ISTIF_ADI = etiket.ISTIF_ADI;
                etiket.ISTIF_ADI = istif;
                //Istif Validasyonu
                var ORACLE_ID_NUM = etiket.ORACLE_ID_NUM == null
                    ? etiket.ORACLE_ID_NUM = 0
                    : etiket.ORACLE_ID_NUM = etiket.ORACLE_ID_NUM;
                etiket.ORACLE_ID_NUM = ORACLE_ID_NUM;
                //Istif Validasyonu
                var DOKUMYOLSIRANOSU = etiket.DOKUMYOLSIRANOSU == null
                    ? etiket.DOKUMYOLSIRANOSU = 0
                    : etiket.DOKUMYOLSIRANOSU = etiket.DOKUMYOLSIRANOSU;
                etiket.DOKUMYOLSIRANOSU = DOKUMYOLSIRANOSU;
                //Istif Validasyonu
                var MAMUL_CAP = etiket.MAMUL_CAP == null
                    ? etiket.MAMUL_CAP = "-"
                    : etiket.MAMUL_CAP = etiket.MAMUL_CAP;
                etiket.MAMUL_CAP = MAMUL_CAP;

                //Istif Validasyonu
                var MERKEZ_TEL_CEVRE_TEL = etiket.MERKEZ_TEL_CEVRE_TEL == null
                    ? etiket.MERKEZ_TEL_CEVRE_TEL = "-"
                    : etiket.MERKEZ_TEL_CEVRE_TEL = etiket.MERKEZ_TEL_CEVRE_TEL;
                etiket.MERKEZ_TEL_CEVRE_TEL = MERKEZ_TEL_CEVRE_TEL;
                //Istif Validasyonu
                var KAYNAK_METRAJI = etiket.KAYNAK_METRAJI == null
                    ? etiket.KAYNAK_METRAJI = "-"
                    : etiket.KAYNAK_METRAJI = etiket.KAYNAK_METRAJI;
                etiket.KAYNAK_METRAJI = KAYNAK_METRAJI;
                //Istif Validasyonu
                var TAKIP_NO = etiket.TAKIP_NO == null
                    ? etiket.TAKIP_NO = "-"
                    : etiket.TAKIP_NO = etiket.TAKIP_NO;
                etiket.TAKIP_NO = TAKIP_NO;



                var report = new Report();
                string path = @"C:\prg\ETIKET DIZAYN\2001\101\KUTUK.frx";
                int[] data = { 0, 1, 2 };
                report.Load(path);
                report.RegisterData(data, "DilerData");
                report.SetParameterValue("URETIM_YERI", etiket.URETIM_YERI.ToString());
                report.SetParameterValue("LOKASYON", etiket.LOKASYON.ToString());
                report.SetParameterValue("LAYOUTADRES", etiket.LAYOUTADRES.ToString());
                report.SetParameterValue("URUN_GRUBU", etiket.URUN_GRUBU.ToString());
                report.SetParameterValue("PRINTER_SELECT_PARAMETRESI", etiket.PRINTER_SELECT_PARAMETRESI.ToString());
                report.SetParameterValue("BASIM_ADT", etiket.BASIM_ADT.ToString());
                report.SetParameterValue("ONEM", etiket.ONEM.ToString());
                report.SetParameterValue("PARTI_NO", etiket.PARTI_NO.ToString());
                report.SetParameterValue("MUS_SIP", etiket.MUS_SIP.ToString());
                report.SetParameterValue("MUS_SIP_KLM", etiket.MUS_SIP_KLM.ToString());
                report.SetParameterValue("LOT", etiket.LOT.ToString());
                report.SetParameterValue("REVIZYON_NO", etiket.REVIZYON_NO.ToString());
                report.SetParameterValue("DOKUM_NO", etiket.DOKUM_NO.ToString());
                report.SetParameterValue("DOKUM_SIRA_NO", etiket.DOKUM_SIRA_NO.ToString());
                report.SetParameterValue("DOKUM_TIPI", etiket.DOKUM_TIPI.ToString());
                report.SetParameterValue("KTK_ID", etiket.KTK_ID.ToString());
                report.SetParameterValue("STANDART", etiket.STANDART.ToString());
                report.SetParameterValue("KALITE", etiket.KALITE.ToString());
                report.SetParameterValue("EBAT", etiket.EBAT.ToString());
                report.SetParameterValue("BOY", etiket.BOY.ToString());
                report.SetParameterValue("CAP", etiket.CAP.ToString());
                report.SetParameterValue("NERVUR_DUZ", etiket.NERVUR_DUZ.ToString());
                report.SetParameterValue("VARDIYA", etiket.VARDIYA.ToString());
                report.SetParameterValue("YOL", etiket.YOL.ToString());
                report.SetParameterValue("YOL_KTK_SIRA", etiket.YOL_KTK_SIRA.ToString());
                report.SetParameterValue("STD_STDDISI", etiket.STD_STDDISI.ToString());
                report.SetParameterValue("IKINCI_KALITE", etiket.IKINCI_KALITE.ToString());
                report.SetParameterValue("BOBIN_SIRA_NO", etiket.BOBIN_SIRA_NO.ToString());
                report.SetParameterValue("BRUT_AGIRLIK", etiket.BRUT_AGIRLIK.ToString());
                report.SetParameterValue("NET_AGIRLIK", etiket.NET_AGIRLIK.ToString());
                report.SetParameterValue("CARES_KOD", etiket.CARES_KOD.ToString());
                report.SetParameterValue("GUID_ID", etiket.GUID_ID.ToString());
                report.SetParameterValue("CUBUK_SAYISI", etiket.CUBUK_SAYISI.ToString());
                report.SetParameterValue("CENTIK_TIP", etiket.CENTIK_TIP.ToString());
                report.SetParameterValue("HURDA", etiket.HURDA.ToString());
                report.SetParameterValue("KISA_KTK", etiket.KISA_KTK.ToString());
                report.SetParameterValue("MARKALAMA", etiket.MARKALAMA.ToString());
                report.SetParameterValue("MASTERCOIL_NO", etiket.MASTERCOIL_NO.ToString());
                report.SetParameterValue("MIN_BOY_TOL", etiket.MIN_BOY_TOL.ToString());
                report.SetParameterValue("MAX_BOY_TOL", etiket.MAX_BOY_TOL.ToString());
                report.SetParameterValue("ULKE", etiket.ULKE.ToString());
                report.SetParameterValue("MENSEI", etiket.MENSEI.ToString());
                report.SetParameterValue("MUSTERI_KAL_KOD", etiket.MUSTERI_KAL_KOD.ToString());
                report.SetParameterValue("SARIM_YONU", etiket.SARIM_YONU.ToString());
                report.SetParameterValue("SAPMA", etiket.SAPMA.ToString());
                report.SetParameterValue("URETIM_YONTEMI", etiket.URETIM_YONTEMI.ToString());
                report.SetParameterValue("URETIM_SEKLI", etiket.URETIM_SEKLI.ToString());
                report.SetParameterValue("UZUNLUK", etiket.UZUNLUK.ToString());
                report.SetParameterValue("URUN_STATU", etiket.URUN_STATU.ToString());
                report.SetParameterValue("VAKUM", etiket.VAKUM.ToString());
                report.SetParameterValue("URET_TAR_SAAT", etiket.URET_TAR_SAAT.ToString());
                report.SetParameterValue("PALET_NO", etiket.PALET_NO.ToString());
                report.SetParameterValue("MASTERCOIL_SIP_SIRA_NO", etiket.MASTERCOIL_SIP_SIRA_NO.ToString());
                report.SetParameterValue("BABY_COIL_SIRA_NO", etiket.BABY_COIL_SIRA_NO.ToString());
                report.SetParameterValue("HATA_KODU", etiket.HATA_KODU.ToString());
                report.SetParameterValue("MUSTERI", etiket.MUSTERI.ToString());
                report.SetParameterValue("BAG_ID", etiket.BAG_ID.ToString());
                report.SetParameterValue("DEPOKODU", etiket.DEPOKODU.ToString());
                report.SetParameterValue("ISTIFKODU", etiket.ISTIFKODU.ToString());
                report.SetParameterValue("ISTIFSIRANO", etiket.ISTIFSIRANO.ToString());
                report.SetParameterValue("CTARIH", etiket.CTARIH.ToString());
                report.SetParameterValue("STDNEDEN", etiket.STDNEDEN.ToString());
                report.SetParameterValue("HEDEFBAG", etiket.HEDEFBAG.ToString());
                report.SetParameterValue("HEDEFTON", etiket.HEDEFTON.ToString());
                report.SetParameterValue("HEDEFBAGKG", etiket.HEDEFBAGKG.ToString());
                report.SetParameterValue("GIRNUM", etiket.GIRNUM.ToString());
                report.SetParameterValue("ARACPLAKA", etiket.ARACPLAKA.ToString());
                report.SetParameterValue("ETIKET_BASIM_TARIHI", etiket.ETIKET_BASIM_TARIHI.ToString());
                report.SetParameterValue("Y_KARISIM_KALITESI", etiket.Y_KARISIM_KALITESI.ToString());
                report.SetParameterValue("Y_ELASTISITE_MODUL_NOM", etiket.Y_ELASTISITE_MODUL_NOM.ToString());
                report.SetParameterValue("DIJITALRECORDID", etiket.DIJITALRECORDID.ToString());
                report.SetParameterValue("METRIKTON", etiket.METRIKTON.ToString());
                report.SetParameterValue("ISLEM_DRM", etiket.ISLEM_DRM.ToString());
                report.SetParameterValue("FILMASIN_TONAJI", etiket.FILMASIN_TONAJI.ToString());
                report.SetParameterValue("QM_CEKME_MUKAVVEMETI", etiket.QM_CEKME_MUKAVVEMETI.ToString());
                report.SetParameterValue("SIPNO_LOT_SIRA", etiket.SIPNO_LOT_SIRA.ToString());
                report.SetParameterValue("MALZEME_KOD", etiket.MALZEME_KOD.ToString());
                report.SetParameterValue("LAYOUT_KOD", etiket.LAYOUT_KOD.ToString());
                report.SetParameterValue("SIPARIS_SIRA_NO", etiket.SIPARIS_SIRA_NO.ToString());
                report.SetParameterValue("MAMUL_STANDART", etiket.MAMUL_STANDART.ToString());
                report.SetParameterValue("MAMUL_KALITE", etiket.MAMUL_KALITE.ToString());
                report.SetParameterValue("KALITE_KODU", etiket.KALITE_KODU.ToString());
                report.SetParameterValue("MALZEME", etiket.MALZEME.ToString());
                report.SetParameterValue("MALZEME_NO", etiket.MALZEME_NO.ToString());
                report.SetParameterValue("UNIQ_ID", etiket.UNIQ_ID.ToString());
                report.SetParameterValue("URUN_TIPI", etiket.URUN_TIPI.ToString());
                report.SetParameterValue("FIRMA", etiket.FIRMA.ToString());
                report.SetParameterValue("DEPO_YERI", etiket.DEPO_YERI.ToString());
                report.SetParameterValue("ISTIF_ADI", etiket.ISTIF_ADI.ToString());
                report.SetParameterValue("ORACLE_ID_NUM", etiket.ORACLE_ID_NUM.ToString());
                report.SetParameterValue("DOKUMYOLSIRANOSU", etiket.DOKUMYOLSIRANOSU.ToString());
                report.SetParameterValue("MAMUL_CAP", etiket.MAMUL_CAP.ToString());
                report.SetParameterValue("MERKEZ_TEL_CEVRE_TEL", etiket.MERKEZ_TEL_CEVRE_TEL.ToString());
                report.SetParameterValue("KAYNAK_METRAJI", etiket.KAYNAK_METRAJI.ToString());
                report.SetParameterValue("TAKIP_NO", etiket.TAKIP_NO.ToString());

                report.SetParameterValue("barkod", etiket.KTK_ID.ToString() + "|" + etiket.STANDART.ToString() + "|" + etiket.KALITE.ToString() + "|" + etiket.EBAT.ToString() + "|" + etiket.BOY.ToString());
                report.PrintSettings.Printer = etiket.PRINTER_SELECT_PARAMETRESI;
                report.PrintSettings.Copies = Convert.ToInt16(etiket.BASIM_ADT);
                report.PrintSettings.ShowDialog = false;
                report.Print();
                report.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK, "BASARILI");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "BASARISIZ");
            }
        }

    }
}
