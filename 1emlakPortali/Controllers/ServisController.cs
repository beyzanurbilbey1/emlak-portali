using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _1emlakPortali.Models;
using _1emlakPortali.ViewModel;

namespace _1emlakPortali.Controllers
{
    public class ServisController : ApiController
    {

        DB01Entities db = new DB01Entities();
        SonucModel sonuc = new SonucModel();

        #region Kategori

        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                katId = x.katId,
                katAd = x.katAd,


            }).ToList();
            return liste;
        }


        [HttpGet]
        [Route("api/kategoribyid/{Kategoriid}")]
        public KategoriModel KategoriById(string kategoriId)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.katId == kategoriId).Select(x => new
                KategoriModel()
            {

                katId = x.katId,
                katAd = x.katAd,


            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if(db.Kategori.Count(s=> s.katAd == model.katAd) > 0)
            {
                sonuc.islem = true;
                sonuc.mesaj = "Girilen Kategori Mevcuttur";
                return sonuc;
            }
            Kategori yeni = new Kategori();
            yeni.katId = Guid.NewGuid().ToString();
            yeni.katAd = model.katAd;
            
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi";
            return sonuc;
        }


        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.katId == model.katId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunamadı!";
                return sonuc;
            }
            kayit.katAd = model.katAd;

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel kategoriSil(string katId)
        {
            Kategori kayit = db.Kategori.Where(s => s.katId == katId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";
            return sonuc;
        }





        #endregion


        #region Evler

        [HttpGet]
        [Route("api/evliste")]
        public List<EvlerModel> EvlerListe()
        {
            List<EvlerModel> liste = db.Evler.Select(x => new
                EvlerModel()
            {
                evId = x.evId,
                evKat = x.evKat,
                evFiyat =x.evFiyat,
                evAdres = x.evAdres,
                evSatilikKiralik = x.evSatilikKiralik,
                evEsya = x.evEsya,
                evOdaSayisi = x.evOdaSayisi,
                evGorsel = x.evGorsel,
                evKodu = x.evKodu,
                evKatId = x.evKatId,
                evKategoriBilgi = new KategoriModel()
                {
                    katId= x.Kategori.katId,
                    katAd = x.Kategori.katAd
                }
            }).ToList();

            return liste;
        }


        [HttpGet]
        [Route("api/evbyid/{evid}")]
        public EvlerModel EvById(string evid)
        {
            EvlerModel kayit = db.Evler.Where(s => s.evId == evid).Select(x => new
                EvlerModel()
            {
                evId = x.evId,
                evKat = x.evKat,
                evFiyat = x.evFiyat,
                evAdres = x.evAdres,
                evSatilikKiralik = x.evSatilikKiralik,
                evEsya = x.evEsya,
                evOdaSayisi = x.evOdaSayisi,
                evGorsel = x.evGorsel,
                evKodu = x.evKodu,
                evKatId = x.evKatId,
                evKategoriBilgi = new KategoriModel()
                {
                    katId = x.Kategori.katId,
                    katAd = x.Kategori.katAd
                }

            }).SingleOrDefault();
            return kayit;
        }

        [HttpGet]
        [Route("api/evlerlistebykatid/{katid}")]
        public EvlerModel EvByKatId(string katid)
        {
            EvlerModel kayit = db.Evler.Where(s => s.evKatId == katid).Select(x => new
                EvlerModel()
            {
                evId = x.evId,
                evKat = x.evKat,
                evFiyat = x.evFiyat,
                evAdres = x.evAdres,
                evSatilikKiralik = x.evSatilikKiralik,
                evEsya = x.evEsya,
                evOdaSayisi = x.evOdaSayisi,
                evGorsel = x.evGorsel,
                evKodu = x.evKodu,
                evKatId = x.evKatId,
                evKategoriBilgi = new KategoriModel()
                {
                    katId = x.Kategori.katId,
                    katAd = x.Kategori.katAd
                }

            }).SingleOrDefault();
            return kayit;
        }


        [HttpPost]
        [Route("api/evekle")]
        public SonucModel EvEkle(EvlerModel model)
        {
            if (db.Evler.Count(s => s.evKodu == model.evKodu) > 0) 
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Ev Kodu Kayitlidir!";
                return sonuc;
            }
           Evler yeni = new Evler();  
            yeni.evId = Guid.NewGuid().ToString();
            yeni.evKat = model.evKat;
            yeni.evFiyat = model.evFiyat;
            yeni.evAdres = model.evAdres;
            yeni.evSatilikKiralik = model.evSatilikKiralik;
            yeni.evEsya = model.evEsya;
            yeni.evOdaSayisi = model.evOdaSayisi; 
            yeni.evGorsel = model.evGorsel;
            yeni.evKodu = model.evKodu;
            yeni.evKatId = model.evKatId;
            db.Evler.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ev Eklendi";
            return sonuc;
        }

       
        [HttpPut]
        [Route("api/evduzenle")]

        public SonucModel EvlerDuzenle(EvlerModel model)
        {
            Evler kayit = db.Evler.Where(s => s.evId == model.evId).FirstOrDefault();
            if (kayit == null)
            { 
                sonuc.islem = false;
                sonuc.mesaj = "Kayit Bulunamadi!";
                return sonuc;
            }

            kayit.evKat = model.evKat;
            kayit.evFiyat = model.evFiyat;
            kayit.evAdres = model.evAdres;
            kayit.evSatilikKiralik = model.evSatilikKiralik;
            kayit.evOdaSayisi = model.evOdaSayisi;
            kayit.evEsya = model.evEsya;
            kayit.evOdaSayisi = model.evOdaSayisi;
            kayit.evGorsel = model.evGorsel;
            kayit.evKatId = model.evKatId;
            kayit.evKodu = model.evKodu;

            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Ev Güncellendi";

            return sonuc;
        }


        [HttpDelete]
        [Route("api/evsil/{evId}")]
        public SonucModel EvlerSil(string evId)
        { 
            Evler kayit = db.Evler.Where(s => s.evId == evId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }

            if (db.Kayit.Count(s => s.kayitEvId == evId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Eve Kayıtlı Üye Olduğu İçin Silinemez!";
                return sonuc; 
            }

            db.Evler.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Ev Silindi";

            return sonuc;
        }
        

        #endregion


        #region Kullanıcı

        [HttpGet]
        [Route("api/kullaniciliste")]
        public List<KullaniciModel> KullaniciListele()
        {
            List<KullaniciModel> liste = db.Kullanici.Select(x => new
                KullaniciModel()
            {
                kullaniciId = x.kullaniciId,
                kullaniciAdSoyad = x.kullaniciAdSoyad,
                kullaniciTel = x.kullaniciTel,
                kullaniciMail = x.kullaniciMail,
                kullaniciParola = x.kullaniciParola,
                kullaniciYetki = x.kullaniciYetki
                
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/kullanicibyid/{kullaniciId}")]

        public KullaniciModel KullaniciById(string kullaniciId)
        {
            KullaniciModel kayit = db.Kullanici.Where(s => s.kullaniciId == kullaniciId).Select(x => new KullaniciModel()
              {

                  kullaniciId = x.kullaniciId,
                  kullaniciTel = x.kullaniciTel,
                  kullaniciAdSoyad = x.kullaniciAdSoyad,
                  kullaniciMail = x.kullaniciMail,
                  kullaniciParola = x.kullaniciParola,
                  kullaniciYetki = x.kullaniciYetki

              }).SingleOrDefault();
            return kayit;
        }

        [HttpPost] 
        [Route("api/kullaniciekle")]
        public SonucModel KullaniciEkle(KullaniciModel model)
        {
            if (db.Kullanici.Count(c => c.kullaniciAdSoyad == model.kullaniciAdSoyad) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kullanıcı Adı Kayitlidir!";
                return sonuc;
            }
            Kullanici yeni = new Kullanici();
            yeni.kullaniciId = Guid.NewGuid().ToString();
            yeni.kullaniciTel = model.kullaniciTel;
            yeni.kullaniciAdSoyad = model.kullaniciAdSoyad;
            yeni.kullaniciMail = model.kullaniciMail;
            yeni.kullaniciParola = model.kullaniciParola;
            yeni.kullaniciYetki = model.kullaniciYetki;

            db.Kullanici.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Eklendi";

            
            return sonuc;
        }

        [HttpPut]
        [Route("api/kullaniciduzenle")]

        public SonucModel KullaniciDuzenle(KullaniciModel model)
        {
            Kullanici kayit = db.Kullanici.Where(s => s.kullaniciId == model.kullaniciId).FirstOrDefault();
            if (kayit == null)
            {

                sonuc.islem = false;
                sonuc.mesaj = "Kayit Bulunamadi!";
                return sonuc;

            }

            kayit.kullaniciTel = model.kullaniciTel;
            kayit.kullaniciAdSoyad = model.kullaniciAdSoyad;
            kayit.kullaniciMail = model.kullaniciMail;
            kayit.kullaniciParola = model.kullaniciParola;
            kayit.kullaniciYetki = model.kullaniciYetki;

            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Güncellendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kullanicisil/{kullaniciId}")]

        public SonucModel KullaniciSil(string kullaniciId)
        {
            Kullanici kayit = db.Kullanici.Where(s => s.kullaniciId == kullaniciId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı Bulunamadı";
                return sonuc;
            }

            if (db.Kayit.Count(s => s.kayitKulId == kullaniciId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı Üzerinde Ev Kaydı Olduğu İçin Kullanıcı Silinemez!";
                return sonuc;
            }

            db.Kullanici.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kullanici Silindi";

            return sonuc;
        }

        #endregion


        #region Kayit

        [HttpGet]
        [Route("api/kullanicievliste/{kullaniciId}")]  

        public List<kayitModel> KullaniciEvlerListe(string kullaniciId)
        {

            List<kayitModel> liste = db.Kayit.Where(s => s.kayitKulId == kullaniciId).Select(x => new
                kayitModel()
            {
                KayitId = x.KayitId,
                kayitEvId = x.kayitEvId,
                kayitKulId = x.kayitKulId,
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.kullaniciBilgi = KullaniciById(kayit.kayitKulId);
                kayit.evBilgi = EvById(kayit.kayitEvId);
            }

            return liste;
        }

         
        [HttpGet]
        [Route("api/evkullanicilistle/{evid}")]

        public List<kayitModel> KullaniciEvListele(string evid)
        { 
            
            List<kayitModel> liste = db.Kayit.Where(s => s.kayitEvId == evid).Select(x => new
                kayitModel()
            {
                KayitId = x.KayitId,
                kayitEvId = x.kayitEvId,
                kayitKulId = x.kayitKulId,
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.kullaniciBilgi = KullaniciById(kayit.kayitKulId);
                kayit.evBilgi = EvById(kayit.kayitEvId);
            }

            return liste;
        }


        [HttpPost]
        [Route("api/kayitekle")]

        public SonucModel KayitEkle(kayitModel model)
        {
            if (db.Kayit.Count(s => s.kayitEvId == model.kayitEvId && s.kayitKulId ==
            model.kayitKulId) > 0)
            
            {
                sonuc.islem = false;
                sonuc.mesaj = "İlgili Kullanıcı Evi Önceden Kiralamıştır!";
                return sonuc;
            }

            Kayit yeni = new Kayit();
            yeni.KayitId = Guid.NewGuid().ToString();
            yeni.kayitEvId = model.kayitEvId;
            yeni.kayitKulId = model.kayitKulId;

            db.Kayit.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ev Kaydı Eklendi";

            return sonuc;
        }


        [HttpDelete]
        [Route("api/kayitsil/{kayitId}")]


        public SonucModel KayitSil(string kayitId)
        {
            Kayit kayit = db.Kayit.Where(s => s.KayitId == kayitId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Kayit.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kayıt Silindi";
            return sonuc;

        }

        #endregion


    }
}
